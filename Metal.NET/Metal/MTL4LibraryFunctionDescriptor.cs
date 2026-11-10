namespace Metal.NET;

public readonly struct MTL4LibraryFunctionDescriptor(nint nativePtr) : IDisposable
{
    public readonly nint NativePtr = nativePtr;

    public bool IsNull => NativePtr is 0;

    public static implicit operator MTL4FunctionDescriptor(MTL4LibraryFunctionDescriptor value) => new(value.NativePtr);

    public static implicit operator NSObject(MTL4LibraryFunctionDescriptor value) => new(value.NativePtr);

    public MTL4LibraryFunctionDescriptor() : this(ObjectiveC.AllocInit(MTL4LibraryFunctionDescriptorBindings.Class))
    {
    }

    public MTL4LibraryFunctionDescriptor Retain()
    {
        return new(ObjectiveC.Retain(NativePtr));
    }

    public void Dispose()
    {
        ObjectiveC.Release(NativePtr);
    }

    public NSString Name
    {
        get => new(ObjectiveC.MsgSendNInt(NativePtr, MTL4LibraryFunctionDescriptorBindings.Name));
        set => ObjectiveC.MsgSend(NativePtr, MTL4LibraryFunctionDescriptorBindings.SetName, value.NativePtr);
    }

    public MTLLibrary Library
    {
        get => new(ObjectiveC.MsgSendNInt(NativePtr, MTL4LibraryFunctionDescriptorBindings.Library));
        set => ObjectiveC.MsgSend(NativePtr, MTL4LibraryFunctionDescriptorBindings.SetLibrary, value.NativePtr);
    }
}

file static class MTL4LibraryFunctionDescriptorBindings
{
    public static readonly nint Class = ObjectiveC.GetClass("MTL4LibraryFunctionDescriptor");

    public static readonly Selector Library = "library";

    public static readonly Selector Name = "name";

    public static readonly Selector SetLibrary = "setLibrary:";

    public static readonly Selector SetName = "setName:";
}
