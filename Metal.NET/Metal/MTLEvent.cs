namespace Metal.NET;

public class MTLEvent(nint nativePtr, bool ownsReference = true) : NativeObject(nativePtr, ownsReference), INativeObject<MTLEvent>
{
    public static MTLEvent Create(nint nativePtr) => new(nativePtr);

    public static MTLEvent CreateBorrowed(nint nativePtr) => new(nativePtr, ownsReference: false);

    public MTLDevice Device
    {
        get => GetProperty(ref field, MTLEventBindings.Device);
    }

    public NSString Label
    {
        get => GetProperty(ref field, MTLEventBindings.Label);
        set => SetProperty(ref field, MTLEventBindings.SetLabel, value);
    }
}

file static class MTLEventBindings
{
    public static readonly Selector Device = "device";

    public static readonly Selector Label = "label";

    public static readonly Selector SetLabel = "setLabel:";
}
