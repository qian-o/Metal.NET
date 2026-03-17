namespace Metal.NET;

/// <summary>
/// A description of a new library of procedurally generated functions.
/// </summary>
public class MTLStitchedLibraryDescriptor(nint nativePtr, NativeObjectOwnership ownership) : NSObject(nativePtr, ownership), INativeObject<MTLStitchedLibraryDescriptor>
{
    #region INativeObject
    public static new MTLStitchedLibraryDescriptor Null { get; } = new(0, NativeObjectOwnership.Borrowed);

    public static new MTLStitchedLibraryDescriptor New(nint nativePtr, NativeObjectOwnership ownership)
    {
        return new(nativePtr, ownership);
    }
    #endregion

    public MTLStitchedLibraryDescriptor() : this(ObjectiveC.AllocInit(MTLStitchedLibraryDescriptorBindings.Class), NativeObjectOwnership.Managed)
    {
    }

    #region Configuring a stitched library - Properties

    /// <summary>
    /// The list of functions for creating the stitched library.
    /// </summary>
    public MTLFunction[] Functions
    {
        get => GetArrayProperty<MTLFunction>(MTLStitchedLibraryDescriptorBindings.Functions);
        set => SetArrayProperty(MTLStitchedLibraryDescriptorBindings.SetFunctions, value);
    }

    /// <summary>
    /// The function graphs that define the new stitched library’s functions.
    /// </summary>
    public MTLFunctionStitchingGraph[] FunctionGraphs
    {
        get => GetArrayProperty<MTLFunctionStitchingGraph>(MTLStitchedLibraryDescriptorBindings.FunctionGraphs);
        set => SetArrayProperty(MTLStitchedLibraryDescriptorBindings.SetFunctionGraphs, value);
    }
    #endregion

    #region Instance Properties - Properties

    public MTLBinaryArchive[] BinaryArchives
    {
        get => GetArrayProperty<MTLBinaryArchive>(MTLStitchedLibraryDescriptorBindings.BinaryArchives);
        set => SetArrayProperty(MTLStitchedLibraryDescriptorBindings.SetBinaryArchives, value);
    }

    public MTLStitchedLibraryOptions Options
    {
        get => (MTLStitchedLibraryOptions)ObjectiveC.MsgSendULong(NativePtr, MTLStitchedLibraryDescriptorBindings.Options);
        set => ObjectiveC.MsgSend(NativePtr, MTLStitchedLibraryDescriptorBindings.SetOptions, (nuint)value);
    }
    #endregion
}

file static class MTLStitchedLibraryDescriptorBindings
{
    public static readonly nint Class = ObjectiveC.GetClass("MTLStitchedLibraryDescriptor");

    public static readonly Selector BinaryArchives = "binaryArchives";

    public static readonly Selector FunctionGraphs = "functionGraphs";

    public static readonly Selector Functions = "functions";

    public static readonly Selector Options = "options";

    public static readonly Selector SetBinaryArchives = "setBinaryArchives:";

    public static readonly Selector SetFunctionGraphs = "setFunctionGraphs:";

    public static readonly Selector SetFunctions = "setFunctions:";

    public static readonly Selector SetOptions = "setOptions:";
}
