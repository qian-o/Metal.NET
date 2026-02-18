namespace Metal.NET;

public class MTLFunctionLog : IDisposable
{
    public MTLFunctionLog(nint nativePtr)
    {
        if (nativePtr is not 0)
        {
            ObjectiveCRuntime.Retain(NativePtr = nativePtr);
        }
    }

    ~MTLFunctionLog()
    {
        Release();
    }

    public nint NativePtr { get; }

    public NSString EncoderLabel
    {
        get => new(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLFunctionLogSelector.EncoderLabel));
    }

    public static implicit operator nint(MTLFunctionLog value)
    {
        return value.NativePtr;
    }

    public static implicit operator MTLFunctionLog(nint value)
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

file class MTLFunctionLogSelector
{
    public static readonly Selector EncoderLabel = Selector.Register("encoderLabel");
}
