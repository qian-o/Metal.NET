namespace Metal.NET;

public readonly struct MTLStitchedLibraryDescriptor(nint nativePtr) : IDisposable
{
    public readonly nint NativePtr = nativePtr;

    public bool IsNull => NativePtr is 0;

    public static implicit operator NSObject(MTLStitchedLibraryDescriptor value) => new(value.NativePtr);

    public MTLStitchedLibraryDescriptor() : this(ObjectiveC.AllocInit(MTLStitchedLibraryDescriptorBindings.Class))
    {
    }

    public MTLStitchedLibraryDescriptor Retain()
    {
        return new(ObjectiveC.Retain(NativePtr));
    }

    public void Release()
    {
        ObjectiveC.Release(NativePtr);
    }

    public void Dispose()
    {
        Release();
    }

    public NSArray<MTLFunctionStitchingGraph> FunctionGraphs
    {
        get => new(ObjectiveC.MsgSendNInt(NativePtr, MTLStitchedLibraryDescriptorBindings.FunctionGraphs));
        set => ObjectiveC.MsgSend(NativePtr, MTLStitchedLibraryDescriptorBindings.SetFunctionGraphs, value.NativePtr);
    }

    public NSArray<MTLFunction> Functions
    {
        get => new(ObjectiveC.MsgSendNInt(NativePtr, MTLStitchedLibraryDescriptorBindings.Functions));
        set => ObjectiveC.MsgSend(NativePtr, MTLStitchedLibraryDescriptorBindings.SetFunctions, value.NativePtr);
    }

    public NSArray<MTLBinaryArchive> BinaryArchives
    {
        get => new(ObjectiveC.MsgSendNInt(NativePtr, MTLStitchedLibraryDescriptorBindings.BinaryArchives));
        set => ObjectiveC.MsgSend(NativePtr, MTLStitchedLibraryDescriptorBindings.SetBinaryArchives, value.NativePtr);
    }

    public MTLStitchedLibraryOptions Options
    {
        get => (MTLStitchedLibraryOptions)ObjectiveC.MsgSendULong(NativePtr, MTLStitchedLibraryDescriptorBindings.Options);
        set => ObjectiveC.MsgSend(NativePtr, MTLStitchedLibraryDescriptorBindings.SetOptions, (nuint)value);
    }
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
