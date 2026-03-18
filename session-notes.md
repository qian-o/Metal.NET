# Metal.NET — Swift Name Diagnostics 会话记录

## 背景

项目 `Metal.NET` 使用 Python 脚本 `.github/scripts/extract_metal_api.py` 从 macOS SDK 的 Clang AST dump 和 Swift Symbol Graph 中提取 Metal API 定义，生成 `Metal.NET.Generator/metal-ast.json`，再由 C# Generator 生成 .NET 绑定代码。

---

## 1. 将 `swiftName` 改为 `name` 并放在 `selector` 上方

### 需求
- JSON 中所有带 `selector` 的方法节点，都应在其上方有一个 `name` 字段
- 已有 `swiftName` 的 → 重命名为 `name`，放在 `selector` 前
- 没有 `swiftName` 的 → 从 `selector` 第一段（冒号前）派生 `name`

### 修改文件：`.github/scripts/extract_metal_api.py`

**修改 1：`extract_method` 函数（约第 355 行）**

```python
# 修改前
r: dict = {
    "selector": name,
    "isClassMethod": not node.get("instance", True),
    ...
}

# 修改后 — 添加 name 字段，从 selector 派生
method_name = name.split(':')[0] if ':' in name else name
r: dict = {
    "name": method_name,
    "selector": name,
    "isClassMethod": not node.get("instance", True),
    ...
}
```

**修改 2：`apply_swift_names` 函数（约第 681 行）**

```python
# 修改前
m['swiftName'] = swift_names[key]

# 修改后 — 直接覆盖 name 而非添加 swiftName
m['name'] = swift_names[key]
```

---

## 2. 统计未带 `swiftName` 的方法数

创建了 `.github/scripts/count_missing_names.py`，运行结果：

| 统计项 | 数量 |
|---|---|
| 方法总数 | 3571 |
| 有 swiftName | 311 |
| 没有 swiftName | 3260 |

---

## 3. 检查 `name` 中包含 `With` 或 `At` 的方法

用户更新了 JSON（所有方法都有了 `name`），创建了 `.github/scripts/check_method_names.py` 检查：

| 统计项 | 数量 |
|---|---|
| 方法总数 | 3571 |
| 没有 name | 0 ✅ |
| name 含 With/At | 311 |

这 311 个方法的 `name` 仍是从 ObjC selector 截取的，未被 Swift 符号图覆盖。

---

## 4. 分析为什么部分方法没有 Swift 名称

### 例子
```
[MTLDevice] name=newRenderPipelineStateWithMeshDescriptor
            selector=newRenderPipelineStateWithMeshDescriptor:options:reflection:error:
```
理论上 Swift 名称应为 `makeRenderPipelineState`。

### `load_swift_names` 函数的过滤逻辑（第 667-668 行）
```python
first_part = selector.split(':')[0]  # "newRenderPipelineStateWithMeshDescriptor"
if swift_base != first_part:          # "makeRenderPipelineState" != 上面 → True，会被收录
```
过滤逻辑没问题，说明这些方法**根本不在符号图里**。

### 创建诊断脚本 `.github/scripts/diagnose_swift_names.py`

本地运行结果（无符号图目录）：
- 306 个方法的 name 含 With/At 且未被 Swift 覆盖
- 其中 MTL/CAMetal 类型：86 个
- NS/其他类型：220 个（预期内，无 Swift 符号图）

### 可能原因分析

1. **MTL4\* 全新 API** — macOS 26 新增，符号图可能尚未覆盖
2. **Property getter/setter** — Swift 符号图只导出 property，不单独导出 getter/setter method
3. **Protocol 成员可能使用 Swift USR** 格式（`s:...`）而非 ObjC USR（`c:objc(...)`），导致正则 `_RE_OBJC_USR` 匹配不到

---

## 5. 在 GitHub Actions 中添加诊断步骤

### 修改文件：`.github/workflows/extract-metal-api.yml`

在 "Extract Metal API" 和 "Commit changes" 之间添加了两个 step：

**Step: "Diagnose missing Swift names"** — 运行 4 个 Python 分析：
1. 运行 `diagnose_swift_names.py /tmp/symbolgraph`
2. Dump 所有符号到 `all_symbols.json`
3. 提取 MTLDevice 相关符号 → `mtldevice_symbols.json`；new/make 模式 → `new_make_symbols.json`
4. 非 ObjC USR 格式的 Metal 符号 → `non_objc_usr_metal.json`（**关键，验证 Swift USR 假设**）

**Step: "Upload diagnostic artifacts"** — 上传为 `swift-name-diagnostics` artifact：
- `/tmp/diagnose/` 目录（所有分析结果）
- `/tmp/symbolgraph/*.symbols.json`（原始符号图）

### Bug 修复
第一次运行失败，因为 `subHeading` 是 dict 数组不是 string 数组：
```python
# 删除了这行（未使用且类型错误）
subhead = ' '.join(sym.get('names', {}).get('subHeading', [{}]))
```

---

## 当前状态

- ✅ `extract_metal_api.py` 已更新：生成 `name` 字段
- ✅ 诊断脚本已就绪
- ✅ GitHub Actions workflow 已添加诊断 + artifact 上传
- ✅ **已下载并分析 `swift-name-diagnostics` artifact**
- ✅ **增强 `load_swift_names` 函数，新增三个阶段**
- ✅ **添加 `new→make` 命名回退逻辑**

## 6. 符号图诊断分析（artifact 下载后）

### 符号图数据总览

| 指标 | 数量 |
|---|---|
| 符号图总符号 | 4837 |
| ObjC USR `(im)` 方法 | 650 |
| ObjC USR `(cm)` 类方法 | 17 |
| ObjC USR `(py)` 属性 | 1203 |
| Swift USR 符号 | 2967 |
| `defaultImplementationOf` 关系 | 14 |

### 根因确认

1. **正则 `_RE_OBJC_USR` 只匹配 `(im)` 和 `(cm)`** — 遗漏了 1203 个 `(py)` 属性符号
2. **Swift USR 方法**（699 个）— Swift overlay 扩展使用纯 Swift USR (`s:So12MTL4CompilerP5MetalE...`)
3. 部分有 `defaultImplementationOf` 关系可链接回 ObjC selector（14 个）；大部分仅有 `memberOf`
4. MTL4\* 新 API 的工厂方法多数只有 Swift USR，无法直接映射

### 增强 `load_swift_names` — 四阶段方案

| 阶段 | 来源 | 新增映射 |
|---|---|---|
| Phase 1 | ObjC USR `(im)`/`(cm)` 符号 — 直接映射（原有） | 326 |
| Phase 2 | `defaultImplementationOf` 关系 — Swift USR → ObjC selector | +11 |
| Phase 3 | ObjC USR `(py)` 属性符号 — 属性名映射 | +29 |
| Phase 4 | `new→make` 命名回退（无符号图覆盖时） | 运行时 +23 |
| **总计** | | **366 符号图 + 23 回退 = 389** |

### 效果对比

| 指标 | 增强前 | 增强后 |
|---|---|---|
| Swift 名称映射数 | 326 | 366 |
| 方法仍有 With/At | 311 | 288 |
| MTL/CAMetal 仍有 With/At | 89 | 68 |
| 其中误报（Attachment/Attribute）| — | 50 |
| **真正未覆盖的 MTL 方法** | — | **18** |

### 剩余 18 个未覆盖方法分析

已确认为正确名称（符号图明确给出）：
- `makeComputePipelineStateWithAdditionalBinaryFunctions` — Apple 保留 `WithAdditional...` 以区分重载
- `makeCommandBufferWithUnretainedReferences` — 区分 retained 和 unretained 版本
- `indirectRenderCommandAt` / `indirectComputeCommandAt` — 实际就是 Swift 名

不在符号图中（无 Swift overlay 或新 API）：
- `resetWithRange:` / `memoryBarrierWithResources:...` / `setStageInRegionWithIndirectBuffer:...`
- `setOwnerWithIdentity:` / `extentAtDimensionIndex:`
- `initWithRank:...` / `initWithSampleCount:...`
- `rasterizationRateMapDescriptorWithScreenSize:`
- `presentsWithTransaction` / `setPresentsWithTransaction:`

## 7. `_new_to_make` 命名规则

正则：`^new(\w+?)(?:With\w+|By\w+)?$` → `make` + 核心名称

示例：
- `newCommandQueue` → `makeCommandQueue`
- `newComputePipelineStateWithDescriptor` → `makeComputePipelineState`
- `newRenderPipelineStateBySpecializationWithDescriptor` → `makeRenderPipelineStateBySpecialization`
- `newDynamicLibraryWithURL` → `makeDynamicLibrary`

## 待办（下一步）

1. 提交 `extract_metal_api.py` 的改动，重跑 GitHub Actions
2. 验证新的 `metal-ast.json` 中 `name` 字段质量
3. 考虑是否需要对 `apply_swift_names` 的属性覆盖做进一步处理
4. 解决 `generator-issues.md` 中的两个生成器问题（方法/属性区分、数组参数封装）

## 关键文件清单

| 文件 | 说明 |
|---|---|
| `.github/scripts/extract_metal_api.py` | 主脚本，从 Clang AST + Swift 符号图生成 metal-ast.json |
| `.github/scripts/diagnose_swift_names.py` | 诊断脚本，交叉对比缺失的 Swift 名称 |
| `.github/scripts/check_method_names.py` | 检查 name 中含 With/At 的方法 |
| `.github/workflows/extract-metal-api.yml` | GitHub Actions 工作流（已添加诊断步骤） |
| `Metal.NET.Generator/metal-ast.json` | 生成的 AST JSON（太大，勿直接读取） |
| `Metal.NET.Generator/AstModels.cs` | C# 模型，`AstMethod` 类暂无 `Name` 属性（待后续添加） |
