# Metal.NET Generator — 已知问题

## 问题 1：方法被错误生成为属性

### 描述

某些 ObjC 方法（无参数、有返回值）被错误地生成为 C# 属性，但它们在语义上是**工厂方法 / 命令方法**，每次调用都会创建或返回新对象，应生成为方法。

### 示例

| 类型 | selector | 当前生成 | 应生成 |
|---|---|---|---|
| `CAMetalLayer` | `nextDrawable` | 属性 `NextDrawable` | 方法 `NextDrawable()` |
| `MTLCommandQueue` | `commandBuffer` | 属性 `CommandBuffer` | 方法 `MakeCommandBuffer()` |
| `MTLCommandBuffer` | `computeCommandEncoder` | 属性 `ComputeCommandEncoder` | 方法 `MakeComputeCommandEncoder()` |
| `MTLCommandBuffer` | `accelerationStructureCommandEncoder` | 属性 | 方法 |

### 根本原因

这些 selector 在 JSON 的 `methods` 数组中（不是 `properties`），但生成器在处理无参数、有返回值的方法时，将它们错误地当作属性来生成。生成器代码中存在将 `methods` 中的无参方法提升为 C# 属性的逻辑，没有区分真正的 property getter 和工厂/命令方法。

### 修复方向

修改生成器，对 `methods` 数组中的条目，即使无参数也应生成为方法。只有 JSON `properties` 数组中的条目才应生成为 C# 属性。

---

## 问题 2：数组参数方法生成错误

### 描述

对于入参是指针+count 模式（ObjC 中的数组传递方式）的方法，生成器直接将原始参数透传，没有封装为 C# 数组风格的 API。

### 示例：值类型数组（struct）

**当前生成（错误）：**

```csharp
public void SetViewports(MTLViewport viewports, nuint count)
{
    ObjectiveC.MsgSend(NativePtr, MTL4RenderCommandEncoderBindings.SetViewports, viewports, count);
}
```

**应生成：**

```csharp
public unsafe void SetViewports(MTLViewport[] viewports)
{
    fixed (MTLViewport* pViewports = viewports)
    {
        ObjectiveC.MsgSend(NativePtr, MTL4RenderCommandEncoderBindings.SetViewports, (nint)pViewports, (nuint)viewports.Length);
    }
}
```

### 示例：Native 对象数组（ObjC 对象指针）

**应生成：**

```csharp
public unsafe void Commit(MTL4CommandBuffer[] commandBuffers)
{
    nint* pCommandBuffers = stackalloc nint[commandBuffers.Length];
    for (int i = 0; i < commandBuffers.Length; i++)
    {
        pCommandBuffers[i] = commandBuffers[i].NativePtr;
    }

    ObjectiveC.MsgSend(NativePtr, MTL4CommandQueueBindings.Commit, (nint)pCommandBuffers, (nuint)commandBuffers.Length);
}
```

### 根本原因

生成器未识别 `(pointer, count)` 参数对模式。ObjC 中数组传递通常表现为连续的两个参数：
- 第一个参数类型为 `Type *`（指向元素的指针）
- 第二个参数类型为 `NSUInteger`（元素数量）

### 修复方向

1. 检测连续参数中的 `(pointer, count)` 模式
2. 根据指针指向的类型区分：
   - **值类型（struct）**：使用 `fixed` + 指针 pin
   - **ObjC 对象**：使用 `stackalloc nint[]` + 逐个提取 `NativePtr`
3. 合并为单个 C# 数组参数，内部自动处理 marshal
