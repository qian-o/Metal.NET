# Generator Enhancement: Integrate `metal-docs.json`

## Background

The `update-sources.ps1` script generates `metal-docs.json`, which contains per-class, per-enum, and per-member metadata distilled from Apple documentation. **This file has never been consumed by the generator.** This is a first-time integration.

### Current state

- The generator already parses `[[deprecated("...")]]` attributes from metal-cpp C++ headers and emits `[Obsolete("...")]` + `/// <summary>Deprecated: ...</summary>` on the corresponding C# members (~30 members covered).
- Apple documentation covers additional deprecations (~107 members, ~25 with messages) that metal-cpp headers do not annotate. The JSON `deprecated` / `deprecatedMessage` fields supplement the header-based mechanism — they do **not** replace it.

## `metal-docs.json` Schema

```jsonc
{
  "<slug>": {                              // Lowercase namespace+class/enum, e.g. "mtldevice", "mtlcpucachemode"
    "summary": "<description>",            // Optional.
    "deprecated": true,                    // Optional; only present when true.
    "deprecatedMessage": "<reason>",       // Optional; human-readable deprecation reason.
    "groups": [                            // Optional.
      {
        "title": "<group title>",
        "members": [
          {
            "name": "<swift-selector>",    // e.g. "makeCommandQueue(descriptor:)"
            "summary": "<description>",    // Optional.
            "deprecated": true,            // Optional; only present when true.
            "deprecatedMessage": "<reason>" // Optional; human-readable deprecation reason.
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

4. **Member-level `/// <summary>`** — If a matched member has a `summary`, emit an XML doc comment above the property or method declaration. Members without `summary` get no doc comment. When a member already has a header-derived `[Obsolete]` with its own `/// <summary>Deprecated: ...</summary>`, the JSON `summary` takes priority (replace, not duplicate).

5. **Name matching** — Match JSON member names (Swift selector syntax) to generated C# members using the existing Swift-to-C++ name mapping logic. Strip parameter labels and disambiguation suffixes (e.g. `-5o46e`) when matching. When multiple JSON entries map to the same C++ name (overloads with different suffixes), match by name + parameter count. If ambiguous, use the first match.

6. **XML escaping** — Escape `<`, `>`, and `&` in summaries. Preserve Unicode characters (curly quotes, em dashes, etc.) as-is.

7. **No empty doc comments** — If `summary` is absent, omit the `/// <summary>` block entirely.

8. **Scope** — Generated class files and enum files are affected. Structs, delegates (`MTLDelegates.cs`), and `ObjectiveC.cs` are out of scope. Hand-written classes in `SkipClasses` are **not** regenerated, but should receive doc comments via a separate mechanism (see requirement 11).

9. **Enum doc comments** — If an enum's slug has an entry in `metal-docs.json`:
   - Emit a class-level `/// <summary>` above the `public enum` declaration if `summary` is present.
   - Emit a member-level `/// <summary>` above each enum member if its name matches a JSON member name that has a `summary`. Name matching is case-insensitive (Apple docs use `camelCase`, C# members use `PascalCase`).
   - Enum member ordering and grouping are **not** changed — enums keep their current order. Only doc comments are added.

10. **Deprecated — supplementing C++ headers** — The generator already emits `[Obsolete("...")]` for members annotated with `[[deprecated("...")]]` in metal-cpp headers. The JSON `deprecated` / `deprecatedMessage` fields provide **additional** deprecation coverage for members the headers do not annotate:
    - If a C# member already has a header-derived `[Obsolete]`, keep it — do not overwrite with JSON data.
    - If a C# member has no header-derived `[Obsolete]` but the matched JSON member has `"deprecated": true`, emit `[Obsolete("deprecatedMessage")]` (or `[Obsolete]` if no message).
    - For classes/enums: if the JSON entry has `"deprecated": true`, emit `[Obsolete("deprecatedMessage")]` on the type declaration.

11. **Hand-written class doc comments** — The following hand-written classes are in `SkipClasses` and are not regenerated, but they have corresponding entries in `metal-docs.json` (14 out of 16). The generator should add class-level `/// <summary>` comments to these files by patching them in-place (insert before the `public class` declaration if no summary exists yet):

    | Class | Slug | Has JSON |
    |---|---|---|
    | `NSString` | `nsstring` | ✅ |
    | `NSError` | `nserror` | ✅ |
    | `NSArray` | `nsarray` | ✅ |
    | `NSURL` | `nsurl` | ✅ |
    | `NSDictionary` | `nsdictionary` | ✅ |
    | `NSNotification` | `nsnotification` | ✅ |
    | `NSNotificationCenter` | `nsnotificationcenter` | ✅ |
    | `NSSet` | `nsset` | ✅ |
    | `NSEnumerator` | `nsenumerator` | ✅ |
    | `NSObject` | `nsobject` | ❌ |
    | `NSProcessInfo` | `nsprocessinfo` | ✅ |
    | `NSBundle` | `nsbundle` | ✅ |
    | `NSAutoreleasePool` | `nsautoreleasepool` | ✅ |
    | `NSNumber` | `nsnumber` | ✅ |
    | `NSValue` | `nsvalue` | ❌ |
    | `NSDate` | `nsdate` | ✅ |

    Member-level doc comments for hand-written classes are **out of scope** — these classes have custom implementations that don't follow the generated member layout, so member matching is not feasible. Only the class-level `/// <summary>` should be synced.

## Notes

- **Slug computation**: `(prefix + className).ToLowerInvariant()` where prefix comes from `TypeMapper.GetPrefix()`. Examples: `MTL::Device` → `mtldevice`, `CA::MetalDrawable` → `cametaldrawable`, `MTLFX::SpatialScaler` → `mtlfxspatialscaler`.
- **Summary-only entries**: Some entries have `summary` but no `groups` (e.g. `mtl4functiondescriptor`). These get a type-level doc comment but no member reordering or regions.
- **`Deprecated` groups**: Some JSON groups are titled `"Deprecated"`. These should still produce regions like any other group (in addition to individual members having `"deprecated": true`).
- **`init(...)` / `subscript(_:)` entries**: The JSON contains `init(...)` and `subscript(_:)` entries that don't map to generated C# members (constructors and indexers are emitted separately). These should be silently skipped during matching.
- **Current alphabetical sort**: Properties are currently sorted alphabetically in `CategorizeMembers`. The new JSON-based ordering replaces this.
