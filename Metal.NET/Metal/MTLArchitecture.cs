namespace Metal.NET;

public class MTLArchitecture(nint nativePtr, bool ownsReference, bool allowGCRelease = false) : NativeObject(nativePtr, ownsReference, allowGCRelease), INativeObject<MTLArchitecture>
{
    public static MTLArchitecture Null { get; } = new(0, false);

    public static MTLArchitecture Create(nint nativePtr, bool ownsReference) => new(nativePtr, ownsReference);

    public MTLArchitecture() : this(ObjectiveCRuntime.AllocInit(MTLArchitectureBindings.Class), true, true)
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
