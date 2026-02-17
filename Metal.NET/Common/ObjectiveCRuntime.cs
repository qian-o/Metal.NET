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
}
