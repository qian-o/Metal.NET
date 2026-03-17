namespace Metal.NET;

public class MTLFunctionStitchingFunctionNode(nint nativePtr, NativeObjectOwnership ownership) : NSObject(nativePtr, ownership), INativeObject<MTLFunctionStitchingFunctionNode>
{
    #region INativeObject
    public static new MTLFunctionStitchingFunctionNode Null { get; } = new(0, NativeObjectOwnership.Borrowed);

    public static new MTLFunctionStitchingFunctionNode New(nint nativePtr, NativeObjectOwnership ownership)
    {
        return new(nativePtr, ownership);
    }
    #endregion

    public NSString Name
    {
        get => GetProperty(ref field, MTLFunctionStitchingFunctionNodeBindings.Name);
        set => SetProperty(ref field, MTLFunctionStitchingFunctionNodeBindings.SetName, value);
    }

    public MTLArgument[] Arguments
    {
        get => GetArrayProperty<MTLArgument>(MTLFunctionStitchingFunctionNodeBindings.Arguments);
        set => SetArrayProperty(MTLFunctionStitchingFunctionNodeBindings.SetArguments, value);
    }

    public MTLFunctionStitchingFunctionNode[] ControlDependencies
    {
        get => GetArrayProperty<MTLFunctionStitchingFunctionNode>(MTLFunctionStitchingFunctionNodeBindings.ControlDependencies);
        set => SetArrayProperty(MTLFunctionStitchingFunctionNodeBindings.SetControlDependencies, value);
    }
}

file static class MTLFunctionStitchingFunctionNodeBindings
{
    public static readonly Selector Arguments = "arguments";

    public static readonly Selector ControlDependencies = "controlDependencies";

    public static readonly Selector Name = "name";

    public static readonly Selector SetArguments = "setArguments:";

    public static readonly Selector SetControlDependencies = "setControlDependencies:";

    public static readonly Selector SetName = "setName:";
}
