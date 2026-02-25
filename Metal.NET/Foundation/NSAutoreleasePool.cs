namespace Metal.NET;

/// <summary>
/// Wraps an Objective-C NSAutoreleasePool for managing autorelease pools.
/// </summary>
public class NSAutoreleasePool(nint nativePtr, bool ownsReference, bool allowGCRelease) : NativeObject(nativePtr, ownsReference, allowGCRelease), INativeObject<NSAutoreleasePool>
{
    public static NSAutoreleasePool Null { get; } = new(0, false, false);

    public static NSAutoreleasePool Create(nint nativePtr, bool ownsReference, bool allowGCRelease) => new(nativePtr, ownsReference, allowGCRelease);

    public NSAutoreleasePool() : this(ObjectiveCRuntime.AllocInit(NSAutoreleasePoolBindings.Class), true, true)
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
