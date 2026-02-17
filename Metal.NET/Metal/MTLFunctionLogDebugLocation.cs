namespace Metal.NET;

public class MTLFunctionLogDebugLocation : IDisposable
{
    public MTLFunctionLogDebugLocation(nint nativePtr)
    {
        ObjectiveCRuntime.Retain(NativePtr = nativePtr);
    }

    ~MTLFunctionLogDebugLocation()
    {
        Release();
    }

    public nint NativePtr { get; }

    public NSURL URL => new(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLFunctionLogDebugLocationSelector.URL));

    public nuint Column => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLFunctionLogDebugLocationSelector.Column);

    public NSString FunctionName => new(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLFunctionLogDebugLocationSelector.FunctionName));

    public nuint Line => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLFunctionLogDebugLocationSelector.Line);

    public static implicit operator nint(MTLFunctionLogDebugLocation value)
    {
        return value.NativePtr;
    }

    public static implicit operator MTLFunctionLogDebugLocation(nint value)
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

file class MTLFunctionLogDebugLocationSelector
{
    public static readonly Selector URL = Selector.Register("URL");

    public static readonly Selector Column = Selector.Register("column");

    public static readonly Selector FunctionName = Selector.Register("functionName");

    public static readonly Selector Line = Selector.Register("line");
}
