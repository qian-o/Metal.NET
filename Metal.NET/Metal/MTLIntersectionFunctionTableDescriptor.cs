namespace Metal.NET;

public class MTLIntersectionFunctionTableDescriptor : IDisposable
{
    public MTLIntersectionFunctionTableDescriptor(nint nativePtr)
    {
        ObjectiveCRuntime.Retain(NativePtr = nativePtr);
    }

    ~MTLIntersectionFunctionTableDescriptor()
    {
        Release();
    }

    public nint NativePtr { get; }

    private static readonly nint Class = ObjectiveCRuntime.GetClass("MTLIntersectionFunctionTableDescriptor");

    public nuint FunctionCount
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLIntersectionFunctionTableDescriptorSelector.FunctionCount);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLIntersectionFunctionTableDescriptorSelector.SetFunctionCount, value);
    }

    public static implicit operator nint(MTLIntersectionFunctionTableDescriptor value)
    {
        return value.NativePtr;
    }

    public static implicit operator MTLIntersectionFunctionTableDescriptor(nint value)
    {
        return new(value);
    }

    public static MTLIntersectionFunctionTableDescriptor IntersectionFunctionTableDescriptor()
    {
        MTLIntersectionFunctionTableDescriptor result = new(ObjectiveCRuntime.MsgSendPtr(Class, MTLIntersectionFunctionTableDescriptorSelector.IntersectionFunctionTableDescriptor));

        return result;
    }

    public void Dispose()
    {
        Release();

        GC.SuppressFinalize(this);
    }

    private void Release()
    {
        if (NativePtr is not 0)
        {
            ObjectiveCRuntime.Release(NativePtr);
        }
    }
}

file class MTLIntersectionFunctionTableDescriptorSelector
{
    public static readonly Selector FunctionCount = Selector.Register("functionCount");

    public static readonly Selector SetFunctionCount = Selector.Register("setFunctionCount:");

    public static readonly Selector IntersectionFunctionTableDescriptor = Selector.Register("intersectionFunctionTableDescriptor");
}
