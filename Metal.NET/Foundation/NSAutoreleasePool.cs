namespace Metal.NET;

/// <summary>
/// Wraps an Objective-C NSAutoreleasePool for managing autorelease pools.
/// </summary>
public class NSAutoreleasePool(nint nativePtr, bool ownsReference) : NativeObject(nativePtr, ownsReference), INativeObject<NSAutoreleasePool>
{
    public static NSAutoreleasePool Create(nint nativePtr, bool ownsReference) => new(nativePtr, ownsReference);

    public NSAutoreleasePool() : this(ObjectiveCRuntime.AllocInit(NSAutoreleasePoolBindings.Class), true)
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
