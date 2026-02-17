using System.Runtime.InteropServices;

namespace Metal.NET;

/// <summary>
/// P/Invoke bindings for the Objective-C runtime (libobjc.dylib).
/// All Metal API calls go through objc_msgSend.
///
/// Overloads use nint for all register-sized arguments. The Source Generator
/// casts enum/uint/nuint/ObjC-wrapper values to nint before calling.
/// Separate overloads exist for value structs, out NSError, and typed returns.
/// </summary>
public static unsafe class ObjectiveCRuntime
{
    private const string ObjCLibrary = "/usr/lib/libobjc.A.dylib";

    // ═══════════════════════════════════════════════════════════════════
    // void returns — uniform nint args (0..12 args)
    // ═══════════════════════════════════════════════════════════════════

    [DllImport(ObjCLibrary, EntryPoint = "objc_msgSend")]
    public static extern void objc_msgSend(nint receiver, Selector selector);

    [DllImport(ObjCLibrary, EntryPoint = "objc_msgSend")]
    public static extern void objc_msgSend(nint receiver, Selector selector, nint a);

    [DllImport(ObjCLibrary, EntryPoint = "objc_msgSend")]
    public static extern void objc_msgSend(nint receiver, Selector selector, nint a, nint b);

    [DllImport(ObjCLibrary, EntryPoint = "objc_msgSend")]
    public static extern void objc_msgSend(nint receiver, Selector selector, nint a, nint b, nint c);

    [DllImport(ObjCLibrary, EntryPoint = "objc_msgSend")]
    public static extern void objc_msgSend(nint receiver, Selector selector, nint a, nint b, nint c, nint d);

    [DllImport(ObjCLibrary, EntryPoint = "objc_msgSend")]
    public static extern void objc_msgSend(nint receiver, Selector selector, nint a, nint b, nint c, nint d, nint e);

    [DllImport(ObjCLibrary, EntryPoint = "objc_msgSend")]
    public static extern void objc_msgSend(nint receiver, Selector selector, nint a, nint b, nint c, nint d, nint e, nint f);

    [DllImport(ObjCLibrary, EntryPoint = "objc_msgSend")]
    public static extern void objc_msgSend(nint receiver, Selector selector, nint a, nint b, nint c, nint d, nint e, nint f, nint g);

    [DllImport(ObjCLibrary, EntryPoint = "objc_msgSend")]
    public static extern void objc_msgSend(nint receiver, Selector selector, nint a, nint b, nint c, nint d, nint e, nint f, nint g, nint h);

    [DllImport(ObjCLibrary, EntryPoint = "objc_msgSend")]
    public static extern void objc_msgSend(nint receiver, Selector selector, nint a, nint b, nint c, nint d, nint e, nint f, nint g, nint h, nint i);

    [DllImport(ObjCLibrary, EntryPoint = "objc_msgSend")]
    public static extern void objc_msgSend(nint receiver, Selector selector, nint a, nint b, nint c, nint d, nint e, nint f, nint g, nint h, nint i, nint j);

    [DllImport(ObjCLibrary, EntryPoint = "objc_msgSend")]
    public static extern void objc_msgSend(nint receiver, Selector selector, nint a, nint b, nint c, nint d, nint e, nint f, nint g, nint h, nint i, nint j, nint k);

    [DllImport(ObjCLibrary, EntryPoint = "objc_msgSend")]
    public static extern void objc_msgSend(nint receiver, Selector selector, nint a, nint b, nint c, nint d, nint e, nint f, nint g, nint h, nint i, nint j, nint k, nint l);

    // ═══════════════════════════════════════════════════════════════════
    // void returns — value struct args (these cannot be cast to nint)
    // ═══════════════════════════════════════════════════════════════════

    [DllImport(ObjCLibrary, EntryPoint = "objc_msgSend")]
    public static extern void objc_msgSend(nint receiver, Selector selector, MTLClearColor a);

    [DllImport(ObjCLibrary, EntryPoint = "objc_msgSend")]
    public static extern void objc_msgSend(nint receiver, Selector selector, MTLSize a);

    [DllImport(ObjCLibrary, EntryPoint = "objc_msgSend")]
    public static extern void objc_msgSend(nint receiver, Selector selector, MTLOrigin a, MTLSize b);

    [DllImport(ObjCLibrary, EntryPoint = "objc_msgSend")]
    public static extern void objc_msgSend(nint receiver, Selector selector, MTLSize a, MTLSize b);

    [DllImport(ObjCLibrary, EntryPoint = "objc_msgSend")]
    public static extern void objc_msgSend(nint receiver, Selector selector, MTLRegion a, nint b, nint c, nint d, nint e, nint f);

    [DllImport(ObjCLibrary, EntryPoint = "objc_msgSend")]
    public static extern void objc_msgSend(nint receiver, Selector selector, nint a, nint b, nint c, nint d, MTLSize e, nint f, nint g, nint h, MTLOrigin i);

    [DllImport(ObjCLibrary, EntryPoint = "objc_msgSend")]
    public static extern void objc_msgSend(nint receiver, Selector selector, nint a, nint b, nint c, MTLOrigin d, MTLSize e, nint f, nint g, nint h, MTLOrigin i);

    // ═══════════════════════════════════════════════════════════════════
    // void returns — float/double args
    // ═══════════════════════════════════════════════════════════════════

    [DllImport(ObjCLibrary, EntryPoint = "objc_msgSend")]
    public static extern void objc_msgSend(nint receiver, Selector selector, float a);

    [DllImport(ObjCLibrary, EntryPoint = "objc_msgSend")]
    public static extern void objc_msgSend(nint receiver, Selector selector, double a);

    // ═══════════════════════════════════════════════════════════════════
    // nint returns — uniform nint args
    // ═══════════════════════════════════════════════════════════════════

    [DllImport(ObjCLibrary, EntryPoint = "objc_msgSend")]
    public static extern nint intptr_objc_msgSend(nint receiver, Selector selector);

    [DllImport(ObjCLibrary, EntryPoint = "objc_msgSend")]
    public static extern nint intptr_objc_msgSend(nint receiver, Selector selector, nint a);

    [DllImport(ObjCLibrary, EntryPoint = "objc_msgSend")]
    public static extern nint intptr_objc_msgSend(nint receiver, Selector selector, nint a, nint b);

    [DllImport(ObjCLibrary, EntryPoint = "objc_msgSend")]
    public static extern nint intptr_objc_msgSend(nint receiver, Selector selector, nint a, nint b, nint c);

    [DllImport(ObjCLibrary, EntryPoint = "objc_msgSend")]
    public static extern nint intptr_objc_msgSend(nint receiver, Selector selector, nint a, nint b, nint c, nint d);

    [DllImport(ObjCLibrary, EntryPoint = "objc_msgSend")]
    public static extern nint intptr_objc_msgSend(nint receiver, Selector selector, nint a, nint b, nint c, nint d, nint e);

    [DllImport(ObjCLibrary, EntryPoint = "objc_msgSend")]
    public static extern nint intptr_objc_msgSend(nint receiver, Selector selector, nint a, nint b, nint c, nint d, nint e, nint f);

    // ═══════════════════════════════════════════════════════════════════
    // nint returns — with out NSError
    // ═══════════════════════════════════════════════════════════════════

    [DllImport(ObjCLibrary, EntryPoint = "objc_msgSend")]
    public static extern nint intptr_objc_msgSend(nint receiver, Selector selector, out NSError error);

    [DllImport(ObjCLibrary, EntryPoint = "objc_msgSend")]
    public static extern nint intptr_objc_msgSend(nint receiver, Selector selector, nint a, out NSError error);

    [DllImport(ObjCLibrary, EntryPoint = "objc_msgSend")]
    public static extern nint intptr_objc_msgSend(nint receiver, Selector selector, nint a, nint b, out NSError error);

    [DllImport(ObjCLibrary, EntryPoint = "objc_msgSend")]
    public static extern nint intptr_objc_msgSend(nint receiver, Selector selector, nint a, nint b, nint c, out NSError error);

    [DllImport(ObjCLibrary, EntryPoint = "objc_msgSend")]
    public static extern nint intptr_objc_msgSend(nint receiver, Selector selector, nint a, nint b, nint c, nint d, out NSError error);

    // ═══════════════════════════════════════════════════════════════════
    // Typed returns (no args) — for property getters
    // ═══════════════════════════════════════════════════════════════════

    [DllImport(ObjCLibrary, EntryPoint = "objc_msgSend")]
    public static extern Bool8 bool8_objc_msgSend(nint receiver, Selector selector);

    [DllImport(ObjCLibrary, EntryPoint = "objc_msgSend")]
    public static extern uint uint_objc_msgSend(nint receiver, Selector selector);

    [DllImport(ObjCLibrary, EntryPoint = "objc_msgSend")]
    public static extern ulong ulong_objc_msgSend(nint receiver, Selector selector);

    [DllImport(ObjCLibrary, EntryPoint = "objc_msgSend")]
    public static extern float float_objc_msgSend(nint receiver, Selector selector);

    [DllImport(ObjCLibrary, EntryPoint = "objc_msgSend")]
    public static extern double double_objc_msgSend(nint receiver, Selector selector);

    [DllImport(ObjCLibrary, EntryPoint = "objc_msgSend")]
    public static extern nuint nuint_objc_msgSend(nint receiver, Selector selector);

    // ═══════════════════════════════════════════════════════════════════
    // ObjC runtime functions
    // ═══════════════════════════════════════════════════════════════════

    [DllImport(ObjCLibrary)]
    public static extern nint objc_getClass(byte* name);

    [DllImport(ObjCLibrary)]
    public static extern Selector sel_registerName(byte* name);

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
