namespace Metal.NET;

public class MTLVisibleFunctionTableDescriptor(nint nativePtr) : NativeObject(nativePtr)
{
    public MTLVisibleFunctionTableDescriptor() : this(ObjectiveCRuntime.AllocInit(MTLVisibleFunctionTableDescriptorSelector.Class))
    {
    }

    public nuint FunctionCount
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLVisibleFunctionTableDescriptorSelector.FunctionCount);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLVisibleFunctionTableDescriptorSelector.SetFunctionCount, value);
    }

    public static MTLVisibleFunctionTableDescriptor? VisibleFunctionTableDescriptor()
    {
        return GetNullableObject<MTLVisibleFunctionTableDescriptor>(ObjectiveCRuntime.MsgSendPtr(MTLVisibleFunctionTableDescriptorSelector.Class, MTLVisibleFunctionTableDescriptorSelector.VisibleFunctionTableDescriptor));
    }
}

file static class MTLVisibleFunctionTableDescriptorSelector
{
    public static readonly nint Class = ObjectiveCRuntime.GetClass("MTLVisibleFunctionTableDescriptor");

    public static readonly Selector FunctionCount = Selector.Register("functionCount");

    public static readonly Selector SetFunctionCount = Selector.Register("setFunctionCount:");

    public static readonly Selector VisibleFunctionTableDescriptor = Selector.Register("visibleFunctionTableDescriptor");
}
