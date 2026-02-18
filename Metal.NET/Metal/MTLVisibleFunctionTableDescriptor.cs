namespace Metal.NET;

public partial class MTLVisibleFunctionTableDescriptor : NativeObject
{
    private static readonly nint Class = ObjectiveCRuntime.GetClass("MTLVisibleFunctionTableDescriptor");

    public MTLVisibleFunctionTableDescriptor(nint nativePtr) : base(nativePtr)
    {
    }

    public nuint FunctionCount
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLVisibleFunctionTableDescriptorSelector.FunctionCount);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLVisibleFunctionTableDescriptorSelector.SetFunctionCount, value);
    }

    public static MTLVisibleFunctionTableDescriptor? VisibleFunctionTableDescriptor()
    {
        nint ptr = ObjectiveCRuntime.MsgSendPtr(Class, MTLVisibleFunctionTableDescriptorSelector.VisibleFunctionTableDescriptor);
        return ptr is not 0 ? new(ptr) : null;
    }
}

file static class MTLVisibleFunctionTableDescriptorSelector
{
    public static readonly Selector FunctionCount = Selector.Register("functionCount");

    public static readonly Selector SetFunctionCount = Selector.Register("setFunctionCount:");

    public static readonly Selector VisibleFunctionTableDescriptor = Selector.Register("visibleFunctionTableDescriptor");
}
