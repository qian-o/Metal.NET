namespace Metal.NET;

public class MTLFunctionStitchingFunctionNode(nint nativePtr, NativeObjectOwnership ownership) : MTLFunctionStitchingNode(nativePtr, ownership), INativeObject<MTLFunctionStitchingFunctionNode>
{
    #region INativeObject
    public static new MTLFunctionStitchingFunctionNode Null { get; } = new(0, NativeObjectOwnership.Borrowed);

    public static new MTLFunctionStitchingFunctionNode New(nint nativePtr, NativeObjectOwnership ownership)
    {
        return new(nativePtr, ownership);
    }
    #endregion

    public MTLFunctionStitchingFunctionNode() : this(ObjectiveC.AllocInit(MTLFunctionStitchingFunctionNodeBindings.Class), NativeObjectOwnership.Managed)
    {
    }

    public NSString Name
    {
        get => GetProperty(ref field, MTLFunctionStitchingFunctionNodeBindings.Name);
        set => SetProperty(ref field, MTLFunctionStitchingFunctionNodeBindings.SetName, value);
    }

    public MTLFunctionStitchingNode[] Arguments
    {
        get => GetArrayProperty<MTLFunctionStitchingNode>(MTLFunctionStitchingFunctionNodeBindings.Arguments);
        set => SetArrayProperty(MTLFunctionStitchingFunctionNodeBindings.SetArguments, value);
    }

    public MTLFunctionStitchingFunctionNode[] ControlDependencies
    {
        get => GetArrayProperty<MTLFunctionStitchingFunctionNode>(MTLFunctionStitchingFunctionNodeBindings.ControlDependencies);
        set => SetArrayProperty(MTLFunctionStitchingFunctionNodeBindings.SetControlDependencies, value);
    }

    public static MTLFunctionStitchingFunctionNode InitWithName(NSString name, MTLFunctionStitchingNode[] arguments, MTLFunctionStitchingFunctionNode[] controlDependencies)
    {
        nint pArguments = NSArray.FromArray(arguments);
        nint pControlDependencies = NSArray.FromArray(controlDependencies);

        nint nativePtr = ObjectiveC.MsgSendNInt(ObjectiveC.Alloc(MTLFunctionStitchingFunctionNodeBindings.Class), MTLFunctionStitchingFunctionNodeBindings.InitWithName_Arguments_ControlDependencies, name.NativePtr, pArguments, pControlDependencies);

        ObjectiveC.Release(pArguments);
        ObjectiveC.Release(pControlDependencies);

        return new(nativePtr, NativeObjectOwnership.Managed);
    }
}

file static class MTLFunctionStitchingFunctionNodeBindings
{
    public static readonly nint Class = ObjectiveC.GetClass("MTLFunctionStitchingFunctionNode");

    public static readonly Selector Arguments = "arguments";

    public static readonly Selector ControlDependencies = "controlDependencies";

    public static readonly Selector InitWithName_Arguments_ControlDependencies = "initWithName:arguments:controlDependencies:";

    public static readonly Selector Name = "name";

    public static readonly Selector SetArguments = "setArguments:";

    public static readonly Selector SetControlDependencies = "setControlDependencies:";

    public static readonly Selector SetName = "setName:";
}
