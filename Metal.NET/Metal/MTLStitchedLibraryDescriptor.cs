namespace Metal.NET;

public class MTLStitchedLibraryDescriptor : IDisposable
{
    private static readonly nint Class = ObjectiveCRuntime.GetClass("MTLStitchedLibraryDescriptor");

    public MTLStitchedLibraryDescriptor(nint nativePtr)
    {
        if (nativePtr is not 0)
        {
            ObjectiveCRuntime.Retain(NativePtr = nativePtr);
        }
    }

    public MTLStitchedLibraryDescriptor() : this(ObjectiveCRuntime.AllocInit(Class))
    {
    }

    ~MTLStitchedLibraryDescriptor()
    {
        Release();
    }

    public nint NativePtr { get; }

    public NSArray BinaryArchives
    {
        get => new(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLStitchedLibraryDescriptorSelector.BinaryArchives));
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLStitchedLibraryDescriptorSelector.SetBinaryArchives, value.NativePtr);
    }

    public NSArray FunctionGraphs
    {
        get => new(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLStitchedLibraryDescriptorSelector.FunctionGraphs));
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLStitchedLibraryDescriptorSelector.SetFunctionGraphs, value.NativePtr);
    }

    public NSArray Functions
    {
        get => new(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLStitchedLibraryDescriptorSelector.Functions));
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLStitchedLibraryDescriptorSelector.SetFunctions, value.NativePtr);
    }

    public MTLStitchedLibraryOptions Options
    {
        get => (MTLStitchedLibraryOptions)ObjectiveCRuntime.MsgSendULong(NativePtr, MTLStitchedLibraryDescriptorSelector.Options);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLStitchedLibraryDescriptorSelector.SetOptions, (ulong)value);
    }

    public static implicit operator nint(MTLStitchedLibraryDescriptor value)
    {
        return value.NativePtr;
    }

    public static implicit operator MTLStitchedLibraryDescriptor(nint value)
    {
        return new(value);
    }

    public void Dispose()
    {
        Release();

        GC.SuppressFinalize(this);
    }

    private void Release()
    {
        if (NativePtr is not 0)
        {
            ObjectiveCRuntime.Release(NativePtr);
        }
    }
}

file class MTLStitchedLibraryDescriptorSelector
{
    public static readonly Selector BinaryArchives = Selector.Register("binaryArchives");

    public static readonly Selector SetBinaryArchives = Selector.Register("setBinaryArchives:");

    public static readonly Selector FunctionGraphs = Selector.Register("functionGraphs");

    public static readonly Selector SetFunctionGraphs = Selector.Register("setFunctionGraphs:");

    public static readonly Selector Functions = Selector.Register("functions");

    public static readonly Selector SetFunctions = Selector.Register("setFunctions:");

    public static readonly Selector Options = Selector.Register("options");

    public static readonly Selector SetOptions = Selector.Register("setOptions:");
}
