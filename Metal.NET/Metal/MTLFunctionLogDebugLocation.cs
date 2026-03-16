namespace Metal.NET;

/// <summary>The source code that logged a debug message.</summary>
public class MTLFunctionLogDebugLocation(nint nativePtr, NativeObjectOwnership ownership) : NSObject(nativePtr, ownership), INativeObject<MTLFunctionLogDebugLocation>
{
    #region INativeObject
    public static new MTLFunctionLogDebugLocation Null { get; } = new(0, NativeObjectOwnership.Borrowed);

    public static new MTLFunctionLogDebugLocation New(nint nativePtr, NativeObjectOwnership ownership)
    {
        return new(nativePtr, ownership);
    }
    #endregion

    #region Inspecting the location details - Properties

    /// <summary>The name of the shader function.</summary>
    public NSString FunctionName
    {
        get => GetProperty(ref field, MTLFunctionLogDebugLocationBindings.FunctionName);
    }

    /// <summary>The URL of the file that contains the shader function.</summary>
    public NSURL URL
    {
        get => GetProperty(ref field, MTLFunctionLogDebugLocationBindings.URL);
    }

    /// <summary>The line that the log message appears on.</summary>
    public nuint Line
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTLFunctionLogDebugLocationBindings.Line);
    }

    /// <summary>The column where the log message appears.</summary>
    public nuint Column
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTLFunctionLogDebugLocationBindings.Column);
    }
    #endregion
}

file static class MTLFunctionLogDebugLocationBindings
{
    public static readonly Selector Column = "column";

    public static readonly Selector FunctionName = "functionName";

    public static readonly Selector Line = "line";

    public static readonly Selector URL = "URL";
}
