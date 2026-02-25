namespace Metal.NET;

public class MTLFunctionStitchingFunctionNode(nint nativePtr, bool ownsReference) : MTLFunctionStitchingNode(nativePtr, ownsReference), INativeObject<MTLFunctionStitchingFunctionNode>
{
    public static new MTLFunctionStitchingFunctionNode Null { get; } = new(0, false);

    public static new MTLFunctionStitchingFunctionNode Create(nint nativePtr, bool ownsReference) => new(nativePtr, ownsReference);

    public MTLFunctionStitchingFunctionNode() : this(ObjectiveCRuntime.AllocInit(MTLFunctionStitchingFunctionNodeBindings.Class), true)
    {
        GC.ReRegisterForFinalize(this);
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

    public NSString Name
    {
        get => GetProperty(ref field, MTLFunctionStitchingFunctionNodeBindings.Name);
        set => SetProperty(ref field, MTLFunctionStitchingFunctionNodeBindings.SetName, value);
    }
}

file static class MTLFunctionStitchingFunctionNodeBindings
{
    public static readonly nint Class = ObjectiveCRuntime.GetClass("MTLFunctionStitchingFunctionNode");

    public static readonly Selector Arguments = "arguments";

    public static readonly Selector ControlDependencies = "controlDependencies";

    public static readonly Selector Name = "name";

    public static readonly Selector SetArguments = "setArguments:";

    public static readonly Selector SetControlDependencies = "setControlDependencies:";

    public static readonly Selector SetName = "setName:";
}
