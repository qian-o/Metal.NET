namespace Metal.NET;

public class MTL4LibraryFunctionDescriptor(nint nativePtr, NativeObjectOwnership ownership) : MTL4FunctionDescriptor(nativePtr, ownership), INativeObject<MTL4LibraryFunctionDescriptor>
{
    #region INativeObject
    public static new MTL4LibraryFunctionDescriptor Null { get; } = new(0, NativeObjectOwnership.Borrowed);

    public static new MTL4LibraryFunctionDescriptor New(nint nativePtr, NativeObjectOwnership ownership)
    {
        return new(nativePtr, ownership);
    }
    #endregion

    public MTL4LibraryFunctionDescriptor() : this(ObjectiveC.AllocInit(MTL4LibraryFunctionDescriptorBindings.Class), NativeObjectOwnership.Managed)
    {
    }

    public NSString Name
    {
        get => GetProperty(ref field, MTL4LibraryFunctionDescriptorBindings.Name);
        set => SetProperty(ref field, MTL4LibraryFunctionDescriptorBindings.SetName, value);
    }

    public MTLLibrary Library
    {
        get => GetProperty(ref field, MTL4LibraryFunctionDescriptorBindings.Library);
        set => SetProperty(ref field, MTL4LibraryFunctionDescriptorBindings.SetLibrary, value);
    }

    public NSString Name
    {
        get => GetProperty(ref field, MTL4LibraryFunctionDescriptorBindings.Name);
        set => SetProperty(ref field, MTL4LibraryFunctionDescriptorBindings.SetName, value);
    }

    public MTLLibrary Library
    {
        get => GetProperty(ref field, MTL4LibraryFunctionDescriptorBindings.Library);
        set => SetProperty(ref field, MTL4LibraryFunctionDescriptorBindings.SetLibrary, value);
    }

    public void SetName(NSString name)
    {
        ObjectiveC.MsgSend(NativePtr, MTL4LibraryFunctionDescriptorBindings.SetName, name.NativePtr);
    }

    public void SetLibrary(MTLLibrary library)
    {
        ObjectiveC.MsgSend(NativePtr, MTL4LibraryFunctionDescriptorBindings.SetLibrary, library.NativePtr);
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
