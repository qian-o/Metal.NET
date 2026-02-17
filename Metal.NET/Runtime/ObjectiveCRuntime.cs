using System.Runtime.InteropServices;

namespace Metal.NET;

/// <summary>
/// P/Invoke bindings for the Objective-C runtime (libobjc.dylib).
/// All Metal API calls go through objc_msgSend.
///
/// Overloads use IntPtr for all register-sized arguments. The Source Generator
/// casts enum/uint/UIntPtr/ObjC-wrapper values to IntPtr before calling.
/// Separate overloads exist for value structs, out NSError, and typed returns.
/// </summary>
public static unsafe class ObjectiveCRuntime
{
    private const string ObjCLibrary = "/usr/lib/libobjc.A.dylib";

    // ═══════════════════════════════════════════════════════════════════
    // void returns — uniform IntPtr args (0..10 args)
    // ═══════════════════════════════════════════════════════════════════

    [DllImport(ObjCLibrary, EntryPoint = "objc_msgSend")]
    public static extern void objc_msgSend(IntPtr receiver, Selector selector);

    [DllImport(ObjCLibrary, EntryPoint = "objc_msgSend")]
    public static extern void objc_msgSend(IntPtr receiver, Selector selector, IntPtr a);

    [DllImport(ObjCLibrary, EntryPoint = "objc_msgSend")]
    public static extern void objc_msgSend(IntPtr receiver, Selector selector, IntPtr a, IntPtr b);

    [DllImport(ObjCLibrary, EntryPoint = "objc_msgSend")]
    public static extern void objc_msgSend(IntPtr receiver, Selector selector, IntPtr a, IntPtr b, IntPtr c);

    [DllImport(ObjCLibrary, EntryPoint = "objc_msgSend")]
    public static extern void objc_msgSend(IntPtr receiver, Selector selector, IntPtr a, IntPtr b, IntPtr c, IntPtr d);

    [DllImport(ObjCLibrary, EntryPoint = "objc_msgSend")]
    public static extern void objc_msgSend(IntPtr receiver, Selector selector, IntPtr a, IntPtr b, IntPtr c, IntPtr d, IntPtr e);

    [DllImport(ObjCLibrary, EntryPoint = "objc_msgSend")]
    public static extern void objc_msgSend(IntPtr receiver, Selector selector, IntPtr a, IntPtr b, IntPtr c, IntPtr d, IntPtr e, IntPtr f);

    [DllImport(ObjCLibrary, EntryPoint = "objc_msgSend")]
    public static extern void objc_msgSend(IntPtr receiver, Selector selector, IntPtr a, IntPtr b, IntPtr c, IntPtr d, IntPtr e, IntPtr f, IntPtr g);

    [DllImport(ObjCLibrary, EntryPoint = "objc_msgSend")]
    public static extern void objc_msgSend(IntPtr receiver, Selector selector, IntPtr a, IntPtr b, IntPtr c, IntPtr d, IntPtr e, IntPtr f, IntPtr g, IntPtr h);

    [DllImport(ObjCLibrary, EntryPoint = "objc_msgSend")]
    public static extern void objc_msgSend(IntPtr receiver, Selector selector, IntPtr a, IntPtr b, IntPtr c, IntPtr d, IntPtr e, IntPtr f, IntPtr g, IntPtr h, IntPtr i);

    [DllImport(ObjCLibrary, EntryPoint = "objc_msgSend")]
    public static extern void objc_msgSend(IntPtr receiver, Selector selector, IntPtr a, IntPtr b, IntPtr c, IntPtr d, IntPtr e, IntPtr f, IntPtr g, IntPtr h, IntPtr i, IntPtr j);

    [DllImport(ObjCLibrary, EntryPoint = "objc_msgSend")]
    public static extern void objc_msgSend(IntPtr receiver, Selector selector, IntPtr a, IntPtr b, IntPtr c, IntPtr d, IntPtr e, IntPtr f, IntPtr g, IntPtr h, IntPtr i, IntPtr j, IntPtr k);

    [DllImport(ObjCLibrary, EntryPoint = "objc_msgSend")]
    public static extern void objc_msgSend(IntPtr receiver, Selector selector, IntPtr a, IntPtr b, IntPtr c, IntPtr d, IntPtr e, IntPtr f, IntPtr g, IntPtr h, IntPtr i, IntPtr j, IntPtr k, IntPtr l);

    // ═══════════════════════════════════════════════════════════════════
    // void returns — value struct args (these cannot be cast to IntPtr)
    // ═══════════════════════════════════════════════════════════════════

    [DllImport(ObjCLibrary, EntryPoint = "objc_msgSend")]
    public static extern void objc_msgSend(IntPtr receiver, Selector selector, MTLClearColor a);

    [DllImport(ObjCLibrary, EntryPoint = "objc_msgSend")]
    public static extern void objc_msgSend(IntPtr receiver, Selector selector, MTLSize a);

    [DllImport(ObjCLibrary, EntryPoint = "objc_msgSend")]
    public static extern void objc_msgSend(IntPtr receiver, Selector selector, MTLOrigin a, MTLSize b);

    [DllImport(ObjCLibrary, EntryPoint = "objc_msgSend")]
    public static extern void objc_msgSend(IntPtr receiver, Selector selector, MTLSize a, MTLSize b);

    [DllImport(ObjCLibrary, EntryPoint = "objc_msgSend")]
    public static extern void objc_msgSend(IntPtr receiver, Selector selector, MTLRegion a, IntPtr b, IntPtr c, IntPtr d, IntPtr e, IntPtr f);

    [DllImport(ObjCLibrary, EntryPoint = "objc_msgSend")]
    public static extern void objc_msgSend(IntPtr receiver, Selector selector, IntPtr a, IntPtr b, IntPtr c, IntPtr d, MTLSize e, IntPtr f, IntPtr g, IntPtr h, MTLOrigin i);

    [DllImport(ObjCLibrary, EntryPoint = "objc_msgSend")]
    public static extern void objc_msgSend(IntPtr receiver, Selector selector, IntPtr a, IntPtr b, IntPtr c, MTLOrigin d, MTLSize e, IntPtr f, IntPtr g, IntPtr h, MTLOrigin i);

    // ═══════════════════════════════════════════════════════════════════
    // void returns — float/double args
    // ═══════════════════════════════════════════════════════════════════

    [DllImport(ObjCLibrary, EntryPoint = "objc_msgSend")]
    public static extern void objc_msgSend(IntPtr receiver, Selector selector, float a);

    [DllImport(ObjCLibrary, EntryPoint = "objc_msgSend")]
    public static extern void objc_msgSend(IntPtr receiver, Selector selector, double a);

    // ═══════════════════════════════════════════════════════════════════
    // IntPtr returns — uniform IntPtr args
    // ═══════════════════════════════════════════════════════════════════

    [DllImport(ObjCLibrary, EntryPoint = "objc_msgSend")]
    public static extern IntPtr intptr_objc_msgSend(IntPtr receiver, Selector selector);

    [DllImport(ObjCLibrary, EntryPoint = "objc_msgSend")]
    public static extern IntPtr intptr_objc_msgSend(IntPtr receiver, Selector selector, IntPtr a);

    [DllImport(ObjCLibrary, EntryPoint = "objc_msgSend")]
    public static extern IntPtr intptr_objc_msgSend(IntPtr receiver, Selector selector, IntPtr a, IntPtr b);

    [DllImport(ObjCLibrary, EntryPoint = "objc_msgSend")]
    public static extern IntPtr intptr_objc_msgSend(IntPtr receiver, Selector selector, IntPtr a, IntPtr b, IntPtr c);

    [DllImport(ObjCLibrary, EntryPoint = "objc_msgSend")]
    public static extern IntPtr intptr_objc_msgSend(IntPtr receiver, Selector selector, IntPtr a, IntPtr b, IntPtr c, IntPtr d);

    [DllImport(ObjCLibrary, EntryPoint = "objc_msgSend")]
    public static extern IntPtr intptr_objc_msgSend(IntPtr receiver, Selector selector, IntPtr a, IntPtr b, IntPtr c, IntPtr d, IntPtr e);

    [DllImport(ObjCLibrary, EntryPoint = "objc_msgSend")]
    public static extern IntPtr intptr_objc_msgSend(IntPtr receiver, Selector selector, IntPtr a, IntPtr b, IntPtr c, IntPtr d, IntPtr e, IntPtr f);

    // ═══════════════════════════════════════════════════════════════════
    // IntPtr returns — with out NSError
    // ═══════════════════════════════════════════════════════════════════

    [DllImport(ObjCLibrary, EntryPoint = "objc_msgSend")]
    public static extern IntPtr intptr_objc_msgSend(IntPtr receiver, Selector selector, out NSError error);

    [DllImport(ObjCLibrary, EntryPoint = "objc_msgSend")]
    public static extern IntPtr intptr_objc_msgSend(IntPtr receiver, Selector selector, IntPtr a, out NSError error);

    [DllImport(ObjCLibrary, EntryPoint = "objc_msgSend")]
    public static extern IntPtr intptr_objc_msgSend(IntPtr receiver, Selector selector, IntPtr a, IntPtr b, out NSError error);

    [DllImport(ObjCLibrary, EntryPoint = "objc_msgSend")]
    public static extern IntPtr intptr_objc_msgSend(IntPtr receiver, Selector selector, IntPtr a, IntPtr b, IntPtr c, out NSError error);

    [DllImport(ObjCLibrary, EntryPoint = "objc_msgSend")]
    public static extern IntPtr intptr_objc_msgSend(IntPtr receiver, Selector selector, IntPtr a, IntPtr b, IntPtr c, IntPtr d, out NSError error);

    // ═══════════════════════════════════════════════════════════════════
    // Typed returns (no args) — for property getters
    // ═══════════════════════════════════════════════════════════════════

    [DllImport(ObjCLibrary, EntryPoint = "objc_msgSend")]
    public static extern Bool8 bool8_objc_msgSend(IntPtr receiver, Selector selector);

    [DllImport(ObjCLibrary, EntryPoint = "objc_msgSend")]
    public static extern uint uint_objc_msgSend(IntPtr receiver, Selector selector);

    [DllImport(ObjCLibrary, EntryPoint = "objc_msgSend")]
    public static extern ulong ulong_objc_msgSend(IntPtr receiver, Selector selector);

    [DllImport(ObjCLibrary, EntryPoint = "objc_msgSend")]
    public static extern float float_objc_msgSend(IntPtr receiver, Selector selector);

    [DllImport(ObjCLibrary, EntryPoint = "objc_msgSend")]
    public static extern double double_objc_msgSend(IntPtr receiver, Selector selector);

    [DllImport(ObjCLibrary, EntryPoint = "objc_msgSend")]
    public static extern UIntPtr UIntPtr_objc_msgSend(IntPtr receiver, Selector selector);

    // ═══════════════════════════════════════════════════════════════════
    // ObjC runtime functions
    // ═══════════════════════════════════════════════════════════════════

    [DllImport(ObjCLibrary)]
    public static extern IntPtr objc_getClass(byte* name);

    [DllImport(ObjCLibrary)]
    public static extern Selector sel_registerName(byte* name);

    // ═══════════════════════════════════════════════════════════════════
    // Helpers
    // ═══════════════════════════════════════════════════════════════════

    public static IntPtr Retain(IntPtr obj)
        => intptr_objc_msgSend(obj, Selector.Register("retain"));

    public static void Release(IntPtr obj)
        => objc_msgSend(obj, Selector.Register("release"));

    public static IntPtr GetClass(string name)
    {
        fixed (byte* utf8 = System.Text.Encoding.UTF8.GetBytes(name + '\0'))
        {
            return objc_getClass(utf8);
        }
    }
}
