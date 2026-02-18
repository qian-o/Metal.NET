namespace Metal.NET;

public class MTLBinding : IDisposable
{
    public MTLBinding(nint nativePtr)
    {
        if (nativePtr is not 0)
        {
            ObjectiveCRuntime.Retain(NativePtr = nativePtr);
        }
    }

    ~MTLBinding()
    {
        Release();
    }

    public nint NativePtr { get; }

    public MTLBindingAccess Access
    {
        get => (MTLBindingAccess)(ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLBindingSelector.Access));
    }

    public Bool8 Argument
    {
        get => ObjectiveCRuntime.MsgSendBool(NativePtr, MTLBindingSelector.Argument);
    }

    public nuint Index
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLBindingSelector.Index);
    }

    public Bool8 IsArgument
    {
        get => ObjectiveCRuntime.MsgSendBool(NativePtr, MTLBindingSelector.IsArgument);
    }

    public Bool8 IsUsed
    {
        get => ObjectiveCRuntime.MsgSendBool(NativePtr, MTLBindingSelector.IsUsed);
    }

    public NSString Name
    {
        get => new(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLBindingSelector.Name));
    }

    public MTLBindingType Type
    {
        get => (MTLBindingType)(ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLBindingSelector.Type));
    }

    public Bool8 Used
    {
        get => ObjectiveCRuntime.MsgSendBool(NativePtr, MTLBindingSelector.Used);
    }

    public static implicit operator nint(MTLBinding value)
    {
        return value.NativePtr;
    }

    public static implicit operator MTLBinding(nint value)
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

file class MTLBindingSelector
{
    public static readonly Selector Access = Selector.Register("access");

    public static readonly Selector Argument = Selector.Register("argument");

    public static readonly Selector Index = Selector.Register("index");

    public static readonly Selector IsArgument = Selector.Register("isArgument");

    public static readonly Selector IsUsed = Selector.Register("isUsed");

    public static readonly Selector Name = Selector.Register("name");

    public static readonly Selector Type = Selector.Register("type");

    public static readonly Selector Used = Selector.Register("used");
}
