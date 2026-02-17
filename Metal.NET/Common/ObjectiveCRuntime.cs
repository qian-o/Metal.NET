using System.Runtime.InteropServices;

namespace Metal.NET;

public static unsafe partial class ObjectiveCRuntime
{
    private const string ObjCLibrary = "/usr/lib/libobjc.A.dylib";

    [LibraryImport(ObjCLibrary, EntryPoint = "objc_msgSend")]
    public static partial void MsgSend(nint receiver, Selector selector);

    [LibraryImport(ObjCLibrary, EntryPoint = "objc_msgSend")]
    public static partial void MsgSend(nint receiver, Selector selector, nint a);

    [LibraryImport(ObjCLibrary, EntryPoint = "objc_msgSend")]
    public static partial void MsgSend(nint receiver, Selector selector, nint a, nint b);

    [LibraryImport(ObjCLibrary, EntryPoint = "objc_msgSend")]
    public static partial void MsgSend(nint receiver, Selector selector, nint a, nint b, nint c);

    [LibraryImport(ObjCLibrary, EntryPoint = "objc_msgSend")]
    public static partial void MsgSend(nint receiver, Selector selector, nint a, nint b, nint c, nint d);

    [LibraryImport(ObjCLibrary, EntryPoint = "objc_msgSend")]
    public static partial void MsgSend(nint receiver, Selector selector, nint a, nint b, nint c, nint d, nint e);

    [LibraryImport(ObjCLibrary, EntryPoint = "objc_msgSend")]
    public static partial void MsgSend(nint receiver, Selector selector, nint a, nint b, nint c, nint d, nint e, nint f);

    [LibraryImport(ObjCLibrary, EntryPoint = "objc_msgSend")]
    public static partial void MsgSend(nint receiver, Selector selector, nint a, nint b, nint c, nint d, nint e, nint f, nint g);

    [LibraryImport(ObjCLibrary, EntryPoint = "objc_msgSend")]
    public static partial void MsgSend(nint receiver, Selector selector, nint a, nint b, nint c, nint d, nint e, nint f, nint g, nint h);

    [LibraryImport(ObjCLibrary, EntryPoint = "objc_msgSend")]
    public static partial void MsgSend(nint receiver, Selector selector, nint a, nint b, nint c, nint d, nint e, nint f, nint g, nint h, nint i);

    [LibraryImport(ObjCLibrary, EntryPoint = "objc_msgSend")]
    public static partial void MsgSend(nint receiver, Selector selector, nint a, nint b, nint c, nint d, nint e, nint f, nint g, nint h, nint i, nint j);

    [LibraryImport(ObjCLibrary, EntryPoint = "objc_msgSend")]
    public static partial void MsgSend(nint receiver, Selector selector, nint a, nint b, nint c, nint d, nint e, nint f, nint g, nint h, nint i, nint j, nint k);

    [LibraryImport(ObjCLibrary, EntryPoint = "objc_msgSend")]
    public static partial void MsgSend(nint receiver, Selector selector, nint a, nint b, nint c, nint d, nint e, nint f, nint g, nint h, nint i, nint j, nint k, nint l);

    [LibraryImport(ObjCLibrary, EntryPoint = "objc_msgSend")]
    public static partial void MsgSend(nint receiver, Selector selector, MTLClearColor a);

    [LibraryImport(ObjCLibrary, EntryPoint = "objc_msgSend")]
    public static partial void MsgSend(nint receiver, Selector selector, MTLSize a);

    [LibraryImport(ObjCLibrary, EntryPoint = "objc_msgSend")]
    public static partial void MsgSend(nint receiver, Selector selector, MTLOrigin a, MTLSize b);

    [LibraryImport(ObjCLibrary, EntryPoint = "objc_msgSend")]
    public static partial void MsgSend(nint receiver, Selector selector, MTLSize a, MTLSize b);

    [LibraryImport(ObjCLibrary, EntryPoint = "objc_msgSend")]
    public static partial void MsgSend(nint receiver, Selector selector, MTLRegion a, nint b, nint c, nint d, nint e, nint f);

    [LibraryImport(ObjCLibrary, EntryPoint = "objc_msgSend")]
    public static partial void MsgSend(nint receiver, Selector selector, nint a, nint b, nint c, nint d, MTLSize e, nint f, nint g, nint h, MTLOrigin i);

    [LibraryImport(ObjCLibrary, EntryPoint = "objc_msgSend")]
    public static partial void MsgSend(nint receiver, Selector selector, nint a, nint b, nint c, MTLOrigin d, MTLSize e, nint f, nint g, nint h, MTLOrigin i);

    [LibraryImport(ObjCLibrary, EntryPoint = "objc_msgSend")]
    public static partial void MsgSend(nint receiver, Selector selector, float a);

    [LibraryImport(ObjCLibrary, EntryPoint = "objc_msgSend")]
    public static partial void MsgSend(nint receiver, Selector selector, double a);

    [LibraryImport(ObjCLibrary, EntryPoint = "objc_msgSend")]
    public static partial nint MsgSendPtr(nint receiver, Selector selector);

    [LibraryImport(ObjCLibrary, EntryPoint = "objc_msgSend")]
    public static partial nint MsgSendPtr(nint receiver, Selector selector, nint a);

    [LibraryImport(ObjCLibrary, EntryPoint = "objc_msgSend")]
    public static partial nint MsgSendPtr(nint receiver, Selector selector, nint a, nint b);

    [LibraryImport(ObjCLibrary, EntryPoint = "objc_msgSend")]
    public static partial nint MsgSendPtr(nint receiver, Selector selector, nint a, nint b, nint c);

    [LibraryImport(ObjCLibrary, EntryPoint = "objc_msgSend")]
    public static partial nint MsgSendPtr(nint receiver, Selector selector, nint a, nint b, nint c, nint d);

    [LibraryImport(ObjCLibrary, EntryPoint = "objc_msgSend")]
    public static partial nint MsgSendPtr(nint receiver, Selector selector, nint a, nint b, nint c, nint d, nint e);

    [LibraryImport(ObjCLibrary, EntryPoint = "objc_msgSend")]
    public static partial nint MsgSendPtr(nint receiver, Selector selector, nint a, nint b, nint c, nint d, nint e, nint f);

    [LibraryImport(ObjCLibrary, EntryPoint = "objc_msgSend")]
    public static partial nint MsgSendPtr(nint receiver, Selector selector, out nint error);

    [LibraryImport(ObjCLibrary, EntryPoint = "objc_msgSend")]
    public static partial nint MsgSendPtr(nint receiver, Selector selector, nint a, out nint error);

    [LibraryImport(ObjCLibrary, EntryPoint = "objc_msgSend")]
    public static partial nint MsgSendPtr(nint receiver, Selector selector, nint a, nint b, out nint error);

    [LibraryImport(ObjCLibrary, EntryPoint = "objc_msgSend")]
    public static partial nint MsgSendPtr(nint receiver, Selector selector, nint a, nint b, nint c, out nint error);

    [LibraryImport(ObjCLibrary, EntryPoint = "objc_msgSend")]
    public static partial nint MsgSendPtr(nint receiver, Selector selector, nint a, nint b, nint c, nint d, out nint error);

    [LibraryImport(ObjCLibrary, EntryPoint = "objc_msgSend")]
    public static partial Bool8 MsgSendBool(nint receiver, Selector selector);

    [LibraryImport(ObjCLibrary, EntryPoint = "objc_msgSend")]
    public static partial uint MsgSendUInt(nint receiver, Selector selector);

    [LibraryImport(ObjCLibrary, EntryPoint = "objc_msgSend")]
    public static partial ulong MsgSendULong(nint receiver, Selector selector);

    [LibraryImport(ObjCLibrary, EntryPoint = "objc_msgSend")]
    public static partial float MsgSendFloat(nint receiver, Selector selector);

    [LibraryImport(ObjCLibrary, EntryPoint = "objc_msgSend")]
    public static partial double MsgSendDouble(nint receiver, Selector selector);

    [LibraryImport(ObjCLibrary, EntryPoint = "objc_msgSend")]
    public static partial nuint MsgSendNUInt(nint receiver, Selector selector);

    [LibraryImport(ObjCLibrary, EntryPoint = "objc_getClass")]
    public static partial nint GetClass(byte* name);

    [LibraryImport(ObjCLibrary, EntryPoint = "sel_registerName")]
    public static partial Selector RegisterName(byte* name);

    public static nint Retain(nint obj)
        => MsgSendPtr(obj, Selector.Register("retain"));

    public static void Release(nint obj)
        => MsgSend(obj, Selector.Register("release"));

    public static nint GetClass(string name)
    {
        fixed (byte* utf8 = System.Text.Encoding.UTF8.GetBytes(name + '\0'))
        {
            return GetClass(utf8);
        }
    }
}
