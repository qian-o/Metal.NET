namespace Metal.NET;

public readonly struct MTLVisibleFunctionTableDescriptor(nint nativePtr)
{
    public readonly nint NativePtr = nativePtr;

    public MTLVisibleFunctionTableDescriptor() : this(ObjectiveCRuntime.AllocInit(MTLVisibleFunctionTableDescriptorBindings.Class))
    {
    }

    public nuint FunctionCount
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLVisibleFunctionTableDescriptorBindings.FunctionCount);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLVisibleFunctionTableDescriptorBindings.SetFunctionCount, value);
    }

    public static MTLVisibleFunctionTableDescriptor? VisibleFunctionTableDescriptor()
    {
        nint ptr = ObjectiveCRuntime.MsgSendPtr(MTLVisibleFunctionTableDescriptorBindings.Class, MTLVisibleFunctionTableDescriptorBindings.VisibleFunctionTableDescriptor);
        return ptr is not 0 ? new MTLVisibleFunctionTableDescriptor(ptr) : default;
    }
}

file static class MTLVisibleFunctionTableDescriptorBindings
{
    public static readonly nint Class = ObjectiveCRuntime.GetClass("MTLVisibleFunctionTableDescriptor");

    public static readonly Selector FunctionCount = Selector.Register("functionCount");

    public static readonly Selector SetFunctionCount = Selector.Register("setFunctionCount:");

    public static readonly Selector VisibleFunctionTableDescriptor = Selector.Register("visibleFunctionTableDescriptor");
}
