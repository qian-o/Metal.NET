using System.Runtime.InteropServices;

namespace Metal.NET;

internal static unsafe partial class ObjectiveC
{
    private static readonly nint msgSend;

    static ObjectiveC()
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

        msgSend = NativeLibrary.GetExport(NativeLibrary.Load("/usr/lib/libobjc.A.dylib"), "objc_msgSend");
    }

    #region Class and Selector Lookups

    [LibraryImport("/usr/lib/libobjc.A.dylib", EntryPoint = "objc_getClass", StringMarshalling = StringMarshalling.Utf8)]
    private static partial nint _GetClass(string name);

    [LibraryImport("/usr/lib/libobjc.A.dylib", EntryPoint = "sel_registerName", StringMarshalling = StringMarshalling.Utf8)]
    private static partial Selector _RegisterName(string name);

    public static nint GetClass(string name)
    {
        if (string.IsNullOrEmpty(name))
        {
            return 0;
        }

        return _GetClass(name);
    }

    public static Selector RegisterName(string name)
    {
        if (string.IsNullOrEmpty(name))
        {
            return default;
        }

        return _RegisterName(name);
    }

    #endregion

    #region MsgSend

    public static void MsgSend(nint receiver, Selector selector)
    {
        if (receiver is 0)
        {
            return;
        }

        ((delegate* unmanaged<nint, Selector, void>)msgSend)(receiver, selector);
    }

    public static void MsgSend(nint receiver, Selector selector, Bool8 a)
    {
        if (receiver is 0)
        {
            return;
        }

        ((delegate* unmanaged<nint, Selector, Bool8, void>)msgSend)(receiver, selector, a);
    }

    public static void MsgSend(nint receiver, Selector selector, CGSize a)
    {
        if (receiver is 0)
        {
            return;
        }

        ((delegate* unmanaged<nint, Selector, CGSize, void>)msgSend)(receiver, selector, a);
    }

    public static void MsgSend(nint receiver, Selector selector, MTL4BufferRange a)
    {
        if (receiver is 0)
        {
            return;
        }

        ((delegate* unmanaged<nint, Selector, MTL4BufferRange, void>)msgSend)(receiver, selector, a);
    }

    public static void MsgSend(nint receiver, Selector selector, MTL4CommitFeedbackHandler a)
    {
        if (receiver is 0)
        {
            return;
        }

        ((delegate* unmanaged<nint, Selector, nint, void>)msgSend)(receiver, selector, Marshal.GetFunctionPointerForDelegate(a));

        GC.KeepAlive(a);
    }

    public static void MsgSend(nint receiver, Selector selector, MTLClearColor a)
    {
        if (receiver is 0)
        {
            return;
        }

        ((delegate* unmanaged<nint, Selector, MTLClearColor, void>)msgSend)(receiver, selector, a);
    }

    public static void MsgSend(nint receiver, Selector selector, MTLCommandBufferHandler a)
    {
        if (receiver is 0)
        {
            return;
        }

        ((delegate* unmanaged<nint, Selector, nint, void>)msgSend)(receiver, selector, Marshal.GetFunctionPointerForDelegate(a));

        GC.KeepAlive(a);
    }

    public static void MsgSend(nint receiver, Selector selector, MTLDrawablePresentedHandler a)
    {
        if (receiver is 0)
        {
            return;
        }

        ((delegate* unmanaged<nint, Selector, nint, void>)msgSend)(receiver, selector, Marshal.GetFunctionPointerForDelegate(a));

        GC.KeepAlive(a);
    }

    public static void MsgSend(nint receiver, Selector selector, MTLIOCommandBufferHandler a)
    {
        if (receiver is 0)
        {
            return;
        }

        ((delegate* unmanaged<nint, Selector, nint, void>)msgSend)(receiver, selector, Marshal.GetFunctionPointerForDelegate(a));

        GC.KeepAlive(a);
    }

    public static void MsgSend(nint receiver, Selector selector, MTLLogHandler a)
    {
        if (receiver is 0)
        {
            return;
        }

        ((delegate* unmanaged<nint, Selector, nint, void>)msgSend)(receiver, selector, Marshal.GetFunctionPointerForDelegate(a));

        GC.KeepAlive(a);
    }

    public static void MsgSend(nint receiver, Selector selector, MTLRegion a)
    {
        if (receiver is 0)
        {
            return;
        }

        ((delegate* unmanaged<nint, Selector, MTLRegion, void>)msgSend)(receiver, selector, a);
    }

    public static void MsgSend(nint receiver, Selector selector, MTLRegion a, MTLRegion b, MTLSize c, nuint d)
    {
        if (receiver is 0)
        {
            return;
        }

        ((delegate* unmanaged<nint, Selector, MTLRegion, MTLRegion, MTLSize, nuint, void>)msgSend)(receiver, selector, a, b, c, d);
    }

    public static void MsgSend(nint receiver, Selector selector, MTLRegion a, MTLRegion b, MTLSize c, nuint d, nuint e)
    {
        if (receiver is 0)
        {
            return;
        }

        ((delegate* unmanaged<nint, Selector, MTLRegion, MTLRegion, MTLSize, nuint, nuint, void>)msgSend)(receiver, selector, a, b, c, d, e);
    }

    public static void MsgSend(nint receiver, Selector selector, MTLRegion a, nuint b, nint c, nuint d)
    {
        if (receiver is 0)
        {
            return;
        }

        ((delegate* unmanaged<nint, Selector, MTLRegion, nuint, nint, nuint, void>)msgSend)(receiver, selector, a, b, c, d);
    }

    public static void MsgSend(nint receiver, Selector selector, MTLRegion a, nuint b, nuint c, nint d, nuint e, nuint f)
    {
        if (receiver is 0)
        {
            return;
        }

        ((delegate* unmanaged<nint, Selector, MTLRegion, nuint, nuint, nint, nuint, nuint, void>)msgSend)(receiver, selector, a, b, c, d, e, f);
    }

    public static void MsgSend(nint receiver, Selector selector, MTLResourceID a, nuint b)
    {
        if (receiver is 0)
        {
            return;
        }

        ((delegate* unmanaged<nint, Selector, MTLResourceID, nuint, void>)msgSend)(receiver, selector, a, b);
    }

    public static void MsgSend(nint receiver, Selector selector, MTLScissorRect a)
    {
        if (receiver is 0)
        {
            return;
        }

        ((delegate* unmanaged<nint, Selector, MTLScissorRect, void>)msgSend)(receiver, selector, a);
    }

    public static void MsgSend(nint receiver, Selector selector, MTLSize a)
    {
        if (receiver is 0)
        {
            return;
        }

        ((delegate* unmanaged<nint, Selector, MTLSize, void>)msgSend)(receiver, selector, a);
    }

    public static void MsgSend(nint receiver, Selector selector, MTLSize a, MTLSize b)
    {
        if (receiver is 0)
        {
            return;
        }

        ((delegate* unmanaged<nint, Selector, MTLSize, MTLSize, void>)msgSend)(receiver, selector, a, b);
    }

    public static void MsgSend(nint receiver, Selector selector, MTLSize a, MTLSize b, MTLSize c)
    {
        if (receiver is 0)
        {
            return;
        }

        ((delegate* unmanaged<nint, Selector, MTLSize, MTLSize, MTLSize, void>)msgSend)(receiver, selector, a, b, c);
    }

    public static void MsgSend(nint receiver, Selector selector, MTLTextureSwizzleChannels a)
    {
        if (receiver is 0)
        {
            return;
        }

        ((delegate* unmanaged<nint, Selector, MTLTextureSwizzleChannels, void>)msgSend)(receiver, selector, a);
    }

    public static void MsgSend(nint receiver, Selector selector, MTLViewport a)
    {
        if (receiver is 0)
        {
            return;
        }

        ((delegate* unmanaged<nint, Selector, MTLViewport, void>)msgSend)(receiver, selector, a);
    }

    public static void MsgSend(nint receiver, Selector selector, NSRange a)
    {
        if (receiver is 0)
        {
            return;
        }

        ((delegate* unmanaged<nint, Selector, NSRange, void>)msgSend)(receiver, selector, a);
    }

    public static void MsgSend(nint receiver, Selector selector, SimdFloat4x4 a)
    {
        if (receiver is 0)
        {
            return;
        }

        ((delegate* unmanaged<nint, Selector, SimdFloat4x4, void>)msgSend)(receiver, selector, a);
    }

    public static void MsgSend(nint receiver, Selector selector, double a)
    {
        if (receiver is 0)
        {
            return;
        }

        ((delegate* unmanaged<nint, Selector, double, void>)msgSend)(receiver, selector, a);
    }

    public static void MsgSend(nint receiver, Selector selector, float a)
    {
        if (receiver is 0)
        {
            return;
        }

        ((delegate* unmanaged<nint, Selector, float, void>)msgSend)(receiver, selector, a);
    }

    public static void MsgSend(nint receiver, Selector selector, float a, float b)
    {
        if (receiver is 0)
        {
            return;
        }

        ((delegate* unmanaged<nint, Selector, float, float, void>)msgSend)(receiver, selector, a, b);
    }

    public static void MsgSend(nint receiver, Selector selector, float a, float b, float c)
    {
        if (receiver is 0)
        {
            return;
        }

        ((delegate* unmanaged<nint, Selector, float, float, float, void>)msgSend)(receiver, selector, a, b, c);
    }

    public static void MsgSend(nint receiver, Selector selector, float a, float b, float c, float d)
    {
        if (receiver is 0)
        {
            return;
        }

        ((delegate* unmanaged<nint, Selector, float, float, float, float, void>)msgSend)(receiver, selector, a, b, c, d);
    }

    public static void MsgSend(nint receiver, Selector selector, nint a)
    {
        if (receiver is 0)
        {
            return;
        }

        ((delegate* unmanaged<nint, Selector, nint, void>)msgSend)(receiver, selector, a);
    }

    public static void MsgSend(nint receiver, Selector selector, nint a, MTL4BufferRange b)
    {
        if (receiver is 0)
        {
            return;
        }

        ((delegate* unmanaged<nint, Selector, nint, MTL4BufferRange, void>)msgSend)(receiver, selector, a, b);
    }

    public static void MsgSend(nint receiver, Selector selector, nint a, MTLNewComputePipelineStateCompletionHandler b)
    {
        if (receiver is 0)
        {
            return;
        }

        ((delegate* unmanaged<nint, Selector, nint, nint, void>)msgSend)(receiver, selector, a, Marshal.GetFunctionPointerForDelegate(b));

        GC.KeepAlive(b);
    }

    public static void MsgSend(nint receiver, Selector selector, nint a, MTLNewFunctionCompletionHandler b)
    {
        if (receiver is 0)
        {
            return;
        }

        ((delegate* unmanaged<nint, Selector, nint, nint, void>)msgSend)(receiver, selector, a, Marshal.GetFunctionPointerForDelegate(b));

        GC.KeepAlive(b);
    }

    public static void MsgSend(nint receiver, Selector selector, nint a, MTLNewLibraryCompletionHandler b)
    {
        if (receiver is 0)
        {
            return;
        }

        ((delegate* unmanaged<nint, Selector, nint, nint, void>)msgSend)(receiver, selector, a, Marshal.GetFunctionPointerForDelegate(b));

        GC.KeepAlive(b);
    }

    public static void MsgSend(nint receiver, Selector selector, nint a, MTLNewRenderPipelineStateCompletionHandler b)
    {
        if (receiver is 0)
        {
            return;
        }

        ((delegate* unmanaged<nint, Selector, nint, nint, void>)msgSend)(receiver, selector, a, Marshal.GetFunctionPointerForDelegate(b));

        GC.KeepAlive(b);
    }

    public static void MsgSend(nint receiver, Selector selector, nint a, MTLRegion b, nuint c, nuint d)
    {
        if (receiver is 0)
        {
            return;
        }

        ((delegate* unmanaged<nint, Selector, nint, MTLRegion, nuint, nuint, void>)msgSend)(receiver, selector, a, b, c, d);
    }

    public static void MsgSend(nint receiver, Selector selector, nint a, MTLRegion b, nuint c, nuint d, Bool8 e, nint f, nuint g)
    {
        if (receiver is 0)
        {
            return;
        }

        ((delegate* unmanaged<nint, Selector, nint, MTLRegion, nuint, nuint, Bool8, nint, nuint, void>)msgSend)(receiver, selector, a, b, c, d, e, f, g);
    }

    public static void MsgSend(nint receiver, Selector selector, nint a, NSRange b)
    {
        if (receiver is 0)
        {
            return;
        }

        ((delegate* unmanaged<nint, Selector, nint, NSRange, void>)msgSend)(receiver, selector, a, b);
    }

    public static void MsgSend(nint receiver, Selector selector, nint a, NSRange b, MTL4BufferRange c, nint d, nint e)
    {
        if (receiver is 0)
        {
            return;
        }

        ((delegate* unmanaged<nint, Selector, nint, NSRange, MTL4BufferRange, nint, nint, void>)msgSend)(receiver, selector, a, b, c, d, e);
    }

    public static void MsgSend(nint receiver, Selector selector, nint a, NSRange b, byte c)
    {
        if (receiver is 0)
        {
            return;
        }

        ((delegate* unmanaged<nint, Selector, nint, NSRange, byte, void>)msgSend)(receiver, selector, a, b, c);
    }

    public static void MsgSend(nint receiver, Selector selector, nint a, NSRange b, nint c, nuint d)
    {
        if (receiver is 0)
        {
            return;
        }

        ((delegate* unmanaged<nint, Selector, nint, NSRange, nint, nuint, void>)msgSend)(receiver, selector, a, b, c, d);
    }

    public static void MsgSend(nint receiver, Selector selector, nint a, double b)
    {
        if (receiver is 0)
        {
            return;
        }

        ((delegate* unmanaged<nint, Selector, nint, double, void>)msgSend)(receiver, selector, a, b);
    }

    public static void MsgSend(nint receiver, Selector selector, nint a, float b, float c, nuint d)
    {
        if (receiver is 0)
        {
            return;
        }

        ((delegate* unmanaged<nint, Selector, nint, float, float, nuint, void>)msgSend)(receiver, selector, a, b, c, d);
    }

    public static void MsgSend(nint receiver, Selector selector, nint a, nint b)
    {
        if (receiver is 0)
        {
            return;
        }

        ((delegate* unmanaged<nint, Selector, nint, nint, void>)msgSend)(receiver, selector, a, b);
    }

    public static void MsgSend(nint receiver, Selector selector, nint a, nint b, MTL4BufferRange c)
    {
        if (receiver is 0)
        {
            return;
        }

        ((delegate* unmanaged<nint, Selector, nint, nint, MTL4BufferRange, void>)msgSend)(receiver, selector, a, b, c);
    }

    public static void MsgSend(nint receiver, Selector selector, nint a, nint b, MTLNewFunctionCompletionHandler c)
    {
        if (receiver is 0)
        {
            return;
        }

        ((delegate* unmanaged<nint, Selector, nint, nint, nint, void>)msgSend)(receiver, selector, a, b, Marshal.GetFunctionPointerForDelegate(c));

        GC.KeepAlive(c);
    }

    public static void MsgSend(nint receiver, Selector selector, nint a, nint b, MTLNewLibraryCompletionHandler c)
    {
        if (receiver is 0)
        {
            return;
        }

        ((delegate* unmanaged<nint, Selector, nint, nint, nint, void>)msgSend)(receiver, selector, a, b, Marshal.GetFunctionPointerForDelegate(c));

        GC.KeepAlive(c);
    }

    public static void MsgSend(nint receiver, Selector selector, nint a, nint b, nint c, MTL4BufferRange d)
    {
        if (receiver is 0)
        {
            return;
        }

        ((delegate* unmanaged<nint, Selector, nint, nint, nint, MTL4BufferRange, void>)msgSend)(receiver, selector, a, b, c, d);
    }

    public static void MsgSend(nint receiver, Selector selector, nint a, nint b, nint c, MTL4BufferRange d, nuint e)
    {
        if (receiver is 0)
        {
            return;
        }

        ((delegate* unmanaged<nint, Selector, nint, nint, nint, MTL4BufferRange, nuint, void>)msgSend)(receiver, selector, a, b, c, d, e);
    }

    public static void MsgSend(nint receiver, Selector selector, nint a, nint b, nint c, nint d)
    {
        if (receiver is 0)
        {
            return;
        }

        ((delegate* unmanaged<nint, Selector, nint, nint, nint, nint, void>)msgSend)(receiver, selector, a, b, c, d);
    }

    public static void MsgSend(nint receiver, Selector selector, nint a, nint b, nint c, nint d, nint e, nint f)
    {
        if (receiver is 0)
        {
            return;
        }

        ((delegate* unmanaged<nint, Selector, nint, nint, nint, nint, nint, nint, void>)msgSend)(receiver, selector, a, b, c, d, e, f);
    }

    public static void MsgSend(nint receiver, Selector selector, nint a, nint b, nint c, nint d, nuint e)
    {
        if (receiver is 0)
        {
            return;
        }

        ((delegate* unmanaged<nint, Selector, nint, nint, nint, nint, nuint, void>)msgSend)(receiver, selector, a, b, c, d, e);
    }

    public static void MsgSend(nint receiver, Selector selector, nint a, nint b, nint c, nint d, nuint e, nuint f)
    {
        if (receiver is 0)
        {
            return;
        }

        ((delegate* unmanaged<nint, Selector, nint, nint, nint, nint, nuint, nuint, void>)msgSend)(receiver, selector, a, b, c, d, e, f);
    }

    public static void MsgSend(nint receiver, Selector selector, nint a, nint b, nint c, nuint d)
    {
        if (receiver is 0)
        {
            return;
        }

        ((delegate* unmanaged<nint, Selector, nint, nint, nint, nuint, void>)msgSend)(receiver, selector, a, b, c, d);
    }

    public static void MsgSend(nint receiver, Selector selector, nint a, nint b, nuint c)
    {
        if (receiver is 0)
        {
            return;
        }

        ((delegate* unmanaged<nint, Selector, nint, nint, nuint, void>)msgSend)(receiver, selector, a, b, c);
    }

    public static void MsgSend(nint receiver, Selector selector, nint a, nint b, nuint c, nuint d)
    {
        if (receiver is 0)
        {
            return;
        }

        ((delegate* unmanaged<nint, Selector, nint, nint, nuint, nuint, void>)msgSend)(receiver, selector, a, b, c, d);
    }

    public static void MsgSend(nint receiver, Selector selector, nint a, nuint b)
    {
        if (receiver is 0)
        {
            return;
        }

        ((delegate* unmanaged<nint, Selector, nint, nuint, void>)msgSend)(receiver, selector, a, b);
    }

    public static void MsgSend(nint receiver, Selector selector, nint a, nuint b, Bool8 c)
    {
        if (receiver is 0)
        {
            return;
        }

        ((delegate* unmanaged<nint, Selector, nint, nuint, Bool8, void>)msgSend)(receiver, selector, a, b, c);
    }

    public static void MsgSend(nint receiver, Selector selector, nint a, nuint b, MTLNewComputePipelineStateWithReflectionCompletionHandler c)
    {
        if (receiver is 0)
        {
            return;
        }

        ((delegate* unmanaged<nint, Selector, nint, nuint, nint, void>)msgSend)(receiver, selector, a, b, Marshal.GetFunctionPointerForDelegate(c));

        GC.KeepAlive(c);
    }

    public static void MsgSend(nint receiver, Selector selector, nint a, nuint b, MTLNewRenderPipelineStateWithReflectionCompletionHandler c)
    {
        if (receiver is 0)
        {
            return;
        }

        ((delegate* unmanaged<nint, Selector, nint, nuint, nint, void>)msgSend)(receiver, selector, a, b, Marshal.GetFunctionPointerForDelegate(c));

        GC.KeepAlive(c);
    }

    public static void MsgSend(nint receiver, Selector selector, nint a, nuint b, MTLRegion c, nint d, nint e, nuint f)
    {
        if (receiver is 0)
        {
            return;
        }

        ((delegate* unmanaged<nint, Selector, nint, nuint, MTLRegion, nint, nint, nuint, void>)msgSend)(receiver, selector, a, b, c, d, e, f);
    }

    public static void MsgSend(nint receiver, Selector selector, nint a, nuint b, MTLRegion c, nuint d)
    {
        if (receiver is 0)
        {
            return;
        }

        ((delegate* unmanaged<nint, Selector, nint, nuint, MTLRegion, nuint, void>)msgSend)(receiver, selector, a, b, c, d);
    }

    public static void MsgSend(nint receiver, Selector selector, nint a, nuint b, MTLRegion c, nuint d, nuint e)
    {
        if (receiver is 0)
        {
            return;
        }

        ((delegate* unmanaged<nint, Selector, nint, nuint, MTLRegion, nuint, nuint, void>)msgSend)(receiver, selector, a, b, c, d, e);
    }

    public static void MsgSend(nint receiver, Selector selector, nint a, nuint b, MTLSize c)
    {
        if (receiver is 0)
        {
            return;
        }

        ((delegate* unmanaged<nint, Selector, nint, nuint, MTLSize, void>)msgSend)(receiver, selector, a, b, c);
    }

    public static void MsgSend(nint receiver, Selector selector, nint a, nuint b, MTLSize c, MTLSize d)
    {
        if (receiver is 0)
        {
            return;
        }

        ((delegate* unmanaged<nint, Selector, nint, nuint, MTLSize, MTLSize, void>)msgSend)(receiver, selector, a, b, c, d);
    }

    public static void MsgSend(nint receiver, Selector selector, nint a, nuint b, NSRange c)
    {
        if (receiver is 0)
        {
            return;
        }

        ((delegate* unmanaged<nint, Selector, nint, nuint, NSRange, void>)msgSend)(receiver, selector, a, b, c);
    }

    public static void MsgSend(nint receiver, Selector selector, nint a, nuint b, nint c)
    {
        if (receiver is 0)
        {
            return;
        }

        ((delegate* unmanaged<nint, Selector, nint, nuint, nint, void>)msgSend)(receiver, selector, a, b, c);
    }

    public static void MsgSend(nint receiver, Selector selector, nint a, nuint b, nint c, nuint d)
    {
        if (receiver is 0)
        {
            return;
        }

        ((delegate* unmanaged<nint, Selector, nint, nuint, nint, nuint, void>)msgSend)(receiver, selector, a, b, c, d);
    }

    public static void MsgSend(nint receiver, Selector selector, nint a, nuint b, nint c, nuint d, nuint e)
    {
        if (receiver is 0)
        {
            return;
        }

        ((delegate* unmanaged<nint, Selector, nint, nuint, nint, nuint, nuint, void>)msgSend)(receiver, selector, a, b, c, d, e);
    }

    public static void MsgSend(nint receiver, Selector selector, nint a, nuint b, nuint c)
    {
        if (receiver is 0)
        {
            return;
        }

        ((delegate* unmanaged<nint, Selector, nint, nuint, nuint, void>)msgSend)(receiver, selector, a, b, c);
    }

    public static void MsgSend(nint receiver, Selector selector, nint a, nuint b, nuint c, MTLOrigin d, MTLSize e, nint f, nuint g, nuint h, MTLOrigin i)
    {
        if (receiver is 0)
        {
            return;
        }

        ((delegate* unmanaged<nint, Selector, nint, nuint, nuint, MTLOrigin, MTLSize, nint, nuint, nuint, MTLOrigin, void>)msgSend)(receiver, selector, a, b, c, d, e, f, g, h, i);
    }

    public static void MsgSend(nint receiver, Selector selector, nint a, nuint b, nuint c, MTLOrigin d, MTLSize e, nint f, nuint g, nuint h, nuint i)
    {
        if (receiver is 0)
        {
            return;
        }

        ((delegate* unmanaged<nint, Selector, nint, nuint, nuint, MTLOrigin, MTLSize, nint, nuint, nuint, nuint, void>)msgSend)(receiver, selector, a, b, c, d, e, f, g, h, i);
    }

    public static void MsgSend(nint receiver, Selector selector, nint a, nuint b, nuint c, MTLOrigin d, MTLSize e, nint f, nuint g, nuint h, nuint i, nuint j)
    {
        if (receiver is 0)
        {
            return;
        }

        ((delegate* unmanaged<nint, Selector, nint, nuint, nuint, MTLOrigin, MTLSize, nint, nuint, nuint, nuint, nuint, void>)msgSend)(receiver, selector, a, b, c, d, e, f, g, h, i, j);
    }

    public static void MsgSend(nint receiver, Selector selector, nint a, nuint b, nuint c, MTLRegion d, nuint e, nuint f)
    {
        if (receiver is 0)
        {
            return;
        }

        ((delegate* unmanaged<nint, Selector, nint, nuint, nuint, MTLRegion, nuint, nuint, void>)msgSend)(receiver, selector, a, b, c, d, e, f);
    }

    public static void MsgSend(nint receiver, Selector selector, nint a, nuint b, nuint c, MTLSize d, nuint e, nuint f, MTLOrigin g, nint h, nuint i)
    {
        if (receiver is 0)
        {
            return;
        }

        ((delegate* unmanaged<nint, Selector, nint, nuint, nuint, MTLSize, nuint, nuint, MTLOrigin, nint, nuint, void>)msgSend)(receiver, selector, a, b, c, d, e, f, g, h, i);
    }

    public static void MsgSend(nint receiver, Selector selector, nint a, nuint b, nuint c, nint d, nuint e)
    {
        if (receiver is 0)
        {
            return;
        }

        ((delegate* unmanaged<nint, Selector, nint, nuint, nuint, nint, nuint, void>)msgSend)(receiver, selector, a, b, c, d, e);
    }

    public static void MsgSend(nint receiver, Selector selector, nint a, nuint b, nuint c, nint d, nuint e, nuint f, nuint g, nuint h)
    {
        if (receiver is 0)
        {
            return;
        }

        ((delegate* unmanaged<nint, Selector, nint, nuint, nuint, nint, nuint, nuint, nuint, nuint, void>)msgSend)(receiver, selector, a, b, c, d, e, f, g, h);
    }

    public static void MsgSend(nint receiver, Selector selector, nint a, nuint b, nuint c, nuint d)
    {
        if (receiver is 0)
        {
            return;
        }

        ((delegate* unmanaged<nint, Selector, nint, nuint, nuint, nuint, void>)msgSend)(receiver, selector, a, b, c, d);
    }

    public static void MsgSend(nint receiver, Selector selector, nint a, nuint b, nuint c, nuint d, MTLSize e, nint f, nuint g, nuint h, MTLOrigin i)
    {
        if (receiver is 0)
        {
            return;
        }

        ((delegate* unmanaged<nint, Selector, nint, nuint, nuint, nuint, MTLSize, nint, nuint, nuint, MTLOrigin, void>)msgSend)(receiver, selector, a, b, c, d, e, f, g, h, i);
    }

    public static void MsgSend(nint receiver, Selector selector, nint a, nuint b, nuint c, nuint d, MTLSize e, nint f, nuint g, nuint h, MTLOrigin i, nuint j)
    {
        if (receiver is 0)
        {
            return;
        }

        ((delegate* unmanaged<nint, Selector, nint, nuint, nuint, nuint, MTLSize, nint, nuint, nuint, MTLOrigin, nuint, void>)msgSend)(receiver, selector, a, b, c, d, e, f, g, h, i, j);
    }

    public static void MsgSend(nint receiver, Selector selector, nint a, ulong b)
    {
        if (receiver is 0)
        {
            return;
        }

        ((delegate* unmanaged<nint, Selector, nint, ulong, void>)msgSend)(receiver, selector, a, b);
    }

    public static void MsgSend(nint receiver, Selector selector, nint a, ulong b, MTLSharedEventNotificationBlock c)
    {
        if (receiver is 0)
        {
            return;
        }

        ((delegate* unmanaged<nint, Selector, nint, ulong, nint, void>)msgSend)(receiver, selector, a, b, Marshal.GetFunctionPointerForDelegate(c));

        GC.KeepAlive(c);
    }

    public static void MsgSend(nint receiver, Selector selector, nuint a)
    {
        if (receiver is 0)
        {
            return;
        }

        ((delegate* unmanaged<nint, Selector, nuint, void>)msgSend)(receiver, selector, a);
    }

    public static void MsgSend(nint receiver, Selector selector, nuint a, MTLSize b)
    {
        if (receiver is 0)
        {
            return;
        }

        ((delegate* unmanaged<nint, Selector, nuint, MTLSize, void>)msgSend)(receiver, selector, a, b);
    }

    public static void MsgSend(nint receiver, Selector selector, nuint a, MTLSize b, MTLSize c)
    {
        if (receiver is 0)
        {
            return;
        }

        ((delegate* unmanaged<nint, Selector, nuint, MTLSize, MTLSize, void>)msgSend)(receiver, selector, a, b, c);
    }

    public static void MsgSend(nint receiver, Selector selector, nuint a, MTLVertexAmplificationViewMapping b)
    {
        if (receiver is 0)
        {
            return;
        }

        ((delegate* unmanaged<nint, Selector, nuint, MTLVertexAmplificationViewMapping, void>)msgSend)(receiver, selector, a, b);
    }

    public static void MsgSend(nint receiver, Selector selector, nuint a, NSRange b)
    {
        if (receiver is 0)
        {
            return;
        }

        ((delegate* unmanaged<nint, Selector, nuint, NSRange, void>)msgSend)(receiver, selector, a, b);
    }

    public static void MsgSend(nint receiver, Selector selector, nuint a, nint b, nuint c)
    {
        if (receiver is 0)
        {
            return;
        }

        ((delegate* unmanaged<nint, Selector, nuint, nint, nuint, void>)msgSend)(receiver, selector, a, b, c);
    }

    public static void MsgSend(nint receiver, Selector selector, nuint a, nint b, nuint c, nint d, nuint e)
    {
        if (receiver is 0)
        {
            return;
        }

        ((delegate* unmanaged<nint, Selector, nuint, nint, nuint, nint, nuint, void>)msgSend)(receiver, selector, a, b, c, d, e);
    }

    public static void MsgSend(nint receiver, Selector selector, nuint a, nint b, nuint c, nint d, nuint e, nint f, nuint g)
    {
        if (receiver is 0)
        {
            return;
        }

        ((delegate* unmanaged<nint, Selector, nuint, nint, nuint, nint, nuint, nint, nuint, void>)msgSend)(receiver, selector, a, b, c, d, e, f, g);
    }

    public static void MsgSend(nint receiver, Selector selector, nuint a, nuint b)
    {
        if (receiver is 0)
        {
            return;
        }

        ((delegate* unmanaged<nint, Selector, nuint, nuint, void>)msgSend)(receiver, selector, a, b);
    }

    public static void MsgSend(nint receiver, Selector selector, nuint a, nuint b, nint c, nuint d, nint e, nuint f)
    {
        if (receiver is 0)
        {
            return;
        }

        ((delegate* unmanaged<nint, Selector, nuint, nuint, nint, nuint, nint, nuint, void>)msgSend)(receiver, selector, a, b, c, d, e, f);
    }

    public static void MsgSend(nint receiver, Selector selector, nuint a, nuint b, nuint c)
    {
        if (receiver is 0)
        {
            return;
        }

        ((delegate* unmanaged<nint, Selector, nuint, nuint, nuint, void>)msgSend)(receiver, selector, a, b, c);
    }

    public static void MsgSend(nint receiver, Selector selector, nuint a, nuint b, nuint c, nint d, nuint e)
    {
        if (receiver is 0)
        {
            return;
        }

        ((delegate* unmanaged<nint, Selector, nuint, nuint, nuint, nint, nuint, void>)msgSend)(receiver, selector, a, b, c, d, e);
    }

    public static void MsgSend(nint receiver, Selector selector, nuint a, nuint b, nuint c, nint d, nuint e, nint f, nuint g, nuint h, nuint i)
    {
        if (receiver is 0)
        {
            return;
        }

        ((delegate* unmanaged<nint, Selector, nuint, nuint, nuint, nint, nuint, nint, nuint, nuint, nuint, void>)msgSend)(receiver, selector, a, b, c, d, e, f, g, h, i);
    }

    public static void MsgSend(nint receiver, Selector selector, nuint a, nuint b, nuint c, nint d, nuint e, nint f, nuint g, nuint h, nuint i, nint j, nuint k, nuint l)
    {
        if (receiver is 0)
        {
            return;
        }

        ((delegate* unmanaged<nint, Selector, nuint, nuint, nuint, nint, nuint, nint, nuint, nuint, nuint, nint, nuint, nuint, void>)msgSend)(receiver, selector, a, b, c, d, e, f, g, h, i, j, k, l);
    }

    public static void MsgSend(nint receiver, Selector selector, nuint a, nuint b, nuint c, nint d, nuint e, nuint f)
    {
        if (receiver is 0)
        {
            return;
        }

        ((delegate* unmanaged<nint, Selector, nuint, nuint, nuint, nint, nuint, nuint, void>)msgSend)(receiver, selector, a, b, c, d, e, f);
    }

    public static void MsgSend(nint receiver, Selector selector, nuint a, nuint b, nuint c, nint d, nuint e, nuint f, nint g, nuint h)
    {
        if (receiver is 0)
        {
            return;
        }

        ((delegate* unmanaged<nint, Selector, nuint, nuint, nuint, nint, nuint, nuint, nint, nuint, void>)msgSend)(receiver, selector, a, b, c, d, e, f, g, h);
    }

    public static void MsgSend(nint receiver, Selector selector, nuint a, nuint b, nuint c, nint d, nuint e, nuint f, nuint g)
    {
        if (receiver is 0)
        {
            return;
        }

        ((delegate* unmanaged<nint, Selector, nuint, nuint, nuint, nint, nuint, nuint, nuint, void>)msgSend)(receiver, selector, a, b, c, d, e, f, g);
    }

    public static void MsgSend(nint receiver, Selector selector, nuint a, nuint b, nuint c, nint d, nuint e, nuint f, nuint g, nint h, nuint i, nuint j)
    {
        if (receiver is 0)
        {
            return;
        }

        ((delegate* unmanaged<nint, Selector, nuint, nuint, nuint, nint, nuint, nuint, nuint, nint, nuint, nuint, void>)msgSend)(receiver, selector, a, b, c, d, e, f, g, h, i, j);
    }

    public static void MsgSend(nint receiver, Selector selector, nuint a, nuint b, nuint c, nuint d)
    {
        if (receiver is 0)
        {
            return;
        }

        ((delegate* unmanaged<nint, Selector, nuint, nuint, nuint, nuint, void>)msgSend)(receiver, selector, a, b, c, d);
    }

    public static void MsgSend(nint receiver, Selector selector, nuint a, nuint b, nuint c, nuint d, nuint e)
    {
        if (receiver is 0)
        {
            return;
        }

        ((delegate* unmanaged<nint, Selector, nuint, nuint, nuint, nuint, nuint, void>)msgSend)(receiver, selector, a, b, c, d, e);
    }

    public static void MsgSend(nint receiver, Selector selector, nuint a, nuint b, nuint c, nuint d, nuint e, nuint f)
    {
        if (receiver is 0)
        {
            return;
        }

        ((delegate* unmanaged<nint, Selector, nuint, nuint, nuint, nuint, nuint, nuint, void>)msgSend)(receiver, selector, a, b, c, d, e, f);
    }

    public static void MsgSend(nint receiver, Selector selector, nuint a, nuint b, nuint c, nuint d, nuint e, nuint f, nint g, nuint h)
    {
        if (receiver is 0)
        {
            return;
        }

        ((delegate* unmanaged<nint, Selector, nuint, nuint, nuint, nuint, nuint, nuint, nint, nuint, void>)msgSend)(receiver, selector, a, b, c, d, e, f, g, h);
    }

    public static void MsgSend(nint receiver, Selector selector, out ulong a, out ulong b)
    {
        if (receiver is 0)
        {
            a = default;
            b = default;
            return;
        }

        fixed (ulong* aPtr = &a)
        fixed (ulong* bPtr = &b)
        {
            ((delegate* unmanaged<nint, Selector, ulong*, ulong*, void>)msgSend)(receiver, selector, aPtr, bPtr);
        }
    }

    public static void MsgSend(nint receiver, Selector selector, uint a)
    {
        if (receiver is 0)
        {
            return;
        }

        ((delegate* unmanaged<nint, Selector, uint, void>)msgSend)(receiver, selector, a);
    }

    public static void MsgSend(nint receiver, Selector selector, uint a, uint b)
    {
        if (receiver is 0)
        {
            return;
        }

        ((delegate* unmanaged<nint, Selector, uint, uint, void>)msgSend)(receiver, selector, a, b);
    }

    public static void MsgSend(nint receiver, Selector selector, ulong a)
    {
        if (receiver is 0)
        {
            return;
        }

        ((delegate* unmanaged<nint, Selector, ulong, void>)msgSend)(receiver, selector, a);
    }

    #endregion

    #region MsgSendBool

    public static Bool8 MsgSendBool(nint receiver, Selector selector)
    {
        if (receiver is 0)
        {
            return default;
        }

        return ((delegate* unmanaged<nint, Selector, Bool8>)msgSend)(receiver, selector);
    }

    public static Bool8 MsgSendBool(nint receiver, Selector selector, nint a)
    {
        if (receiver is 0)
        {
            return default;
        }

        return ((delegate* unmanaged<nint, Selector, nint, Bool8>)msgSend)(receiver, selector, a);
    }

    public static Bool8 MsgSendBool(nint receiver, Selector selector, nint a, nint b, out nint c)
    {
        if (receiver is 0)
        {
            c = default;
            return default;
        }

        fixed (nint* cPtr = &c)
        {
            return ((delegate* unmanaged<nint, Selector, nint, nint, nint*, Bool8>)msgSend)(receiver, selector, a, b, cPtr);
        }
    }

    public static Bool8 MsgSendBool(nint receiver, Selector selector, nint a, out nint b)
    {
        if (receiver is 0)
        {
            b = default;
            return default;
        }

        fixed (nint* bPtr = &b)
        {
            return ((delegate* unmanaged<nint, Selector, nint, nint*, Bool8>)msgSend)(receiver, selector, a, bPtr);
        }
    }

    public static Bool8 MsgSendBool(nint receiver, Selector selector, nuint a)
    {
        if (receiver is 0)
        {
            return default;
        }

        return ((delegate* unmanaged<nint, Selector, nuint, Bool8>)msgSend)(receiver, selector, a);
    }

    public static Bool8 MsgSendBool(nint receiver, Selector selector, ulong a, ulong b)
    {
        if (receiver is 0)
        {
            return default;
        }

        return ((delegate* unmanaged<nint, Selector, ulong, ulong, Bool8>)msgSend)(receiver, selector, a, b);
    }

    #endregion

    #region MsgSendCGSize

    public static CGSize MsgSendCGSize(nint receiver, Selector selector)
    {
        if (receiver is 0)
        {
            return default;
        }

        return ((delegate* unmanaged<nint, Selector, CGSize>)msgSend)(receiver, selector);
    }

    #endregion

    #region MsgSendDouble

    public static double MsgSendDouble(nint receiver, Selector selector)
    {
        if (receiver is 0)
        {
            return default;
        }

        return ((delegate* unmanaged<nint, Selector, double>)msgSend)(receiver, selector);
    }

    #endregion

    #region MsgSendFloat

    public static float MsgSendFloat(nint receiver, Selector selector)
    {
        if (receiver is 0)
        {
            return default;
        }

        return ((delegate* unmanaged<nint, Selector, float>)msgSend)(receiver, selector);
    }

    public static float MsgSendFloat(nint receiver, Selector selector, nint a)
    {
        if (receiver is 0)
        {
            return default;
        }

        return ((delegate* unmanaged<nint, Selector, nint, float>)msgSend)(receiver, selector, a);
    }

    #endregion

    #region MsgSendInt

    public static int MsgSendInt(nint receiver, Selector selector)
    {
        if (receiver is 0)
        {
            return default;
        }

        return ((delegate* unmanaged<nint, Selector, int>)msgSend)(receiver, selector);
    }

    #endregion

    #region MsgSendLong

    public static long MsgSendLong(nint receiver, Selector selector)
    {
        if (receiver is 0)
        {
            return default;
        }

        return ((delegate* unmanaged<nint, Selector, long>)msgSend)(receiver, selector);
    }

    #endregion

    #region MsgSendMTL4BufferRange

    public static MTL4BufferRange MsgSendMTL4BufferRange(nint receiver, Selector selector)
    {
        if (receiver is 0)
        {
            return default;
        }

        return ((delegate* unmanaged<nint, Selector, MTL4BufferRange>)msgSend)(receiver, selector);
    }

    #endregion

    #region MsgSendMTLAccelerationStructureSizes

    public static MTLAccelerationStructureSizes MsgSendMTLAccelerationStructureSizes(nint receiver, Selector selector, nint a)
    {
        if (receiver is 0)
        {
            return default;
        }

        return ((delegate* unmanaged<nint, Selector, nint, MTLAccelerationStructureSizes>)msgSend)(receiver, selector, a);
    }

    #endregion

    #region MsgSendMTLClearColor

    public static MTLClearColor MsgSendMTLClearColor(nint receiver, Selector selector)
    {
        if (receiver is 0)
        {
            return default;
        }

        return ((delegate* unmanaged<nint, Selector, MTLClearColor>)msgSend)(receiver, selector);
    }

    #endregion

    #region MsgSendMTLResourceID

    public static MTLResourceID MsgSendMTLResourceID(nint receiver, Selector selector)
    {
        if (receiver is 0)
        {
            return default;
        }

        return ((delegate* unmanaged<nint, Selector, MTLResourceID>)msgSend)(receiver, selector);
    }

    public static MTLResourceID MsgSendMTLResourceID(nint receiver, Selector selector, nint a, NSRange b, nuint c)
    {
        if (receiver is 0)
        {
            return default;
        }

        return ((delegate* unmanaged<nint, Selector, nint, NSRange, nuint, MTLResourceID>)msgSend)(receiver, selector, a, b, c);
    }

    public static MTLResourceID MsgSendMTLResourceID(nint receiver, Selector selector, nint a, nint b, nuint c)
    {
        if (receiver is 0)
        {
            return default;
        }

        return ((delegate* unmanaged<nint, Selector, nint, nint, nuint, MTLResourceID>)msgSend)(receiver, selector, a, b, c);
    }

    public static MTLResourceID MsgSendMTLResourceID(nint receiver, Selector selector, nint a, nint b, nuint c, nuint d, nuint e)
    {
        if (receiver is 0)
        {
            return default;
        }

        return ((delegate* unmanaged<nint, Selector, nint, nint, nuint, nuint, nuint, MTLResourceID>)msgSend)(receiver, selector, a, b, c, d, e);
    }

    public static MTLResourceID MsgSendMTLResourceID(nint receiver, Selector selector, nint a, nuint b)
    {
        if (receiver is 0)
        {
            return default;
        }

        return ((delegate* unmanaged<nint, Selector, nint, nuint, MTLResourceID>)msgSend)(receiver, selector, a, b);
    }

    #endregion

    #region MsgSendMTLSamplePosition

    public static MTLSamplePosition MsgSendMTLSamplePosition(nint receiver, Selector selector, MTLSamplePosition a, nuint b)
    {
        if (receiver is 0)
        {
            return default;
        }

        return ((delegate* unmanaged<nint, Selector, MTLSamplePosition, nuint, MTLSamplePosition>)msgSend)(receiver, selector, a, b);
    }

    #endregion

    #region MsgSendMTLSize

    public static MTLSize MsgSendMTLSize(nint receiver, Selector selector)
    {
        if (receiver is 0)
        {
            return default;
        }

        return ((delegate* unmanaged<nint, Selector, MTLSize>)msgSend)(receiver, selector);
    }

    public static MTLSize MsgSendMTLSize(nint receiver, Selector selector, nuint a)
    {
        if (receiver is 0)
        {
            return default;
        }

        return ((delegate* unmanaged<nint, Selector, nuint, MTLSize>)msgSend)(receiver, selector, a);
    }

    public static MTLSize MsgSendMTLSize(nint receiver, Selector selector, nuint a, nuint b, nuint c)
    {
        if (receiver is 0)
        {
            return default;
        }

        return ((delegate* unmanaged<nint, Selector, nuint, nuint, nuint, MTLSize>)msgSend)(receiver, selector, a, b, c);
    }

    public static MTLSize MsgSendMTLSize(nint receiver, Selector selector, nuint a, nuint b, nuint c, nint d)
    {
        if (receiver is 0)
        {
            return default;
        }

        return ((delegate* unmanaged<nint, Selector, nuint, nuint, nuint, nint, MTLSize>)msgSend)(receiver, selector, a, b, c, d);
    }

    #endregion

    #region MsgSendMTLSizeAndAlign

    public static MTLSizeAndAlign MsgSendMTLSizeAndAlign(nint receiver, Selector selector)
    {
        if (receiver is 0)
        {
            return default;
        }

        return ((delegate* unmanaged<nint, Selector, MTLSizeAndAlign>)msgSend)(receiver, selector);
    }

    public static MTLSizeAndAlign MsgSendMTLSizeAndAlign(nint receiver, Selector selector, nint a)
    {
        if (receiver is 0)
        {
            return default;
        }

        return ((delegate* unmanaged<nint, Selector, nint, MTLSizeAndAlign>)msgSend)(receiver, selector, a);
    }

    public static MTLSizeAndAlign MsgSendMTLSizeAndAlign(nint receiver, Selector selector, nuint a)
    {
        if (receiver is 0)
        {
            return default;
        }

        return ((delegate* unmanaged<nint, Selector, nuint, MTLSizeAndAlign>)msgSend)(receiver, selector, a);
    }

    public static MTLSizeAndAlign MsgSendMTLSizeAndAlign(nint receiver, Selector selector, nuint a, nuint b)
    {
        if (receiver is 0)
        {
            return default;
        }

        return ((delegate* unmanaged<nint, Selector, nuint, nuint, MTLSizeAndAlign>)msgSend)(receiver, selector, a, b);
    }

    #endregion

    #region MsgSendMTLTextureSwizzleChannels

    public static MTLTextureSwizzleChannels MsgSendMTLTextureSwizzleChannels(nint receiver, Selector selector)
    {
        if (receiver is 0)
        {
            return default;
        }

        return ((delegate* unmanaged<nint, Selector, MTLTextureSwizzleChannels>)msgSend)(receiver, selector);
    }

    #endregion

    #region MsgSendNInt

    public static nint MsgSendNInt(nint receiver, Selector selector)
    {
        if (receiver is 0)
        {
            return default;
        }

        return ((delegate* unmanaged<nint, Selector, nint>)msgSend)(receiver, selector);
    }

    public static nint MsgSendNInt(nint receiver, Selector selector, Bool8 a)
    {
        if (receiver is 0)
        {
            return default;
        }

        return ((delegate* unmanaged<nint, Selector, Bool8, nint>)msgSend)(receiver, selector, a);
    }

    public static nint MsgSendNInt(nint receiver, Selector selector, MTLSize a)
    {
        if (receiver is 0)
        {
            return default;
        }

        return ((delegate* unmanaged<nint, Selector, MTLSize, nint>)msgSend)(receiver, selector, a);
    }

    public static nint MsgSendNInt(nint receiver, Selector selector, MTLSize a, nint b)
    {
        if (receiver is 0)
        {
            return default;
        }

        return ((delegate* unmanaged<nint, Selector, MTLSize, nint, nint>)msgSend)(receiver, selector, a, b);
    }

    public static nint MsgSendNInt(nint receiver, Selector selector, NSRange a)
    {
        if (receiver is 0)
        {
            return default;
        }

        return ((delegate* unmanaged<nint, Selector, NSRange, nint>)msgSend)(receiver, selector, a);
    }

    public static nint MsgSendNInt(nint receiver, Selector selector, double a)
    {
        if (receiver is 0)
        {
            return default;
        }

        return ((delegate* unmanaged<nint, Selector, double, nint>)msgSend)(receiver, selector, a);
    }

    public static nint MsgSendNInt(nint receiver, Selector selector, float a)
    {
        if (receiver is 0)
        {
            return default;
        }

        return ((delegate* unmanaged<nint, Selector, float, nint>)msgSend)(receiver, selector, a);
    }

    public static nint MsgSendNInt(nint receiver, Selector selector, int a)
    {
        if (receiver is 0)
        {
            return default;
        }

        return ((delegate* unmanaged<nint, Selector, int, nint>)msgSend)(receiver, selector, a);
    }

    public static nint MsgSendNInt(nint receiver, Selector selector, long a)
    {
        if (receiver is 0)
        {
            return default;
        }

        return ((delegate* unmanaged<nint, Selector, long, nint>)msgSend)(receiver, selector, a);
    }

    public static nint MsgSendNInt(nint receiver, Selector selector, nint a)
    {
        if (receiver is 0)
        {
            return default;
        }

        return ((delegate* unmanaged<nint, Selector, nint, nint>)msgSend)(receiver, selector, a);
    }

    public static nint MsgSendNInt(nint receiver, Selector selector, nint a, MTL4NewMachineLearningPipelineStateCompletionHandler b)
    {
        if (receiver is 0)
        {
            return default;
        }

        nint result = ((delegate* unmanaged<nint, Selector, nint, nint, nint>)msgSend)(receiver, selector, a, Marshal.GetFunctionPointerForDelegate(b));

        GC.KeepAlive(b);

        return result;
    }

    public static nint MsgSendNInt(nint receiver, Selector selector, nint a, MTLNewDynamicLibraryCompletionHandler b)
    {
        if (receiver is 0)
        {
            return default;
        }

        nint result = ((delegate* unmanaged<nint, Selector, nint, nint, nint>)msgSend)(receiver, selector, a, Marshal.GetFunctionPointerForDelegate(b));

        GC.KeepAlive(b);

        return result;
    }

    public static nint MsgSendNInt(nint receiver, Selector selector, nint a, MTLNewLibraryCompletionHandler b)
    {
        if (receiver is 0)
        {
            return default;
        }

        nint result = ((delegate* unmanaged<nint, Selector, nint, nint, nint>)msgSend)(receiver, selector, a, Marshal.GetFunctionPointerForDelegate(b));

        GC.KeepAlive(b);

        return result;
    }

    public static nint MsgSendNInt(nint receiver, Selector selector, nint a, nint b)
    {
        if (receiver is 0)
        {
            return default;
        }

        return ((delegate* unmanaged<nint, Selector, nint, nint, nint>)msgSend)(receiver, selector, a, b);
    }

    public static nint MsgSendNInt(nint receiver, Selector selector, nint a, nint b, MTL4NewBinaryFunctionCompletionHandler c)
    {
        if (receiver is 0)
        {
            return default;
        }

        nint result = ((delegate* unmanaged<nint, Selector, nint, nint, nint, nint>)msgSend)(receiver, selector, a, b, Marshal.GetFunctionPointerForDelegate(c));

        GC.KeepAlive(c);

        return result;
    }

    public static nint MsgSendNInt(nint receiver, Selector selector, nint a, nint b, MTLNewComputePipelineStateCompletionHandler c)
    {
        if (receiver is 0)
        {
            return default;
        }

        nint result = ((delegate* unmanaged<nint, Selector, nint, nint, nint, nint>)msgSend)(receiver, selector, a, b, Marshal.GetFunctionPointerForDelegate(c));

        GC.KeepAlive(c);

        return result;
    }

    public static nint MsgSendNInt(nint receiver, Selector selector, nint a, nint b, MTLNewRenderPipelineStateCompletionHandler c)
    {
        if (receiver is 0)
        {
            return default;
        }

        nint result = ((delegate* unmanaged<nint, Selector, nint, nint, nint, nint>)msgSend)(receiver, selector, a, b, Marshal.GetFunctionPointerForDelegate(c));

        GC.KeepAlive(c);

        return result;
    }

    public static nint MsgSendNInt(nint receiver, Selector selector, nint a, nint b, nint c, MTLNewComputePipelineStateCompletionHandler d)
    {
        if (receiver is 0)
        {
            return default;
        }

        nint result = ((delegate* unmanaged<nint, Selector, nint, nint, nint, nint, nint>)msgSend)(receiver, selector, a, b, c, Marshal.GetFunctionPointerForDelegate(d));

        GC.KeepAlive(d);

        return result;
    }

    public static nint MsgSendNInt(nint receiver, Selector selector, nint a, nint b, nint c, MTLNewRenderPipelineStateCompletionHandler d)
    {
        if (receiver is 0)
        {
            return default;
        }

        nint result = ((delegate* unmanaged<nint, Selector, nint, nint, nint, nint, nint>)msgSend)(receiver, selector, a, b, c, Marshal.GetFunctionPointerForDelegate(d));

        GC.KeepAlive(d);

        return result;
    }

    public static nint MsgSendNInt(nint receiver, Selector selector, nint a, nint b, nint c, out nint d)
    {
        if (receiver is 0)
        {
            d = default;
            return default;
        }

        fixed (nint* dPtr = &d)
        {
            return ((delegate* unmanaged<nint, Selector, nint, nint, nint, nint*, nint>)msgSend)(receiver, selector, a, b, c, dPtr);
        }
    }

    public static nint MsgSendNInt(nint receiver, Selector selector, nint a, nint b, nuint c)
    {
        if (receiver is 0)
        {
            return default;
        }

        return ((delegate* unmanaged<nint, Selector, nint, nint, nuint, nint>)msgSend)(receiver, selector, a, b, c);
    }

    public static nint MsgSendNInt(nint receiver, Selector selector, nint a, nint b, out nint c)
    {
        if (receiver is 0)
        {
            c = default;
            return default;
        }

        fixed (nint* cPtr = &c)
        {
            return ((delegate* unmanaged<nint, Selector, nint, nint, nint*, nint>)msgSend)(receiver, selector, a, b, cPtr);
        }
    }

    public static nint MsgSendNInt(nint receiver, Selector selector, nint a, nuint b)
    {
        if (receiver is 0)
        {
            return default;
        }

        return ((delegate* unmanaged<nint, Selector, nint, nuint, nint>)msgSend)(receiver, selector, a, b);
    }

    public static nint MsgSendNInt(nint receiver, Selector selector, nint a, nuint b, nuint c)
    {
        if (receiver is 0)
        {
            return default;
        }

        return ((delegate* unmanaged<nint, Selector, nint, nuint, nuint, nint>)msgSend)(receiver, selector, a, b, c);
    }

    public static nint MsgSendNInt(nint receiver, Selector selector, nint a, nuint b, nuint c, MTLDeallocator d)
    {
        if (receiver is 0)
        {
            return default;
        }

        nint result = ((delegate* unmanaged<nint, Selector, nint, nuint, nuint, nint, nint>)msgSend)(receiver, selector, a, b, c, Marshal.GetFunctionPointerForDelegate(d));

        GC.KeepAlive(d);

        return result;
    }

    public static nint MsgSendNInt(nint receiver, Selector selector, nint a, nuint b, out nint c)
    {
        if (receiver is 0)
        {
            c = default;
            return default;
        }

        fixed (nint* cPtr = &c)
        {
            return ((delegate* unmanaged<nint, Selector, nint, nuint, nint*, nint>)msgSend)(receiver, selector, a, b, cPtr);
        }
    }

    public static nint MsgSendNInt(nint receiver, Selector selector, nint a, out nint b)
    {
        if (receiver is 0)
        {
            b = default;
            return default;
        }

        fixed (nint* bPtr = &b)
        {
            return ((delegate* unmanaged<nint, Selector, nint, nint*, nint>)msgSend)(receiver, selector, a, bPtr);
        }
    }

    public static nint MsgSendNInt(nint receiver, Selector selector, nuint a)
    {
        if (receiver is 0)
        {
            return default;
        }

        return ((delegate* unmanaged<nint, Selector, nuint, nint>)msgSend)(receiver, selector, a);
    }

    public static nint MsgSendNInt(nint receiver, Selector selector, nuint a, nuint b)
    {
        if (receiver is 0)
        {
            return default;
        }

        return ((delegate* unmanaged<nint, Selector, nuint, nuint, nint>)msgSend)(receiver, selector, a, b);
    }

    public static nint MsgSendNInt(nint receiver, Selector selector, nuint a, nuint b, Bool8 c)
    {
        if (receiver is 0)
        {
            return default;
        }

        return ((delegate* unmanaged<nint, Selector, nuint, nuint, Bool8, nint>)msgSend)(receiver, selector, a, b, c);
    }

    public static nint MsgSendNInt(nint receiver, Selector selector, nuint a, nuint b, NSRange c, NSRange d)
    {
        if (receiver is 0)
        {
            return default;
        }

        return ((delegate* unmanaged<nint, Selector, nuint, nuint, NSRange, NSRange, nint>)msgSend)(receiver, selector, a, b, c, d);
    }

    public static nint MsgSendNInt(nint receiver, Selector selector, nuint a, nuint b, NSRange c, NSRange d, MTLTextureSwizzleChannels e)
    {
        if (receiver is 0)
        {
            return default;
        }

        return ((delegate* unmanaged<nint, Selector, nuint, nuint, NSRange, NSRange, MTLTextureSwizzleChannels, nint>)msgSend)(receiver, selector, a, b, c, d, e);
    }

    public static nint MsgSendNInt(nint receiver, Selector selector, nuint a, nuint b, nint c)
    {
        if (receiver is 0)
        {
            return default;
        }

        return ((delegate* unmanaged<nint, Selector, nuint, nuint, nint, nint>)msgSend)(receiver, selector, a, b, c);
    }

    public static nint MsgSendNInt(nint receiver, Selector selector, nuint a, nuint b, nuint c)
    {
        if (receiver is 0)
        {
            return default;
        }

        return ((delegate* unmanaged<nint, Selector, nuint, nuint, nuint, nint>)msgSend)(receiver, selector, a, b, c);
    }

    public static nint MsgSendNInt(nint receiver, Selector selector, nuint a, nuint b, nuint c, Bool8 d)
    {
        if (receiver is 0)
        {
            return default;
        }

        return ((delegate* unmanaged<nint, Selector, nuint, nuint, nuint, Bool8, nint>)msgSend)(receiver, selector, a, b, c, d);
    }

    public static nint MsgSendNInt(nint receiver, Selector selector, nuint a, nuint b, nuint c, nuint d)
    {
        if (receiver is 0)
        {
            return default;
        }

        return ((delegate* unmanaged<nint, Selector, nuint, nuint, nuint, nuint, nint>)msgSend)(receiver, selector, a, b, c, d);
    }

    public static nint MsgSendNInt(nint receiver, Selector selector, out nint a)
    {
        if (receiver is 0)
        {
            a = default;
            return default;
        }

        fixed (nint* aPtr = &a)
        {
            return ((delegate* unmanaged<nint, Selector, nint*, nint>)msgSend)(receiver, selector, aPtr);
        }
    }

    public static nint MsgSendNInt(nint receiver, Selector selector, uint a)
    {
        if (receiver is 0)
        {
            return default;
        }

        return ((delegate* unmanaged<nint, Selector, uint, nint>)msgSend)(receiver, selector, a);
    }

    public static nint MsgSendNInt(nint receiver, Selector selector, ulong a)
    {
        if (receiver is 0)
        {
            return default;
        }

        return ((delegate* unmanaged<nint, Selector, ulong, nint>)msgSend)(receiver, selector, a);
    }

    #endregion

    #region MsgSendNSRange

    public static NSRange MsgSendNSRange(nint receiver, Selector selector)
    {
        if (receiver is 0)
        {
            return default;
        }

        return ((delegate* unmanaged<nint, Selector, NSRange>)msgSend)(receiver, selector);
    }

    #endregion

    #region MsgSendNUInt

    public static nuint MsgSendNUInt(nint receiver, Selector selector)
    {
        if (receiver is 0)
        {
            return default;
        }

        return ((delegate* unmanaged<nint, Selector, nuint>)msgSend)(receiver, selector);
    }

    public static nuint MsgSendNUInt(nint receiver, Selector selector, MTLSize a)
    {
        if (receiver is 0)
        {
            return default;
        }

        return ((delegate* unmanaged<nint, Selector, MTLSize, nuint>)msgSend)(receiver, selector, a);
    }

    public static nuint MsgSendNUInt(nint receiver, Selector selector, nint a)
    {
        if (receiver is 0)
        {
            return default;
        }

        return ((delegate* unmanaged<nint, Selector, nint, nuint>)msgSend)(receiver, selector, a);
    }

    public static nuint MsgSendNUInt(nint receiver, Selector selector, nint a, nuint b)
    {
        if (receiver is 0)
        {
            return default;
        }

        return ((delegate* unmanaged<nint, Selector, nint, nuint, nuint>)msgSend)(receiver, selector, a, b);
    }

    public static nuint MsgSendNUInt(nint receiver, Selector selector, nuint a)
    {
        if (receiver is 0)
        {
            return default;
        }

        return ((delegate* unmanaged<nint, Selector, nuint, nuint>)msgSend)(receiver, selector, a);
    }

    #endregion

    #region MsgSendSimdFloat4x4

    public static SimdFloat4x4 MsgSendSimdFloat4x4(nint receiver, Selector selector)
    {
        if (receiver is 0)
        {
            return default;
        }

        return ((delegate* unmanaged<nint, Selector, SimdFloat4x4>)msgSend)(receiver, selector);
    }

    #endregion

    #region MsgSendUInt

    public static uint MsgSendUInt(nint receiver, Selector selector)
    {
        if (receiver is 0)
        {
            return default;
        }

        return ((delegate* unmanaged<nint, Selector, uint>)msgSend)(receiver, selector);
    }

    #endregion

    #region MsgSendULong

    public static ulong MsgSendULong(nint receiver, Selector selector)
    {
        if (receiver is 0)
        {
            return default;
        }

        return ((delegate* unmanaged<nint, Selector, ulong>)msgSend)(receiver, selector);
    }

    public static ulong MsgSendULong(nint receiver, Selector selector, nuint a)
    {
        if (receiver is 0)
        {
            return default;
        }

        return ((delegate* unmanaged<nint, Selector, nuint, ulong>)msgSend)(receiver, selector, a);
    }

    #endregion

    public static nint Alloc(nint @class)
    {
        return MsgSendNInt(@class, "alloc");
    }

    public static nint Init(nint receiver)
    {
        return MsgSendNInt(receiver, "init");
    }

    public static nint AllocInit(nint @class)
    {
        return Init(Alloc(@class));
    }

    public static nint Retain(nint receiver)
    {
        return MsgSendNInt(receiver, "retain");
    }

    public static void Release(nint receiver)
    {
        MsgSend(receiver, "release");
    }
}
