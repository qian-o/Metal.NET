namespace Metal.NET;

public class MTLStitchedLibraryDescriptor(nint nativePtr, bool retain) : NativeObject(nativePtr, retain)
{
    public MTLStitchedLibraryDescriptor() : this(ObjectiveCRuntime.AllocInit(MTLStitchedLibraryDescriptorBindings.Class), false)
    {
    }

    public NSArray? BinaryArchives
    {
        get => GetProperty(ref field, MTLStitchedLibraryDescriptorBindings.BinaryArchives);
        set => SetProperty(ref field, MTLStitchedLibraryDescriptorBindings.SetBinaryArchives, value);
    }

    public NSArray? FunctionGraphs
    {
        get => GetProperty(ref field, MTLStitchedLibraryDescriptorBindings.FunctionGraphs);
        set => SetProperty(ref field, MTLStitchedLibraryDescriptorBindings.SetFunctionGraphs, value);
    }

    public NSArray? Functions
    {
        get => GetProperty(ref field, MTLStitchedLibraryDescriptorBindings.Functions);
        set => SetProperty(ref field, MTLStitchedLibraryDescriptorBindings.SetFunctions, value);
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
