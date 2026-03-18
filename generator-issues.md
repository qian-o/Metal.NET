# Metal.NET Generator — 已知问题（全部已修复）

> 以下 3 个问题均已在之前的迭代中修复并通过编译验证（0 errors, 0 warnings）。
> 本文档保留作为历史记录。

## 问题 1：方法被错误生成为属性 ✅ 已修复

### 修复方案
在 `AstJsonParser.ClassParsing.cs` 中为属性解析生成的 getter/setter 方法添加 `IsPropertyAccessor = true` 标志。
`CSharpEmitter.ClassGeneration.cs` 的 `CategorizeMembers()` 仅将标有该标志的方法提升为 C# 属性，
其他无参方法保持为方法。同时使用 `propertyNames` HashSet 防止属性与方法名称冲突。

---

## 问题 2：数组参数方法生成错误 ✅ 已修复

### 修复方案
在 `AstJsonParser.ClassParsing.cs` 添加 `DetectArrayParamPairs()` 方法，检测连续的 `(pointer, count)` 参数对，
将指针参数重标记为 `STRUCT_ARRAY:ElementType`，count 参数标记为 `ARRAY_PARAM`。
`CSharpEmitter.MethodEmission.cs` 的 `EmitMethod()` 根据标记自动生成 `fixed` 或 `stackalloc` 的数组封送代码。

---

## 问题 3：生成器应使用 `name` 而非解析 `selector` 来生成方法名 ✅ 已修复

### 修复方案
`EmitMethod()` 现在直接使用 `TypeMapper.ToPascalCase(method.Name)` 生成 C# 方法名。
`selector` 字段仅用于 ObjC runtime 调用（MsgSend 的 selector 注册）。
`ComputeSimplifiedMethodNames()` 已删除。`BuildMethodNameFromSelector()` 仅保留用于极少数 selector key 冲突的 fallback。
`AstJsonParser.ClassParsing.cs` 中 `Name` 字段来源优先使用 JSON 的 `name`，仅在为空时 fallback 到 `SelectorToMethodName()`。
