# Generator Enhancement: Integrate `metal-docs.json`

## Background

The `update-sources.ps1` script generates `metal-docs.json`, which contains per-class and per-member metadata distilled from Apple documentation. **This file has never been consumed by the generator.** This is a first-time integration.

## `metal-docs.json` Schema

```jsonc
{
  "<class-slug>": {                    // Lowercase namespace+class, e.g. "mtldevice", "mtl4commandbuffer"
    "summary": "<class description>",  // Optional.
    "groups": [                        // Optional.
      {
        "title": "<group title>",
        "members": [
          {
            "name": "<swift-selector>", // e.g. "makeCommandQueue(descriptor:)"
            "summary": "<description>"  // Optional.
          }
        ]
      }
    ]
  }
}
```

## Requirements

1. **Load `metal-docs.json`** at generator startup (located in `Metal.NET.Generator/`). Pass the data to `CSharpEmitter`.

2. **Class body layout** — Within each generated class, members must be laid out in this fixed order:

   1. `#region INativeObject` (existing)
   2. Constructor (if applicable)
   3. Grouped properties — properties that appear in `metal-docs.json` groups, wrapped in `#region <GroupTitle> - Properties`, ordered by JSON group order and intra-group member order
   4. Ungrouped properties — properties not found in any JSON group, in their original order
   5. Indexer (if applicable, existing `subscript(_:)` logic — keep as-is, no region needed)
   6. Grouped methods — methods that appear in `metal-docs.json` groups, wrapped in `#region <GroupTitle> - Methods`, ordered by JSON group order and intra-group member order
   7. Ungrouped methods — methods not found in any JSON group, in their original order
   8. Free functions (P/Invoke wrappers — keep as-is, no region or doc comments)

   Properties and methods must always be separated, even if they belong to the same JSON group. A JSON group that contains both properties and methods produces two `#region` blocks: one in the properties section, one in the methods section.

3. **Class-level `/// <summary>`** — If a class entry has a `summary`, emit an XML doc comment above the class declaration.

4. **Member-level `/// <summary>`** — If a matched member has a `summary`, emit an XML doc comment above the property or method declaration. Members without `summary` get no doc comment. When a member already has a `[Obsolete]` attribute with its own `/// <summary>Deprecated: ...</summary>`, the JSON `summary` takes priority (replace, not duplicate).

5. **Name matching** — Match JSON member names (Swift selector syntax) to generated C# members using the existing Swift-to-C++ name mapping logic. Strip parameter labels and disambiguation suffixes (e.g. `-5o46e`) when matching. When multiple JSON entries map to the same C++ name (overloads with different suffixes), match by name + parameter count. If ambiguous, use the first match.

6. **XML escaping** — Escape `<`, `>`, and `&` in summaries. Preserve Unicode characters (curly quotes, em dashes, etc.) as-is.

7. **No empty doc comments** — If `summary` is absent, omit the `/// <summary>` block entirely.

8. **Scope** — Only generated class files are affected. Enums, structs, delegates (`MTLDelegates.cs`), and `ObjectiveC.cs` are out of scope. Hand-written classes in `SkipClasses` are also unaffected.

## Notes

- **Slug computation**: `(prefix + className).ToLowerInvariant()` where prefix comes from `TypeMapper.GetPrefix()`. Examples: `MTL::Device` → `mtldevice`, `CA::MetalDrawable` → `cametaldrawable`, `MTLFX::SpatialScaler` → `mtlfxspatialscaler`.
- **Summary-only classes**: 7 classes have `summary` but no `groups` (e.g. `mtl4functiondescriptor`). These get a class-level doc comment but no member reordering or regions.
- **`Deprecated` groups**: Some JSON groups are titled `"Deprecated"`. These should still produce regions like any other group.
- **`init(...)` / `subscript(_:)` entries**: The JSON contains `init(...)` and `subscript(_:)` entries that don't map to generated C# members (constructors and indexers are emitted separately). These should be silently skipped during matching.
- **Current alphabetical sort**: Properties are currently sorted alphabetically in `CategorizeMembers`. The new JSON-based ordering replaces this.
