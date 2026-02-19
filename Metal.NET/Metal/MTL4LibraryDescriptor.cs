namespace Metal.NET;

public class MTL4LibraryDescriptor(nint nativePtr) : NativeObject(nativePtr)
{
    public MTL4LibraryDescriptor() : this(ObjectiveCRuntime.AllocInit(MTL4LibraryDescriptorBindings.Class))
    {
    }

    public NSString? Name
    {
        get => GetProperty(ref field, MTL4LibraryDescriptorBindings.Name);
        set => SetProperty(ref field, MTL4LibraryDescriptorBindings.SetName, value);
    }

    public MTLCompileOptions? Options
    {
        get => GetProperty(ref field, MTL4LibraryDescriptorBindings.Options);
        set => SetProperty(ref field, MTL4LibraryDescriptorBindings.SetOptions, value);
    }

    public NSString? Source
    {
        get => GetProperty(ref field, MTL4LibraryDescriptorBindings.Source);
        set => SetProperty(ref field, MTL4LibraryDescriptorBindings.SetSource, value);
    }
}

file static class MTL4LibraryDescriptorBindings
{
    public static readonly nint Class = ObjectiveCRuntime.GetClass("MTL4LibraryDescriptor");

    public static readonly Selector Name = "name";

    public static readonly Selector Options = "options";

    public static readonly Selector SetName = "setName:";

    public static readonly Selector SetOptions = "setOptions:";

    public static readonly Selector SetSource = "setSource:";

    public static readonly Selector Source = "source";
}
