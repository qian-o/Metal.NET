using System.Runtime.InteropServices;

namespace Metal.NET;

public static partial class ObjectiveCRuntime
{
    static ObjectiveCRuntime()
    {
        string[] frameworks =
        [
            "CoreGraphics",
            "QuartzCore",
            "AppKit",
            "Metal",
            "MetalFX",
            "MetalKit"
        ];

        foreach (string framework in frameworks)
        {
            NativeLibrary.TryLoad(framework, out _);
        }
    }

    #region Class and Selector Lookups
    [LibraryImport("/usr/lib/libobjc.A.dylib", EntryPoint = "objc_getClass", StringMarshalling = StringMarshalling.Utf8)]
    public static partial nint GetClass(string name);

    [LibraryImport("/usr/lib/libobjc.A.dylib", EntryPoint = "sel_registerName", StringMarshalling = StringMarshalling.Utf8)]
    public static partial Selector RegisterName(string name);
    #endregion

    #region MsgSend

    [LibraryImport("/usr/lib/libobjc.A.dylib", EntryPoint = "objc_msgSend")]
    private static partial void _MsgSend(nint receiver, Selector selector);

    public static void MsgSend(nint receiver, Selector selector)
    {
        if (receiver is 0) return;
        _MsgSend(receiver, selector);
    }

    [LibraryImport("/usr/lib/libobjc.A.dylib", EntryPoint = "objc_msgSend")]
    private static partial void _MsgSend(nint receiver, Selector selector, out ulong a, out ulong b);

    public static void MsgSend(nint receiver, Selector selector, out ulong a, out ulong b)
    {
        if (receiver is 0) { a = default; b = default; return; }
        _MsgSend(receiver, selector, out a, out b);
    }

    [LibraryImport("/usr/lib/libobjc.A.dylib", EntryPoint = "objc_msgSend")]
    private static partial void _MsgSend(nint receiver, Selector selector, Bool8 a);

    public static void MsgSend(nint receiver, Selector selector, Bool8 a)
    {
        if (receiver is 0) return;
        _MsgSend(receiver, selector, a);
    }

    [LibraryImport("/usr/lib/libobjc.A.dylib", EntryPoint = "objc_msgSend")]
    private static partial void _MsgSend(nint receiver, Selector selector, CGSize a);

    public static void MsgSend(nint receiver, Selector selector, CGSize a)
    {
        if (receiver is 0) return;
        _MsgSend(receiver, selector, a);
    }

    [LibraryImport("/usr/lib/libobjc.A.dylib", EntryPoint = "objc_msgSend")]
    private static partial void _MsgSend(nint receiver, Selector selector, MTL4BufferRange a);

    public static void MsgSend(nint receiver, Selector selector, MTL4BufferRange a)
    {
        if (receiver is 0) return;
        _MsgSend(receiver, selector, a);
    }

    [LibraryImport("/usr/lib/libobjc.A.dylib", EntryPoint = "objc_msgSend")]
    private static partial void _MsgSend(nint receiver, Selector selector, MTLClearColor a);

    public static void MsgSend(nint receiver, Selector selector, MTLClearColor a)
    {
        if (receiver is 0) return;
        _MsgSend(receiver, selector, a);
    }

    [LibraryImport("/usr/lib/libobjc.A.dylib", EntryPoint = "objc_msgSend")]
    private static partial void _MsgSend(nint receiver, Selector selector, MTLRegion a);

    public static void MsgSend(nint receiver, Selector selector, MTLRegion a)
    {
        if (receiver is 0) return;
        _MsgSend(receiver, selector, a);
    }

    [LibraryImport("/usr/lib/libobjc.A.dylib", EntryPoint = "objc_msgSend")]
    private static partial void _MsgSend(nint receiver, Selector selector, MTLRegion a, MTLRegion b, MTLSize c, nuint d);

    public static void MsgSend(nint receiver, Selector selector, MTLRegion a, MTLRegion b, MTLSize c, nuint d)
    {
        if (receiver is 0) return;
        _MsgSend(receiver, selector, a, b, c, d);
    }

    [LibraryImport("/usr/lib/libobjc.A.dylib", EntryPoint = "objc_msgSend")]
    private static partial void _MsgSend(nint receiver, Selector selector, MTLRegion a, MTLRegion b, MTLSize c, nuint d, nuint e);

    public static void MsgSend(nint receiver, Selector selector, MTLRegion a, MTLRegion b, MTLSize c, nuint d, nuint e)
    {
        if (receiver is 0) return;
        _MsgSend(receiver, selector, a, b, c, d, e);
    }

    [LibraryImport("/usr/lib/libobjc.A.dylib", EntryPoint = "objc_msgSend")]
    private static partial void _MsgSend(nint receiver, Selector selector, MTLRegion a, nuint b, nint c, nuint d);

    public static void MsgSend(nint receiver, Selector selector, MTLRegion a, nuint b, nint c, nuint d)
    {
        if (receiver is 0) return;
        _MsgSend(receiver, selector, a, b, c, d);
    }

    [LibraryImport("/usr/lib/libobjc.A.dylib", EntryPoint = "objc_msgSend")]
    private static partial void _MsgSend(nint receiver, Selector selector, MTLRegion a, nuint b, nuint c, nint d, nuint e, nuint f);

    public static void MsgSend(nint receiver, Selector selector, MTLRegion a, nuint b, nuint c, nint d, nuint e, nuint f)
    {
        if (receiver is 0) return;
        _MsgSend(receiver, selector, a, b, c, d, e, f);
    }

    [LibraryImport("/usr/lib/libobjc.A.dylib", EntryPoint = "objc_msgSend")]
    private static partial void _MsgSend(nint receiver, Selector selector, MTLResourceID a, nuint b);

    public static void MsgSend(nint receiver, Selector selector, MTLResourceID a, nuint b)
    {
        if (receiver is 0) return;
        _MsgSend(receiver, selector, a, b);
    }

    [LibraryImport("/usr/lib/libobjc.A.dylib", EntryPoint = "objc_msgSend")]
    private static partial void _MsgSend(nint receiver, Selector selector, MTLSamplePosition a, nuint b);

    public static void MsgSend(nint receiver, Selector selector, MTLSamplePosition a, nuint b)
    {
        if (receiver is 0) return;
        _MsgSend(receiver, selector, a, b);
    }

    [LibraryImport("/usr/lib/libobjc.A.dylib", EntryPoint = "objc_msgSend")]
    private static partial void _MsgSend(nint receiver, Selector selector, MTLScissorRect a);

    public static void MsgSend(nint receiver, Selector selector, MTLScissorRect a)
    {
        if (receiver is 0) return;
        _MsgSend(receiver, selector, a);
    }

    [LibraryImport("/usr/lib/libobjc.A.dylib", EntryPoint = "objc_msgSend")]
    private static partial void _MsgSend(nint receiver, Selector selector, MTLScissorRect a, nuint b);

    public static void MsgSend(nint receiver, Selector selector, MTLScissorRect a, nuint b)
    {
        if (receiver is 0) return;
        _MsgSend(receiver, selector, a, b);
    }

    [LibraryImport("/usr/lib/libobjc.A.dylib", EntryPoint = "objc_msgSend")]
    private static partial void _MsgSend(nint receiver, Selector selector, MTLSize a);

    public static void MsgSend(nint receiver, Selector selector, MTLSize a)
    {
        if (receiver is 0) return;
        _MsgSend(receiver, selector, a);
    }

    [LibraryImport("/usr/lib/libobjc.A.dylib", EntryPoint = "objc_msgSend")]
    private static partial void _MsgSend(nint receiver, Selector selector, MTLSize a, MTLSize b);

    public static void MsgSend(nint receiver, Selector selector, MTLSize a, MTLSize b)
    {
        if (receiver is 0) return;
        _MsgSend(receiver, selector, a, b);
    }

    [LibraryImport("/usr/lib/libobjc.A.dylib", EntryPoint = "objc_msgSend")]
    private static partial void _MsgSend(nint receiver, Selector selector, MTLSize a, MTLSize b, MTLSize c);

    public static void MsgSend(nint receiver, Selector selector, MTLSize a, MTLSize b, MTLSize c)
    {
        if (receiver is 0) return;
        _MsgSend(receiver, selector, a, b, c);
    }

    [LibraryImport("/usr/lib/libobjc.A.dylib", EntryPoint = "objc_msgSend")]
    private static partial void _MsgSend(nint receiver, Selector selector, MTLTextureSwizzleChannels a);

    public static void MsgSend(nint receiver, Selector selector, MTLTextureSwizzleChannels a)
    {
        if (receiver is 0) return;
        _MsgSend(receiver, selector, a);
    }

    [LibraryImport("/usr/lib/libobjc.A.dylib", EntryPoint = "objc_msgSend")]
    private static partial void _MsgSend(nint receiver, Selector selector, MTLViewport a);

    public static void MsgSend(nint receiver, Selector selector, MTLViewport a)
    {
        if (receiver is 0) return;
        _MsgSend(receiver, selector, a);
    }

    [LibraryImport("/usr/lib/libobjc.A.dylib", EntryPoint = "objc_msgSend")]
    private static partial void _MsgSend(nint receiver, Selector selector, MTLViewport a, nuint b);

    public static void MsgSend(nint receiver, Selector selector, MTLViewport a, nuint b)
    {
        if (receiver is 0) return;
        _MsgSend(receiver, selector, a, b);
    }

    [LibraryImport("/usr/lib/libobjc.A.dylib", EntryPoint = "objc_msgSend")]
    private static partial void _MsgSend(nint receiver, Selector selector, NSRange a);

    public static void MsgSend(nint receiver, Selector selector, NSRange a)
    {
        if (receiver is 0) return;
        _MsgSend(receiver, selector, a);
    }

    [LibraryImport("/usr/lib/libobjc.A.dylib", EntryPoint = "objc_msgSend")]
    private static partial void _MsgSend(nint receiver, Selector selector, double a);

    public static void MsgSend(nint receiver, Selector selector, double a)
    {
        if (receiver is 0) return;
        _MsgSend(receiver, selector, a);
    }

    [LibraryImport("/usr/lib/libobjc.A.dylib", EntryPoint = "objc_msgSend")]
    private static partial void _MsgSend(nint receiver, Selector selector, float a);

    public static void MsgSend(nint receiver, Selector selector, float a)
    {
        if (receiver is 0) return;
        _MsgSend(receiver, selector, a);
    }

    [LibraryImport("/usr/lib/libobjc.A.dylib", EntryPoint = "objc_msgSend")]
    private static partial void _MsgSend(nint receiver, Selector selector, float a, float b);

    public static void MsgSend(nint receiver, Selector selector, float a, float b)
    {
        if (receiver is 0) return;
        _MsgSend(receiver, selector, a, b);
    }

    [LibraryImport("/usr/lib/libobjc.A.dylib", EntryPoint = "objc_msgSend")]
    private static partial void _MsgSend(nint receiver, Selector selector, float a, float b, float c);

    public static void MsgSend(nint receiver, Selector selector, float a, float b, float c)
    {
        if (receiver is 0) return;
        _MsgSend(receiver, selector, a, b, c);
    }

    [LibraryImport("/usr/lib/libobjc.A.dylib", EntryPoint = "objc_msgSend")]
    private static partial void _MsgSend(nint receiver, Selector selector, float a, float b, float c, float d);

    public static void MsgSend(nint receiver, Selector selector, float a, float b, float c, float d)
    {
        if (receiver is 0) return;
        _MsgSend(receiver, selector, a, b, c, d);
    }

    [LibraryImport("/usr/lib/libobjc.A.dylib", EntryPoint = "objc_msgSend")]
    private static partial void _MsgSend(nint receiver, Selector selector, nint a);

    public static void MsgSend(nint receiver, Selector selector, nint a)
    {
        if (receiver is 0) return;
        _MsgSend(receiver, selector, a);
    }

    [LibraryImport("/usr/lib/libobjc.A.dylib", EntryPoint = "objc_msgSend")]
    private static partial void _MsgSend(nint receiver, Selector selector, nint a, MTL4BufferRange b);

    public static void MsgSend(nint receiver, Selector selector, nint a, MTL4BufferRange b)
    {
        if (receiver is 0) return;
        _MsgSend(receiver, selector, a, b);
    }

    [LibraryImport("/usr/lib/libobjc.A.dylib", EntryPoint = "objc_msgSend")]
    private static partial void _MsgSend(nint receiver, Selector selector, nint a, MTLRegion b, nuint c, nuint d);

    public static void MsgSend(nint receiver, Selector selector, nint a, MTLRegion b, nuint c, nuint d)
    {
        if (receiver is 0) return;
        _MsgSend(receiver, selector, a, b, c, d);
    }

    [LibraryImport("/usr/lib/libobjc.A.dylib", EntryPoint = "objc_msgSend")]
    private static partial void _MsgSend(nint receiver, Selector selector, nint a, MTLRegion b, nuint c, nuint d, Bool8 e, nint f, nuint g);

    public static void MsgSend(nint receiver, Selector selector, nint a, MTLRegion b, nuint c, nuint d, Bool8 e, nint f, nuint g)
    {
        if (receiver is 0) return;
        _MsgSend(receiver, selector, a, b, c, d, e, f, g);
    }

    [LibraryImport("/usr/lib/libobjc.A.dylib", EntryPoint = "objc_msgSend")]
    private static partial void _MsgSend(nint receiver, Selector selector, nint a, NSRange b);

    public static void MsgSend(nint receiver, Selector selector, nint a, NSRange b)
    {
        if (receiver is 0) return;
        _MsgSend(receiver, selector, a, b);
    }

    [LibraryImport("/usr/lib/libobjc.A.dylib", EntryPoint = "objc_msgSend")]
    private static partial void _MsgSend(nint receiver, Selector selector, nint a, NSRange b, MTL4BufferRange c, nint d, nint e);

    public static void MsgSend(nint receiver, Selector selector, nint a, NSRange b, MTL4BufferRange c, nint d, nint e)
    {
        if (receiver is 0) return;
        _MsgSend(receiver, selector, a, b, c, d, e);
    }

    [LibraryImport("/usr/lib/libobjc.A.dylib", EntryPoint = "objc_msgSend")]
    private static partial void _MsgSend(nint receiver, Selector selector, nint a, NSRange b, byte c);

    public static void MsgSend(nint receiver, Selector selector, nint a, NSRange b, byte c)
    {
        if (receiver is 0) return;
        _MsgSend(receiver, selector, a, b, c);
    }

    [LibraryImport("/usr/lib/libobjc.A.dylib", EntryPoint = "objc_msgSend")]
    private static partial void _MsgSend(nint receiver, Selector selector, nint a, NSRange b, nint c, nuint d);

    public static void MsgSend(nint receiver, Selector selector, nint a, NSRange b, nint c, nuint d)
    {
        if (receiver is 0) return;
        _MsgSend(receiver, selector, a, b, c, d);
    }

    [LibraryImport("/usr/lib/libobjc.A.dylib", EntryPoint = "objc_msgSend")]
    private static partial void _MsgSend(nint receiver, Selector selector, nint a, double b);

    public static void MsgSend(nint receiver, Selector selector, nint a, double b)
    {
        if (receiver is 0) return;
        _MsgSend(receiver, selector, a, b);
    }

    [LibraryImport("/usr/lib/libobjc.A.dylib", EntryPoint = "objc_msgSend")]
    private static partial void _MsgSend(nint receiver, Selector selector, nint a, float b, float c, nuint d);

    public static void MsgSend(nint receiver, Selector selector, nint a, float b, float c, nuint d)
    {
        if (receiver is 0) return;
        _MsgSend(receiver, selector, a, b, c, d);
    }

    [LibraryImport("/usr/lib/libobjc.A.dylib", EntryPoint = "objc_msgSend")]
    private static partial void _MsgSend(nint receiver, Selector selector, nint a, nint b);

    public static void MsgSend(nint receiver, Selector selector, nint a, nint b)
    {
        if (receiver is 0) return;
        _MsgSend(receiver, selector, a, b);
    }

    [LibraryImport("/usr/lib/libobjc.A.dylib", EntryPoint = "objc_msgSend")]
    private static partial void _MsgSend(nint receiver, Selector selector, nint a, nint b, MTL4BufferRange c);

    public static void MsgSend(nint receiver, Selector selector, nint a, nint b, MTL4BufferRange c)
    {
        if (receiver is 0) return;
        _MsgSend(receiver, selector, a, b, c);
    }

    [LibraryImport("/usr/lib/libobjc.A.dylib", EntryPoint = "objc_msgSend")]
    private static partial void _MsgSend(nint receiver, Selector selector, nint a, nint b, MTL4CopySparseBufferMappingOperation c, nuint d);

    public static void MsgSend(nint receiver, Selector selector, nint a, nint b, MTL4CopySparseBufferMappingOperation c, nuint d)
    {
        if (receiver is 0) return;
        _MsgSend(receiver, selector, a, b, c, d);
    }

    [LibraryImport("/usr/lib/libobjc.A.dylib", EntryPoint = "objc_msgSend")]
    private static partial void _MsgSend(nint receiver, Selector selector, nint a, nint b, MTL4CopySparseTextureMappingOperation c, nuint d);

    public static void MsgSend(nint receiver, Selector selector, nint a, nint b, MTL4CopySparseTextureMappingOperation c, nuint d)
    {
        if (receiver is 0) return;
        _MsgSend(receiver, selector, a, b, c, d);
    }

    [LibraryImport("/usr/lib/libobjc.A.dylib", EntryPoint = "objc_msgSend")]
    private static partial void _MsgSend(nint receiver, Selector selector, nint a, nint b, MTL4UpdateSparseBufferMappingOperation c, nuint d);

    public static void MsgSend(nint receiver, Selector selector, nint a, nint b, MTL4UpdateSparseBufferMappingOperation c, nuint d)
    {
        if (receiver is 0) return;
        _MsgSend(receiver, selector, a, b, c, d);
    }

    [LibraryImport("/usr/lib/libobjc.A.dylib", EntryPoint = "objc_msgSend")]
    private static partial void _MsgSend(nint receiver, Selector selector, nint a, nint b, MTL4UpdateSparseTextureMappingOperation c, nuint d);

    public static void MsgSend(nint receiver, Selector selector, nint a, nint b, MTL4UpdateSparseTextureMappingOperation c, nuint d)
    {
        if (receiver is 0) return;
        _MsgSend(receiver, selector, a, b, c, d);
    }

    [LibraryImport("/usr/lib/libobjc.A.dylib", EntryPoint = "objc_msgSend")]
    private static partial void _MsgSend(nint receiver, Selector selector, nint a, nint b, nint c, MTL4BufferRange d);

    public static void MsgSend(nint receiver, Selector selector, nint a, nint b, nint c, MTL4BufferRange d)
    {
        if (receiver is 0) return;
        _MsgSend(receiver, selector, a, b, c, d);
    }

    [LibraryImport("/usr/lib/libobjc.A.dylib", EntryPoint = "objc_msgSend")]
    private static partial void _MsgSend(nint receiver, Selector selector, nint a, nint b, nint c, MTL4BufferRange d, nuint e);

    public static void MsgSend(nint receiver, Selector selector, nint a, nint b, nint c, MTL4BufferRange d, nuint e)
    {
        if (receiver is 0) return;
        _MsgSend(receiver, selector, a, b, c, d, e);
    }

    [LibraryImport("/usr/lib/libobjc.A.dylib", EntryPoint = "objc_msgSend")]
    private static partial void _MsgSend(nint receiver, Selector selector, nint a, nint b, nint c, nint d);

    public static void MsgSend(nint receiver, Selector selector, nint a, nint b, nint c, nint d)
    {
        if (receiver is 0) return;
        _MsgSend(receiver, selector, a, b, c, d);
    }

    [LibraryImport("/usr/lib/libobjc.A.dylib", EntryPoint = "objc_msgSend")]
    private static partial void _MsgSend(nint receiver, Selector selector, nint a, nint b, nint c, nint d, nint e, nint f);

    public static void MsgSend(nint receiver, Selector selector, nint a, nint b, nint c, nint d, nint e, nint f)
    {
        if (receiver is 0) return;
        _MsgSend(receiver, selector, a, b, c, d, e, f);
    }

    [LibraryImport("/usr/lib/libobjc.A.dylib", EntryPoint = "objc_msgSend")]
    private static partial void _MsgSend(nint receiver, Selector selector, nint a, nint b, nint c, nint d, nuint e);

    public static void MsgSend(nint receiver, Selector selector, nint a, nint b, nint c, nint d, nuint e)
    {
        if (receiver is 0) return;
        _MsgSend(receiver, selector, a, b, c, d, e);
    }

    [LibraryImport("/usr/lib/libobjc.A.dylib", EntryPoint = "objc_msgSend")]
    private static partial void _MsgSend(nint receiver, Selector selector, nint a, nint b, nint c, nint d, nuint e, nuint f);

    public static void MsgSend(nint receiver, Selector selector, nint a, nint b, nint c, nint d, nuint e, nuint f)
    {
        if (receiver is 0) return;
        _MsgSend(receiver, selector, a, b, c, d, e, f);
    }

    [LibraryImport("/usr/lib/libobjc.A.dylib", EntryPoint = "objc_msgSend")]
    private static partial void _MsgSend(nint receiver, Selector selector, nint a, nint b, nint c, nuint d);

    public static void MsgSend(nint receiver, Selector selector, nint a, nint b, nint c, nuint d)
    {
        if (receiver is 0) return;
        _MsgSend(receiver, selector, a, b, c, d);
    }

    [LibraryImport("/usr/lib/libobjc.A.dylib", EntryPoint = "objc_msgSend")]
    private static partial void _MsgSend(nint receiver, Selector selector, nint a, nint b, nuint c);

    public static void MsgSend(nint receiver, Selector selector, nint a, nint b, nuint c)
    {
        if (receiver is 0) return;
        _MsgSend(receiver, selector, a, b, c);
    }

    [LibraryImport("/usr/lib/libobjc.A.dylib", EntryPoint = "objc_msgSend")]
    private static partial void _MsgSend(nint receiver, Selector selector, nint a, nint b, nuint c, nuint d);

    public static void MsgSend(nint receiver, Selector selector, nint a, nint b, nuint c, nuint d)
    {
        if (receiver is 0) return;
        _MsgSend(receiver, selector, a, b, c, d);
    }

    [LibraryImport("/usr/lib/libobjc.A.dylib", EntryPoint = "objc_msgSend")]
    private static partial void _MsgSend(nint receiver, Selector selector, nint a, nuint b);

    public static void MsgSend(nint receiver, Selector selector, nint a, nuint b)
    {
        if (receiver is 0) return;
        _MsgSend(receiver, selector, a, b);
    }

    [LibraryImport("/usr/lib/libobjc.A.dylib", EntryPoint = "objc_msgSend")]
    private static partial void _MsgSend(nint receiver, Selector selector, nint a, nuint b, Bool8 c);

    public static void MsgSend(nint receiver, Selector selector, nint a, nuint b, Bool8 c)
    {
        if (receiver is 0) return;
        _MsgSend(receiver, selector, a, b, c);
    }

    [LibraryImport("/usr/lib/libobjc.A.dylib", EntryPoint = "objc_msgSend")]
    private static partial void _MsgSend(nint receiver, Selector selector, nint a, nuint b, MTLRegion c, nint d, nint e, nuint f);

    public static void MsgSend(nint receiver, Selector selector, nint a, nuint b, MTLRegion c, nint d, nint e, nuint f)
    {
        if (receiver is 0) return;
        _MsgSend(receiver, selector, a, b, c, d, e, f);
    }

    [LibraryImport("/usr/lib/libobjc.A.dylib", EntryPoint = "objc_msgSend")]
    private static partial void _MsgSend(nint receiver, Selector selector, nint a, nuint b, MTLRegion c, nuint d);

    public static void MsgSend(nint receiver, Selector selector, nint a, nuint b, MTLRegion c, nuint d)
    {
        if (receiver is 0) return;
        _MsgSend(receiver, selector, a, b, c, d);
    }

    [LibraryImport("/usr/lib/libobjc.A.dylib", EntryPoint = "objc_msgSend")]
    private static partial void _MsgSend(nint receiver, Selector selector, nint a, nuint b, MTLRegion c, nuint d, nuint e);

    public static void MsgSend(nint receiver, Selector selector, nint a, nuint b, MTLRegion c, nuint d, nuint e)
    {
        if (receiver is 0) return;
        _MsgSend(receiver, selector, a, b, c, d, e);
    }

    [LibraryImport("/usr/lib/libobjc.A.dylib", EntryPoint = "objc_msgSend")]
    private static partial void _MsgSend(nint receiver, Selector selector, nint a, nuint b, MTLSize c);

    public static void MsgSend(nint receiver, Selector selector, nint a, nuint b, MTLSize c)
    {
        if (receiver is 0) return;
        _MsgSend(receiver, selector, a, b, c);
    }

    [LibraryImport("/usr/lib/libobjc.A.dylib", EntryPoint = "objc_msgSend")]
    private static partial void _MsgSend(nint receiver, Selector selector, nint a, nuint b, MTLSize c, MTLSize d);

    public static void MsgSend(nint receiver, Selector selector, nint a, nuint b, MTLSize c, MTLSize d)
    {
        if (receiver is 0) return;
        _MsgSend(receiver, selector, a, b, c, d);
    }

    [LibraryImport("/usr/lib/libobjc.A.dylib", EntryPoint = "objc_msgSend")]
    private static partial void _MsgSend(nint receiver, Selector selector, nint a, nuint b, NSRange c);

    public static void MsgSend(nint receiver, Selector selector, nint a, nuint b, NSRange c)
    {
        if (receiver is 0) return;
        _MsgSend(receiver, selector, a, b, c);
    }

    [LibraryImport("/usr/lib/libobjc.A.dylib", EntryPoint = "objc_msgSend")]
    private static partial void _MsgSend(nint receiver, Selector selector, nint a, nuint b, nint c);

    public static void MsgSend(nint receiver, Selector selector, nint a, nuint b, nint c)
    {
        if (receiver is 0) return;
        _MsgSend(receiver, selector, a, b, c);
    }

    [LibraryImport("/usr/lib/libobjc.A.dylib", EntryPoint = "objc_msgSend")]
    private static partial void _MsgSend(nint receiver, Selector selector, nint a, nuint b, nint c, nuint d);

    public static void MsgSend(nint receiver, Selector selector, nint a, nuint b, nint c, nuint d)
    {
        if (receiver is 0) return;
        _MsgSend(receiver, selector, a, b, c, d);
    }

    [LibraryImport("/usr/lib/libobjc.A.dylib", EntryPoint = "objc_msgSend")]
    private static partial void _MsgSend(nint receiver, Selector selector, nint a, nuint b, nint c, nuint d, nuint e);

    public static void MsgSend(nint receiver, Selector selector, nint a, nuint b, nint c, nuint d, nuint e)
    {
        if (receiver is 0) return;
        _MsgSend(receiver, selector, a, b, c, d, e);
    }

    [LibraryImport("/usr/lib/libobjc.A.dylib", EntryPoint = "objc_msgSend")]
    private static partial void _MsgSend(nint receiver, Selector selector, nint a, nuint b, nuint c);

    public static void MsgSend(nint receiver, Selector selector, nint a, nuint b, nuint c)
    {
        if (receiver is 0) return;
        _MsgSend(receiver, selector, a, b, c);
    }

    [LibraryImport("/usr/lib/libobjc.A.dylib", EntryPoint = "objc_msgSend")]
    private static partial void _MsgSend(nint receiver, Selector selector, nint a, nuint b, nuint c, MTLOrigin d, MTLSize e, nint f, nuint g, nuint h, MTLOrigin i);

    public static void MsgSend(nint receiver, Selector selector, nint a, nuint b, nuint c, MTLOrigin d, MTLSize e, nint f, nuint g, nuint h, MTLOrigin i)
    {
        if (receiver is 0) return;
        _MsgSend(receiver, selector, a, b, c, d, e, f, g, h, i);
    }

    [LibraryImport("/usr/lib/libobjc.A.dylib", EntryPoint = "objc_msgSend")]
    private static partial void _MsgSend(nint receiver, Selector selector, nint a, nuint b, nuint c, MTLOrigin d, MTLSize e, nint f, nuint g, nuint h, nuint i);

    public static void MsgSend(nint receiver, Selector selector, nint a, nuint b, nuint c, MTLOrigin d, MTLSize e, nint f, nuint g, nuint h, nuint i)
    {
        if (receiver is 0) return;
        _MsgSend(receiver, selector, a, b, c, d, e, f, g, h, i);
    }

    [LibraryImport("/usr/lib/libobjc.A.dylib", EntryPoint = "objc_msgSend")]
    private static partial void _MsgSend(nint receiver, Selector selector, nint a, nuint b, nuint c, MTLOrigin d, MTLSize e, nint f, nuint g, nuint h, nuint i, nuint j);

    public static void MsgSend(nint receiver, Selector selector, nint a, nuint b, nuint c, MTLOrigin d, MTLSize e, nint f, nuint g, nuint h, nuint i, nuint j)
    {
        if (receiver is 0) return;
        _MsgSend(receiver, selector, a, b, c, d, e, f, g, h, i, j);
    }

    [LibraryImport("/usr/lib/libobjc.A.dylib", EntryPoint = "objc_msgSend")]
    private static partial void _MsgSend(nint receiver, Selector selector, nint a, nuint b, nuint c, MTLRegion d, nuint e, nuint f);

    public static void MsgSend(nint receiver, Selector selector, nint a, nuint b, nuint c, MTLRegion d, nuint e, nuint f)
    {
        if (receiver is 0) return;
        _MsgSend(receiver, selector, a, b, c, d, e, f);
    }

    [LibraryImport("/usr/lib/libobjc.A.dylib", EntryPoint = "objc_msgSend")]
    private static partial void _MsgSend(nint receiver, Selector selector, nint a, nuint b, nuint c, MTLSize d, nuint e, nuint f, MTLOrigin g, nint h, nuint i);

    public static void MsgSend(nint receiver, Selector selector, nint a, nuint b, nuint c, MTLSize d, nuint e, nuint f, MTLOrigin g, nint h, nuint i)
    {
        if (receiver is 0) return;
        _MsgSend(receiver, selector, a, b, c, d, e, f, g, h, i);
    }

    [LibraryImport("/usr/lib/libobjc.A.dylib", EntryPoint = "objc_msgSend")]
    private static partial void _MsgSend(nint receiver, Selector selector, nint a, nuint b, nuint c, nint d, nuint e);

    public static void MsgSend(nint receiver, Selector selector, nint a, nuint b, nuint c, nint d, nuint e)
    {
        if (receiver is 0) return;
        _MsgSend(receiver, selector, a, b, c, d, e);
    }

    [LibraryImport("/usr/lib/libobjc.A.dylib", EntryPoint = "objc_msgSend")]
    private static partial void _MsgSend(nint receiver, Selector selector, nint a, nuint b, nuint c, nint d, nuint e, nuint f, nuint g, nuint h);

    public static void MsgSend(nint receiver, Selector selector, nint a, nuint b, nuint c, nint d, nuint e, nuint f, nuint g, nuint h)
    {
        if (receiver is 0) return;
        _MsgSend(receiver, selector, a, b, c, d, e, f, g, h);
    }

    [LibraryImport("/usr/lib/libobjc.A.dylib", EntryPoint = "objc_msgSend")]
    private static partial void _MsgSend(nint receiver, Selector selector, nint a, nuint b, nuint c, nuint d);

    public static void MsgSend(nint receiver, Selector selector, nint a, nuint b, nuint c, nuint d)
    {
        if (receiver is 0) return;
        _MsgSend(receiver, selector, a, b, c, d);
    }

    [LibraryImport("/usr/lib/libobjc.A.dylib", EntryPoint = "objc_msgSend")]
    private static partial void _MsgSend(nint receiver, Selector selector, nint a, nuint b, nuint c, nuint d, MTLSize e, nint f, nuint g, nuint h, MTLOrigin i);

    public static void MsgSend(nint receiver, Selector selector, nint a, nuint b, nuint c, nuint d, MTLSize e, nint f, nuint g, nuint h, MTLOrigin i)
    {
        if (receiver is 0) return;
        _MsgSend(receiver, selector, a, b, c, d, e, f, g, h, i);
    }

    [LibraryImport("/usr/lib/libobjc.A.dylib", EntryPoint = "objc_msgSend")]
    private static partial void _MsgSend(nint receiver, Selector selector, nint a, nuint b, nuint c, nuint d, MTLSize e, nint f, nuint g, nuint h, MTLOrigin i, nuint j);

    public static void MsgSend(nint receiver, Selector selector, nint a, nuint b, nuint c, nuint d, MTLSize e, nint f, nuint g, nuint h, MTLOrigin i, nuint j)
    {
        if (receiver is 0) return;
        _MsgSend(receiver, selector, a, b, c, d, e, f, g, h, i, j);
    }

    [LibraryImport("/usr/lib/libobjc.A.dylib", EntryPoint = "objc_msgSend")]
    private static partial void _MsgSend(nint receiver, Selector selector, nuint a);

    public static void MsgSend(nint receiver, Selector selector, nuint a)
    {
        if (receiver is 0) return;
        _MsgSend(receiver, selector, a);
    }

    [LibraryImport("/usr/lib/libobjc.A.dylib", EntryPoint = "objc_msgSend")]
    private static partial void _MsgSend(nint receiver, Selector selector, nuint a, MTLSize b);

    public static void MsgSend(nint receiver, Selector selector, nuint a, MTLSize b)
    {
        if (receiver is 0) return;
        _MsgSend(receiver, selector, a, b);
    }

    [LibraryImport("/usr/lib/libobjc.A.dylib", EntryPoint = "objc_msgSend")]
    private static partial void _MsgSend(nint receiver, Selector selector, nuint a, MTLSize b, MTLSize c);

    public static void MsgSend(nint receiver, Selector selector, nuint a, MTLSize b, MTLSize c)
    {
        if (receiver is 0) return;
        _MsgSend(receiver, selector, a, b, c);
    }

    [LibraryImport("/usr/lib/libobjc.A.dylib", EntryPoint = "objc_msgSend")]
    private static partial void _MsgSend(nint receiver, Selector selector, nuint a, MTLVertexAmplificationViewMapping b);

    public static void MsgSend(nint receiver, Selector selector, nuint a, MTLVertexAmplificationViewMapping b)
    {
        if (receiver is 0) return;
        _MsgSend(receiver, selector, a, b);
    }

    [LibraryImport("/usr/lib/libobjc.A.dylib", EntryPoint = "objc_msgSend")]
    private static partial void _MsgSend(nint receiver, Selector selector, nuint a, NSRange b);

    public static void MsgSend(nint receiver, Selector selector, nuint a, NSRange b)
    {
        if (receiver is 0) return;
        _MsgSend(receiver, selector, a, b);
    }

    [LibraryImport("/usr/lib/libobjc.A.dylib", EntryPoint = "objc_msgSend")]
    private static partial void _MsgSend(nint receiver, Selector selector, nuint a, nint b, nuint c);

    public static void MsgSend(nint receiver, Selector selector, nuint a, nint b, nuint c)
    {
        if (receiver is 0) return;
        _MsgSend(receiver, selector, a, b, c);
    }

    [LibraryImport("/usr/lib/libobjc.A.dylib", EntryPoint = "objc_msgSend")]
    private static partial void _MsgSend(nint receiver, Selector selector, nuint a, nint b, nuint c, nint d, nuint e);

    public static void MsgSend(nint receiver, Selector selector, nuint a, nint b, nuint c, nint d, nuint e)
    {
        if (receiver is 0) return;
        _MsgSend(receiver, selector, a, b, c, d, e);
    }

    [LibraryImport("/usr/lib/libobjc.A.dylib", EntryPoint = "objc_msgSend")]
    private static partial void _MsgSend(nint receiver, Selector selector, nuint a, nint b, nuint c, nint d, nuint e, nint f, nuint g);

    public static void MsgSend(nint receiver, Selector selector, nuint a, nint b, nuint c, nint d, nuint e, nint f, nuint g)
    {
        if (receiver is 0) return;
        _MsgSend(receiver, selector, a, b, c, d, e, f, g);
    }

    [LibraryImport("/usr/lib/libobjc.A.dylib", EntryPoint = "objc_msgSend")]
    private static partial void _MsgSend(nint receiver, Selector selector, nuint a, nuint b);

    public static void MsgSend(nint receiver, Selector selector, nuint a, nuint b)
    {
        if (receiver is 0) return;
        _MsgSend(receiver, selector, a, b);
    }

    [LibraryImport("/usr/lib/libobjc.A.dylib", EntryPoint = "objc_msgSend")]
    private static partial void _MsgSend(nint receiver, Selector selector, nuint a, nuint b, nint c, nuint d, nint e, nuint f);

    public static void MsgSend(nint receiver, Selector selector, nuint a, nuint b, nint c, nuint d, nint e, nuint f)
    {
        if (receiver is 0) return;
        _MsgSend(receiver, selector, a, b, c, d, e, f);
    }

    [LibraryImport("/usr/lib/libobjc.A.dylib", EntryPoint = "objc_msgSend")]
    private static partial void _MsgSend(nint receiver, Selector selector, nuint a, nuint b, nuint c);

    public static void MsgSend(nint receiver, Selector selector, nuint a, nuint b, nuint c)
    {
        if (receiver is 0) return;
        _MsgSend(receiver, selector, a, b, c);
    }

    [LibraryImport("/usr/lib/libobjc.A.dylib", EntryPoint = "objc_msgSend")]
    private static partial void _MsgSend(nint receiver, Selector selector, nuint a, nuint b, nuint c, nint d, nuint e);

    public static void MsgSend(nint receiver, Selector selector, nuint a, nuint b, nuint c, nint d, nuint e)
    {
        if (receiver is 0) return;
        _MsgSend(receiver, selector, a, b, c, d, e);
    }

    [LibraryImport("/usr/lib/libobjc.A.dylib", EntryPoint = "objc_msgSend")]
    private static partial void _MsgSend(nint receiver, Selector selector, nuint a, nuint b, nuint c, nint d, nuint e, nint f, nuint g, nuint h, nuint i);

    public static void MsgSend(nint receiver, Selector selector, nuint a, nuint b, nuint c, nint d, nuint e, nint f, nuint g, nuint h, nuint i)
    {
        if (receiver is 0) return;
        _MsgSend(receiver, selector, a, b, c, d, e, f, g, h, i);
    }

    [LibraryImport("/usr/lib/libobjc.A.dylib", EntryPoint = "objc_msgSend")]
    private static partial void _MsgSend(nint receiver, Selector selector, nuint a, nuint b, nuint c, nint d, nuint e, nint f, nuint g, nuint h, nuint i, nint j, nuint k, nuint l);

    public static void MsgSend(nint receiver, Selector selector, nuint a, nuint b, nuint c, nint d, nuint e, nint f, nuint g, nuint h, nuint i, nint j, nuint k, nuint l)
    {
        if (receiver is 0) return;
        _MsgSend(receiver, selector, a, b, c, d, e, f, g, h, i, j, k, l);
    }

    [LibraryImport("/usr/lib/libobjc.A.dylib", EntryPoint = "objc_msgSend")]
    private static partial void _MsgSend(nint receiver, Selector selector, nuint a, nuint b, nuint c, nint d, nuint e, nuint f);

    public static void MsgSend(nint receiver, Selector selector, nuint a, nuint b, nuint c, nint d, nuint e, nuint f)
    {
        if (receiver is 0) return;
        _MsgSend(receiver, selector, a, b, c, d, e, f);
    }

    [LibraryImport("/usr/lib/libobjc.A.dylib", EntryPoint = "objc_msgSend")]
    private static partial void _MsgSend(nint receiver, Selector selector, nuint a, nuint b, nuint c, nint d, nuint e, nuint f, nint g, nuint h);

    public static void MsgSend(nint receiver, Selector selector, nuint a, nuint b, nuint c, nint d, nuint e, nuint f, nint g, nuint h)
    {
        if (receiver is 0) return;
        _MsgSend(receiver, selector, a, b, c, d, e, f, g, h);
    }

    [LibraryImport("/usr/lib/libobjc.A.dylib", EntryPoint = "objc_msgSend")]
    private static partial void _MsgSend(nint receiver, Selector selector, nuint a, nuint b, nuint c, nint d, nuint e, nuint f, nuint g);

    public static void MsgSend(nint receiver, Selector selector, nuint a, nuint b, nuint c, nint d, nuint e, nuint f, nuint g)
    {
        if (receiver is 0) return;
        _MsgSend(receiver, selector, a, b, c, d, e, f, g);
    }

    [LibraryImport("/usr/lib/libobjc.A.dylib", EntryPoint = "objc_msgSend")]
    private static partial void _MsgSend(nint receiver, Selector selector, nuint a, nuint b, nuint c, nint d, nuint e, nuint f, nuint g, nint h, nuint i, nuint j);

    public static void MsgSend(nint receiver, Selector selector, nuint a, nuint b, nuint c, nint d, nuint e, nuint f, nuint g, nint h, nuint i, nuint j)
    {
        if (receiver is 0) return;
        _MsgSend(receiver, selector, a, b, c, d, e, f, g, h, i, j);
    }

    [LibraryImport("/usr/lib/libobjc.A.dylib", EntryPoint = "objc_msgSend")]
    private static partial void _MsgSend(nint receiver, Selector selector, nuint a, nuint b, nuint c, nuint d);

    public static void MsgSend(nint receiver, Selector selector, nuint a, nuint b, nuint c, nuint d)
    {
        if (receiver is 0) return;
        _MsgSend(receiver, selector, a, b, c, d);
    }

    [LibraryImport("/usr/lib/libobjc.A.dylib", EntryPoint = "objc_msgSend")]
    private static partial void _MsgSend(nint receiver, Selector selector, nuint a, nuint b, nuint c, nuint d, nuint e);

    public static void MsgSend(nint receiver, Selector selector, nuint a, nuint b, nuint c, nuint d, nuint e)
    {
        if (receiver is 0) return;
        _MsgSend(receiver, selector, a, b, c, d, e);
    }

    [LibraryImport("/usr/lib/libobjc.A.dylib", EntryPoint = "objc_msgSend")]
    private static partial void _MsgSend(nint receiver, Selector selector, nuint a, nuint b, nuint c, nuint d, nuint e, nuint f);

    public static void MsgSend(nint receiver, Selector selector, nuint a, nuint b, nuint c, nuint d, nuint e, nuint f)
    {
        if (receiver is 0) return;
        _MsgSend(receiver, selector, a, b, c, d, e, f);
    }

    [LibraryImport("/usr/lib/libobjc.A.dylib", EntryPoint = "objc_msgSend")]
    private static partial void _MsgSend(nint receiver, Selector selector, nuint a, nuint b, nuint c, nuint d, nuint e, nuint f, nint g, nuint h);

    public static void MsgSend(nint receiver, Selector selector, nuint a, nuint b, nuint c, nuint d, nuint e, nuint f, nint g, nuint h)
    {
        if (receiver is 0) return;
        _MsgSend(receiver, selector, a, b, c, d, e, f, g, h);
    }

    [LibraryImport("/usr/lib/libobjc.A.dylib", EntryPoint = "objc_msgSend")]
    private static partial void _MsgSend(nint receiver, Selector selector, int a);

    public static void MsgSend(nint receiver, Selector selector, int a)
    {
        if (receiver is 0) return;
        _MsgSend(receiver, selector, a);
    }

    [LibraryImport("/usr/lib/libobjc.A.dylib", EntryPoint = "objc_msgSend")]
    private static partial void _MsgSend(nint receiver, Selector selector, uint a);

    public static void MsgSend(nint receiver, Selector selector, uint a)
    {
        if (receiver is 0) return;
        _MsgSend(receiver, selector, a);
    }

    [LibraryImport("/usr/lib/libobjc.A.dylib", EntryPoint = "objc_msgSend")]
    private static partial void _MsgSend(nint receiver, Selector selector, uint a, uint b);

    public static void MsgSend(nint receiver, Selector selector, uint a, uint b)
    {
        if (receiver is 0) return;
        _MsgSend(receiver, selector, a, b);
    }

    [LibraryImport("/usr/lib/libobjc.A.dylib", EntryPoint = "objc_msgSend")]
    private static partial void _MsgSend(nint receiver, Selector selector, ulong a);

    public static void MsgSend(nint receiver, Selector selector, ulong a)
    {
        if (receiver is 0) return;
        _MsgSend(receiver, selector, a);
    }

    #endregion

    #region MsgSendBool

    [LibraryImport("/usr/lib/libobjc.A.dylib", EntryPoint = "objc_msgSend")]
    private static partial Bool8 _MsgSendBool(nint receiver, Selector selector);

    public static Bool8 MsgSendBool(nint receiver, Selector selector)
    {
        if (receiver is 0) return default;
        return _MsgSendBool(receiver, selector);
    }

    [LibraryImport("/usr/lib/libobjc.A.dylib", EntryPoint = "objc_msgSend")]
    private static partial Bool8 _MsgSendBool(nint receiver, Selector selector, nint a);

    public static Bool8 MsgSendBool(nint receiver, Selector selector, nint a)
    {
        if (receiver is 0) return default;
        return _MsgSendBool(receiver, selector, a);
    }

    [LibraryImport("/usr/lib/libobjc.A.dylib", EntryPoint = "objc_msgSend")]
    private static partial Bool8 _MsgSendBool(nint receiver, Selector selector, nint a, nint b, out nint c);

    public static Bool8 MsgSendBool(nint receiver, Selector selector, nint a, nint b, out nint c)
    {
        if (receiver is 0) return default;
        return _MsgSendBool(receiver, selector, a, b, out c);
    }

    [LibraryImport("/usr/lib/libobjc.A.dylib", EntryPoint = "objc_msgSend")]
    private static partial Bool8 _MsgSendBool(nint receiver, Selector selector, nint a, out nint b);

    public static Bool8 MsgSendBool(nint receiver, Selector selector, nint a, out nint b)
    {
        if (receiver is 0) return default;
        return _MsgSendBool(receiver, selector, a, out b);
    }

    [LibraryImport("/usr/lib/libobjc.A.dylib", EntryPoint = "objc_msgSend")]
    private static partial Bool8 _MsgSendBool(nint receiver, Selector selector, nuint a);

    public static Bool8 MsgSendBool(nint receiver, Selector selector, nuint a)
    {
        if (receiver is 0) return default;
        return _MsgSendBool(receiver, selector, a);
    }

    [LibraryImport("/usr/lib/libobjc.A.dylib", EntryPoint = "objc_msgSend")]
    private static partial Bool8 _MsgSendBool(nint receiver, Selector selector, nuint a, nuint b);

    public static Bool8 MsgSendBool(nint receiver, Selector selector, nuint a, nuint b)
    {
        if (receiver is 0) return default;
        return _MsgSendBool(receiver, selector, a, b);
    }

    #endregion

    #region MsgSendCGSize

    [LibraryImport("/usr/lib/libobjc.A.dylib", EntryPoint = "objc_msgSend")]
    private static partial CGSize _MsgSendCGSize(nint receiver, Selector selector);

    public static CGSize MsgSendCGSize(nint receiver, Selector selector)
    {
        if (receiver is 0) return default;
        return _MsgSendCGSize(receiver, selector);
    }

    #endregion

    #region MsgSendDouble

    [LibraryImport("/usr/lib/libobjc.A.dylib", EntryPoint = "objc_msgSend")]
    private static partial double _MsgSendDouble(nint receiver, Selector selector);

    public static double MsgSendDouble(nint receiver, Selector selector)
    {
        if (receiver is 0) return default;
        return _MsgSendDouble(receiver, selector);
    }

    #endregion

    #region MsgSendFloat

    [LibraryImport("/usr/lib/libobjc.A.dylib", EntryPoint = "objc_msgSend")]
    private static partial float _MsgSendFloat(nint receiver, Selector selector);

    public static float MsgSendFloat(nint receiver, Selector selector)
    {
        if (receiver is 0) return default;
        return _MsgSendFloat(receiver, selector);
    }

    [LibraryImport("/usr/lib/libobjc.A.dylib", EntryPoint = "objc_msgSend")]
    private static partial float _MsgSendFloat(nint receiver, Selector selector, nint a);

    public static float MsgSendFloat(nint receiver, Selector selector, nint a)
    {
        if (receiver is 0) return default;
        return _MsgSendFloat(receiver, selector, a);
    }

    #endregion

    #region MsgSendMTL4BufferRange

    [LibraryImport("/usr/lib/libobjc.A.dylib", EntryPoint = "objc_msgSend")]
    private static partial MTL4BufferRange _MsgSendMTL4BufferRange(nint receiver, Selector selector);

    public static MTL4BufferRange MsgSendMTL4BufferRange(nint receiver, Selector selector)
    {
        if (receiver is 0) return default;
        return _MsgSendMTL4BufferRange(receiver, selector);
    }

    #endregion

    #region MsgSendMTLAccelerationStructureSizes

    [LibraryImport("/usr/lib/libobjc.A.dylib", EntryPoint = "objc_msgSend")]
    private static partial MTLAccelerationStructureSizes _MsgSendMTLAccelerationStructureSizes(nint receiver, Selector selector, nint a);

    public static MTLAccelerationStructureSizes MsgSendMTLAccelerationStructureSizes(nint receiver, Selector selector, nint a)
    {
        if (receiver is 0) return default;
        return _MsgSendMTLAccelerationStructureSizes(receiver, selector, a);
    }

    #endregion

    #region MsgSendMTLClearColor

    [LibraryImport("/usr/lib/libobjc.A.dylib", EntryPoint = "objc_msgSend")]
    private static partial MTLClearColor _MsgSendMTLClearColor(nint receiver, Selector selector);

    public static MTLClearColor MsgSendMTLClearColor(nint receiver, Selector selector)
    {
        if (receiver is 0) return default;
        return _MsgSendMTLClearColor(receiver, selector);
    }

    #endregion

    #region MsgSendMTLResourceID

    [LibraryImport("/usr/lib/libobjc.A.dylib", EntryPoint = "objc_msgSend")]
    private static partial MTLResourceID _MsgSendMTLResourceID(nint receiver, Selector selector);

    public static MTLResourceID MsgSendMTLResourceID(nint receiver, Selector selector)
    {
        if (receiver is 0) return default;
        return _MsgSendMTLResourceID(receiver, selector);
    }

    [LibraryImport("/usr/lib/libobjc.A.dylib", EntryPoint = "objc_msgSend")]
    private static partial MTLResourceID _MsgSendMTLResourceID(nint receiver, Selector selector, nint a, NSRange b, nuint c);

    public static MTLResourceID MsgSendMTLResourceID(nint receiver, Selector selector, nint a, NSRange b, nuint c)
    {
        if (receiver is 0) return default;
        return _MsgSendMTLResourceID(receiver, selector, a, b, c);
    }

    [LibraryImport("/usr/lib/libobjc.A.dylib", EntryPoint = "objc_msgSend")]
    private static partial MTLResourceID _MsgSendMTLResourceID(nint receiver, Selector selector, nint a, nint b, nuint c);

    public static MTLResourceID MsgSendMTLResourceID(nint receiver, Selector selector, nint a, nint b, nuint c)
    {
        if (receiver is 0) return default;
        return _MsgSendMTLResourceID(receiver, selector, a, b, c);
    }

    [LibraryImport("/usr/lib/libobjc.A.dylib", EntryPoint = "objc_msgSend")]
    private static partial MTLResourceID _MsgSendMTLResourceID(nint receiver, Selector selector, nint a, nint b, nuint c, nuint d, nuint e);

    public static MTLResourceID MsgSendMTLResourceID(nint receiver, Selector selector, nint a, nint b, nuint c, nuint d, nuint e)
    {
        if (receiver is 0) return default;
        return _MsgSendMTLResourceID(receiver, selector, a, b, c, d, e);
    }

    [LibraryImport("/usr/lib/libobjc.A.dylib", EntryPoint = "objc_msgSend")]
    private static partial MTLResourceID _MsgSendMTLResourceID(nint receiver, Selector selector, nint a, nuint b);

    public static MTLResourceID MsgSendMTLResourceID(nint receiver, Selector selector, nint a, nuint b)
    {
        if (receiver is 0) return default;
        return _MsgSendMTLResourceID(receiver, selector, a, b);
    }

    #endregion

    #region MsgSendMTLSamplePosition

    [LibraryImport("/usr/lib/libobjc.A.dylib", EntryPoint = "objc_msgSend")]
    private static partial MTLSamplePosition _MsgSendMTLSamplePosition(nint receiver, Selector selector, MTLSamplePosition a, nuint b);

    public static MTLSamplePosition MsgSendMTLSamplePosition(nint receiver, Selector selector, MTLSamplePosition a, nuint b)
    {
        if (receiver is 0) return default;
        return _MsgSendMTLSamplePosition(receiver, selector, a, b);
    }

    #endregion

    #region MsgSendMTLSize

    [LibraryImport("/usr/lib/libobjc.A.dylib", EntryPoint = "objc_msgSend")]
    private static partial MTLSize _MsgSendMTLSize(nint receiver, Selector selector);

    public static MTLSize MsgSendMTLSize(nint receiver, Selector selector)
    {
        if (receiver is 0) return default;
        return _MsgSendMTLSize(receiver, selector);
    }

    [LibraryImport("/usr/lib/libobjc.A.dylib", EntryPoint = "objc_msgSend")]
    private static partial MTLSize _MsgSendMTLSize(nint receiver, Selector selector, nuint a);

    public static MTLSize MsgSendMTLSize(nint receiver, Selector selector, nuint a)
    {
        if (receiver is 0) return default;
        return _MsgSendMTLSize(receiver, selector, a);
    }

    [LibraryImport("/usr/lib/libobjc.A.dylib", EntryPoint = "objc_msgSend")]
    private static partial MTLSize _MsgSendMTLSize(nint receiver, Selector selector, nuint a, nuint b, nuint c);

    public static MTLSize MsgSendMTLSize(nint receiver, Selector selector, nuint a, nuint b, nuint c)
    {
        if (receiver is 0) return default;
        return _MsgSendMTLSize(receiver, selector, a, b, c);
    }

    [LibraryImport("/usr/lib/libobjc.A.dylib", EntryPoint = "objc_msgSend")]
    private static partial MTLSize _MsgSendMTLSize(nint receiver, Selector selector, nuint a, nuint b, nuint c, nint d);

    public static MTLSize MsgSendMTLSize(nint receiver, Selector selector, nuint a, nuint b, nuint c, nint d)
    {
        if (receiver is 0) return default;
        return _MsgSendMTLSize(receiver, selector, a, b, c, d);
    }

    #endregion

    #region MsgSendMTLSizeAndAlign

    [LibraryImport("/usr/lib/libobjc.A.dylib", EntryPoint = "objc_msgSend")]
    private static partial MTLSizeAndAlign _MsgSendMTLSizeAndAlign(nint receiver, Selector selector);

    public static MTLSizeAndAlign MsgSendMTLSizeAndAlign(nint receiver, Selector selector)
    {
        if (receiver is 0) return default;
        return _MsgSendMTLSizeAndAlign(receiver, selector);
    }

    [LibraryImport("/usr/lib/libobjc.A.dylib", EntryPoint = "objc_msgSend")]
    private static partial MTLSizeAndAlign _MsgSendMTLSizeAndAlign(nint receiver, Selector selector, nint a);

    public static MTLSizeAndAlign MsgSendMTLSizeAndAlign(nint receiver, Selector selector, nint a)
    {
        if (receiver is 0) return default;
        return _MsgSendMTLSizeAndAlign(receiver, selector, a);
    }

    [LibraryImport("/usr/lib/libobjc.A.dylib", EntryPoint = "objc_msgSend")]
    private static partial MTLSizeAndAlign _MsgSendMTLSizeAndAlign(nint receiver, Selector selector, nuint a);

    public static MTLSizeAndAlign MsgSendMTLSizeAndAlign(nint receiver, Selector selector, nuint a)
    {
        if (receiver is 0) return default;
        return _MsgSendMTLSizeAndAlign(receiver, selector, a);
    }

    [LibraryImport("/usr/lib/libobjc.A.dylib", EntryPoint = "objc_msgSend")]
    private static partial MTLSizeAndAlign _MsgSendMTLSizeAndAlign(nint receiver, Selector selector, nuint a, nuint b);

    public static MTLSizeAndAlign MsgSendMTLSizeAndAlign(nint receiver, Selector selector, nuint a, nuint b)
    {
        if (receiver is 0) return default;
        return _MsgSendMTLSizeAndAlign(receiver, selector, a, b);
    }

    #endregion

    #region MsgSendMTLTextureSwizzleChannels

    [LibraryImport("/usr/lib/libobjc.A.dylib", EntryPoint = "objc_msgSend")]
    private static partial MTLTextureSwizzleChannels _MsgSendMTLTextureSwizzleChannels(nint receiver, Selector selector);

    public static MTLTextureSwizzleChannels MsgSendMTLTextureSwizzleChannels(nint receiver, Selector selector)
    {
        if (receiver is 0) return default;
        return _MsgSendMTLTextureSwizzleChannels(receiver, selector);
    }

    #endregion

    #region MsgSendSimdFloat4x4

    [LibraryImport("/usr/lib/libobjc.A.dylib", EntryPoint = "objc_msgSend")]
    private static partial SimdFloat4x4 _MsgSendSimdFloat4x4(nint receiver, Selector selector);

    public static SimdFloat4x4 MsgSendSimdFloat4x4(nint receiver, Selector selector)
    {
        if (receiver is 0) return default;
        return _MsgSendSimdFloat4x4(receiver, selector);
    }

    [LibraryImport("/usr/lib/libobjc.A.dylib", EntryPoint = "objc_msgSend")]
    private static partial void _MsgSend(nint receiver, Selector selector, SimdFloat4x4 a);

    public static void MsgSend(nint receiver, Selector selector, SimdFloat4x4 a)
    {
        if (receiver is 0) return;
        _MsgSend(receiver, selector, a);
    }

    #endregion

    #region MsgSendNSRange

    [LibraryImport("/usr/lib/libobjc.A.dylib", EntryPoint = "objc_msgSend")]
    private static partial NSRange _MsgSendNSRange(nint receiver, Selector selector);

    public static NSRange MsgSendNSRange(nint receiver, Selector selector)
    {
        if (receiver is 0) return default;
        return _MsgSendNSRange(receiver, selector);
    }

    #endregion

    #region MsgSendNUInt

    [LibraryImport("/usr/lib/libobjc.A.dylib", EntryPoint = "objc_msgSend")]
    private static partial nuint _MsgSendNUInt(nint receiver, Selector selector);

    public static nuint MsgSendNUInt(nint receiver, Selector selector)
    {
        if (receiver is 0) return default;
        return _MsgSendNUInt(receiver, selector);
    }

    [LibraryImport("/usr/lib/libobjc.A.dylib", EntryPoint = "objc_msgSend")]
    private static partial nuint _MsgSendNUInt(nint receiver, Selector selector, MTLSamplePosition a, nuint b);

    public static nuint MsgSendNUInt(nint receiver, Selector selector, MTLSamplePosition a, nuint b)
    {
        if (receiver is 0) return default;
        return _MsgSendNUInt(receiver, selector, a, b);
    }

    [LibraryImport("/usr/lib/libobjc.A.dylib", EntryPoint = "objc_msgSend")]
    private static partial nuint _MsgSendNUInt(nint receiver, Selector selector, MTLSize a);

    public static nuint MsgSendNUInt(nint receiver, Selector selector, MTLSize a)
    {
        if (receiver is 0) return default;
        return _MsgSendNUInt(receiver, selector, a);
    }

    [LibraryImport("/usr/lib/libobjc.A.dylib", EntryPoint = "objc_msgSend")]
    private static partial nuint _MsgSendNUInt(nint receiver, Selector selector, nint a);

    public static nuint MsgSendNUInt(nint receiver, Selector selector, nint a)
    {
        if (receiver is 0) return default;
        return _MsgSendNUInt(receiver, selector, a);
    }

    [LibraryImport("/usr/lib/libobjc.A.dylib", EntryPoint = "objc_msgSend")]
    private static partial nuint _MsgSendNUInt(nint receiver, Selector selector, nint a, nuint b);

    public static nuint MsgSendNUInt(nint receiver, Selector selector, nint a, nuint b)
    {
        if (receiver is 0) return default;
        return _MsgSendNUInt(receiver, selector, a, b);
    }

    [LibraryImport("/usr/lib/libobjc.A.dylib", EntryPoint = "objc_msgSend")]
    private static partial nuint _MsgSendNUInt(nint receiver, Selector selector, nuint a);

    public static nuint MsgSendNUInt(nint receiver, Selector selector, nuint a)
    {
        if (receiver is 0) return default;
        return _MsgSendNUInt(receiver, selector, a);
    }

    #endregion

    #region MsgSendPtr

    [LibraryImport("/usr/lib/libobjc.A.dylib", EntryPoint = "objc_msgSend")]
    private static partial nint _MsgSendPtr(nint receiver, Selector selector);

    public static nint MsgSendPtr(nint receiver, Selector selector)
    {
        if (receiver is 0) return default;
        return _MsgSendPtr(receiver, selector);
    }

    [LibraryImport("/usr/lib/libobjc.A.dylib", EntryPoint = "objc_msgSend")]
    private static partial nint _MsgSendPtr(nint receiver, Selector selector, MTLSize a);

    public static nint MsgSendPtr(nint receiver, Selector selector, MTLSize a)
    {
        if (receiver is 0) return default;
        return _MsgSendPtr(receiver, selector, a);
    }

    [LibraryImport("/usr/lib/libobjc.A.dylib", EntryPoint = "objc_msgSend")]
    private static partial nint _MsgSendPtr(nint receiver, Selector selector, MTLSize a, nint b);

    public static nint MsgSendPtr(nint receiver, Selector selector, MTLSize a, nint b)
    {
        if (receiver is 0) return default;
        return _MsgSendPtr(receiver, selector, a, b);
    }

    [LibraryImport("/usr/lib/libobjc.A.dylib", EntryPoint = "objc_msgSend")]
    private static partial nint _MsgSendPtr(nint receiver, Selector selector, MTLSize a, nuint b, nint c);

    public static nint MsgSendPtr(nint receiver, Selector selector, MTLSize a, nuint b, nint c)
    {
        if (receiver is 0) return default;
        return _MsgSendPtr(receiver, selector, a, b, c);
    }

    [LibraryImport("/usr/lib/libobjc.A.dylib", EntryPoint = "objc_msgSend")]
    private static partial nint _MsgSendPtr(nint receiver, Selector selector, NSRange a);

    public static nint MsgSendPtr(nint receiver, Selector selector, NSRange a)
    {
        if (receiver is 0) return default;
        return _MsgSendPtr(receiver, selector, a);
    }

    [LibraryImport("/usr/lib/libobjc.A.dylib", EntryPoint = "objc_msgSend")]
    private static partial nint _MsgSendPtr(nint receiver, Selector selector, nint a);

    public static nint MsgSendPtr(nint receiver, Selector selector, nint a)
    {
        if (receiver is 0) return default;
        return _MsgSendPtr(receiver, selector, a);
    }

    [LibraryImport("/usr/lib/libobjc.A.dylib", EntryPoint = "objc_msgSend")]
    private static partial nint _MsgSendPtr(nint receiver, Selector selector, nint a, nint b);

    public static nint MsgSendPtr(nint receiver, Selector selector, nint a, nint b)
    {
        if (receiver is 0) return default;
        return _MsgSendPtr(receiver, selector, a, b);
    }

    [LibraryImport("/usr/lib/libobjc.A.dylib", EntryPoint = "objc_msgSend")]
    private static partial nint _MsgSendPtr(nint receiver, Selector selector, nint a, nint b, nint c, out nint d);

    public static nint MsgSendPtr(nint receiver, Selector selector, nint a, nint b, nint c, out nint d)
    {
        if (receiver is 0) return default;
        return _MsgSendPtr(receiver, selector, a, b, c, out d);
    }

    [LibraryImport("/usr/lib/libobjc.A.dylib", EntryPoint = "objc_msgSend")]
    private static partial nint _MsgSendPtr(nint receiver, Selector selector, nint a, nint b, nuint c);

    public static nint MsgSendPtr(nint receiver, Selector selector, nint a, nint b, nuint c)
    {
        if (receiver is 0) return default;
        return _MsgSendPtr(receiver, selector, a, b, c);
    }

    [LibraryImport("/usr/lib/libobjc.A.dylib", EntryPoint = "objc_msgSend")]
    private static partial nint _MsgSendPtr(nint receiver, Selector selector, nint a, nint b, out nint c);

    public static nint MsgSendPtr(nint receiver, Selector selector, nint a, nint b, out nint c)
    {
        if (receiver is 0) return default;
        return _MsgSendPtr(receiver, selector, a, b, out c);
    }

    [LibraryImport("/usr/lib/libobjc.A.dylib", EntryPoint = "objc_msgSend")]
    private static partial nint _MsgSendPtr(nint receiver, Selector selector, nint a, nuint b);

    public static nint MsgSendPtr(nint receiver, Selector selector, nint a, nuint b)
    {
        if (receiver is 0) return default;
        return _MsgSendPtr(receiver, selector, a, b);
    }

    [LibraryImport("/usr/lib/libobjc.A.dylib", EntryPoint = "objc_msgSend")]
    private static partial nint _MsgSendPtr(nint receiver, Selector selector, nint a, nuint b, nuint c);

    public static nint MsgSendPtr(nint receiver, Selector selector, nint a, nuint b, nuint c)
    {
        if (receiver is 0) return default;
        return _MsgSendPtr(receiver, selector, a, b, c);
    }

    [LibraryImport("/usr/lib/libobjc.A.dylib", EntryPoint = "objc_msgSend")]
    private static partial nint _MsgSendPtr(nint receiver, Selector selector, nint a, nuint b, out nint c);

    public static nint MsgSendPtr(nint receiver, Selector selector, nint a, nuint b, out nint c)
    {
        if (receiver is 0) return default;
        return _MsgSendPtr(receiver, selector, a, b, out c);
    }

    [LibraryImport("/usr/lib/libobjc.A.dylib", EntryPoint = "objc_msgSend")]
    private static partial nint _MsgSendPtr(nint receiver, Selector selector, nint a, out nint b);

    public static nint MsgSendPtr(nint receiver, Selector selector, nint a, out nint b)
    {
        if (receiver is 0) return default;
        return _MsgSendPtr(receiver, selector, a, out b);
    }

    [LibraryImport("/usr/lib/libobjc.A.dylib", EntryPoint = "objc_msgSend")]
    private static partial nint _MsgSendPtr(nint receiver, Selector selector, nuint a);

    public static nint MsgSendPtr(nint receiver, Selector selector, nuint a)
    {
        if (receiver is 0) return default;
        return _MsgSendPtr(receiver, selector, a);
    }

    [LibraryImport("/usr/lib/libobjc.A.dylib", EntryPoint = "objc_msgSend")]
    private static partial nint _MsgSendPtr(nint receiver, Selector selector, nuint a, nuint b);

    public static nint MsgSendPtr(nint receiver, Selector selector, nuint a, nuint b)
    {
        if (receiver is 0) return default;
        return _MsgSendPtr(receiver, selector, a, b);
    }

    [LibraryImport("/usr/lib/libobjc.A.dylib", EntryPoint = "objc_msgSend")]
    private static partial nint _MsgSendPtr(nint receiver, Selector selector, nuint a, nuint b, Bool8 c);

    public static nint MsgSendPtr(nint receiver, Selector selector, nuint a, nuint b, Bool8 c)
    {
        if (receiver is 0) return default;
        return _MsgSendPtr(receiver, selector, a, b, c);
    }

    [LibraryImport("/usr/lib/libobjc.A.dylib", EntryPoint = "objc_msgSend")]
    private static partial nint _MsgSendPtr(nint receiver, Selector selector, nuint a, nuint b, NSRange c, NSRange d);

    public static nint MsgSendPtr(nint receiver, Selector selector, nuint a, nuint b, NSRange c, NSRange d)
    {
        if (receiver is 0) return default;
        return _MsgSendPtr(receiver, selector, a, b, c, d);
    }

    [LibraryImport("/usr/lib/libobjc.A.dylib", EntryPoint = "objc_msgSend")]
    private static partial nint _MsgSendPtr(nint receiver, Selector selector, nuint a, nuint b, NSRange c, NSRange d, MTLTextureSwizzleChannels e);

    public static nint MsgSendPtr(nint receiver, Selector selector, nuint a, nuint b, NSRange c, NSRange d, MTLTextureSwizzleChannels e)
    {
        if (receiver is 0) return default;
        return _MsgSendPtr(receiver, selector, a, b, c, d, e);
    }

    [LibraryImport("/usr/lib/libobjc.A.dylib", EntryPoint = "objc_msgSend")]
    private static partial nint _MsgSendPtr(nint receiver, Selector selector, nuint a, nuint b, nint c);

    public static nint MsgSendPtr(nint receiver, Selector selector, nuint a, nuint b, nint c)
    {
        if (receiver is 0) return default;
        return _MsgSendPtr(receiver, selector, a, b, c);
    }

    [LibraryImport("/usr/lib/libobjc.A.dylib", EntryPoint = "objc_msgSend")]
    private static partial nint _MsgSendPtr(nint receiver, Selector selector, nuint a, nuint b, nuint c);

    public static nint MsgSendPtr(nint receiver, Selector selector, nuint a, nuint b, nuint c)
    {
        if (receiver is 0) return default;
        return _MsgSendPtr(receiver, selector, a, b, c);
    }

    [LibraryImport("/usr/lib/libobjc.A.dylib", EntryPoint = "objc_msgSend")]
    private static partial nint _MsgSendPtr(nint receiver, Selector selector, nuint a, nuint b, nuint c, Bool8 d);

    public static nint MsgSendPtr(nint receiver, Selector selector, nuint a, nuint b, nuint c, Bool8 d)
    {
        if (receiver is 0) return default;
        return _MsgSendPtr(receiver, selector, a, b, c, d);
    }

    [LibraryImport("/usr/lib/libobjc.A.dylib", EntryPoint = "objc_msgSend")]
    private static partial nint _MsgSendPtr(nint receiver, Selector selector, nuint a, nuint b, nuint c, nuint d);

    public static nint MsgSendPtr(nint receiver, Selector selector, nuint a, nuint b, nuint c, nuint d)
    {
        if (receiver is 0) return default;
        return _MsgSendPtr(receiver, selector, a, b, c, d);
    }

    #endregion

    #region MsgSendInt

    [LibraryImport("/usr/lib/libobjc.A.dylib", EntryPoint = "objc_msgSend")]
    private static partial int _MsgSendInt(nint receiver, Selector selector);

    public static int MsgSendInt(nint receiver, Selector selector)
    {
        if (receiver is 0) return default;
        return _MsgSendInt(receiver, selector);
    }

    [LibraryImport("/usr/lib/libobjc.A.dylib", EntryPoint = "objc_msgSend")]
    private static partial int _MsgSendInt(nint receiver, Selector selector, nint a);

    public static int MsgSendInt(nint receiver, Selector selector, nint a)
    {
        if (receiver is 0) return default;
        return _MsgSendInt(receiver, selector, a);
    }

    #endregion

    #region MsgSendUInt

    [LibraryImport("/usr/lib/libobjc.A.dylib", EntryPoint = "objc_msgSend")]
    private static partial uint _MsgSendUInt(nint receiver, Selector selector);

    public static uint MsgSendUInt(nint receiver, Selector selector)
    {
        if (receiver is 0) return default;
        return _MsgSendUInt(receiver, selector);
    }

    [LibraryImport("/usr/lib/libobjc.A.dylib", EntryPoint = "objc_msgSend")]
    private static partial uint _MsgSendUInt(nint receiver, Selector selector, nint a);

    public static uint MsgSendUInt(nint receiver, Selector selector, nint a)
    {
        if (receiver is 0) return default;
        return _MsgSendUInt(receiver, selector, a);
    }

    #endregion

    #region MsgSendULong

    [LibraryImport("/usr/lib/libobjc.A.dylib", EntryPoint = "objc_msgSend")]
    private static partial ulong _MsgSendULong(nint receiver, Selector selector);

    public static ulong MsgSendULong(nint receiver, Selector selector)
    {
        if (receiver is 0) return default;
        return _MsgSendULong(receiver, selector);
    }

    #endregion

    public static nint AllocInit(nint @class)
    {
        return MsgSendPtr(MsgSendPtr(@class, (Selector)"alloc"), (Selector)"init");
    }

    public static nint Retain(nint receiver)
    {
        if (receiver is 0) return 0;

        return MsgSendPtr(receiver, (Selector)"retain");
    }

    public static void Release(nint receiver)
    {
        if (receiver is 0) return;

        MsgSend(receiver, (Selector)"release");
    }
}
