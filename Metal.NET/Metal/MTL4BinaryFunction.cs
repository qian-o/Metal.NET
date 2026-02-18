namespace Metal.NET;

public class MTL4BinaryFunction : IDisposable
{
    public MTL4BinaryFunction(nint nativePtr)
    {
        if (nativePtr is not 0)
        {
            ObjectiveCRuntime.Retain(NativePtr = nativePtr);
        }
    }

    ~MTL4BinaryFunction()
    {
        Release();
    }

    public nint NativePtr { get; }

    public MTLFunctionType FunctionType
    {
        get => (MTLFunctionType)(ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTL4BinaryFunctionSelector.FunctionType));
    }

    public NSString Name
    {
        get => new(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTL4BinaryFunctionSelector.Name));
    }

    public static implicit operator nint(MTL4BinaryFunction value)
    {
        return value.NativePtr;
    }

    public static implicit operator MTL4BinaryFunction(nint value)
    {
        return new(value);
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

file class MTL4BinaryFunctionSelector
{
    public static readonly Selector FunctionType = Selector.Register("functionType");

    public static readonly Selector Name = Selector.Register("name");
}
