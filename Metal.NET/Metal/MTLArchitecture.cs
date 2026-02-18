namespace Metal.NET;

public class MTLArchitecture(nint nativePtr) : NativeObject(nativePtr)
{
    public MTLArchitecture() : this(ObjectiveCRuntime.AllocInit(MTLArchitectureSelector.Class))
    {
    }

    public NSString? Name
    {
        get => GetNullableObject<NSString>(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLArchitectureSelector.Name));
    }
}

file static class MTLArchitectureSelector
{
    public static readonly nint Class = ObjectiveCRuntime.GetClass("MTLArchitecture");

    public static readonly Selector Name = Selector.Register("name");
}
