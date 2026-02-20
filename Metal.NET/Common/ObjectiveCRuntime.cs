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
    public static partial void MsgSend(nint receiver, Selector selector);

    [LibraryImport("/usr/lib/libobjc.A.dylib", EntryPoint = "objc_msgSend")]
    public static partial void MsgSend(nint receiver, Selector selector, Bool8 a);

    [LibraryImport("/usr/lib/libobjc.A.dylib", EntryPoint = "objc_msgSend")]
    public static partial void MsgSend(nint receiver, Selector selector, CGSize a);

    [LibraryImport("/usr/lib/libobjc.A.dylib", EntryPoint = "objc_msgSend")]
    public static partial void MsgSend(nint receiver, Selector selector, MTL4BufferRange a);

    [LibraryImport("/usr/lib/libobjc.A.dylib", EntryPoint = "objc_msgSend")]
    public static partial void MsgSend(nint receiver, Selector selector, MTLClearColor a);

    [LibraryImport("/usr/lib/libobjc.A.dylib", EntryPoint = "objc_msgSend")]
    public static partial void MsgSend(nint receiver, Selector selector, MTLRegion a);

    [LibraryImport("/usr/lib/libobjc.A.dylib", EntryPoint = "objc_msgSend")]
    public static partial void MsgSend(nint receiver, Selector selector, MTLRegion a, MTLRegion b, MTLSize c, nuint d);

    [LibraryImport("/usr/lib/libobjc.A.dylib", EntryPoint = "objc_msgSend")]
    public static partial void MsgSend(nint receiver, Selector selector, MTLRegion a, MTLRegion b, MTLSize c, nuint d, nuint e);

    [LibraryImport("/usr/lib/libobjc.A.dylib", EntryPoint = "objc_msgSend")]
    public static partial void MsgSend(nint receiver, Selector selector, MTLRegion a, nuint b, nint c, nuint d);

    [LibraryImport("/usr/lib/libobjc.A.dylib", EntryPoint = "objc_msgSend")]
    public static partial void MsgSend(nint receiver, Selector selector, MTLRegion a, nuint b, nuint c, nint d, nuint e, nuint f);

    [LibraryImport("/usr/lib/libobjc.A.dylib", EntryPoint = "objc_msgSend")]
    public static partial void MsgSend(nint receiver, Selector selector, MTLResourceID a, nuint b);

    [LibraryImport("/usr/lib/libobjc.A.dylib", EntryPoint = "objc_msgSend")]
    public static partial void MsgSend(nint receiver, Selector selector, MTLSamplePosition a, nuint b);

    [LibraryImport("/usr/lib/libobjc.A.dylib", EntryPoint = "objc_msgSend")]
    public static partial void MsgSend(nint receiver, Selector selector, MTLScissorRect a);

    [LibraryImport("/usr/lib/libobjc.A.dylib", EntryPoint = "objc_msgSend")]
    public static partial void MsgSend(nint receiver, Selector selector, MTLScissorRect a, nuint b);

    [LibraryImport("/usr/lib/libobjc.A.dylib", EntryPoint = "objc_msgSend")]
    public static partial void MsgSend(nint receiver, Selector selector, MTLSize a);

    [LibraryImport("/usr/lib/libobjc.A.dylib", EntryPoint = "objc_msgSend")]
    public static partial void MsgSend(nint receiver, Selector selector, MTLSize a, MTLSize b);

    [LibraryImport("/usr/lib/libobjc.A.dylib", EntryPoint = "objc_msgSend")]
    public static partial void MsgSend(nint receiver, Selector selector, MTLSize a, MTLSize b, MTLSize c);

    [LibraryImport("/usr/lib/libobjc.A.dylib", EntryPoint = "objc_msgSend")]
    public static partial void MsgSend(nint receiver, Selector selector, MTLTextureSwizzleChannels a);

    [LibraryImport("/usr/lib/libobjc.A.dylib", EntryPoint = "objc_msgSend")]
    public static partial void MsgSend(nint receiver, Selector selector, MTLViewport a);

    [LibraryImport("/usr/lib/libobjc.A.dylib", EntryPoint = "objc_msgSend")]
    public static partial void MsgSend(nint receiver, Selector selector, MTLViewport a, nuint b);

    [LibraryImport("/usr/lib/libobjc.A.dylib", EntryPoint = "objc_msgSend")]
    public static partial void MsgSend(nint receiver, Selector selector, NSRange a);

    [LibraryImport("/usr/lib/libobjc.A.dylib", EntryPoint = "objc_msgSend")]
    public static partial void MsgSend(nint receiver, Selector selector, double a);

    [LibraryImport("/usr/lib/libobjc.A.dylib", EntryPoint = "objc_msgSend")]
    public static partial void MsgSend(nint receiver, Selector selector, float a);

    [LibraryImport("/usr/lib/libobjc.A.dylib", EntryPoint = "objc_msgSend")]
    public static partial void MsgSend(nint receiver, Selector selector, float a, float b);

    [LibraryImport("/usr/lib/libobjc.A.dylib", EntryPoint = "objc_msgSend")]
    public static partial void MsgSend(nint receiver, Selector selector, float a, float b, float c);

    [LibraryImport("/usr/lib/libobjc.A.dylib", EntryPoint = "objc_msgSend")]
    public static partial void MsgSend(nint receiver, Selector selector, float a, float b, float c, float d);

    [LibraryImport("/usr/lib/libobjc.A.dylib", EntryPoint = "objc_msgSend")]
    public static partial void MsgSend(nint receiver, Selector selector, nint a);

    [LibraryImport("/usr/lib/libobjc.A.dylib", EntryPoint = "objc_msgSend")]
    public static partial void MsgSend(nint receiver, Selector selector, nint a, MTL4BufferRange b);

    [LibraryImport("/usr/lib/libobjc.A.dylib", EntryPoint = "objc_msgSend")]
    public static partial void MsgSend(nint receiver, Selector selector, nint a, MTLRegion b, nuint c, nuint d);

    [LibraryImport("/usr/lib/libobjc.A.dylib", EntryPoint = "objc_msgSend")]
    public static partial void MsgSend(nint receiver, Selector selector, nint a, MTLRegion b, nuint c, nuint d, Bool8 e, nint f, nuint g);

    [LibraryImport("/usr/lib/libobjc.A.dylib", EntryPoint = "objc_msgSend")]
    public static partial void MsgSend(nint receiver, Selector selector, nint a, NSRange b);

    [LibraryImport("/usr/lib/libobjc.A.dylib", EntryPoint = "objc_msgSend")]
    public static partial void MsgSend(nint receiver, Selector selector, nint a, NSRange b, MTL4BufferRange c, nint d, nint e);

    [LibraryImport("/usr/lib/libobjc.A.dylib", EntryPoint = "objc_msgSend")]
    public static partial void MsgSend(nint receiver, Selector selector, nint a, NSRange b, byte c);

    [LibraryImport("/usr/lib/libobjc.A.dylib", EntryPoint = "objc_msgSend")]
    public static partial void MsgSend(nint receiver, Selector selector, nint a, NSRange b, nint c, nuint d);

    [LibraryImport("/usr/lib/libobjc.A.dylib", EntryPoint = "objc_msgSend")]
    public static partial void MsgSend(nint receiver, Selector selector, nint a, double b);

    [LibraryImport("/usr/lib/libobjc.A.dylib", EntryPoint = "objc_msgSend")]
    public static partial void MsgSend(nint receiver, Selector selector, nint a, float b, float c, nuint d);

    [LibraryImport("/usr/lib/libobjc.A.dylib", EntryPoint = "objc_msgSend")]
    public static partial void MsgSend(nint receiver, Selector selector, nint a, nint b);

    [LibraryImport("/usr/lib/libobjc.A.dylib", EntryPoint = "objc_msgSend")]
    public static partial void MsgSend(nint receiver, Selector selector, nint a, nint b, MTL4BufferRange c);

    [LibraryImport("/usr/lib/libobjc.A.dylib", EntryPoint = "objc_msgSend")]
    public static partial void MsgSend(nint receiver, Selector selector, nint a, nint b, MTL4CopySparseBufferMappingOperation c, nuint d);

    [LibraryImport("/usr/lib/libobjc.A.dylib", EntryPoint = "objc_msgSend")]
    public static partial void MsgSend(nint receiver, Selector selector, nint a, nint b, MTL4CopySparseTextureMappingOperation c, nuint d);

    [LibraryImport("/usr/lib/libobjc.A.dylib", EntryPoint = "objc_msgSend")]
    public static partial void MsgSend(nint receiver, Selector selector, nint a, nint b, MTL4UpdateSparseBufferMappingOperation c, nuint d);

    [LibraryImport("/usr/lib/libobjc.A.dylib", EntryPoint = "objc_msgSend")]
    public static partial void MsgSend(nint receiver, Selector selector, nint a, nint b, MTL4UpdateSparseTextureMappingOperation c, nuint d);

    [LibraryImport("/usr/lib/libobjc.A.dylib", EntryPoint = "objc_msgSend")]
    public static partial void MsgSend(nint receiver, Selector selector, nint a, nint b, nint c, MTL4BufferRange d);

    [LibraryImport("/usr/lib/libobjc.A.dylib", EntryPoint = "objc_msgSend")]
    public static partial void MsgSend(nint receiver, Selector selector, nint a, nint b, nint c, MTL4BufferRange d, nuint e);

    [LibraryImport("/usr/lib/libobjc.A.dylib", EntryPoint = "objc_msgSend")]
    public static partial void MsgSend(nint receiver, Selector selector, nint a, nint b, nint c, nint d);

    [LibraryImport("/usr/lib/libobjc.A.dylib", EntryPoint = "objc_msgSend")]
    public static partial void MsgSend(nint receiver, Selector selector, nint a, nint b, nint c, nint d, nint e, nint f);

    [LibraryImport("/usr/lib/libobjc.A.dylib", EntryPoint = "objc_msgSend")]
    public static partial void MsgSend(nint receiver, Selector selector, nint a, nint b, nint c, nint d, nuint e);

    [LibraryImport("/usr/lib/libobjc.A.dylib", EntryPoint = "objc_msgSend")]
    public static partial void MsgSend(nint receiver, Selector selector, nint a, nint b, nint c, nint d, nuint e, nuint f);

    [LibraryImport("/usr/lib/libobjc.A.dylib", EntryPoint = "objc_msgSend")]
    public static partial void MsgSend(nint receiver, Selector selector, nint a, nint b, nint c, nuint d);

    [LibraryImport("/usr/lib/libobjc.A.dylib", EntryPoint = "objc_msgSend")]
    public static partial void MsgSend(nint receiver, Selector selector, nint a, nint b, nuint c);

    [LibraryImport("/usr/lib/libobjc.A.dylib", EntryPoint = "objc_msgSend")]
    public static partial void MsgSend(nint receiver, Selector selector, nint a, nint b, nuint c, nuint d);

    [LibraryImport("/usr/lib/libobjc.A.dylib", EntryPoint = "objc_msgSend")]
    public static partial void MsgSend(nint receiver, Selector selector, nint a, nuint b);

    [LibraryImport("/usr/lib/libobjc.A.dylib", EntryPoint = "objc_msgSend")]
    public static partial void MsgSend(nint receiver, Selector selector, nint a, nuint b, Bool8 c);

    [LibraryImport("/usr/lib/libobjc.A.dylib", EntryPoint = "objc_msgSend")]
    public static partial void MsgSend(nint receiver, Selector selector, nint a, nuint b, MTLRegion c, nint d, nint e, nuint f);

    [LibraryImport("/usr/lib/libobjc.A.dylib", EntryPoint = "objc_msgSend")]
    public static partial void MsgSend(nint receiver, Selector selector, nint a, nuint b, MTLRegion c, nuint d);

    [LibraryImport("/usr/lib/libobjc.A.dylib", EntryPoint = "objc_msgSend")]
    public static partial void MsgSend(nint receiver, Selector selector, nint a, nuint b, MTLRegion c, nuint d, nuint e);

    [LibraryImport("/usr/lib/libobjc.A.dylib", EntryPoint = "objc_msgSend")]
    public static partial void MsgSend(nint receiver, Selector selector, nint a, nuint b, MTLSize c);

    [LibraryImport("/usr/lib/libobjc.A.dylib", EntryPoint = "objc_msgSend")]
    public static partial void MsgSend(nint receiver, Selector selector, nint a, nuint b, MTLSize c, MTLSize d);

    [LibraryImport("/usr/lib/libobjc.A.dylib", EntryPoint = "objc_msgSend")]
    public static partial void MsgSend(nint receiver, Selector selector, nint a, nuint b, NSRange c);

    [LibraryImport("/usr/lib/libobjc.A.dylib", EntryPoint = "objc_msgSend")]
    public static partial void MsgSend(nint receiver, Selector selector, nint a, nuint b, nint c);

    [LibraryImport("/usr/lib/libobjc.A.dylib", EntryPoint = "objc_msgSend")]
    public static partial void MsgSend(nint receiver, Selector selector, nint a, nuint b, nint c, nuint d);

    [LibraryImport("/usr/lib/libobjc.A.dylib", EntryPoint = "objc_msgSend")]
    public static partial void MsgSend(nint receiver, Selector selector, nint a, nuint b, nint c, nuint d, nuint e);

    [LibraryImport("/usr/lib/libobjc.A.dylib", EntryPoint = "objc_msgSend")]
    public static partial void MsgSend(nint receiver, Selector selector, nint a, nuint b, nuint c);

    [LibraryImport("/usr/lib/libobjc.A.dylib", EntryPoint = "objc_msgSend")]
    public static partial void MsgSend(nint receiver, Selector selector, nint a, nuint b, nuint c, MTLOrigin d, MTLSize e, nint f, nuint g, nuint h, MTLOrigin i);

    [LibraryImport("/usr/lib/libobjc.A.dylib", EntryPoint = "objc_msgSend")]
    public static partial void MsgSend(nint receiver, Selector selector, nint a, nuint b, nuint c, MTLOrigin d, MTLSize e, nint f, nuint g, nuint h, nuint i);

    [LibraryImport("/usr/lib/libobjc.A.dylib", EntryPoint = "objc_msgSend")]
    public static partial void MsgSend(nint receiver, Selector selector, nint a, nuint b, nuint c, MTLOrigin d, MTLSize e, nint f, nuint g, nuint h, nuint i, nuint j);

    [LibraryImport("/usr/lib/libobjc.A.dylib", EntryPoint = "objc_msgSend")]
    public static partial void MsgSend(nint receiver, Selector selector, nint a, nuint b, nuint c, MTLRegion d, nuint e, nuint f);

    [LibraryImport("/usr/lib/libobjc.A.dylib", EntryPoint = "objc_msgSend")]
    public static partial void MsgSend(nint receiver, Selector selector, nint a, nuint b, nuint c, MTLSize d, nuint e, nuint f, MTLOrigin g, nint h, nuint i);

    [LibraryImport("/usr/lib/libobjc.A.dylib", EntryPoint = "objc_msgSend")]
    public static partial void MsgSend(nint receiver, Selector selector, nint a, nuint b, nuint c, nint d, nuint e);

    [LibraryImport("/usr/lib/libobjc.A.dylib", EntryPoint = "objc_msgSend")]
    public static partial void MsgSend(nint receiver, Selector selector, nint a, nuint b, nuint c, nint d, nuint e, nuint f, nuint g, nuint h);

    [LibraryImport("/usr/lib/libobjc.A.dylib", EntryPoint = "objc_msgSend")]
    public static partial void MsgSend(nint receiver, Selector selector, nint a, nuint b, nuint c, nuint d);

    [LibraryImport("/usr/lib/libobjc.A.dylib", EntryPoint = "objc_msgSend")]
    public static partial void MsgSend(nint receiver, Selector selector, nint a, nuint b, nuint c, nuint d, MTLSize e, nint f, nuint g, nuint h, MTLOrigin i);

    [LibraryImport("/usr/lib/libobjc.A.dylib", EntryPoint = "objc_msgSend")]
    public static partial void MsgSend(nint receiver, Selector selector, nint a, nuint b, nuint c, nuint d, MTLSize e, nint f, nuint g, nuint h, MTLOrigin i, nuint j);

    [LibraryImport("/usr/lib/libobjc.A.dylib", EntryPoint = "objc_msgSend")]
    public static partial void MsgSend(nint receiver, Selector selector, nuint a);

    [LibraryImport("/usr/lib/libobjc.A.dylib", EntryPoint = "objc_msgSend")]
    public static partial void MsgSend(nint receiver, Selector selector, nuint a, MTLSize b);

    [LibraryImport("/usr/lib/libobjc.A.dylib", EntryPoint = "objc_msgSend")]
    public static partial void MsgSend(nint receiver, Selector selector, nuint a, MTLSize b, MTLSize c);

    [LibraryImport("/usr/lib/libobjc.A.dylib", EntryPoint = "objc_msgSend")]
    public static partial void MsgSend(nint receiver, Selector selector, nuint a, MTLVertexAmplificationViewMapping b);

    [LibraryImport("/usr/lib/libobjc.A.dylib", EntryPoint = "objc_msgSend")]
    public static partial void MsgSend(nint receiver, Selector selector, nuint a, NSRange b);

    [LibraryImport("/usr/lib/libobjc.A.dylib", EntryPoint = "objc_msgSend")]
    public static partial void MsgSend(nint receiver, Selector selector, nuint a, nint b, nuint c);

    [LibraryImport("/usr/lib/libobjc.A.dylib", EntryPoint = "objc_msgSend")]
    public static partial void MsgSend(nint receiver, Selector selector, nuint a, nint b, nuint c, nint d, nuint e);

    [LibraryImport("/usr/lib/libobjc.A.dylib", EntryPoint = "objc_msgSend")]
    public static partial void MsgSend(nint receiver, Selector selector, nuint a, nint b, nuint c, nint d, nuint e, nint f, nuint g);

    [LibraryImport("/usr/lib/libobjc.A.dylib", EntryPoint = "objc_msgSend")]
    public static partial void MsgSend(nint receiver, Selector selector, nuint a, nuint b);

    [LibraryImport("/usr/lib/libobjc.A.dylib", EntryPoint = "objc_msgSend")]
    public static partial void MsgSend(nint receiver, Selector selector, nuint a, nuint b, nint c, nuint d, nint e, nuint f);

    [LibraryImport("/usr/lib/libobjc.A.dylib", EntryPoint = "objc_msgSend")]
    public static partial void MsgSend(nint receiver, Selector selector, nuint a, nuint b, nuint c);

    [LibraryImport("/usr/lib/libobjc.A.dylib", EntryPoint = "objc_msgSend")]
    public static partial void MsgSend(nint receiver, Selector selector, nuint a, nuint b, nuint c, nint d, nuint e);

    [LibraryImport("/usr/lib/libobjc.A.dylib", EntryPoint = "objc_msgSend")]
    public static partial void MsgSend(nint receiver, Selector selector, nuint a, nuint b, nuint c, nint d, nuint e, nint f, nuint g, nuint h, nuint i);

    [LibraryImport("/usr/lib/libobjc.A.dylib", EntryPoint = "objc_msgSend")]
    public static partial void MsgSend(nint receiver, Selector selector, nuint a, nuint b, nuint c, nint d, nuint e, nint f, nuint g, nuint h, nuint i, nint j, nuint k, nuint l);

    [LibraryImport("/usr/lib/libobjc.A.dylib", EntryPoint = "objc_msgSend")]
    public static partial void MsgSend(nint receiver, Selector selector, nuint a, nuint b, nuint c, nint d, nuint e, nuint f);

    [LibraryImport("/usr/lib/libobjc.A.dylib", EntryPoint = "objc_msgSend")]
    public static partial void MsgSend(nint receiver, Selector selector, nuint a, nuint b, nuint c, nint d, nuint e, nuint f, nint g, nuint h);

    [LibraryImport("/usr/lib/libobjc.A.dylib", EntryPoint = "objc_msgSend")]
    public static partial void MsgSend(nint receiver, Selector selector, nuint a, nuint b, nuint c, nint d, nuint e, nuint f, nuint g);

    [LibraryImport("/usr/lib/libobjc.A.dylib", EntryPoint = "objc_msgSend")]
    public static partial void MsgSend(nint receiver, Selector selector, nuint a, nuint b, nuint c, nint d, nuint e, nuint f, nuint g, nint h, nuint i, nuint j);

    [LibraryImport("/usr/lib/libobjc.A.dylib", EntryPoint = "objc_msgSend")]
    public static partial void MsgSend(nint receiver, Selector selector, nuint a, nuint b, nuint c, nuint d);

    [LibraryImport("/usr/lib/libobjc.A.dylib", EntryPoint = "objc_msgSend")]
    public static partial void MsgSend(nint receiver, Selector selector, nuint a, nuint b, nuint c, nuint d, nuint e);

    [LibraryImport("/usr/lib/libobjc.A.dylib", EntryPoint = "objc_msgSend")]
    public static partial void MsgSend(nint receiver, Selector selector, nuint a, nuint b, nuint c, nuint d, nuint e, nuint f);

    [LibraryImport("/usr/lib/libobjc.A.dylib", EntryPoint = "objc_msgSend")]
    public static partial void MsgSend(nint receiver, Selector selector, nuint a, nuint b, nuint c, nuint d, nuint e, nuint f, nint g, nuint h);

    [LibraryImport("/usr/lib/libobjc.A.dylib", EntryPoint = "objc_msgSend")]
    public static partial void MsgSend(nint receiver, Selector selector, int a);

    [LibraryImport("/usr/lib/libobjc.A.dylib", EntryPoint = "objc_msgSend")]
    public static partial void MsgSend(nint receiver, Selector selector, uint a);

    [LibraryImport("/usr/lib/libobjc.A.dylib", EntryPoint = "objc_msgSend")]
    public static partial void MsgSend(nint receiver, Selector selector, uint a, uint b);

    [LibraryImport("/usr/lib/libobjc.A.dylib", EntryPoint = "objc_msgSend")]
    public static partial void MsgSend(nint receiver, Selector selector, ulong a);

    #endregion

    #region MsgSendBool

    [LibraryImport("/usr/lib/libobjc.A.dylib", EntryPoint = "objc_msgSend")]
    public static partial Bool8 MsgSendBool(nint receiver, Selector selector);

    [LibraryImport("/usr/lib/libobjc.A.dylib", EntryPoint = "objc_msgSend")]
    public static partial Bool8 MsgSendBool(nint receiver, Selector selector, nint a);

    [LibraryImport("/usr/lib/libobjc.A.dylib", EntryPoint = "objc_msgSend")]
    public static partial Bool8 MsgSendBool(nint receiver, Selector selector, nint a, nint b, out nint c);

    [LibraryImport("/usr/lib/libobjc.A.dylib", EntryPoint = "objc_msgSend")]
    public static partial Bool8 MsgSendBool(nint receiver, Selector selector, nint a, out nint b);

    [LibraryImport("/usr/lib/libobjc.A.dylib", EntryPoint = "objc_msgSend")]
    public static partial Bool8 MsgSendBool(nint receiver, Selector selector, nuint a);

    [LibraryImport("/usr/lib/libobjc.A.dylib", EntryPoint = "objc_msgSend")]
    public static partial Bool8 MsgSendBool(nint receiver, Selector selector, nuint a, nuint b);

    #endregion

    #region MsgSendCGSize

    [LibraryImport("/usr/lib/libobjc.A.dylib", EntryPoint = "objc_msgSend")]
    public static partial CGSize MsgSendCGSize(nint receiver, Selector selector);

    #endregion

    #region MsgSendDouble

    [LibraryImport("/usr/lib/libobjc.A.dylib", EntryPoint = "objc_msgSend")]
    public static partial double MsgSendDouble(nint receiver, Selector selector);

    #endregion

    #region MsgSendFloat

    [LibraryImport("/usr/lib/libobjc.A.dylib", EntryPoint = "objc_msgSend")]
    public static partial float MsgSendFloat(nint receiver, Selector selector);

    [LibraryImport("/usr/lib/libobjc.A.dylib", EntryPoint = "objc_msgSend")]
    public static partial float MsgSendFloat(nint receiver, Selector selector, nint a);

    #endregion

    #region MsgSendMTL4BufferRange

    [LibraryImport("/usr/lib/libobjc.A.dylib", EntryPoint = "objc_msgSend")]
    public static partial MTL4BufferRange MsgSendMTL4BufferRange(nint receiver, Selector selector);

    #endregion

    #region MsgSendMTLAccelerationStructureSizes

    [LibraryImport("/usr/lib/libobjc.A.dylib", EntryPoint = "objc_msgSend")]
    public static partial MTLAccelerationStructureSizes MsgSendMTLAccelerationStructureSizes(nint receiver, Selector selector, nint a);

    #endregion

    #region MsgSendMTLClearColor

    [LibraryImport("/usr/lib/libobjc.A.dylib", EntryPoint = "objc_msgSend")]
    public static partial MTLClearColor MsgSendMTLClearColor(nint receiver, Selector selector);

    #endregion

    #region MsgSendMTLResourceID

    [LibraryImport("/usr/lib/libobjc.A.dylib", EntryPoint = "objc_msgSend")]
    public static partial MTLResourceID MsgSendMTLResourceID(nint receiver, Selector selector);

    [LibraryImport("/usr/lib/libobjc.A.dylib", EntryPoint = "objc_msgSend")]
    public static partial MTLResourceID MsgSendMTLResourceID(nint receiver, Selector selector, nint a, NSRange b, nuint c);

    [LibraryImport("/usr/lib/libobjc.A.dylib", EntryPoint = "objc_msgSend")]
    public static partial MTLResourceID MsgSendMTLResourceID(nint receiver, Selector selector, nint a, nint b, nuint c);

    [LibraryImport("/usr/lib/libobjc.A.dylib", EntryPoint = "objc_msgSend")]
    public static partial MTLResourceID MsgSendMTLResourceID(nint receiver, Selector selector, nint a, nint b, nuint c, nuint d, nuint e);

    [LibraryImport("/usr/lib/libobjc.A.dylib", EntryPoint = "objc_msgSend")]
    public static partial MTLResourceID MsgSendMTLResourceID(nint receiver, Selector selector, nint a, nuint b);

    #endregion

    #region MsgSendMTLSamplePosition

    [LibraryImport("/usr/lib/libobjc.A.dylib", EntryPoint = "objc_msgSend")]
    public static partial MTLSamplePosition MsgSendMTLSamplePosition(nint receiver, Selector selector, MTLSamplePosition a, nuint b);

    #endregion

    #region MsgSendMTLSize

    [LibraryImport("/usr/lib/libobjc.A.dylib", EntryPoint = "objc_msgSend")]
    public static partial MTLSize MsgSendMTLSize(nint receiver, Selector selector);

    [LibraryImport("/usr/lib/libobjc.A.dylib", EntryPoint = "objc_msgSend")]
    public static partial MTLSize MsgSendMTLSize(nint receiver, Selector selector, nuint a);

    [LibraryImport("/usr/lib/libobjc.A.dylib", EntryPoint = "objc_msgSend")]
    public static partial MTLSize MsgSendMTLSize(nint receiver, Selector selector, nuint a, nuint b, nuint c);

    [LibraryImport("/usr/lib/libobjc.A.dylib", EntryPoint = "objc_msgSend")]
    public static partial MTLSize MsgSendMTLSize(nint receiver, Selector selector, nuint a, nuint b, nuint c, nint d);

    #endregion

    #region MsgSendMTLSizeAndAlign

    [LibraryImport("/usr/lib/libobjc.A.dylib", EntryPoint = "objc_msgSend")]
    public static partial MTLSizeAndAlign MsgSendMTLSizeAndAlign(nint receiver, Selector selector);

    [LibraryImport("/usr/lib/libobjc.A.dylib", EntryPoint = "objc_msgSend")]
    public static partial MTLSizeAndAlign MsgSendMTLSizeAndAlign(nint receiver, Selector selector, nint a);

    [LibraryImport("/usr/lib/libobjc.A.dylib", EntryPoint = "objc_msgSend")]
    public static partial MTLSizeAndAlign MsgSendMTLSizeAndAlign(nint receiver, Selector selector, nuint a);

    [LibraryImport("/usr/lib/libobjc.A.dylib", EntryPoint = "objc_msgSend")]
    public static partial MTLSizeAndAlign MsgSendMTLSizeAndAlign(nint receiver, Selector selector, nuint a, nuint b);

    #endregion

    #region MsgSendMTLTextureSwizzleChannels

    [LibraryImport("/usr/lib/libobjc.A.dylib", EntryPoint = "objc_msgSend")]
    public static partial MTLTextureSwizzleChannels MsgSendMTLTextureSwizzleChannels(nint receiver, Selector selector);

    #endregion

    #region MsgSendNSRange

    [LibraryImport("/usr/lib/libobjc.A.dylib", EntryPoint = "objc_msgSend")]
    public static partial NSRange MsgSendNSRange(nint receiver, Selector selector);

    #endregion

    #region MsgSendNUInt

    [LibraryImport("/usr/lib/libobjc.A.dylib", EntryPoint = "objc_msgSend")]
    public static partial nuint MsgSendNUInt(nint receiver, Selector selector);

    [LibraryImport("/usr/lib/libobjc.A.dylib", EntryPoint = "objc_msgSend")]
    public static partial nuint MsgSendNUInt(nint receiver, Selector selector, MTLSamplePosition a, nuint b);

    [LibraryImport("/usr/lib/libobjc.A.dylib", EntryPoint = "objc_msgSend")]
    public static partial nuint MsgSendNUInt(nint receiver, Selector selector, MTLSize a);

    [LibraryImport("/usr/lib/libobjc.A.dylib", EntryPoint = "objc_msgSend")]
    public static partial nuint MsgSendNUInt(nint receiver, Selector selector, nint a);

    [LibraryImport("/usr/lib/libobjc.A.dylib", EntryPoint = "objc_msgSend")]
    public static partial nuint MsgSendNUInt(nint receiver, Selector selector, nint a, nuint b);

    [LibraryImport("/usr/lib/libobjc.A.dylib", EntryPoint = "objc_msgSend")]
    public static partial nuint MsgSendNUInt(nint receiver, Selector selector, nuint a);

    #endregion

    #region MsgSendPtr

    [LibraryImport("/usr/lib/libobjc.A.dylib", EntryPoint = "objc_msgSend")]
    public static partial nint MsgSendPtr(nint receiver, Selector selector);

    [LibraryImport("/usr/lib/libobjc.A.dylib", EntryPoint = "objc_msgSend")]
    public static partial nint MsgSendPtr(nint receiver, Selector selector, MTLSize a);

    [LibraryImport("/usr/lib/libobjc.A.dylib", EntryPoint = "objc_msgSend")]
    public static partial nint MsgSendPtr(nint receiver, Selector selector, MTLSize a, nint b);

    [LibraryImport("/usr/lib/libobjc.A.dylib", EntryPoint = "objc_msgSend")]
    public static partial nint MsgSendPtr(nint receiver, Selector selector, MTLSize a, nuint b, nint c);

    [LibraryImport("/usr/lib/libobjc.A.dylib", EntryPoint = "objc_msgSend")]
    public static partial nint MsgSendPtr(nint receiver, Selector selector, NSRange a);

    [LibraryImport("/usr/lib/libobjc.A.dylib", EntryPoint = "objc_msgSend")]
    public static partial nint MsgSendPtr(nint receiver, Selector selector, nint a);

    [LibraryImport("/usr/lib/libobjc.A.dylib", EntryPoint = "objc_msgSend")]
    public static partial nint MsgSendPtr(nint receiver, Selector selector, nint a, nint b);

    [LibraryImport("/usr/lib/libobjc.A.dylib", EntryPoint = "objc_msgSend")]
    public static partial nint MsgSendPtr(nint receiver, Selector selector, nint a, nint b, nint c, out nint d);

    [LibraryImport("/usr/lib/libobjc.A.dylib", EntryPoint = "objc_msgSend")]
    public static partial nint MsgSendPtr(nint receiver, Selector selector, nint a, nint b, nuint c);

    [LibraryImport("/usr/lib/libobjc.A.dylib", EntryPoint = "objc_msgSend")]
    public static partial nint MsgSendPtr(nint receiver, Selector selector, nint a, nint b, out nint c);

    [LibraryImport("/usr/lib/libobjc.A.dylib", EntryPoint = "objc_msgSend")]
    public static partial nint MsgSendPtr(nint receiver, Selector selector, nint a, nuint b);

    [LibraryImport("/usr/lib/libobjc.A.dylib", EntryPoint = "objc_msgSend")]
    public static partial nint MsgSendPtr(nint receiver, Selector selector, nint a, nuint b, nuint c);

    [LibraryImport("/usr/lib/libobjc.A.dylib", EntryPoint = "objc_msgSend")]
    public static partial nint MsgSendPtr(nint receiver, Selector selector, nint a, nuint b, out nint c);

    [LibraryImport("/usr/lib/libobjc.A.dylib", EntryPoint = "objc_msgSend")]
    public static partial nint MsgSendPtr(nint receiver, Selector selector, nint a, out nint b);

    [LibraryImport("/usr/lib/libobjc.A.dylib", EntryPoint = "objc_msgSend")]
    public static partial nint MsgSendPtr(nint receiver, Selector selector, nuint a);

    [LibraryImport("/usr/lib/libobjc.A.dylib", EntryPoint = "objc_msgSend")]
    public static partial nint MsgSendPtr(nint receiver, Selector selector, nuint a, nuint b);

    [LibraryImport("/usr/lib/libobjc.A.dylib", EntryPoint = "objc_msgSend")]
    public static partial nint MsgSendPtr(nint receiver, Selector selector, nuint a, nuint b, Bool8 c);

    [LibraryImport("/usr/lib/libobjc.A.dylib", EntryPoint = "objc_msgSend")]
    public static partial nint MsgSendPtr(nint receiver, Selector selector, nuint a, nuint b, NSRange c, NSRange d);

    [LibraryImport("/usr/lib/libobjc.A.dylib", EntryPoint = "objc_msgSend")]
    public static partial nint MsgSendPtr(nint receiver, Selector selector, nuint a, nuint b, NSRange c, NSRange d, MTLTextureSwizzleChannels e);

    [LibraryImport("/usr/lib/libobjc.A.dylib", EntryPoint = "objc_msgSend")]
    public static partial nint MsgSendPtr(nint receiver, Selector selector, nuint a, nuint b, nint c);

    [LibraryImport("/usr/lib/libobjc.A.dylib", EntryPoint = "objc_msgSend")]
    public static partial nint MsgSendPtr(nint receiver, Selector selector, nuint a, nuint b, nuint c);

    [LibraryImport("/usr/lib/libobjc.A.dylib", EntryPoint = "objc_msgSend")]
    public static partial nint MsgSendPtr(nint receiver, Selector selector, nuint a, nuint b, nuint c, Bool8 d);

    [LibraryImport("/usr/lib/libobjc.A.dylib", EntryPoint = "objc_msgSend")]
    public static partial nint MsgSendPtr(nint receiver, Selector selector, nuint a, nuint b, nuint c, nuint d);

    #endregion

    #region MsgSendInt

    [LibraryImport("/usr/lib/libobjc.A.dylib", EntryPoint = "objc_msgSend")]
    public static partial int MsgSendInt(nint receiver, Selector selector);

    [LibraryImport("/usr/lib/libobjc.A.dylib", EntryPoint = "objc_msgSend")]
    public static partial int MsgSendInt(nint receiver, Selector selector, nint a);

    #endregion

    #region MsgSendUInt

    [LibraryImport("/usr/lib/libobjc.A.dylib", EntryPoint = "objc_msgSend")]
    public static partial uint MsgSendUInt(nint receiver, Selector selector);

    [LibraryImport("/usr/lib/libobjc.A.dylib", EntryPoint = "objc_msgSend")]
    public static partial uint MsgSendUInt(nint receiver, Selector selector, nint a);

    #endregion

    #region MsgSendULong

    [LibraryImport("/usr/lib/libobjc.A.dylib", EntryPoint = "objc_msgSend")]
    public static partial ulong MsgSendULong(nint receiver, Selector selector);

    #endregion

    public static nint AllocInit(nint @class)
    {
        return MsgSendPtr(MsgSendPtr(@class, (Selector)"alloc"), (Selector)"init");
    }

    public static nint Retain(nint receiver)
    {
        return MsgSendPtr(receiver, (Selector)"retain");
    }

    public static void Release(nint receiver)
    {
        MsgSend(receiver, (Selector)"release");
    }
}
