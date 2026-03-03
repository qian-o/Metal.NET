namespace Metal.NET;

public class MTLVisibleFunctionTableDescriptor(nint nativePtr, NativeObjectOwnership ownership) : NativeObject(nativePtr, ownership), INativeObject<MTLVisibleFunctionTableDescriptor>
{
    public static MTLVisibleFunctionTableDescriptor Null { get; } = new(0, NativeObjectOwnership.Borrowed);

    public static MTLVisibleFunctionTableDescriptor Create(nint nativePtr, NativeObjectOwnership ownership) => new(nativePtr, ownership);

    public MTLVisibleFunctionTableDescriptor() : this(ObjectiveCRuntime.AllocInit(MTLVisibleFunctionTableDescriptorBindings.Class), NativeObjectOwnership.Managed)
    {
    }

    public nuint FunctionCount
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLVisibleFunctionTableDescriptorBindings.FunctionCount);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLVisibleFunctionTableDescriptorBindings.SetFunctionCount, value);
    }

    public static MTLVisibleFunctionTableDescriptor VisibleFunctionTableDescriptor()
    {
        nint nativePtr = ObjectiveCRuntime.MsgSendPtr(MTLVisibleFunctionTableDescriptorBindings.Class, MTLVisibleFunctionTableDescriptorBindings.VisibleFunctionTableDescriptor);

        return new(nativePtr, NativeObjectOwnership.Owned);
    }
}

file static class MTLVisibleFunctionTableDescriptorBindings
{
    public static readonly nint Class = ObjectiveCRuntime.GetClass("MTLVisibleFunctionTableDescriptor");

    public static readonly Selector FunctionCount = "functionCount";

    public static readonly Selector SetFunctionCount = "setFunctionCount:";

    public static readonly Selector VisibleFunctionTableDescriptor = "visibleFunctionTableDescriptor";
}
