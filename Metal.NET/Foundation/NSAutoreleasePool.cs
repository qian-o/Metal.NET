namespace Metal.NET;

/// <summary>
/// An object that supports Cocoa’s reference-counted memory management system.
/// </summary>
public class NSAutoreleasePool(nint nativePtr, NativeObjectOwnership ownership) : NSObject(nativePtr, ownership), INativeObject<NSAutoreleasePool>
{
    #region INativeObject
    public static new NSAutoreleasePool Null { get; } = new(0, NativeObjectOwnership.Borrowed);

    public static new NSAutoreleasePool New(nint nativePtr, NativeObjectOwnership ownership)
    {
        return new(nativePtr, ownership);
    }
    #endregion

    public NSAutoreleasePool() : this(ObjectiveC.AllocInit(NSAutoreleasePoolBindings.Class), NativeObjectOwnership.Managed)
    {
    }

    public void Drain()
    {
        ObjectiveC.MsgSend(NativePtr, NSAutoreleasePoolBindings.Drain);
    }

    public void AddObject(NativeObject nativeObject)
    {
        ObjectiveC.MsgSend(NativePtr, NSAutoreleasePoolBindings.AddObject, nativeObject.NativePtr);
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
