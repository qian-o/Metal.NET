namespace Metal.NET;

public partial class MTLStitchedLibraryDescriptor : NativeObject
{
    private static readonly nint Class = ObjectiveCRuntime.GetClass("MTLStitchedLibraryDescriptor");

    public MTLStitchedLibraryDescriptor(nint nativePtr) : base(nativePtr)
    {
    }

    public NSArray? BinaryArchives
    {
        get
        {
            nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLStitchedLibraryDescriptorSelector.BinaryArchives);
            return ptr is not 0 ? new(ptr) : null;
        }
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLStitchedLibraryDescriptorSelector.SetBinaryArchives, value?.NativePtr ?? 0);
    }

    public NSArray? FunctionGraphs
    {
        get
        {
            nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLStitchedLibraryDescriptorSelector.FunctionGraphs);
            return ptr is not 0 ? new(ptr) : null;
        }
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLStitchedLibraryDescriptorSelector.SetFunctionGraphs, value?.NativePtr ?? 0);
    }

    public NSArray? Functions
    {
        get
        {
            nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLStitchedLibraryDescriptorSelector.Functions);
            return ptr is not 0 ? new(ptr) : null;
        }
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLStitchedLibraryDescriptorSelector.SetFunctions, value?.NativePtr ?? 0);
    }

    public nuint Options
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLStitchedLibraryDescriptorSelector.Options);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLStitchedLibraryDescriptorSelector.SetOptions, value);
    }
}

file static class MTLStitchedLibraryDescriptorSelector
{
    public static readonly Selector BinaryArchives = Selector.Register("binaryArchives");

    public static readonly Selector FunctionGraphs = Selector.Register("functionGraphs");

    public static readonly Selector Functions = Selector.Register("functions");

    public static readonly Selector Options = Selector.Register("options");

    public static readonly Selector SetBinaryArchives = Selector.Register("setBinaryArchives:");

    public static readonly Selector SetFunctionGraphs = Selector.Register("setFunctionGraphs:");

    public static readonly Selector SetFunctions = Selector.Register("setFunctions:");

    public static readonly Selector SetOptions = Selector.Register("setOptions:");
}
