namespace Metal.NET;

public class MTLFunctionDescriptor : IDisposable
{
    private static readonly nint Class = ObjectiveCRuntime.GetClass("MTLFunctionDescriptor");

    public MTLFunctionDescriptor(nint nativePtr)
    {
        if (nativePtr is not 0)
        {
            ObjectiveCRuntime.Retain(NativePtr = nativePtr);
        }
    }

    public MTLFunctionDescriptor() : this(ObjectiveCRuntime.AllocInit(Class))
    {
    }

    ~MTLFunctionDescriptor()
    {
        Release();
    }

    public nint NativePtr { get; }

    public NSArray BinaryArchives
    {
        get => new(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLFunctionDescriptorSelector.BinaryArchives));
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLFunctionDescriptorSelector.SetBinaryArchives, value.NativePtr);
    }

    public NSString Name
    {
        get => new(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLFunctionDescriptorSelector.Name));
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLFunctionDescriptorSelector.SetName, value.NativePtr);
    }

    public NSString SpecializedName
    {
        get => new(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLFunctionDescriptorSelector.SpecializedName));
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLFunctionDescriptorSelector.SetSpecializedName, value.NativePtr);
    }

    public static implicit operator nint(MTLFunctionDescriptor value)
    {
        return value.NativePtr;
    }

    public static implicit operator MTLFunctionDescriptor(nint value)
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

file class MTLFunctionDescriptorSelector
{
    public static readonly Selector BinaryArchives = Selector.Register("binaryArchives");

    public static readonly Selector SetBinaryArchives = Selector.Register("setBinaryArchives:");

    public static readonly Selector Name = Selector.Register("name");

    public static readonly Selector SetName = Selector.Register("setName:");

    public static readonly Selector SpecializedName = Selector.Register("specializedName");

    public static readonly Selector SetSpecializedName = Selector.Register("setSpecializedName:");
}
