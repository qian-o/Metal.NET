namespace Metal.NET;

public class MTLFunctionLogDebugLocation(nint nativePtr, NativeObjectOwnership ownership) : ObjectiveCObject(nativePtr, ownership), INativeObject<MTLFunctionLogDebugLocation>
{
    #region INativeObject
    public static MTLFunctionLogDebugLocation Null { get; } = new(0, NativeObjectOwnership.Borrowed);

    public static MTLFunctionLogDebugLocation New(nint nativePtr, NativeObjectOwnership ownership)
    {
        return new(nativePtr, ownership);
    }
    #endregion

    public nuint Column
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTLFunctionLogDebugLocationBindings.Column);
    }

    public NSString FunctionName
    {
        get => GetProperty(ref field, MTLFunctionLogDebugLocationBindings.FunctionName);
    }

    public nuint Line
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTLFunctionLogDebugLocationBindings.Line);
    }

    public NSURL URL
    {
        get => GetProperty(ref field, MTLFunctionLogDebugLocationBindings.URL);
    }
}

file static class MTLFunctionLogDebugLocationBindings
{
    public static readonly Selector Column = "column";

    public static readonly Selector FunctionName = "functionName";

    public static readonly Selector Line = "line";

    public static readonly Selector URL = "URL";
}
