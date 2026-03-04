namespace Metal.NET;

public class MTLArchitecture(nint nativePtr, NativeObjectOwnership ownership) : ObjectiveCObject(nativePtr, ownership), INativeObject<MTLArchitecture>
{
    #region INativeObject
    public static MTLArchitecture Null { get; } = new(0, NativeObjectOwnership.Borrowed);

    public static MTLArchitecture New(nint nativePtr, NativeObjectOwnership ownership)
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
