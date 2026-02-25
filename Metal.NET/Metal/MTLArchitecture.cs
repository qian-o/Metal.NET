namespace Metal.NET;

public class MTLArchitecture(nint nativePtr, bool ownsReference = true) : NativeObject(nativePtr, ownsReference), INativeObject<MTLArchitecture>
{
    public static MTLArchitecture Create(nint nativePtr) => new(nativePtr);

    public static MTLArchitecture CreateBorrowed(nint nativePtr) => new(nativePtr, ownsReference: false);

    public MTLArchitecture() : this(ObjectiveCRuntime.AllocInit(MTLArchitectureBindings.Class))
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
