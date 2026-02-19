namespace Metal.NET;

public class MTLArchitecture(nint nativePtr) : NativeObject(nativePtr)
{
    public MTLArchitecture() : this(ObjectiveCRuntime.AllocInit(MTLArchitectureBindings.Class))
    {
    }

    public NSString? Name
    {
        get => GetProperty<NSString>(ref field, MTLArchitectureBindings.Name);
    }
}

file static class MTLArchitectureBindings
{
    public static readonly nint Class = ObjectiveCRuntime.GetClass("MTLArchitecture");

    public static readonly Selector Name = "name";
}
