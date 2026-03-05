namespace Metal.NET;

public class MTLArchitecture(nint nativePtr, NativeObjectOwnership ownership) : NSObject(nativePtr, ownership), INativeObject<MTLArchitecture>
{
    #region INativeObject
    public static new MTLArchitecture Null { get; } = new(0, NativeObjectOwnership.Borrowed);

    public static new MTLArchitecture New(nint nativePtr, NativeObjectOwnership ownership)
    {
        return new(nativePtr, ownership);
    }
    #endregion

    public MTLArchitecture() : this(ObjectiveC.AllocInit(MTLArchitectureBindings.Class), NativeObjectOwnership.Managed)
    {
    }

    public NSString Name
    {
        get => GetProperty(ref field, MTLArchitectureBindings.Name);
    }
}

file static class MTLArchitectureBindings
{
    public static readonly nint Class = ObjectiveC.GetClass("MTLArchitecture");

    public static readonly Selector Name = "name";
}
