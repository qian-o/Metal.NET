namespace Metal.NET;

public class MTL4LibraryFunctionDescriptor(nint nativePtr, bool ownsReference) : MTL4FunctionDescriptor(nativePtr, ownsReference), INativeObject<MTL4LibraryFunctionDescriptor>
{
    public static new MTL4LibraryFunctionDescriptor Create(nint nativePtr) => new(nativePtr, true);

    public static new MTL4LibraryFunctionDescriptor CreateBorrowed(nint nativePtr) => new(nativePtr, false);

    public MTL4LibraryFunctionDescriptor() : this(ObjectiveCRuntime.AllocInit(MTL4LibraryFunctionDescriptorBindings.Class), true)
    {
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
}

file static class MTL4LibraryFunctionDescriptorBindings
{
    public static readonly nint Class = ObjectiveCRuntime.GetClass("MTL4LibraryFunctionDescriptor");

    public static readonly Selector Library = "library";

    public static readonly Selector Name = "name";

    public static readonly Selector SetLibrary = "setLibrary:";

    public static readonly Selector SetName = "setName:";
}
