using System.Runtime.InteropServices;

namespace Metal.NET;

public static unsafe partial class ObjectiveCRuntime
{
    [LibraryImport("/usr/lib/libobjc.A.dylib", EntryPoint = "objc_getClass")]
    public static partial nint GetClass(byte* name);

    [LibraryImport("/usr/lib/libobjc.A.dylib", EntryPoint = "sel_registerName")]
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
