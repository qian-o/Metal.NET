namespace Metal.NET;

public class MTLFunctionStitchingFunctionNode(nint nativePtr, bool retain) : MTLFunctionStitchingNode(nativePtr, retain)
{
    public MTLFunctionStitchingFunctionNode() : this(ObjectiveCRuntime.AllocInit(MTLFunctionStitchingFunctionNodeBindings.Class), false)
    {
    }

    public NSArray? Arguments
    {
        get => GetProperty(ref field, MTLFunctionStitchingFunctionNodeBindings.Arguments);
        set => SetProperty(ref field, MTLFunctionStitchingFunctionNodeBindings.SetArguments, value);
    }

    public NSArray? ControlDependencies
    {
        get => GetProperty(ref field, MTLFunctionStitchingFunctionNodeBindings.ControlDependencies);
        set => SetProperty(ref field, MTLFunctionStitchingFunctionNodeBindings.SetControlDependencies, value);
    }

    public NSString? Name
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
