namespace Metal.NET;

public class MTLFunctionConstant : IDisposable
{
    public MTLFunctionConstant(nint nativePtr)
    {
        if (nativePtr is not 0)
        {
            ObjectiveCRuntime.Retain(NativePtr = nativePtr);
        }
    }

    ~MTLFunctionConstant()
    {
        Release();
    }

    public nint NativePtr { get; }

    public nuint Index
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLFunctionConstantSelector.Index);
    }

    public NSString Name
    {
        get => new(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLFunctionConstantSelector.Name));
    }

    public Bool8 Required
    {
        get => ObjectiveCRuntime.MsgSendBool(NativePtr, MTLFunctionConstantSelector.Required);
    }

    public MTLDataType Type
    {
        get => (MTLDataType)(ObjectiveCRuntime.MsgSendUInt(NativePtr, MTLFunctionConstantSelector.Type));
    }

    public static implicit operator nint(MTLFunctionConstant value)
    {
        return value.NativePtr;
    }

    public static implicit operator MTLFunctionConstant(nint value)
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

file class MTLFunctionConstantSelector
{
    public static readonly Selector Index = Selector.Register("index");

    public static readonly Selector Name = Selector.Register("name");

    public static readonly Selector Required = Selector.Register("required");

    public static readonly Selector Type = Selector.Register("type");
}
