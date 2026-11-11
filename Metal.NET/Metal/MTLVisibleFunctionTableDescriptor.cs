namespace Metal.NET;

public readonly struct MTLVisibleFunctionTableDescriptor(nint nativePtr) : IDisposable
{
    public readonly nint NativePtr = nativePtr;

    public bool IsNull => NativePtr is 0;

    public static implicit operator NSObject(MTLVisibleFunctionTableDescriptor value) => new(value.NativePtr);

    public MTLVisibleFunctionTableDescriptor() : this(ObjectiveC.AllocInit(MTLVisibleFunctionTableDescriptorBindings.Class))
    {
    }

    public MTLVisibleFunctionTableDescriptor Retain()
    {
        return new(ObjectiveC.Retain(NativePtr));
    }

    public void Release()
    {
        ObjectiveC.Release(NativePtr);
    }

    public void Dispose()
    {
        Release();
    }

    public nuint FunctionCount
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTLVisibleFunctionTableDescriptorBindings.FunctionCount);
        set => ObjectiveC.MsgSend(NativePtr, MTLVisibleFunctionTableDescriptorBindings.SetFunctionCount, value);
    }

    public static MTLVisibleFunctionTableDescriptor VisibleFunctionTableDescriptor()
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(MTLVisibleFunctionTableDescriptorBindings.Class, MTLVisibleFunctionTableDescriptorBindings.VisibleFunctionTableDescriptor);

        return new(nativePtr);
    }
}

file static class MTLVisibleFunctionTableDescriptorBindings
{
    public static readonly nint Class = ObjectiveC.GetClass("MTLVisibleFunctionTableDescriptor");

    public static readonly Selector FunctionCount = "functionCount";

    public static readonly Selector SetFunctionCount = "setFunctionCount:";

    public static readonly Selector VisibleFunctionTableDescriptor = "visibleFunctionTableDescriptor";
}
