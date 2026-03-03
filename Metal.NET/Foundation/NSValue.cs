using System.Runtime.InteropServices;

namespace Metal.NET;

/// <summary>
/// Wraps an Objective-C NSValue for boxing simple C types and pointers.
/// </summary>
public class NSValue(nint nativePtr, NativeObjectOwnership ownership) : NativeObject(nativePtr, ownership), INativeObject<NSValue>
{
    public static NSValue Null { get; } = new(0, NativeObjectOwnership.Borrowed);

    public static NSValue Create(nint nativePtr, NativeObjectOwnership ownership) => new(nativePtr, ownership);

    public nint PointerValue
    {
        get => ObjectiveCRuntime.MsgSendPtr(NativePtr, NSValueBindings.PointerValue);
    }

    public nint ObjCType
    {
        get => ObjectiveCRuntime.MsgSendPtr(NativePtr, NSValueBindings.ObjCType);
    }

    public string ObjCTypeString
    {
        get => Marshal.PtrToStringUTF8(ObjCType) ?? string.Empty;
    }

    public static NSValue ValueWithPointer(nint pointer)
    {
        return new(ObjectiveCRuntime.MsgSendPtr(NSValueBindings.Class, NSValueBindings.ValueWithPointer, pointer), NativeObjectOwnership.Owned);
    }

    public NSString Description
    {
        get => GetProperty(ref field, NSValueBindings.Description);
    }

    public override string ToString()
    {
        return Description.Value;
    }
}

file static class NSValueBindings
{
    public static readonly nint Class = ObjectiveCRuntime.GetClass("NSValue");

    public static readonly Selector PointerValue = "pointerValue";

    public static readonly Selector ObjCType = "objCType";

    public static readonly Selector ValueWithPointer = "valueWithPointer:";

    public static readonly Selector Description = "description";
}
