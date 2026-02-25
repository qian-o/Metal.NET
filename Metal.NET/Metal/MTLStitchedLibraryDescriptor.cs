namespace Metal.NET;

public class MTLStitchedLibraryDescriptor(nint nativePtr, NativeObjectOwnership ownership) : NativeObject(nativePtr, ownership), INativeObject<MTLStitchedLibraryDescriptor>
{
    public static MTLStitchedLibraryDescriptor Null { get; } = new(0, NativeObjectOwnership.Borrowed);

    public static MTLStitchedLibraryDescriptor Create(nint nativePtr, NativeObjectOwnership ownership) => new(nativePtr, ownership);

    public MTLStitchedLibraryDescriptor() : this(ObjectiveCRuntime.AllocInit(MTLStitchedLibraryDescriptorBindings.Class), NativeObjectOwnership.Managed)
    {
    }

    public MTLBinaryArchive[] BinaryArchives
    {
        get => GetArrayProperty<MTLBinaryArchive>(MTLStitchedLibraryDescriptorBindings.BinaryArchives);
        set => SetArrayProperty(MTLStitchedLibraryDescriptorBindings.SetBinaryArchives, value);
    }

    public MTLFunctionStitchingGraph[] FunctionGraphs
    {
        get => GetArrayProperty<MTLFunctionStitchingGraph>(MTLStitchedLibraryDescriptorBindings.FunctionGraphs);
        set => SetArrayProperty(MTLStitchedLibraryDescriptorBindings.SetFunctionGraphs, value);
    }

    public MTLFunction[] Functions
    {
        get => GetArrayProperty<MTLFunction>(MTLStitchedLibraryDescriptorBindings.Functions);
        set => SetArrayProperty(MTLStitchedLibraryDescriptorBindings.SetFunctions, value);
    }

    public MTLStitchedLibraryOptions Options
    {
        get => (MTLStitchedLibraryOptions)ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLStitchedLibraryDescriptorBindings.Options);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLStitchedLibraryDescriptorBindings.SetOptions, (nuint)value);
    }
}

file static class MTLStitchedLibraryDescriptorBindings
{
    public static readonly nint Class = ObjectiveCRuntime.GetClass("MTLStitchedLibraryDescriptor");

    public static readonly Selector BinaryArchives = "binaryArchives";

    public static readonly Selector FunctionGraphs = "functionGraphs";

    public static readonly Selector Functions = "functions";

    public static readonly Selector Options = "options";

    public static readonly Selector SetBinaryArchives = "setBinaryArchives:";

    public static readonly Selector SetFunctionGraphs = "setFunctionGraphs:";

    public static readonly Selector SetFunctions = "setFunctions:";

    public static readonly Selector SetOptions = "setOptions:";
}
