namespace Metal.NET;

public class MTLFunctionStitchingGraph(nint nativePtr, NativeObjectOwnership ownership) : NSObject(nativePtr, ownership), INativeObject<MTLFunctionStitchingGraph>
{
    #region INativeObject
    public static new MTLFunctionStitchingGraph Null { get; } = new(0, NativeObjectOwnership.Borrowed);

    public static new MTLFunctionStitchingGraph New(nint nativePtr, NativeObjectOwnership ownership)
    {
        return new(nativePtr, ownership);
    }
    #endregion

    public NSString FunctionName
    {
        get => GetProperty(ref field, MTLFunctionStitchingGraphBindings.FunctionName);
        set => SetProperty(ref field, MTLFunctionStitchingGraphBindings.SetFunctionName, value);
    }

    public MTLFunctionStitchingFunctionNode OutputNode
    {
        get => GetProperty(ref field, MTLFunctionStitchingGraphBindings.OutputNode);
        set => SetProperty(ref field, MTLFunctionStitchingGraphBindings.SetOutputNode, value);
    }
}

file static class MTLFunctionStitchingGraphBindings
{
    public static readonly Selector FunctionName = "functionName";

    public static readonly Selector OutputNode = "outputNode";

    public static readonly Selector SetFunctionName = "setFunctionName:";

    public static readonly Selector SetOutputNode = "setOutputNode:";
}
