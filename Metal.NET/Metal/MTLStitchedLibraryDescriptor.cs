namespace Metal.NET;

public class MTLStitchedLibraryDescriptor(nint nativePtr, NativeObjectOwnership ownership) : NSObject(nativePtr, ownership), INativeObject<MTLStitchedLibraryDescriptor>
{
    #region INativeObject
    public static new MTLStitchedLibraryDescriptor Null { get; } = new(0, NativeObjectOwnership.Borrowed);

    public static new MTLStitchedLibraryDescriptor New(nint nativePtr, NativeObjectOwnership ownership)
    {
        return new(nativePtr, ownership);
    }
    #endregion

    public MTLStitchedLibraryDescriptor() : this(ObjectiveC.AllocInit(MTLStitchedLibraryDescriptorBindings.Class), NativeObjectOwnership.Managed)
    {
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

    public static readonly Selector Options = "options";

    public static readonly Selector SetOptions = "setOptions:";
}
