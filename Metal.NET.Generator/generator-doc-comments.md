# Generator Enhancement: Add XML Doc Comments from `api-order.json`

## Overview

The `api-order.json` file now contains Apple documentation summaries for Metal API classes and their members. The code generator should use this data to emit `/// <summary>` XML documentation comments on generated C# types and members.

## `api-order.json` Schema

```jsonc
{
  "<class-slug>": {                    // e.g. "mtldevice", "mtl4commandbuffer"
    "summary": "<class description>",  // Optional. Apple doc summary for the class.
    "groups": [                        // Optional. Ordered member groups.
      {
        "title": "<group title>",      // e.g. "Instance Properties", "Instance Methods"
        "members": [
          {
            "name": "<member-name>",     // Swift-style selector, e.g. "makeCommandQueue(descriptor:)"
            "summary": "<description>"   // Optional. Apple doc summary for the member.
          }
        ]
      }
    ]
  }
}
```

### Key Points

- **`summary`** fields are short, factual API descriptions (1-2 sentences).
- **`name`** values use Swift selector syntax (e.g. `makeCommandQueue(descriptor:)`). The generator already maps these to C++ method names; use the same mapping to match generated C# members.
- Some members have **no `summary`** (value is absent, not null). Skip doc comment generation for those.
- Some classes have **only `summary`** with no `groups`** (abstract base classes with no own members).
- The `groups` array also defines **member ordering** — generated members should appear in the same order.

## Requirements

### 1. Class-Level Doc Comments

For each generated C# class, if the corresponding entry in `api-order.json` has a `summary`, emit an XML doc comment above the class declaration:

```csharp
/// <summary>
/// The main Metal interface to a GPU that apps use to draw graphics and run computations in parallel.
/// </summary>
public class MTLDevice : NSObject, INativeObject<MTLDevice>
{
```

### 2. Member-Level Doc Comments

For each generated property or method, if the corresponding member in `api-order.json` has a `summary`, emit an XML doc comment:

```csharp
/// <summary>
/// The full name of the GPU device.
/// </summary>
public NSString Name { get; }

/// <summary>
/// Creates a queue you use to submit rendering and computation commands to a GPU.
/// </summary>
public MTLCommandQueue MakeCommandQueue() { ... }
```

### 3. Member Ordering (Already Implemented)

The generator already uses `api-order.json` for member ordering. The new `summary` fields are additive — existing ordering logic should continue to work. The structure change is:

**Before** (old format):
```json
{
  "mtldevice": [
    { "title": "...", "members": ["name", "makeCommandQueue()"] }
  ]
}
```

**After** (new format):
```json
{
  "mtldevice": {
    "summary": "...",
    "groups": [
      { "title": "...", "members": [{ "name": "name", "summary": "..." }] }
    ]
  }
}
```

The ordering data moved from `apiOrder["class"]` (array of groups) to `apiOrder["class"].groups` (array of groups under a `groups` key). Member names moved from plain strings to objects with `name` and optional `summary` properties. **Update any existing code that reads `api-order.json` accordingly.**

### 4. Special Characters

Some summaries contain Unicode characters (e.g. curly quotes `'`, em dashes `—`). These should be preserved as-is in the XML doc comments. The generator should properly XML-escape `<`, `>`, and `&` if they appear in summaries.

### 5. Summary Text Rules

- Do **not** modify the summary text (no truncation, no casing changes).
- If a summary is missing for a member or class, simply omit the `/// <summary>` block — do not generate an empty one.
- Each summary should be on a single line within the `<summary>` tags (no multi-line wrapping needed since all summaries are 1-2 sentences).

## Lookup Strategy

When the generator processes a C++ header class:

1. Convert the class name to a slug: lowercase the namespace + class name (e.g. `MTL::Device` → `mtldevice`, `MTL4::CommandBuffer` → `mtl4commandbuffer`).
2. Look up `apiOrder[slug]` to get the class entry.
3. Read `.summary` for the class-level doc comment.
4. Read `.groups` for member ordering and per-member summaries.
5. For each member in `.groups[*].members`, match `.name` to the generated C# member using the existing Swift-to-C++ name mapping logic.
6. If matched and `.summary` exists, emit the XML doc comment above the C# member.

## Files to Modify

- **Generator source files** that read `api-order.json` — update to handle the new schema (object with `summary` + `groups` instead of bare array of groups).
- **Generator source files** that emit C# class/member declarations — add logic to prepend `/// <summary>` comments.

## Testing

After implementation, verify:
1. Generated `MTLDevice.cs` has a class-level `/// <summary>` comment.
2. Generated members like `Name`, `MakeCommandQueue()` have `/// <summary>` comments.
3. Members without summaries in `api-order.json` have no doc comments (no empty `<summary>` blocks).
4. Classes with only `summary` and no `groups` (e.g. `MTL4FunctionDescriptor`) still compile correctly.
5. Member ordering is preserved (no regression from schema change).
