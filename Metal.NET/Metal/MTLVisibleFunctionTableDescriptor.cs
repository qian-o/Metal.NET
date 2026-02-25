namespace Metal.NET;

public class MTLVisibleFunctionTableDescriptor(nint nativePtr, bool ownsReference) : NativeObject(nativePtr, ownsReference), INativeObject<MTLVisibleFunctionTableDescriptor>
{
    public static MTLVisibleFunctionTableDescriptor Create(nint nativePtr) => new(nativePtr, true);

    public static MTLVisibleFunctionTableDescriptor CreateBorrowed(nint nativePtr) => new(nativePtr, false);

    public MTLVisibleFunctionTableDescriptor() : this(ObjectiveCRuntime.AllocInit(MTLVisibleFunctionTableDescriptorBindings.Class), true)
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

        return new(nativePtr, true);
    }
}

file static class MTLVisibleFunctionTableDescriptorBindings
{
    public static readonly nint Class = ObjectiveCRuntime.GetClass("MTLVisibleFunctionTableDescriptor");

    public static readonly Selector FunctionCount = "functionCount";

    public static readonly Selector SetFunctionCount = "setFunctionCount:";

    public static readonly Selector VisibleFunctionTableDescriptor = "visibleFunctionTableDescriptor";
}
