namespace Metal.NET;

/// <summary>
/// An object that supports Cocoa’s reference-counted memory management system.
/// </summary>
public readonly struct NSAutoreleasePool(nint nativePtr) : IDisposable
{
    public readonly nint NativePtr = nativePtr;

    public bool IsNull => NativePtr is 0;

    public static implicit operator NSObject(NSAutoreleasePool value) => new(value.NativePtr);

    public NSAutoreleasePool() : this(ObjectiveC.AllocInit(NSAutoreleasePoolBindings.Class))
    {
    }

    public NSAutoreleasePool Retain()
    {
        return new(ObjectiveC.Retain(NativePtr));
    }

    public void Dispose()
    {
        ObjectiveC.Release(NativePtr);
    }

    public void Drain()
    {
        ObjectiveC.MsgSend(NativePtr, NSAutoreleasePoolBindings.Drain);
    }

    public void AddObject(NSObject anObject)
    {
        ObjectiveC.MsgSend(NativePtr, NSAutoreleasePoolBindings.AddObject, anObject.NativePtr);
    }

    public static void ShowPools()
    {
        ObjectiveC.MsgSend(NSAutoreleasePoolBindings.Class, NSAutoreleasePoolBindings.ShowPools);
    }
}

file static class NSAutoreleasePoolBindings
{
    public static readonly nint Class = ObjectiveC.GetClass("NSAutoreleasePool");

    public static readonly Selector Drain = "drain";

    public static readonly Selector AddObject = "addObject:";

    public static readonly Selector ShowPools = "showPools";
}
