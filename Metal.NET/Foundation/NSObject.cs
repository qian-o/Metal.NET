using System.Runtime.InteropServices;

namespace Metal.NET;

/// <summary>
/// Wraps an Objective-C NSObject, the root class of all Objective-C objects.
/// <para>
/// Note: In Objective-C, NSObject is the root base class. Metal types (MTLDevice, etc.)
/// all inherit from NSObject. Currently, <see cref="NativeObject"/> serves as the C# base
/// class for all wrappers. A future refactoring could merge NSObject with NativeObject
/// so that NSObject provides the retain/release lifecycle and all Metal types derive
/// from NSObject directly, mirroring the Objective-C hierarchy.
/// </para>
/// </summary>
public class NSObject(nint nativePtr, NativeObjectOwnership ownership) : NativeObject(nativePtr, ownership), INativeObject<NSObject>
{
    public static NSObject Null { get; } = new(0, NativeObjectOwnership.Borrowed);

    public static NSObject Create(nint nativePtr, NativeObjectOwnership ownership) => new(nativePtr, ownership);

    public NSString Description
    {
        get => GetProperty(ref field, NSObjectBindings.Description);
    }

    public NSString DebugDescription
    {
        get => GetProperty(ref field, NSObjectBindings.DebugDescription);
    }

    public nuint Hash
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, NSObjectBindings.Hash);
    }

    public NSString ClassName
    {
        get => GetProperty(ref field, NSObjectBindings.ClassName);
    }

    public nint Superclass
    {
        get => ObjectiveCRuntime.MsgSendPtr(NativePtr, NSObjectBindings.Superclass);
    }

    public bool IsEqual(nint obj)
    {
        return ObjectiveCRuntime.MsgSendBool(NativePtr, NSObjectBindings.IsEqual, obj);
    }

    public bool IsKindOfClass(nint cls)
    {
        return ObjectiveCRuntime.MsgSendBool(NativePtr, NSObjectBindings.IsKindOfClass, cls);
    }

    public bool IsMemberOfClass(nint cls)
    {
        return ObjectiveCRuntime.MsgSendBool(NativePtr, NSObjectBindings.IsMemberOfClass, cls);
    }

    public bool RespondsToSelector(Selector selector)
    {
        return ObjectiveCRuntime.MsgSendBool(NativePtr, NSObjectBindings.RespondsToSelector, selector.NativePtr);
    }

    public bool ConformsToProtocol(nint protocol)
    {
        return ObjectiveCRuntime.MsgSendBool(NativePtr, NSObjectBindings.ConformsToProtocol, protocol);
    }

    public nint PerformSelector(Selector selector)
    {
        return ObjectiveCRuntime.MsgSendPtr(NativePtr, NSObjectBindings.PerformSelector, selector.NativePtr);
    }

    public void Retain()
    {
        ObjectiveCRuntime.MsgSend(NativePtr, NSObjectBindings.Retain);
    }

    public nuint RetainCount
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, NSObjectBindings.RetainCount);
    }

    public override string ToString()
    {
        return Description.Value;
    }
}

file static class NSObjectBindings
{
    public static readonly Selector Description = "description";

    public static readonly Selector DebugDescription = "debugDescription";

    public static readonly Selector Hash = "hash";

    public static readonly Selector ClassName = "className";

    public static readonly Selector Superclass = "superclass";

    public static readonly Selector IsEqual = "isEqual:";

    public static readonly Selector IsKindOfClass = "isKindOfClass:";

    public static readonly Selector IsMemberOfClass = "isMemberOfClass:";

    public static readonly Selector RespondsToSelector = "respondsToSelector:";

    public static readonly Selector ConformsToProtocol = "conformsToProtocol:";

    public static readonly Selector PerformSelector = "performSelector:";

    public static readonly Selector Retain = "retain";

    public static readonly Selector RetainCount = "retainCount";
}
