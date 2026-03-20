# Metal.NET Generator — Session Summary

> 本文件是 `refactor/generator` 分支上代码生成器的工作总结，可作为后续会话的初始上下文。
> **最后更新**：2026-03-20

## 1. 项目概览

| 项 | 值 |
|---|---|
| 仓库 | `c:\Users\13247\source\repos\qian-o\Metal.NET` |
| 分支 | `refactor/generator` |
| C# 版本 | 14（.NET 10），使用 `extension` 块 / `field` 关键字 |
| 生成器 | `Metal.NET.Generator`，读取 `metal-ast.json` → 输出 C# 到 `Metal.NET/Generated/` |
| 构建命令 | `dotnet run --project Metal.NET.Generator/Metal.NET.Generator.csproj -c Release` |
| 编译命令 | `dotnet build Metal.NET/Metal.NET.csproj -c Release` |
| 审计命令 | `python _audit_selectors.py` |

### 生成产物统计（最新）

| 指标 | 数值 |
|---|---|
| 生成类（含 Selectors） | 245 |
| 总 Selectors | **3212** |
| Metal/MetalFX 缺失 | **0** |
| 全框架缺失 | **0** |
| MsgSend 重载 | 209（21 组） |
| Delegate 类 | 19 |
| 编译错误/警告 | **0** |

---

## 2. 历史会话工作记录

### 会话 1（初始开发）

完成了生成器的核心架构和基础功能。

### 会话 2（NSEnums + Bug 修复 + 审计）

#### 2.1 添加 Foundation NSEnums

手写了 `Metal.NET/Foundation/NSEnums.cs`（`NSComparisonResult`, `NSStringCompareOptions`, `NSStringEncoding`），并注册到 `CSharpEmitter.cs` 的 `EnumBackingTypes` 和 `TypeMapper.cs`。

#### 2.2 Bug 修复：Selector 键名冲突

`BuildMethodNameFromSelector` 对不同 selector 生成相同的 C# 方法名。修复：用下划线代替冒号分隔片段。

#### 2.3 Bug 修复：Protocol / Class 覆盖

空壳 class 覆盖已解析的 protocol。修复：`ParseClasses` 跳过已存在于 `context.Classes` 的类名。

### 会话 3（Block/Delegate + 5个Bug修复）

- 实现了 `ParseInlineBlocks` 自动发现 block/callback 类型
- 修复了多个 delegate 生成问题
- 达成 0 errors / 0 warnings，19 个 delegate 类

### 会话 4（审计脚本修复 + 缺失selector修复）

#### 4.1 `_audit_selectors.py` 3个Bug修复

- Bug 1: `sel_value.startswith('alloc')` 误过滤 `allocatedSize`/`allocationCount` → 改为 `== 'alloc'`
- Bug 2: 属性用 `name` 构造 selector 而非用 methods 数组的 `selector` → 改为只用 methods
- Bug 3: 不考虑继承 → 添加父类/协议 selector 查找
- 结果：49 个假阳性 → 2 个真正缺失

#### 4.2 修复 2 个缺失 Selector

1. **`sparseTileSizeInBytesForSparsePageSize:`** — 方法名与属性名冲突，被 `propertyNames.Contains(name)` 过滤
   - 修复：属性名冲突检查仅跳过无参方法；有参方法加 "get" 前缀
2. **`setOwnerWithIdentity:`** — `kern_return_t`/`task_id_token_t` 在不可映射列表中
   - 修复：添加类型映射 `kern_return_t`→`int`、`task_id_token_t`→`uint`

### 会话 5（本次 — 最大化完整性 "尽量生成完整 不要跳过"）

目标：最小化跳过的方法，生成尽可能完整的绑定。

#### 5.1 移除 NSArray 返回值方法的无条件跳过（+15 selectors）

**问题**：解析器遇到返回 `NSArray` 的方法时直接 `continue`，但发射器已有完善的 NSArray 返回值处理逻辑。

**修改 3 个文件**：
- `GeneratorContext.cs` — 新增 `NSArrayReturnTypes` 字典，parser→emitter 传递 AST 泛型元素类型
- `AstJsonParser.ClassParsing.cs` — 方法解析：用 `ExtractNSArrayElementType()` 尝试提取元素类型，能解析则放行
- `CSharpEmitter.cs` — `TryResolveNSArrayElementType` 从 `static` 改为实例方法，增加 context 回退查找

#### 5.2 移除 `unichar *` 的不可映射标记（+2 selectors）

`MapObjCTypeForModel` 已能映射 `unichar *` → `nint`，只需从 `IsUnmappableObjCType` 删除。
解锁：`initWithCharactersNoCopy:length:deallocator:` 和 `initWithCharactersNoCopy:length:freeWhenDone:`

#### 5.3 移除 `Class` 的不可映射标记（+3 selectors）

`TypeMapper.MapType` 已映射 `Class` → `nint`，只需从 `IsUnmappableObjCType` 删除。
解锁：`NSBundle.bundleForClass:`、`classNamed:`、`principalClass`

#### 5.4 为 NSArray 属性注册泛型元素类型（+5 selectors，property 解析）

之前仅对方法做了 NSArray 泛型提取，属性没有。在属性解析循环中添加 `ExtractNSArrayElementType` + 注册到 `context.NSArrayReturnTypes`。
解锁：NSBundle 的 `allBundles`、`allFrameworks`、`localizations`、`preferredLocalizations`、`executableArchitectures`

#### 5.5 Selector 增长记录

| 阶段 | Selectors |
|---|---|
| 会话 4 完成后 | 3181 |
| 移除 NSArray 方法跳过 + unichar * | 3196 (+15) |
| 移除 Class 不可映射 + NSArray 属性注册 | **3208** (+12) |

### 会话 6（完整绑定 — 消灭最后 4 个缺失 selector）

目标：为 3 个缺失类型创建完整绑定，实现全框架 0 缺失。

#### 6.1 新增手写绑定类

| 类 | 文件 | 说明 |
|---|---|---|
| `NSAttributedString` | `Metal.NET/Foundation/NSAttributedString.cs` | Foundation 富文本类，继承 NSObject，提供 String/Length 属性 |
| `NSSet` | `Metal.NET/Foundation/NSSet.cs` | Foundation 集合类，静态类（同 NSArray 模式），提供 `FromArray<T>()` |
| `CAEDRMetadata` | `Metal.NET/QuartzCore/CAEDRMetadata.cs` | QuartzCore EDR 元数据类，继承 NSObject |

#### 6.2 生成器修改

**`AstJsonParser.TypeMapping.cs`**：
- `IsUnmappableObjCType`：移除 `CAEDRMetadata`、`NSAttributedString`、`NSSet<`
- `MapObjCTypeForModel`：新增 `NSSet<...>` → `NSSet*` 泛型剥离（同 NSArray/NSDictionary 模式）

**`TypeMapper.cs`**：
- `MapType`：新增 `NSSet` → `nint`（NSSet 是静态类，参数传原生指针）

#### 6.3 NSSET_PARAM 机制 — NSSet 参数类型化

**问题**：`MTLHeap.SetPreservationPriority(double, nint)` 中 `nint` 参数实际是 `NSSet<NSString>`，用户需手动创建 NSSet 传入，不友好。

**方案**：参照已有 `NSARRAY_PARAM` 机制，新增 `NSSET_PARAM:{elemType}` 标记。

**修改 3 个文件**：
- `AstJsonParser.ClassParsing.cs` — 方法解析 + init 解析：检测 `NSSet<...>` 参数类型，提取元素类型后标记为 `NSSET_PARAM:{elemType}`
- `CSharpEmitter.MethodEmission.cs` — 新增 NSSET_PARAM 处理：生成 `ElementType[] param` 签名 + `NSSet.FromArray(param)` 转换 + 自动释放

**效果**：`SetPreservationPriority(double priority, NSString[] tags)` — 自动转换为 NSSet，与 NSARRAY_PARAM 保持一致。

#### 6.4 属性配对大小写修复（EDRMetadata）

**问题**：`EDRMetadata`（getter）和 `setEDRMetadata:`（setter）未被配对为属性，仍然是两个独立方法。

**根因**：`GetPropertyName` 将 `setEDRMetadata` 转换为 `eDRMetadata`（首字母小写），但 getter 名为 `EDRMetadata`（大写）。`CategorizeMembers` 中的 `setterMap` 使用 `StringComparer.Ordinal`，导致 `eDRMetadata` ≠ `EDRMetadata` 匹配失败。

**修复**：`CSharpEmitter.ClassGeneration.cs` — 将 `setterMap` 的比较器从 `StringComparer.Ordinal` 改为 `StringComparer.OrdinalIgnoreCase`。

#### 6.5 NSSet.ToArray 方法

为 `Metal.NET/Foundation/NSSet.cs` 添加 `ToArray<T>(nint setPtr)` 方法，内部调用 `allObjects` selector 获取 NSArray，再委托给 `NSArray.ToArray<T>()`。

#### 6.6 最终审计 — 不可映射类型与 nint 回退

运行 `_audit_nint_fallback.py` 全面审计：

- **IsUnmappableObjCType 阻止的 selector**：101 个，**全部在 CoreFoundation**（NSString、NSDictionary、NSData 等 Foundation 类），Metal/MetalFX/QuartzCore 为 0
- **生成代码中的 nint 参数**：108 个，均为合法用途（`void*` 指针、`NSInteger`、`Class`、`IOSurfaceRef` 等）
- **生成代码中的 nint 返回/属性**：54 个，均为 `id` 返回、`void*` 指针、`NSInteger` 属性等合法用途
- **结论**：无需修复，所有类型映射正确

#### 6.7 Selector 增长

| 阶段 | Selectors |
|---|---|
| 会话 5 完成后 | 3208 |
| 新增 3 个类绑定 | **3212** (+4) |

---

## 3. 当前剩余缺失

通过 `_audit_truly_missing.py` 精确审计（排除 SkipClasses、SkipSelectors、init、继承），**所有框架合计缺失：0**。

全部 selector 已覆盖 ✓

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

- `IsUnmappableObjCType`：跳过 `IMP`、`SEL`、`FourCharCode`、`id *`（精确匹配），以及 `NSCoder`、`MTLIOCompressionContext` 等（模式匹配）
- **已移除的过滤**（历次会话）：`Class`（→`nint`）、`unichar *`（→`nint`）、NSArray 返回值无条件跳过、`CAEDRMetadata`（→手写类）、`NSAttributedString`（→手写类）、`NSSet<`（→`nint`）
- `SkipClasses`：`NSArray`、`NSObject`、`NSDate`、`NSSet`、`NSEnumerator` 等（手写或不生成）
- `SkipSelectors`：`description`、`hash`、`isEqual:` 等 NSObject 基础方法（39 个）
- `SkipMethods`：`alloc`、`init`、`retain`、`release` 等（6 个）

### 4.3 NSArray 处理（完整流程）

**解析阶段**（AstJsonParser.ClassParsing.cs）：
1. 方法返回 `NSArray*` → 调用 `ExtractNSArrayElementType(astMethod.ReturnType)` 从泛型提取元素类型
2. 能提取 → 注册到 `context.NSArrayReturnTypes[(className, methodName)]`，方法放行
3. 不能提取（如 `NSArray<ObjectType>`）→ 跳过
4. 属性返回 `NSArray*` → 同样提取并注册到 context

**发射阶段**（CSharpEmitter）：
1. `TryResolveNSArrayElementType(className, memberName)` 查找优先级：
   - 硬编码字典 `NSArrayElementTypes`
   - 后缀规则 `NSArraySuffixRules`
   - **context.NSArrayReturnTypes**（从 AST 泛型提取）
2. 找到元素类型 → 生成 `ElementType[]` 返回值 + `NSArray.ToArray<T>()`
3. 找不到 → 跳过该方法/属性

### 4.4 Init 静态工厂模式

```csharp
public static ClassName InitXxx(params)
{
    // ...
    return new(nativePtr, NativeObjectOwnership.Managed);
}
```

### 4.5 Selector 命名规则

每个冒号分隔的片段 PascalCase 后用 `_` 连接：

| Selector | C# 名称 |
|---|---|
| `setVertexBuffer:offset:atIndex:` | `SetVertexBuffer_Offset_AtIndex_` |
| `newBufferWithLength:options:` | `NewBufferWithLength_Options_` |
| `label` | `Label` |

### 4.6 属性 Getter/Setter 配对

通过 `CategorizeMembers` 将方法分为属性（getter/setter 配对）和剩余方法。Setter selector 使用 AST 中的显式名称（如 `setUITexture:` 而非自动推导的 `setUiTexture:`）。布尔属性：`isDepthReversed` → setter 为 `setDepthReversed:`。

**大小写不敏感匹配**（会话 6 修复）：`setterMap` 使用 `StringComparer.OrdinalIgnoreCase`，解决 `setEDRMetadata` → `eDRMetadata` 与 getter `EDRMetadata` 首字母大小写不匹配的问题。

### 4.9 NSSET_PARAM 处理（同 NSARRAY_PARAM 模式）

**解析阶段**（AstJsonParser.ClassParsing.cs）：
- 检测参数类型含 `NSSet<...>` → 提取泛型元素类型 → 标记参数类型为 `NSSET_PARAM:{elemType}`

**发射阶段**（CSharpEmitter.MethodEmission.cs）：
- 检测 `NSSET_PARAM:` 前缀 → 生成 `ElemType[] paramName` 签名
- 方法体中调用 `NSSet.FromArray(paramName)` 创建临时 NSSet → 传入 MsgSend → 事后释放

### 4.7 枚举支持

- AST 中的枚举（Metal / MetalFX）→ 自动生成
- Foundation 枚举（NSComparisonResult, NSStringCompareOptions, NSStringEncoding）→ 手写 `NSEnums.cs` + 注册到 `EnumBackingTypes`
- `EnumBackingTypes` 字典：枚举 C# 名 → 底层类型字符串

### 4.8 GeneratorContext — parser→emitter 共享状态

| 属性 | 说明 |
|---|---|
| `Enums` | 所有解析的枚举定义 |
| `Classes` | 所有解析的类/协议定义 |
| `Structs` | 所有解析的 struct 定义 |
| `FreeFunctions` | 所有解析的自由函数 |
| `EnumBackingTypes` | 枚举 C# 名 → 底层类型 |
| `KnownClassNames` | 所有已知类名（用于验证基类引用） |
| `BlockTypeAliases` | ObjC block 类型别名 |
| `MsgSendSignatures` | MsgSend 重载签名（发射阶段填充） |
| `NSArrayReturnTypes` | **新增** — AST 泛型提取的 NSArray 元素类型映射 |

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

## 6. IsUnmappableObjCType 当前完整列表

精确匹配：`IMP`, `SEL`, `FourCharCode`, `id *`

模式匹配（`t.Contains()`）：
```
NS::Process, NS::Observer, NSProcess, NSObserver,
ObjectType, KeyType, NS_RETURNS_INNER_POINTER,
NSStringEncoding *, NSStringEncodingConversionOptions,
NSCoder, MTLIOCompressionContext, va_list,
NSDate, NSLocale, NSCharacterSet, NSStringTransform,
NSRangePointer, NSURLBookmark, NSURLHandle, NSURLResourceKey,
NSDataWritingOptions, NSDataSearchOptions, NSDataReadingOptions,
NSDataBase64, NSDataCompressionAlgorithm,
NSDecimal, NSLinguistic, NSEnumerator, NSErrorDomain
```

> 注：以上 101 个被阻止的 selector **全部在 CoreFoundation**（Foundation 类），Metal/MetalFX/QuartzCore 为 0。

已移除（历次会话中）：`Class`（→`nint`）、`unichar *`（→`nint`）、`kern_return_t`、`task_id_token_t`、`CAEDRMetadata`（→手写类）、`NSAttributedString`（→手写类）、`NSSet<`（→泛型剥离+`nint`）

特殊模式匹配：
- `*const ` 在类型中且不以 `*` 结尾
- `const` + `* _Nonnull *` 且不以 `*` 结尾

---

## 7. Windows 开发环境注意事项

- Python 用 `py`（不是 `python`）
- `metal-ast.json` 有 UTF-8 BOM，Python 读取时用 `utf-8-sig` 编码
- PowerShell 中 f-string 含花括号 dict 访问会导致 SyntaxError，应使用 `.py` 脚本文件而非内联 Python
- 仓库根目录有临时审计脚本（`_audit_*.py`、`_check_*.py`、`_search_enums.py`），可在后续清理

---

## 8. 临时文件清单

以下文件为审计用临时脚本，位于仓库根目录，可安全删除：

```
_audit_fallback_classes.py
_audit_missing_detail.py
_audit_selectors.py          ← 主审计脚本（已修复 3 个 bug，可继续使用）
_audit_skips.py              ← 本次新增：全面审计所有跳过原因
_audit_truly_missing.py      ← 本次新增：精确审计（排除继承/SkipClasses）
_audit_types.py
_check_desc.py
_check_idptr.py
_check_metal_blocked.py
_check_missing.py
_check_nsbundle_props.py
_check_ns.py
_check_ns2.py
_check_props.py
_check_sels.py
_check_ui.py
_search_enums.py
```

---

## 9. 后续工作建议

1. ~~**剩余 4 个缺失的 selector**~~ ✓ 已在会话 6 完成
2. ~~**NSSET_PARAM 类型化**~~ ✓ 已在会话 6 完成（`SetPreservationPriority` 等方法使用 `NSString[]`）
3. ~~**属性配对大小写修复**~~ ✓ 已在会话 6 完成（`OrdinalIgnoreCase`）
4. ~~**最终审计**~~ ✓ 已在会话 6 完成（101 blocked 全在 CoreFoundation，Metal 为 0，nint 均为合法用途）
5. **考虑移除更多不必要的 IsUnmappableObjCType 条目**（可选，仅增加 Foundation 覆盖率）：
   - `NSErrorDomain` → 已映射为 `NSString`
   - `NSDecimal` → 已映射为 `nint`
   - `NS_RETURNS_INNER_POINTER` → 是注解不是类型，应在 strip 阶段处理
6. **清理临时审计脚本**：删除根目录下的 `_*.py` 文件

---

## 10. 关键代码位置速查

| 需求 | 文件 | 位置 |
|---|---|---|
| 添加新的不可映射类型 | `AstJsonParser.TypeMapping.cs` | `IsUnmappableObjCType()` |
| 添加新的类型映射 | `AstJsonParser.TypeMapping.cs` + `TypeMapper.cs` | `MapObjCTypeForModel()` + `MapType()` |
| NSArray 元素类型硬编码 | `CSharpEmitter.cs` | `NSArrayElementTypes` 字典 |
| NSArray 后缀规则 | `CSharpEmitter.cs` | `NSArraySuffixRules` 数组 |
| NSArray AST 泛型回退 | `GeneratorContext.cs` | `NSArrayReturnTypes` 属性 |
| 跳过的类列表 | `AstJsonParser.cs` | `SkipClasses` |
| 跳过的 selector 列表 | `AstJsonParser.cs` | `SkipSelectors` |
| Selector→C# 键名 | `CSharpEmitter.MethodEmission.cs` | `BuildMethodNameFromSelector()` |
| 属性解析 | `AstJsonParser.ClassParsing.cs` | `foreach (AstProperty prop in ast.Properties)` |
| 方法解析 | `AstJsonParser.ClassParsing.cs` | `foreach (AstMethod astMethod in ast.Methods)` |
| Init 解析 | `AstJsonParser.ClassParsing.cs` | 第二个 `foreach (AstMethod astMethod in ast.Methods)` |
| NSSET_PARAM 解析 | `AstJsonParser.ClassParsing.cs` | 方法/init 循环中 NSSet 检测 |
| NSSET_PARAM 发射 | `CSharpEmitter.MethodEmission.cs` | `NSSET_PARAM:` 前缀处理 |
| 属性配对（setter map） | `CSharpEmitter.ClassGeneration.cs` | `CategorizeMembers` → `setterMap` |
