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

修改生成器，对 `methods` 数组中的条目，即使无参数并且没有对应 `SetXXX` 的时候应生成为方法。只有 JSON `properties` 数组中的条目和 `methods` 中存在 `XXX` 和 `SetXXX` 才应生成为 C# 属性。

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

---

## 问题 3：生成器应使用 `name` 而非解析 `selector` 来生成方法名

### 描述

当前生成器通过解析 `selector` 字段来推导 C# 方法名称（拆分冒号、拼接 PascalCase），而 JSON 中已经提供了经过 Swift Symbol Graph 映射的 `name` 字段。生成器应直接使用 `name` 作为方法名称来源。

### 当前行为

生成器中有多处从 `selector` 推导名称的逻辑：

1. **`SelectorToMethodName()`**（`AstJsonParser.cs`）：取 selector 第一个 `:` 前的部分作为方法名
2. **`BuildMethodNameFromSelector()`**（`CSharpEmitter.MethodEmission.cs`）：将多段 selector 拼接为 PascalCase（如 `presentDrawable:atTime:` → `PresentDrawableAtTime`）
3. **`ComputeSimplifiedMethodNames()`**（`CSharpEmitter.MethodEmission.cs`）：基于 selector 首段做冲突检测和简化
4. **`EmitMethod()`**：优先使用 selector 派生名称，仅在无 selector 时 fallback 到 `method.Name`

### 示例

| selector | 当前生成（从 selector 推导） | `name` 字段值 | 应生成 |
|---|---|---|---|
| `newCommandQueue` | `NewCommandQueue` | `makeCommandQueue` | `MakeCommandQueue()` |
| `blitCommandEncoder` | `BlitCommandEncoder`（属性） | `makeBlitCommandEncoder` | `MakeBlitCommandEncoder()` |
| `renderCommandEncoderWithDescriptor:` | `RenderCommandEncoderWithDescriptor` | `makeRenderCommandEncoder` | `MakeRenderCommandEncoder()` |
| `newTextureViewWithPixelFormat:textureType:levels:slices:swizzle:` | `NewTextureViewWithPixelFormatTextureTypeLevelsSlicesSwizzle` | `makeTextureView` | `MakeTextureView()` |
| `presentDrawable:atTime:` | `PresentDrawableAtTime` | `presentDrawableAtTime` | `PresentDrawableAtTime()` |

### 根本原因

生成器在 `name` 字段引入之前就已经编写，当时只有 `selector` 可用。现在 `extract_metal_api.py` 已经通过 Swift Symbol Graph 和 `new→make` 转换等逻辑为每个方法生成了准确的 `name` 字段，生成器应切换到使用它。

### 修复方向

1. **`EmitMethod()` 中**：直接使用 `TypeMapper.ToPascalCase(method.Name)` 作为 C# 方法名，不再解析 selector
2. **`selector` 字段**：仅用于 ObjC runtime 调用（`ObjectiveC.MsgSend` 的 selector 参数注册），不再用于命名
3. **删除**：`BuildMethodNameFromSelector()`、`ComputeSimplifiedMethodNames()` 中基于 selector 的命名逻辑可以简化或移除
4. **冲突检测**：如果同一类型中出现同名方法（合法重载），仍需通过参数类型区分，而非 fallback 到 selector 拼接
