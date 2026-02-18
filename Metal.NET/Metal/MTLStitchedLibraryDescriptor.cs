namespace Metal.NET;

public class MTLStitchedLibraryDescriptor(nint nativePtr) : NativeObject(nativePtr)
{
    public MTLStitchedLibraryDescriptor() : this(ObjectiveCRuntime.AllocInit(MTLStitchedLibraryDescriptorSelector.Class))
    {
    }

    public NSArray? BinaryArchives
    {
        get => GetNullableObject<NSArray>(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLStitchedLibraryDescriptorSelector.BinaryArchives));
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLStitchedLibraryDescriptorSelector.SetBinaryArchives, value?.NativePtr ?? 0);
    }

    public NSArray? FunctionGraphs
    {
        get => GetNullableObject<NSArray>(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLStitchedLibraryDescriptorSelector.FunctionGraphs));
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLStitchedLibraryDescriptorSelector.SetFunctionGraphs, value?.NativePtr ?? 0);
    }

    public NSArray? Functions
    {
        get => GetNullableObject<NSArray>(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLStitchedLibraryDescriptorSelector.Functions));
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLStitchedLibraryDescriptorSelector.SetFunctions, value?.NativePtr ?? 0);
    }

    public MTLStitchedLibraryOptions Options
    {
        get => (MTLStitchedLibraryOptions)ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLStitchedLibraryDescriptorSelector.Options);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLStitchedLibraryDescriptorSelector.SetOptions, (nuint)value);
    }
}

file static class MTLStitchedLibraryDescriptorSelector
{
    public static readonly nint Class = ObjectiveCRuntime.GetClass("MTLStitchedLibraryDescriptor");

    public static readonly Selector BinaryArchives = Selector.Register("binaryArchives");

    public static readonly Selector FunctionGraphs = Selector.Register("functionGraphs");

    public static readonly Selector Functions = Selector.Register("functions");

    public static readonly Selector Options = Selector.Register("options");

    public static readonly Selector SetBinaryArchives = Selector.Register("setBinaryArchives:");

    public static readonly Selector SetFunctionGraphs = Selector.Register("setFunctionGraphs:");

    public static readonly Selector SetFunctions = Selector.Register("setFunctions:");

    public static readonly Selector SetOptions = Selector.Register("setOptions:");
}
