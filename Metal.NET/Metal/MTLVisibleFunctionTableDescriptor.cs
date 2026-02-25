namespace Metal.NET;

public class MTLVisibleFunctionTableDescriptor(nint nativePtr, bool ownsReference = true) : NativeObject(nativePtr, ownsReference), INativeObject<MTLVisibleFunctionTableDescriptor>
{
    public static MTLVisibleFunctionTableDescriptor Create(nint nativePtr) => new(nativePtr);

    public static MTLVisibleFunctionTableDescriptor CreateBorrowed(nint nativePtr) => new(nativePtr, ownsReference: false);

    public MTLVisibleFunctionTableDescriptor() : this(ObjectiveCRuntime.AllocInit(MTLVisibleFunctionTableDescriptorBindings.Class))
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

        return new(nativePtr);
    }
}

file static class MTLVisibleFunctionTableDescriptorBindings
{
    public static readonly nint Class = ObjectiveCRuntime.GetClass("MTLVisibleFunctionTableDescriptor");

    public static readonly Selector FunctionCount = "functionCount";

    public static readonly Selector SetFunctionCount = "setFunctionCount:";

    public static readonly Selector VisibleFunctionTableDescriptor = "visibleFunctionTableDescriptor";
}
