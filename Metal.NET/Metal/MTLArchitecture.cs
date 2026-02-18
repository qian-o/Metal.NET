namespace Metal.NET;

public partial class MTLArchitecture : NativeObject
{
    private static readonly nint Class = ObjectiveCRuntime.GetClass("MTLArchitecture");

    public MTLArchitecture(nint nativePtr) : base(nativePtr)
    {
    }

    public NSString? Name
    {
        get
        {
            nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLArchitectureSelector.Name);
            return ptr is not 0 ? new(ptr) : null;
        }
    }
}

file static class MTLArchitectureSelector
{
    public static readonly Selector Name = Selector.Register("name");
}
