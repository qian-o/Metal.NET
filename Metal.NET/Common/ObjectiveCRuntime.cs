using System.Runtime.InteropServices;
using System.Text;

namespace Metal.NET;

internal static unsafe partial class ObjectiveCRuntime
{
    [LibraryImport("/usr/lib/libobjc.A.dylib", EntryPoint = "objc_getClass")]
    public static partial nint GetClass(byte* name);

    [LibraryImport("/usr/lib/libobjc.A.dylib", EntryPoint = "sel_registerName")]
    public static partial Selector RegisterName(byte* name);

    public static nint Retain(nint obj)
    {
        return MsgSendPtr(obj, Selector.Register("retain"));
    }

    public static void Release(nint obj)
    {
        MsgSend(obj, Selector.Register("release"));
    }

    public static nint GetClass(string name)
    {
        fixed (byte* utf8 = Encoding.UTF8.GetBytes(name + '\0'))
        {
            return GetClass(utf8);
        }
    }

    public static nint AllocInit(nint @class)
    {
        return MsgSendPtr(MsgSendPtr(@class, Selector.Register("alloc")), Selector.Register("init"));
    }

    #region MsgSend

    [LibraryImport("/usr/lib/libobjc.A.dylib", EntryPoint = "objc_msgSend")]
    public static partial void MsgSend(nint receiver, Selector selector);

    [LibraryImport("/usr/lib/libobjc.A.dylib", EntryPoint = "objc_msgSend")]
    public static partial void MsgSend(nint receiver, Selector selector, Bool8 a);

    [LibraryImport("/usr/lib/libobjc.A.dylib", EntryPoint = "objc_msgSend")]
    public static partial void MsgSend(nint receiver, Selector selector, CGSize a);

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
    public static partial void MsgSend(nint receiver, Selector selector, MTL4BufferRange a);

    [LibraryImport("/usr/lib/libobjc.A.dylib", EntryPoint = "objc_msgSend")]
    public static partial void MsgSend(nint receiver, Selector selector, MTLClearColor a);

    [LibraryImport("/usr/lib/libobjc.A.dylib", EntryPoint = "objc_msgSend")]
    public static partial void MsgSend(nint receiver, Selector selector, MTLRegion a);

    [LibraryImport("/usr/lib/libobjc.A.dylib", EntryPoint = "objc_msgSend")]
    public static partial void MsgSend(nint receiver, Selector selector, MTLRegion a, MTLRegion b, MTLSize c, nuint d);

    [LibraryImport("/usr/lib/libobjc.A.dylib", EntryPoint = "objc_msgSend")]
    public static partial void MsgSend(nint receiver, Selector selector, MTLRegion a, MTLRegion b, MTLSize c, ulong d, nuint e);

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
    public static partial void MsgSend(nint receiver, Selector selector, MTLViewport a);

    [LibraryImport("/usr/lib/libobjc.A.dylib", EntryPoint = "objc_msgSend")]
    public static partial void MsgSend(nint receiver, Selector selector, MTLViewport a, nuint b);

    [LibraryImport("/usr/lib/libobjc.A.dylib", EntryPoint = "objc_msgSend")]
    public static partial void MsgSend(nint receiver, Selector selector, nint a);

    [LibraryImport("/usr/lib/libobjc.A.dylib", EntryPoint = "objc_msgSend")]
    public static partial void MsgSend(nint receiver, Selector selector, nint a, double b);

    [LibraryImport("/usr/lib/libobjc.A.dylib", EntryPoint = "objc_msgSend")]
    public static partial void MsgSend(nint receiver, Selector selector, nint a, float b, float c, nuint d);

    [LibraryImport("/usr/lib/libobjc.A.dylib", EntryPoint = "objc_msgSend")]
    public static partial void MsgSend(nint receiver, Selector selector, nint a, MTL4BufferRange b);

    [LibraryImport("/usr/lib/libobjc.A.dylib", EntryPoint = "objc_msgSend")]
    public static partial void MsgSend(nint receiver, Selector selector, nint a, MTLRegion b, nuint c, nuint d);

    [LibraryImport("/usr/lib/libobjc.A.dylib", EntryPoint = "objc_msgSend")]
    public static partial void MsgSend(nint receiver, Selector selector, nint a, MTLRegion b, nuint c, nuint d, Bool8 e, nint f, nuint g);

    [LibraryImport("/usr/lib/libobjc.A.dylib", EntryPoint = "objc_msgSend")]
    public static partial void MsgSend(nint receiver, Selector selector, nint a, MTLSize b);

    [LibraryImport("/usr/lib/libobjc.A.dylib", EntryPoint = "objc_msgSend")]
    public static partial void MsgSend(nint receiver, Selector selector, nint a, MTLSize b, MTLSize c);

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
    public static partial void MsgSend(nint receiver, Selector selector, nint a, nint b, nint c, MTL4BufferRange d, ulong e);

    [LibraryImport("/usr/lib/libobjc.A.dylib", EntryPoint = "objc_msgSend")]
    public static partial void MsgSend(nint receiver, Selector selector, nint a, nint b, nint c, nint d);

    [LibraryImport("/usr/lib/libobjc.A.dylib", EntryPoint = "objc_msgSend")]
    public static partial void MsgSend(nint receiver, Selector selector, nint a, nint b, nint c, nint d, nint e, nint f);

    [LibraryImport("/usr/lib/libobjc.A.dylib", EntryPoint = "objc_msgSend")]
    public static partial void MsgSend(nint receiver, Selector selector, nint a, nint b, nint c, nint d, nuint e);

    [LibraryImport("/usr/lib/libobjc.A.dylib", EntryPoint = "objc_msgSend")]
    public static partial void MsgSend(nint receiver, Selector selector, nint a, nint b, nint c, nint d, nuint e, ulong f);

    [LibraryImport("/usr/lib/libobjc.A.dylib", EntryPoint = "objc_msgSend")]
    public static partial void MsgSend(nint receiver, Selector selector, nint a, nint b, nint c, nuint d);

    [LibraryImport("/usr/lib/libobjc.A.dylib", EntryPoint = "objc_msgSend")]
    public static partial void MsgSend(nint receiver, Selector selector, nint a, nint b, nuint c);

    [LibraryImport("/usr/lib/libobjc.A.dylib", EntryPoint = "objc_msgSend")]
    public static partial void MsgSend(nint receiver, Selector selector, nint a, nint b, nuint c, ulong d);

    [LibraryImport("/usr/lib/libobjc.A.dylib", EntryPoint = "objc_msgSend")]
    public static partial void MsgSend(nint receiver, Selector selector, nint a, NSRange b);

    [LibraryImport("/usr/lib/libobjc.A.dylib", EntryPoint = "objc_msgSend")]
    public static partial void MsgSend(nint receiver, Selector selector, nint a, NSRange b, byte c);

    [LibraryImport("/usr/lib/libobjc.A.dylib", EntryPoint = "objc_msgSend")]
    public static partial void MsgSend(nint receiver, Selector selector, nint a, NSRange b, MTL4BufferRange c, nint d, nint e);

    [LibraryImport("/usr/lib/libobjc.A.dylib", EntryPoint = "objc_msgSend")]
    public static partial void MsgSend(nint receiver, Selector selector, nint a, NSRange b, nint c, nuint d);

    [LibraryImport("/usr/lib/libobjc.A.dylib", EntryPoint = "objc_msgSend")]
    public static partial void MsgSend(nint receiver, Selector selector, nint a, nuint b);

    [LibraryImport("/usr/lib/libobjc.A.dylib", EntryPoint = "objc_msgSend")]
    public static partial void MsgSend(nint receiver, Selector selector, nint a, nuint b, Bool8 c);

    [LibraryImport("/usr/lib/libobjc.A.dylib", EntryPoint = "objc_msgSend")]
    public static partial void MsgSend(nint receiver, Selector selector, nint a, nuint b, MTLRegion c, nuint d);

    [LibraryImport("/usr/lib/libobjc.A.dylib", EntryPoint = "objc_msgSend")]
    public static partial void MsgSend(nint receiver, Selector selector, nint a, nuint b, MTLSize c);

    [LibraryImport("/usr/lib/libobjc.A.dylib", EntryPoint = "objc_msgSend")]
    public static partial void MsgSend(nint receiver, Selector selector, nint a, nuint b, MTLSize c, MTLSize d);

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
    public static partial void MsgSend(nint receiver, Selector selector, nint a, nuint b, nuint c, MTLOrigin d, MTLSize e, nint f, nuint g, nuint h, nuint i, ulong j);

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
    public static partial void MsgSend(nint receiver, Selector selector, nint a, nuint b, nuint c, nuint d, MTLSize e, nint f, nuint g, nuint h, MTLOrigin i, ulong j);

    [LibraryImport("/usr/lib/libobjc.A.dylib", EntryPoint = "objc_msgSend")]
    public static partial void MsgSend(nint receiver, Selector selector, nint a, nuint b, ulong c);

    [LibraryImport("/usr/lib/libobjc.A.dylib", EntryPoint = "objc_msgSend")]
    public static partial void MsgSend(nint receiver, Selector selector, nint a, ulong b);

    [LibraryImport("/usr/lib/libobjc.A.dylib", EntryPoint = "objc_msgSend")]
    public static partial void MsgSend(nint receiver, Selector selector, nint a, ulong b, MTLRegion c, nuint d, nuint e);

    [LibraryImport("/usr/lib/libobjc.A.dylib", EntryPoint = "objc_msgSend")]
    public static partial void MsgSend(nint receiver, Selector selector, nint a, ulong b, MTLRegion c, nuint d, nuint e, nuint f);

    [LibraryImport("/usr/lib/libobjc.A.dylib", EntryPoint = "objc_msgSend")]
    public static partial void MsgSend(nint receiver, Selector selector, nint a, ulong b, nint c);

    [LibraryImport("/usr/lib/libobjc.A.dylib", EntryPoint = "objc_msgSend")]
    public static partial void MsgSend(nint receiver, Selector selector, nint a, ulong b, nint c, nuint d);

    [LibraryImport("/usr/lib/libobjc.A.dylib", EntryPoint = "objc_msgSend")]
    public static partial void MsgSend(nint receiver, Selector selector, nint a, ulong b, NSRange c);

    [LibraryImport("/usr/lib/libobjc.A.dylib", EntryPoint = "objc_msgSend")]
    public static partial void MsgSend(nint receiver, Selector selector, nint a, ulong b, nuint c);

    [LibraryImport("/usr/lib/libobjc.A.dylib", EntryPoint = "objc_msgSend")]
    public static partial void MsgSend(nint receiver, Selector selector, nint a, ulong b, ulong c);

    [LibraryImport("/usr/lib/libobjc.A.dylib", EntryPoint = "objc_msgSend")]
    public static partial void MsgSend(nint receiver, Selector selector, NSRange a);

    [LibraryImport("/usr/lib/libobjc.A.dylib", EntryPoint = "objc_msgSend")]
    public static partial void MsgSend(nint receiver, Selector selector, nuint a);

    [LibraryImport("/usr/lib/libobjc.A.dylib", EntryPoint = "objc_msgSend")]
    public static partial void MsgSend(nint receiver, Selector selector, nuint a, MTLVertexAmplificationViewMapping b);

    [LibraryImport("/usr/lib/libobjc.A.dylib", EntryPoint = "objc_msgSend")]
    public static partial void MsgSend(nint receiver, Selector selector, nuint a, nint b, nuint c, nint d, nuint e);

    [LibraryImport("/usr/lib/libobjc.A.dylib", EntryPoint = "objc_msgSend")]
    public static partial void MsgSend(nint receiver, Selector selector, nuint a, nint b, nuint c, nint d, nuint e, nint f, nuint g);

    [LibraryImport("/usr/lib/libobjc.A.dylib", EntryPoint = "objc_msgSend")]
    public static partial void MsgSend(nint receiver, Selector selector, nuint a, nuint b);

    [LibraryImport("/usr/lib/libobjc.A.dylib", EntryPoint = "objc_msgSend")]
    public static partial void MsgSend(nint receiver, Selector selector, nuint a, nuint b, nuint c);

    [LibraryImport("/usr/lib/libobjc.A.dylib", EntryPoint = "objc_msgSend")]
    public static partial void MsgSend(nint receiver, Selector selector, nuint a, nuint b, nuint c, nint d, nuint e, nint f, nuint g, nuint h, nuint i);

    [LibraryImport("/usr/lib/libobjc.A.dylib", EntryPoint = "objc_msgSend")]
    public static partial void MsgSend(nint receiver, Selector selector, nuint a, nuint b, nuint c, nint d, nuint e, nint f, nuint g, nuint h, nuint i, nint j, nuint k, nuint l);

    [LibraryImport("/usr/lib/libobjc.A.dylib", EntryPoint = "objc_msgSend")]
    public static partial void MsgSend(nint receiver, Selector selector, nuint a, nuint b, nuint c, nint d, nuint e, nuint f, nuint g);

    [LibraryImport("/usr/lib/libobjc.A.dylib", EntryPoint = "objc_msgSend")]
    public static partial void MsgSend(nint receiver, Selector selector, nuint a, nuint b, nuint c, nint d, nuint e, nuint f, nuint g, nint h, nuint i, nuint j);

    [LibraryImport("/usr/lib/libobjc.A.dylib", EntryPoint = "objc_msgSend")]
    public static partial void MsgSend(nint receiver, Selector selector, uint a);

    [LibraryImport("/usr/lib/libobjc.A.dylib", EntryPoint = "objc_msgSend")]
    public static partial void MsgSend(nint receiver, Selector selector, uint a, uint b);

    [LibraryImport("/usr/lib/libobjc.A.dylib", EntryPoint = "objc_msgSend")]
    public static partial void MsgSend(nint receiver, Selector selector, ulong a);

    [LibraryImport("/usr/lib/libobjc.A.dylib", EntryPoint = "objc_msgSend")]
    public static partial void MsgSend(nint receiver, Selector selector, ulong a, nint b);

    [LibraryImport("/usr/lib/libobjc.A.dylib", EntryPoint = "objc_msgSend")]
    public static partial void MsgSend(nint receiver, Selector selector, ulong a, nint b, nuint c);

    [LibraryImport("/usr/lib/libobjc.A.dylib", EntryPoint = "objc_msgSend")]
    public static partial void MsgSend(nint receiver, Selector selector, ulong a, NSRange b);

    [LibraryImport("/usr/lib/libobjc.A.dylib", EntryPoint = "objc_msgSend")]
    public static partial void MsgSend(nint receiver, Selector selector, ulong a, nuint b);

    [LibraryImport("/usr/lib/libobjc.A.dylib", EntryPoint = "objc_msgSend")]
    public static partial void MsgSend(nint receiver, Selector selector, ulong a, nuint b, nuint c);

    [LibraryImport("/usr/lib/libobjc.A.dylib", EntryPoint = "objc_msgSend")]
    public static partial void MsgSend(nint receiver, Selector selector, ulong a, nuint b, nuint c, nuint d);

    [LibraryImport("/usr/lib/libobjc.A.dylib", EntryPoint = "objc_msgSend")]
    public static partial void MsgSend(nint receiver, Selector selector, ulong a, nuint b, nuint c, nuint d, nuint e);

    [LibraryImport("/usr/lib/libobjc.A.dylib", EntryPoint = "objc_msgSend")]
    public static partial void MsgSend(nint receiver, Selector selector, ulong a, nuint b, ulong c, nint d, nuint e);

    [LibraryImport("/usr/lib/libobjc.A.dylib", EntryPoint = "objc_msgSend")]
    public static partial void MsgSend(nint receiver, Selector selector, ulong a, nuint b, ulong c, nint d, nuint e, nuint f);

    [LibraryImport("/usr/lib/libobjc.A.dylib", EntryPoint = "objc_msgSend")]
    public static partial void MsgSend(nint receiver, Selector selector, ulong a, nuint b, ulong c, nint d, nuint e, nuint f, nint g, nuint h);

    [LibraryImport("/usr/lib/libobjc.A.dylib", EntryPoint = "objc_msgSend")]
    public static partial void MsgSend(nint receiver, Selector selector, ulong a, ulong b);

    [LibraryImport("/usr/lib/libobjc.A.dylib", EntryPoint = "objc_msgSend")]
    public static partial void MsgSend(nint receiver, Selector selector, ulong a, ulong b, nint c, nuint d);

    [LibraryImport("/usr/lib/libobjc.A.dylib", EntryPoint = "objc_msgSend")]
    public static partial void MsgSend(nint receiver, Selector selector, ulong a, ulong b, nint c, nuint d, nint e);

    [LibraryImport("/usr/lib/libobjc.A.dylib", EntryPoint = "objc_msgSend")]
    public static partial void MsgSend(nint receiver, Selector selector, ulong a, ulong b, nint c, nuint d, nint e, nuint f);

    [LibraryImport("/usr/lib/libobjc.A.dylib", EntryPoint = "objc_msgSend")]
    public static partial void MsgSend(nint receiver, Selector selector, ulong a, ulong b, ulong c);

    #endregion

    #region MsgSendBool

    [LibraryImport("/usr/lib/libobjc.A.dylib", EntryPoint = "objc_msgSend")]
    public static partial Bool8 MsgSendBool(nint receiver, Selector selector);

    [LibraryImport("/usr/lib/libobjc.A.dylib", EntryPoint = "objc_msgSend")]
    public static partial Bool8 MsgSendBool(nint receiver, Selector selector, nint a);

    [LibraryImport("/usr/lib/libobjc.A.dylib", EntryPoint = "objc_msgSend")]
    public static partial Bool8 MsgSendBool(nint receiver, Selector selector, nint a, nint b, out nint error);

    [LibraryImport("/usr/lib/libobjc.A.dylib", EntryPoint = "objc_msgSend")]
    public static partial Bool8 MsgSendBool(nint receiver, Selector selector, nint a, out nint error);

    [LibraryImport("/usr/lib/libobjc.A.dylib", EntryPoint = "objc_msgSend")]
    public static partial Bool8 MsgSendBool(nint receiver, Selector selector, nuint a);

    [LibraryImport("/usr/lib/libobjc.A.dylib", EntryPoint = "objc_msgSend")]
    public static partial Bool8 MsgSendBool(nint receiver, Selector selector, nuint a, nuint b);

    [LibraryImport("/usr/lib/libobjc.A.dylib", EntryPoint = "objc_msgSend")]
    public static partial Bool8 MsgSendBool(nint receiver, Selector selector, ulong a);

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

    #region MsgSendMTLClearColor

    [LibraryImport("/usr/lib/libobjc.A.dylib", EntryPoint = "objc_msgSend")]
    public static partial MTLClearColor MsgSendMTLClearColor(nint receiver, Selector selector);

    #endregion

    #region MsgSendMTLResourceID

    [LibraryImport("/usr/lib/libobjc.A.dylib", EntryPoint = "objc_msgSend")]
    public static partial MTLResourceID MsgSendMTLResourceID(nint receiver, Selector selector);

    [LibraryImport("/usr/lib/libobjc.A.dylib", EntryPoint = "objc_msgSend")]
    public static partial MTLResourceID MsgSendMTLResourceID(nint receiver, Selector selector, nint a, nint b, nuint c);

    [LibraryImport("/usr/lib/libobjc.A.dylib", EntryPoint = "objc_msgSend")]
    public static partial MTLResourceID MsgSendMTLResourceID(nint receiver, Selector selector, nint a, nint b, nuint c, nuint d, nuint e);

    [LibraryImport("/usr/lib/libobjc.A.dylib", EntryPoint = "objc_msgSend")]
    public static partial MTLResourceID MsgSendMTLResourceID(nint receiver, Selector selector, nint a, NSRange b, nuint c);

    [LibraryImport("/usr/lib/libobjc.A.dylib", EntryPoint = "objc_msgSend")]
    public static partial MTLResourceID MsgSendMTLResourceID(nint receiver, Selector selector, nint a, nuint b);

    #endregion

    #region MsgSendMTLSize

    [LibraryImport("/usr/lib/libobjc.A.dylib", EntryPoint = "objc_msgSend")]
    public static partial MTLSize MsgSendMTLSize(nint receiver, Selector selector);

    [LibraryImport("/usr/lib/libobjc.A.dylib", EntryPoint = "objc_msgSend")]
    public static partial MTLSize MsgSendMTLSize(nint receiver, Selector selector, nuint a);

    [LibraryImport("/usr/lib/libobjc.A.dylib", EntryPoint = "objc_msgSend")]
    public static partial MTLSize MsgSendMTLSize(nint receiver, Selector selector, ulong a, ulong b, nuint c);

    [LibraryImport("/usr/lib/libobjc.A.dylib", EntryPoint = "objc_msgSend")]
    public static partial MTLSize MsgSendMTLSize(nint receiver, Selector selector, ulong a, ulong b, nuint c, ulong d);

    #endregion

    #region MsgSendMTLSizeAndAlign

    [LibraryImport("/usr/lib/libobjc.A.dylib", EntryPoint = "objc_msgSend")]
    public static partial MTLSizeAndAlign MsgSendMTLSizeAndAlign(nint receiver, Selector selector);

    [LibraryImport("/usr/lib/libobjc.A.dylib", EntryPoint = "objc_msgSend")]
    public static partial MTLSizeAndAlign MsgSendMTLSizeAndAlign(nint receiver, Selector selector, nint a);

    [LibraryImport("/usr/lib/libobjc.A.dylib", EntryPoint = "objc_msgSend")]
    public static partial MTLSizeAndAlign MsgSendMTLSizeAndAlign(nint receiver, Selector selector, nuint a);

    [LibraryImport("/usr/lib/libobjc.A.dylib", EntryPoint = "objc_msgSend")]
    public static partial MTLSizeAndAlign MsgSendMTLSizeAndAlign(nint receiver, Selector selector, nuint a, ulong b);

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
    public static partial nuint MsgSendNUInt(nint receiver, Selector selector, nuint a);

    [LibraryImport("/usr/lib/libobjc.A.dylib", EntryPoint = "objc_msgSend")]
    public static partial nuint MsgSendNUInt(nint receiver, Selector selector, ulong a);

    #endregion

    #region MsgSendPtr

    [LibraryImport("/usr/lib/libobjc.A.dylib", EntryPoint = "objc_msgSend")]
    public static partial nint MsgSendPtr(nint receiver, Selector selector);

    [LibraryImport("/usr/lib/libobjc.A.dylib", EntryPoint = "objc_msgSend")]
    public static partial nint MsgSendPtr(nint receiver, Selector selector, out nint error);

    [LibraryImport("/usr/lib/libobjc.A.dylib", EntryPoint = "objc_msgSend")]
    public static partial nint MsgSendPtr(nint receiver, Selector selector, MTLSize a);

    [LibraryImport("/usr/lib/libobjc.A.dylib", EntryPoint = "objc_msgSend")]
    public static partial nint MsgSendPtr(nint receiver, Selector selector, MTLSize a, nint b);

    [LibraryImport("/usr/lib/libobjc.A.dylib", EntryPoint = "objc_msgSend")]
    public static partial nint MsgSendPtr(nint receiver, Selector selector, MTLSize a, nuint b, nint c);

    [LibraryImport("/usr/lib/libobjc.A.dylib", EntryPoint = "objc_msgSend")]
    public static partial nint MsgSendPtr(nint receiver, Selector selector, nint a);

    [LibraryImport("/usr/lib/libobjc.A.dylib", EntryPoint = "objc_msgSend")]
    public static partial nint MsgSendPtr(nint receiver, Selector selector, nint a, nint b);

    [LibraryImport("/usr/lib/libobjc.A.dylib", EntryPoint = "objc_msgSend")]
    public static partial nint MsgSendPtr(nint receiver, Selector selector, nint a, nint b, nint c, out nint error);

    [LibraryImport("/usr/lib/libobjc.A.dylib", EntryPoint = "objc_msgSend")]
    public static partial nint MsgSendPtr(nint receiver, Selector selector, nint a, nint b, nuint c);

    [LibraryImport("/usr/lib/libobjc.A.dylib", EntryPoint = "objc_msgSend")]
    public static partial nint MsgSendPtr(nint receiver, Selector selector, nint a, nint b, out nint error);

    [LibraryImport("/usr/lib/libobjc.A.dylib", EntryPoint = "objc_msgSend")]
    public static partial nint MsgSendPtr(nint receiver, Selector selector, nint a, nuint b);

    [LibraryImport("/usr/lib/libobjc.A.dylib", EntryPoint = "objc_msgSend")]
    public static partial nint MsgSendPtr(nint receiver, Selector selector, nint a, nuint b, nuint c);

    [LibraryImport("/usr/lib/libobjc.A.dylib", EntryPoint = "objc_msgSend")]
    public static partial nint MsgSendPtr(nint receiver, Selector selector, nint a, nuint b, ulong c);

    [LibraryImport("/usr/lib/libobjc.A.dylib", EntryPoint = "objc_msgSend")]
    public static partial nint MsgSendPtr(nint receiver, Selector selector, nint a, nuint b, out nint error);

    [LibraryImport("/usr/lib/libobjc.A.dylib", EntryPoint = "objc_msgSend")]
    public static partial nint MsgSendPtr(nint receiver, Selector selector, nint a, ulong b);

    [LibraryImport("/usr/lib/libobjc.A.dylib", EntryPoint = "objc_msgSend")]
    public static partial nint MsgSendPtr(nint receiver, Selector selector, nint a, ulong b, ulong c, out nint error);

    [LibraryImport("/usr/lib/libobjc.A.dylib", EntryPoint = "objc_msgSend")]
    public static partial nint MsgSendPtr(nint receiver, Selector selector, nint a, ulong b, out nint error);

    [LibraryImport("/usr/lib/libobjc.A.dylib", EntryPoint = "objc_msgSend")]
    public static partial nint MsgSendPtr(nint receiver, Selector selector, nint a, out nint error);

    [LibraryImport("/usr/lib/libobjc.A.dylib", EntryPoint = "objc_msgSend")]
    public static partial nint MsgSendPtr(nint receiver, Selector selector, NSRange a);

    [LibraryImport("/usr/lib/libobjc.A.dylib", EntryPoint = "objc_msgSend")]
    public static partial nint MsgSendPtr(nint receiver, Selector selector, nuint a);

    [LibraryImport("/usr/lib/libobjc.A.dylib", EntryPoint = "objc_msgSend")]
    public static partial nint MsgSendPtr(nint receiver, Selector selector, nuint a, nint b);

    [LibraryImport("/usr/lib/libobjc.A.dylib", EntryPoint = "objc_msgSend")]
    public static partial nint MsgSendPtr(nint receiver, Selector selector, nuint a, nuint b);

    [LibraryImport("/usr/lib/libobjc.A.dylib", EntryPoint = "objc_msgSend")]
    public static partial nint MsgSendPtr(nint receiver, Selector selector, nuint a, ulong b);

    [LibraryImport("/usr/lib/libobjc.A.dylib", EntryPoint = "objc_msgSend")]
    public static partial nint MsgSendPtr(nint receiver, Selector selector, nuint a, ulong b, nuint c);

    [LibraryImport("/usr/lib/libobjc.A.dylib", EntryPoint = "objc_msgSend")]
    public static partial nint MsgSendPtr(nint receiver, Selector selector, nuint a, ulong b, ulong c);

    [LibraryImport("/usr/lib/libobjc.A.dylib", EntryPoint = "objc_msgSend")]
    public static partial nint MsgSendPtr(nint receiver, Selector selector, ulong a);

    [LibraryImport("/usr/lib/libobjc.A.dylib", EntryPoint = "objc_msgSend")]
    public static partial nint MsgSendPtr(nint receiver, Selector selector, ulong a, nuint b, Bool8 c);

    [LibraryImport("/usr/lib/libobjc.A.dylib", EntryPoint = "objc_msgSend")]
    public static partial nint MsgSendPtr(nint receiver, Selector selector, ulong a, nuint b, nuint c, Bool8 d);

    [LibraryImport("/usr/lib/libobjc.A.dylib", EntryPoint = "objc_msgSend")]
    public static partial nint MsgSendPtr(nint receiver, Selector selector, ulong a, nuint b, ulong c, ulong d);

    [LibraryImport("/usr/lib/libobjc.A.dylib", EntryPoint = "objc_msgSend")]
    public static partial nint MsgSendPtr(nint receiver, Selector selector, ulong a, ulong b, NSRange c, NSRange d);

    [LibraryImport("/usr/lib/libobjc.A.dylib", EntryPoint = "objc_msgSend")]
    public static partial nint MsgSendPtr(nint receiver, Selector selector, ulong a, ulong b, NSRange c, NSRange d, nint e);

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

    [LibraryImport("/usr/lib/libobjc.A.dylib", EntryPoint = "objc_msgSend")]
    public static partial ulong MsgSendULong(nint receiver, Selector selector, ulong a);

    #endregion
}
