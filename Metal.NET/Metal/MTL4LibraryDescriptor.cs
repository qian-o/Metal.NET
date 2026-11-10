namespace Metal.NET;

public readonly struct MTL4LibraryDescriptor(nint nativePtr) : IDisposable
{
    public readonly nint NativePtr = nativePtr;

    public bool IsNull => NativePtr is 0;

    public static implicit operator NSObject(MTL4LibraryDescriptor value) => new(value.NativePtr);

    public MTL4LibraryDescriptor() : this(ObjectiveC.AllocInit(MTL4LibraryDescriptorBindings.Class))
    {
    }

    public MTL4LibraryDescriptor Retain()
    {
        return new(ObjectiveC.Retain(NativePtr));
    }

    public void Dispose()
    {
        ObjectiveC.Release(NativePtr);
    }

    public NSString Source
    {
        get => new(ObjectiveC.MsgSendNInt(NativePtr, MTL4LibraryDescriptorBindings.Source));
        set => ObjectiveC.MsgSend(NativePtr, MTL4LibraryDescriptorBindings.SetSource, value.NativePtr);
    }

    public MTLCompileOptions Options
    {
        get => new(ObjectiveC.MsgSendNInt(NativePtr, MTL4LibraryDescriptorBindings.Options));
        set => ObjectiveC.MsgSend(NativePtr, MTL4LibraryDescriptorBindings.SetOptions, value.NativePtr);
    }

    public NSString Name
    {
        get => new(ObjectiveC.MsgSendNInt(NativePtr, MTL4LibraryDescriptorBindings.Name));
        set => ObjectiveC.MsgSend(NativePtr, MTL4LibraryDescriptorBindings.SetName, value.NativePtr);
    }
}

file static class MTL4LibraryDescriptorBindings
{
    public static readonly nint Class = ObjectiveC.GetClass("MTL4LibraryDescriptor");

    public static readonly Selector Name = "name";

    public static readonly Selector Options = "options";

    public static readonly Selector SetName = "setName:";

    public static readonly Selector SetOptions = "setOptions:";

    public static readonly Selector SetSource = "setSource:";

    public static readonly Selector Source = "source";
}
