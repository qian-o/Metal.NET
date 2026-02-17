using System.Runtime.InteropServices;

namespace Metal.NET;

/// <summary>
/// P/Invoke bindings for the Objective-C runtime (libobjc.dylib).
/// All Metal API calls go through objc_msgSend.
///
/// Overloads use nint for all register-sized arguments. The Generator
/// casts enum/uint/nuint/ObjC-wrapper values to nint before calling.
/// Separate overloads exist for value structs, out NSError, and typed returns.
/// </summary>
public static unsafe partial class ObjectiveCRuntime
{
    private const string ObjCLibrary = "/usr/lib/libobjc.A.dylib";

    // ═══════════════════════════════════════════════════════════════════
    // void returns — uniform nint args (0..12 args)
    // ═══════════════════════════════════════════════════════════════════

    [LibraryImport(ObjCLibrary, EntryPoint = "objc_msgSend")]
    public static partial void objc_msgSend(nint receiver, Selector selector);

    [LibraryImport(ObjCLibrary, EntryPoint = "objc_msgSend")]
    public static partial void objc_msgSend(nint receiver, Selector selector, nint a);

    [LibraryImport(ObjCLibrary, EntryPoint = "objc_msgSend")]
    public static partial void objc_msgSend(nint receiver, Selector selector, nint a, nint b);

    [LibraryImport(ObjCLibrary, EntryPoint = "objc_msgSend")]
    public static partial void objc_msgSend(nint receiver, Selector selector, nint a, nint b, nint c);

    [LibraryImport(ObjCLibrary, EntryPoint = "objc_msgSend")]
    public static partial void objc_msgSend(nint receiver, Selector selector, nint a, nint b, nint c, nint d);

    [LibraryImport(ObjCLibrary, EntryPoint = "objc_msgSend")]
    public static partial void objc_msgSend(nint receiver, Selector selector, nint a, nint b, nint c, nint d, nint e);

    [LibraryImport(ObjCLibrary, EntryPoint = "objc_msgSend")]
    public static partial void objc_msgSend(nint receiver, Selector selector, nint a, nint b, nint c, nint d, nint e, nint f);

    [LibraryImport(ObjCLibrary, EntryPoint = "objc_msgSend")]
    public static partial void objc_msgSend(nint receiver, Selector selector, nint a, nint b, nint c, nint d, nint e, nint f, nint g);

    [LibraryImport(ObjCLibrary, EntryPoint = "objc_msgSend")]
    public static partial void objc_msgSend(nint receiver, Selector selector, nint a, nint b, nint c, nint d, nint e, nint f, nint g, nint h);

    [LibraryImport(ObjCLibrary, EntryPoint = "objc_msgSend")]
    public static partial void objc_msgSend(nint receiver, Selector selector, nint a, nint b, nint c, nint d, nint e, nint f, nint g, nint h, nint i);

    [LibraryImport(ObjCLibrary, EntryPoint = "objc_msgSend")]
    public static partial void objc_msgSend(nint receiver, Selector selector, nint a, nint b, nint c, nint d, nint e, nint f, nint g, nint h, nint i, nint j);

    [LibraryImport(ObjCLibrary, EntryPoint = "objc_msgSend")]
    public static partial void objc_msgSend(nint receiver, Selector selector, nint a, nint b, nint c, nint d, nint e, nint f, nint g, nint h, nint i, nint j, nint k);

    [LibraryImport(ObjCLibrary, EntryPoint = "objc_msgSend")]
    public static partial void objc_msgSend(nint receiver, Selector selector, nint a, nint b, nint c, nint d, nint e, nint f, nint g, nint h, nint i, nint j, nint k, nint l);

    // ═══════════════════════════════════════════════════════════════════
    // void returns — value struct args (these cannot be cast to nint)
    // ═══════════════════════════════════════════════════════════════════

    [LibraryImport(ObjCLibrary, EntryPoint = "objc_msgSend")]
    public static partial void objc_msgSend(nint receiver, Selector selector, MTLClearColor a);

    [LibraryImport(ObjCLibrary, EntryPoint = "objc_msgSend")]
    public static partial void objc_msgSend(nint receiver, Selector selector, MTLSize a);

    [LibraryImport(ObjCLibrary, EntryPoint = "objc_msgSend")]
    public static partial void objc_msgSend(nint receiver, Selector selector, MTLOrigin a, MTLSize b);

    [LibraryImport(ObjCLibrary, EntryPoint = "objc_msgSend")]
    public static partial void objc_msgSend(nint receiver, Selector selector, MTLSize a, MTLSize b);

    [LibraryImport(ObjCLibrary, EntryPoint = "objc_msgSend")]
    public static partial void objc_msgSend(nint receiver, Selector selector, MTLRegion a, nint b, nint c, nint d, nint e, nint f);

    [LibraryImport(ObjCLibrary, EntryPoint = "objc_msgSend")]
    public static partial void objc_msgSend(nint receiver, Selector selector, nint a, nint b, nint c, nint d, MTLSize e, nint f, nint g, nint h, MTLOrigin i);

    [LibraryImport(ObjCLibrary, EntryPoint = "objc_msgSend")]
    public static partial void objc_msgSend(nint receiver, Selector selector, nint a, nint b, nint c, MTLOrigin d, MTLSize e, nint f, nint g, nint h, MTLOrigin i);

    // ═══════════════════════════════════════════════════════════════════
    // void returns — float/double args
    // ═══════════════════════════════════════════════════════════════════

    [LibraryImport(ObjCLibrary, EntryPoint = "objc_msgSend")]
    public static partial void objc_msgSend(nint receiver, Selector selector, float a);

    [LibraryImport(ObjCLibrary, EntryPoint = "objc_msgSend")]
    public static partial void objc_msgSend(nint receiver, Selector selector, double a);

    // ═══════════════════════════════════════════════════════════════════
    // nint returns — uniform nint args
    // ═══════════════════════════════════════════════════════════════════

    [LibraryImport(ObjCLibrary, EntryPoint = "objc_msgSend")]
    public static partial nint intptr_objc_msgSend(nint receiver, Selector selector);

    [LibraryImport(ObjCLibrary, EntryPoint = "objc_msgSend")]
    public static partial nint intptr_objc_msgSend(nint receiver, Selector selector, nint a);

    [LibraryImport(ObjCLibrary, EntryPoint = "objc_msgSend")]
    public static partial nint intptr_objc_msgSend(nint receiver, Selector selector, nint a, nint b);

    [LibraryImport(ObjCLibrary, EntryPoint = "objc_msgSend")]
    public static partial nint intptr_objc_msgSend(nint receiver, Selector selector, nint a, nint b, nint c);

    [LibraryImport(ObjCLibrary, EntryPoint = "objc_msgSend")]
    public static partial nint intptr_objc_msgSend(nint receiver, Selector selector, nint a, nint b, nint c, nint d);

    [LibraryImport(ObjCLibrary, EntryPoint = "objc_msgSend")]
    public static partial nint intptr_objc_msgSend(nint receiver, Selector selector, nint a, nint b, nint c, nint d, nint e);

    [LibraryImport(ObjCLibrary, EntryPoint = "objc_msgSend")]
    public static partial nint intptr_objc_msgSend(nint receiver, Selector selector, nint a, nint b, nint c, nint d, nint e, nint f);

    // ═══════════════════════════════════════════════════════════════════
    // nint returns — with out NSError
    // ═══════════════════════════════════════════════════════════════════

    [LibraryImport(ObjCLibrary, EntryPoint = "objc_msgSend")]
    public static partial nint intptr_objc_msgSend(nint receiver, Selector selector, out nint error);

    [LibraryImport(ObjCLibrary, EntryPoint = "objc_msgSend")]
    public static partial nint intptr_objc_msgSend(nint receiver, Selector selector, nint a, out nint error);

    [LibraryImport(ObjCLibrary, EntryPoint = "objc_msgSend")]
    public static partial nint intptr_objc_msgSend(nint receiver, Selector selector, nint a, nint b, out nint error);

    [LibraryImport(ObjCLibrary, EntryPoint = "objc_msgSend")]
    public static partial nint intptr_objc_msgSend(nint receiver, Selector selector, nint a, nint b, nint c, out nint error);

    [LibraryImport(ObjCLibrary, EntryPoint = "objc_msgSend")]
    public static partial nint intptr_objc_msgSend(nint receiver, Selector selector, nint a, nint b, nint c, nint d, out nint error);

    // ═══════════════════════════════════════════════════════════════════
    // Typed returns (no args) — for property getters
    // ═══════════════════════════════════════════════════════════════════

    [LibraryImport(ObjCLibrary, EntryPoint = "objc_msgSend")]
    public static partial Bool8 bool8_objc_msgSend(nint receiver, Selector selector);

    [LibraryImport(ObjCLibrary, EntryPoint = "objc_msgSend")]
    public static partial uint uint_objc_msgSend(nint receiver, Selector selector);

    [LibraryImport(ObjCLibrary, EntryPoint = "objc_msgSend")]
    public static partial ulong ulong_objc_msgSend(nint receiver, Selector selector);

    [LibraryImport(ObjCLibrary, EntryPoint = "objc_msgSend")]
    public static partial float float_objc_msgSend(nint receiver, Selector selector);

    [LibraryImport(ObjCLibrary, EntryPoint = "objc_msgSend")]
    public static partial double double_objc_msgSend(nint receiver, Selector selector);

    [LibraryImport(ObjCLibrary, EntryPoint = "objc_msgSend")]
    public static partial nuint nuint_objc_msgSend(nint receiver, Selector selector);

    // ═══════════════════════════════════════════════════════════════════
    // ObjC runtime functions
    // ═══════════════════════════════════════════════════════════════════

    [LibraryImport(ObjCLibrary, EntryPoint = "objc_getClass")]
    public static partial nint objc_getClass(byte* name);

    [LibraryImport(ObjCLibrary, EntryPoint = "sel_registerName")]
    public static partial Selector sel_registerName(byte* name);

    // ═══════════════════════════════════════════════════════════════════
    // Helpers
    // ═══════════════════════════════════════════════════════════════════

    public static nint Retain(nint obj)
        => intptr_objc_msgSend(obj, Selector.Register("retain"));

    public static void Release(nint obj)
        => objc_msgSend(obj, Selector.Register("release"));

    public static nint GetClass(string name)
    {
        fixed (byte* utf8 = System.Text.Encoding.UTF8.GetBytes(name + '\0'))
        {
            return objc_getClass(utf8);
        }
    }
}
