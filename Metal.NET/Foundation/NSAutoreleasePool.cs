namespace Metal.NET;

/// <summary>
/// Wraps an Objective-C NSAutoreleasePool for managing autorelease pools.
/// </summary>
public class NSAutoreleasePool(nint nativePtr, NativeObjectOwnership ownership) : NativeObject(nativePtr, ownership), INativeObject<NSAutoreleasePool>
{
    public static NSAutoreleasePool Null { get; } = new(0, NativeObjectOwnership.Borrowed);

    public static NSAutoreleasePool Create(nint nativePtr, NativeObjectOwnership ownership) => new(nativePtr, ownership);

    public NSAutoreleasePool() : this(ObjectiveCRuntime.AllocInit(NSAutoreleasePoolBindings.Class), NativeObjectOwnership.Managed)
    {
    }

    public void Drain()
    {
        ObjectiveCRuntime.MsgSend(NativePtr, NSAutoreleasePoolBindings.Drain);
    }

    public void AddObject(NativeObject pObject)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, NSAutoreleasePoolBindings.AddObject, pObject.NativePtr);
    }

    public static void ShowPools()
    {
        ObjectiveCRuntime.MsgSend(NSAutoreleasePoolBindings.Class, NSAutoreleasePoolBindings.ShowPools);
    }
}

file static class NSAutoreleasePoolBindings
{
    public static readonly nint Class = ObjectiveCRuntime.GetClass("NSAutoreleasePool");

    public static readonly Selector Drain = "drain";

    public static readonly Selector AddObject = "addObject:";

    public static readonly Selector ShowPools = "showPools";
}
