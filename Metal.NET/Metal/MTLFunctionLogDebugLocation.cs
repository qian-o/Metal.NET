namespace Metal.NET;

public class MTLFunctionLogDebugLocation(nint nativePtr, NativeObjectOwnership ownership) : NSObject(nativePtr, ownership), INativeObject<MTLFunctionLogDebugLocation>
{
    #region INativeObject
    public static new MTLFunctionLogDebugLocation Null { get; } = new(0, NativeObjectOwnership.Borrowed);

    public static new MTLFunctionLogDebugLocation New(nint nativePtr, NativeObjectOwnership ownership)
    {
        return new(nativePtr, ownership);
    }
    #endregion

    public NSString FunctionName
    {
        get => GetProperty(ref field, MTLFunctionLogDebugLocationBindings.FunctionName);
    }

    public NSURL Url
    {
        get => GetProperty(ref field, MTLFunctionLogDebugLocationBindings.Url);
    }

    public nuint Line
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTLFunctionLogDebugLocationBindings.Line);
    }

    public nuint Column
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTLFunctionLogDebugLocationBindings.Column);
    }
}

file static class MTLFunctionLogDebugLocationBindings
{
    public static readonly Selector Column = "column";

    public static readonly Selector FunctionName = "functionName";

    public static readonly Selector Line = "line";

    public static readonly Selector Url = "url";
}
