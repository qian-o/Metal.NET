# Metal.NET Generator — Session Summary

> 本文件是 `refactor/generator` 分支上代码生成器的工作总结，可作为后续会话的初始上下文。

## 1. 项目概览

| 项 | 值 |
|---|---|
| 仓库 | `c:\Users\13247\source\repos\Metal.NET` |
| 分支 | `refactor/generator`（工作树已全部提交，干净状态） |
| 最新提交 | `fad6d96c` — Refactor Metal.NET generated bindings for improved selector naming and auditing scripts |
| C# 版本 | 14（.NET 10），使用 `extension` 块 / `field` 关键字 |
| 生成器 | `Metal.NET.Generator`，读取 `metal-ast.json` → 输出 C# 到 `Metal.NET/Generated/` |

### 生成产物统计

| 目录 | 文件数 |
|---|---|
| Metal | 233 |
| MetalFX | 18 |
| Foundation | 8 |
| Common (ObjectiveC.cs) | 1 |
| **合计** | **262** |

- 243 个类包含 Selectors
- 3110 个 Selector
- 202 个 MsgSend 重载（21 组）

---

## 2. 本次会话完成的工作

### 2.1 添加 Foundation NSEnums

AST 中不含 Foundation 枚举定义，因此手写了 `Metal.NET/Foundation/NSEnums.cs`，包含：

- `NSComparisonResult : long`（Ascending = -1, Same = 0, Descending = 1）
- `NSStringCompareOptions : ulong`（[Flags]，CaseInsensitiveSearch = 1 …）
- `NSStringEncoding : ulong`（ASCIIStringEncoding = 1, UTF8StringEncoding = 4 … 共 25+ 项）

同时在 `CSharpEmitter.cs` 中将这三个枚举注册到 `EnumBackingTypes`；在 `TypeMapper.cs` 和 `AstJsonParser.TypeMapping.cs` 中添加了直接映射（不再走 `NS::UInteger` 中间类型）。

### 2.2 Bug 修复：Selector 键名冲突

**问题**：`BuildMethodNameFromSelector` 对不同的 selector 生成相同的 C# 方法名。例如：

- `setVertexBuffer:offset:atIndex:` → `SetVertexBufferOffsetAtIndex`
- `setVertexBufferOffset:atIndex:` → `SetVertexBufferOffsetAtIndex`

**修复**：采用"下划线代替冒号"方案——每个冒号分隔的片段 PascalCase 后用 `_` 连接。

- `setVertexBuffer:offset:atIndex:` → `SetVertexBuffer_Offset_AtIndex_`
- `setVertexBufferOffset:atIndex:` → `SetVertexBufferOffset_AtIndex_`

改动在 `CSharpEmitter.MethodEmission.cs` 的 `BuildMethodNameFromSelector` 方法中，同时移除了之前的 `AddUniqueSelectorKey` 数字后缀方案。

### 2.3 Bug 修复：Protocol / Class 覆盖

**问题**：`MTL4BinaryFunction`、`MTLDynamicLibrary` 在 AST 中同时存在于 `protocols`（有成员）和 `classes`（空壳）。`ParseClasses` 在 `ParseProtocols` 之后运行，空壳覆盖了已解析的 protocol。

**修复**：在 `AstJsonParser.ClassParsing.cs` 的 `ParseClasses` 中添加去重检查——构建 `protocolNames` 集合，跳过已存在于 `context.Classes` 中的类名。

### 2.4 全面审计

运行了多个审计脚本，对生成结果与 AST 进行交叉比对：

| 审计项 | 结果 |
|---|---|
| 枚举→回退类型 | 0 问题 |
| 类指针→nint 回退 | 0 问题 |
| Metal/MetalFX 方法因 IsUnmappableObjCType 被跳过 | 0 |
| 生成的 selector 在 AST 中不存在 | 0 / 3110 |
| selector 字母排序 | 243 个 Bindings 类全部正确排序 |
| AST 中存在但未生成的 selector | 106 个（见下文分类） |

---

## 3. 已知未解决问题

### 3.1 未生成的 106 个 AST Selectors

通过 `_audit_missing_detail.py` 分类（78 个可分类，其余为审计脚本误报）：

| 分类 | 数量 | 说明 |
|---|---|---|
| `c_array_param` | 47 | 参数含 C 数组（如 `setBuffers:offsets:withRange:`），生成器尚不支持 |
| `property_not_generated` | 9 | **审计脚本误报** — 实际已生成，getter selector 被重映射（如 `gpuStartTime` → `GPUStartTime`） |
| `setter_not_generated` | 4 | **审计脚本误报** — 实际已生成，setter 使用 AST 显式名称（如 `setUITexture:` 而非 `setUiTexture:`） |
| `unmappable_type` | 5 | 参数含 block / 函数指针回调，被 `HasFunctionPointerParam` 过滤 |
| `unknown` | 9 | 特殊情况：`kern_return_t` 参数、无参 `init`（非 AllocInit 类）、`NSArray<MTLTensorExtents *>` |
| `method_dup_of_property` | 3 | 方法与属性重复 |
| `method_name_clashes_property` | 1 | 方法名与属性名冲突 |

**实际需要关注的**：主要是 47 个 C 数组参数方法和 5 个 block 回调方法。9 个 unknown 中也有需要考虑支持的。

### 3.2 Class → Struct 重构计划

已规划但尚未开始。目标：将所有 ObjC 对象绑定从 C# class 改为 struct（参考 SharpMetal 风格）。

**当前架构**：
- 所有 ObjC 对象 = C# class（堆分配、GC 跟踪）
- 继承层次：`NativeObject → NSObject → MTLDevice` 等
- 所有权模型：Borrowed / Owned / Managed + IDisposable + finalizer
- 属性缓存 `GetProperty(ref field, selector)`
- Selectors 在文件级 `{Class}Bindings` 静态类中
- `ObjectiveC.cs` 使用 unmanaged function pointers 做 `objc_msgSend`

**目标架构**：
- 所有 ObjC 对象 = C# partial struct + `IntPtr NativePtr`
- 无继承层次，每个 struct 独立
- 无所有权跟踪、无 IDisposable、无 finalizer
- 每个属性/方法直接调用 `objc_msgSend`
- Selectors 作为 struct 内部 `private static readonly` 字段
- 工厂方法：`static New()` → `s_class.AllocInit<T>()`
- 隐式转换到 `IntPtr`
- 使用 `LibraryImport` 做 P/Invoke

**需要修改的生成器文件**：
- `CSharpEmitter.ClassGeneration.cs` → struct 生成
- `CSharpEmitter.PropertyEmission.cs` → 简化，去掉缓存
- `CSharpEmitter.MethodEmission.cs` → 简化参数传递
- `CSharpEmitter.ObjectiveCGeneration.cs` → 切换到 LibraryImport
- `Models.cs` → ClassDef 可能需要更新
- `TypeMapper.cs` → 返回类型处理变化

---

## 4. 生成器关键设计

### 4.1 类型映射链

```
ObjC 类型 (AST)
  → MapObjCTypeForModel()        [AstJsonParser.TypeMapping.cs]
  → ModelType (string)
  → MapType()                     [TypeMapper.cs]
  → C# 类型 + MsgSend 方法组
```

### 4.2 跳过/过滤规则

- `IsUnmappableObjCType`：跳过 `NSDate`、`NSLocale`、`NSCharacterSet`、`NSCoder` 等 Foundation-only 类型，以及 `NSStringEncoding *`（指针）、`NSStringEncodingConversionOptions` 等
- `HasFunctionPointerParam`：跳过含 block / 函数指针参数的方法
- `HasUnmergableArrayParam`：跳过含无法合并的数组参数的方法
- `HasUnmappableParam`：跳过含 `TypeMapper.MapType` 返回 `null` 的参数的方法

### 4.3 Init 静态工厂模式

```csharp
public static ClassName InitXxx(params)
{
    // ...
    return new(nativePtr, NativeObjectOwnership.Managed);
}
```

### 4.4 NSArray 处理

- `NSArray` 是一个 `static class` helper，提供 `ToArray<T>()` 和 `FromArray<T>()`
- AST 中标记为 `NSARRAY_PARAM:ElementType` 的类型 → C# 参数为 `ElementType[]` + 内部调用 `NSArray.FromArray()`

### 4.5 Selector 命名规则

每个冒号分隔的片段 PascalCase 后用 `_` 连接：

| Selector | C# 名称 |
|---|---|
| `setVertexBuffer:offset:atIndex:` | `SetVertexBuffer_Offset_AtIndex_` |
| `newBufferWithLength:options:` | `NewBufferWithLength_Options_` |
| `label` | `Label` |

### 4.6 属性 Getter/Setter 配对

通过 `CategorizeMembers` 将方法分为属性（getter/setter 配对）和剩余方法。Setter selector 使用 AST 中的显式名称（如 `setUITexture:` 而非自动推导的 `setUiTexture:`）。布尔属性：`isDepthReversed` → setter 为 `setDepthReversed:`。

### 4.7 枚举支持

- AST 中的枚举（Metal / MetalFX）→ 自动生成
- Foundation 枚举（NSComparisonResult, NSStringCompareOptions, NSStringEncoding）→ 手写 `NSEnums.cs` + 注册到 `EnumBackingTypes`
- `EnumBackingTypes` 字典：枚举 C# 名 → 底层类型字符串

---

## 5. 生成器核心文件清单

| 文件 | 职责 |
|---|---|
| `AstJsonParser.cs` | AST JSON 总入口 |
| `AstJsonParser.BlockParsing.cs` | block / 函数指针解析 |
| `AstJsonParser.ClassParsing.cs` | protocol + class 解析 |
| `AstJsonParser.EnumParsing.cs` | 枚举解析 |
| `AstJsonParser.FreeFunctionParsing.cs` | 自由函数解析 |
| `AstJsonParser.StructParsing.cs` | struct 解析 |
| `AstJsonParser.TypeMapping.cs` | ObjC→Model 类型映射 + 过滤 |
| `CSharpEmitter.cs` | 生成总入口，EnumBackingTypes 注册 |
| `CSharpEmitter.ClassGeneration.cs` | 类文件生成（INativeObject, 构造, 属性, 方法, Bindings） |
| `CSharpEmitter.DelegateGeneration.cs` | delegate 生成 |
| `CSharpEmitter.EnumGeneration.cs` | 枚举文件生成 |
| `CSharpEmitter.FreeFunctionEmission.cs` | 自由函数生成 |
| `CSharpEmitter.MethodEmission.cs` | 方法 / init 静态工厂生成，`BuildMethodNameFromSelector` |
| `CSharpEmitter.ObjectiveCGeneration.cs` | ObjectiveC.cs 多重 MsgSend 生成 |
| `CSharpEmitter.PropertyEmission.cs` | 属性生成 |
| `CSharpEmitter.StructGeneration.cs` | struct 文件生成 |
| `TypeMapper.cs` | 最终 C# 类型解析 + MsgSend 方法组选择 |
| `Models.cs` | ClassDef, MethodInfo 等数据模型 |
| `GeneratorContext.cs` | 生成上下文 |

---

## 6. Windows 开发环境注意事项

- Python 用 `py`（不是 `python`）
- `metal-ast.json` 有 UTF-8 BOM，Python 读取时用 `utf-8-sig` 编码
- PowerShell 中 f-string 含花括号 dict 访问会导致 SyntaxError，应使用 `.py` 脚本文件而非内联 Python
- 仓库根目录有临时审计脚本（`_audit_*.py`、`_check_*.py`、`_search_enums.py`），可在后续清理

---

## 7. 临时文件清单

以下文件为审计用临时脚本，位于仓库根目录，可安全删除：

```
_audit_fallback_classes.py
_audit_missing_detail.py
_audit_selectors.py
_audit_types.py
_check_desc.py
_check_ns.py
_check_ns2.py
_check_props.py
_check_sels.py
_check_ui.py
_search_enums.py
```

---

## 8. 后续工作建议

1. **C 数组参数支持**：47 个方法因 C 数组参数未生成，需要设计 `Span<T>` 或指针参数的映射方案
2. **Block / 函数指针回调**：5 个方法含 block 参数，需要设计 delegate 映射
3. **Unknown 类别处理**：9 个特殊情况逐一评估
4. **Class → Struct 重构**：主要架构变更，涉及多个生成器文件
5. **清理临时审计脚本**：删除根目录下的 `_*.py` 文件
