namespace Metal.NET;

public class MTL4LibraryDescriptor(nint nativePtr, bool ownsReference, bool allowGCRelease = false) : NativeObject(nativePtr, ownsReference, allowGCRelease), INativeObject<MTL4LibraryDescriptor>
{
    public static MTL4LibraryDescriptor Null { get; } = new(0, false);

    public static MTL4LibraryDescriptor Create(nint nativePtr, bool ownsReference) => new(nativePtr, ownsReference);

    public MTL4LibraryDescriptor() : this(ObjectiveCRuntime.AllocInit(MTL4LibraryDescriptorBindings.Class), true, true)
    {
    }

    public NSString Name
    {
        get => GetProperty(ref field, MTL4LibraryDescriptorBindings.Name);
        set => SetProperty(ref field, MTL4LibraryDescriptorBindings.SetName, value);
    }

    public MTLCompileOptions Options
    {
        get => GetProperty(ref field, MTL4LibraryDescriptorBindings.Options);
        set => SetProperty(ref field, MTL4LibraryDescriptorBindings.SetOptions, value);
    }

    public NSString Source
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
