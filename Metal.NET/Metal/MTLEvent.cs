namespace Metal.NET;

public class MTLEvent(nint nativePtr, bool ownsReference) : NativeObject(nativePtr, ownsReference), INativeObject<MTLEvent>
{
    public static MTLEvent Null => Create(0, false);
    public static MTLEvent Create(nint nativePtr, bool ownsReference) => new(nativePtr, ownsReference);

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
