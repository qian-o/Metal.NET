namespace Metal.NET;

public class MTLArchitecture(nint nativePtr, NativeObjectOwnership ownership) : NativeObject(nativePtr, ownership), INativeObject<MTLArchitecture>
{
    public static MTLArchitecture Null { get; } = new(0, NativeObjectOwnership.Borrowed);

    public static MTLArchitecture Create(nint nativePtr, NativeObjectOwnership ownership) => new(nativePtr, ownership);

    public MTLArchitecture() : this(ObjectiveCRuntime.AllocInit(MTLArchitectureBindings.Class), NativeObjectOwnership.Managed)
    {
    }

    public NSString Name
    {
        get => GetProperty(ref field, MTLArchitectureBindings.Name);
    }
}

file static class MTLArchitectureBindings
{
    public static readonly nint Class = ObjectiveCRuntime.GetClass("MTLArchitecture");

    public static readonly Selector Name = "name";
}
