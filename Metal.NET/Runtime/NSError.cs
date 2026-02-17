using System.Runtime.InteropServices;

namespace Metal.NET;

/// <summary>
/// Wraps an Objective-C NSError pointer.
/// </summary>
[StructLayout(LayoutKind.Sequential)]
public readonly struct NSError
{
    public readonly nint NativePtr;

    public NSError(nint ptr) => NativePtr = ptr;

    public static implicit operator nint(NSError e) => e.NativePtr;
    public static implicit operator NSError(nint ptr) => new(ptr);

    public bool IsNull => NativePtr == 0;

    private static readonly Selector s_localizedDescription = Selector.Register("localizedDescription");
    private static readonly Selector s_code = Selector.Register("code");
    private static readonly Selector s_domain = Selector.Register("domain");

    public string LocalizedDescription
    {
        get
        {
            var nsStr = new NSString(ObjectiveCRuntime.intptr_objc_msgSend(NativePtr, s_localizedDescription));
            return nsStr.GetValue();
        }
    }

    public long Code => (long)ObjectiveCRuntime.nuint_objc_msgSend(NativePtr, s_code);

    public string Domain
    {
        get
        {
            var nsStr = new NSString(ObjectiveCRuntime.intptr_objc_msgSend(NativePtr, s_domain));
            return nsStr.GetValue();
        }
    }
}
