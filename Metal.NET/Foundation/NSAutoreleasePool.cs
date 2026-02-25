namespace Metal.NET;

/// <summary>
/// Wraps an Objective-C NSAutoreleasePool for managing autorelease pools.
/// </summary>
public class NSAutoreleasePool(nint nativePtr, bool ownsReference = true) : NativeObject(nativePtr, ownsReference), INativeObject<NSAutoreleasePool>
{
    public static NSAutoreleasePool Create(nint nativePtr) => new(nativePtr);

    public static NSAutoreleasePool CreateBorrowed(nint nativePtr) => new(nativePtr, ownsReference: false);

    public NSAutoreleasePool() : this(ObjectiveCRuntime.AllocInit(NSAutoreleasePoolBindings.Class))
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
