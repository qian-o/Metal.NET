namespace Metal.NET;

public readonly struct MTLStitchedLibraryDescriptor(nint nativePtr)
{
    public readonly nint NativePtr = nativePtr;

    public MTLStitchedLibraryDescriptor() : this(ObjectiveCRuntime.AllocInit(MTLStitchedLibraryDescriptorBindings.Class))
    {
    }

    public NSArray? BinaryArchives
    {
        get
        {
            nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLStitchedLibraryDescriptorBindings.BinaryArchives);
            return ptr is not 0 ? new NSArray(ptr) : default;
        }
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLStitchedLibraryDescriptorBindings.SetBinaryArchives, value?.NativePtr ?? 0);
    }

    public NSArray? FunctionGraphs
    {
        get
        {
            nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLStitchedLibraryDescriptorBindings.FunctionGraphs);
            return ptr is not 0 ? new NSArray(ptr) : default;
        }
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLStitchedLibraryDescriptorBindings.SetFunctionGraphs, value?.NativePtr ?? 0);
    }

    public NSArray? Functions
    {
        get
        {
            nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLStitchedLibraryDescriptorBindings.Functions);
            return ptr is not 0 ? new NSArray(ptr) : default;
        }
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLStitchedLibraryDescriptorBindings.SetFunctions, value?.NativePtr ?? 0);
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

    public static readonly Selector BinaryArchives = Selector.Register("binaryArchives");

    public static readonly Selector FunctionGraphs = Selector.Register("functionGraphs");

    public static readonly Selector Functions = Selector.Register("functions");

    public static readonly Selector Options = Selector.Register("options");

    public static readonly Selector SetBinaryArchives = Selector.Register("setBinaryArchives:");

    public static readonly Selector SetFunctionGraphs = Selector.Register("setFunctionGraphs:");

    public static readonly Selector SetFunctions = Selector.Register("setFunctions:");

    public static readonly Selector SetOptions = Selector.Register("setOptions:");
}
