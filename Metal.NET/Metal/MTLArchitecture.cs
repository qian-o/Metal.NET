namespace Metal.NET;

public class MTLArchitecture(nint nativePtr, bool retain) : NativeObject(nativePtr, retain)
{
    public MTLArchitecture() : this(ObjectiveCRuntime.AllocInit(MTLArchitectureBindings.Class), false)
    {
    }

    public NSString? Name
    {
        get => GetProperty(ref field, MTLArchitectureBindings.Name);
    }
}

file static class MTLArchitectureBindings
{
    public static readonly nint Class = ObjectiveCRuntime.GetClass("MTLArchitecture");

    public static readonly Selector Name = "name";
}
