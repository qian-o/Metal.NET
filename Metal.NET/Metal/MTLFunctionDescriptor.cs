namespace Metal.NET;

/// <summary>A description of a function object to create.</summary>
public class MTLFunctionDescriptor(nint nativePtr, NativeObjectOwnership ownership) : NSObject(nativePtr, ownership), INativeObject<MTLFunctionDescriptor>
{
    #region INativeObject
    public static new MTLFunctionDescriptor Null { get; } = new(0, NativeObjectOwnership.Borrowed);

    public static new MTLFunctionDescriptor New(nint nativePtr, NativeObjectOwnership ownership)
    {
        return new(nativePtr, ownership);
    }
    #endregion

    public MTLFunctionDescriptor() : this(ObjectiveC.AllocInit(MTLFunctionDescriptorBindings.Class), NativeObjectOwnership.Managed)
    {
    }

    #region Specifying the function configuration - Properties

    /// <summary>The name of the function to fetch from the library.</summary>
    public NSString Name
    {
        get => GetProperty(ref field, MTLFunctionDescriptorBindings.Name);
        set => SetProperty(ref field, MTLFunctionDescriptorBindings.SetName, value);
    }

    /// <summary>A new name for the created function object.</summary>
    public NSString SpecializedName
    {
        get => GetProperty(ref field, MTLFunctionDescriptorBindings.SpecializedName);
        set => SetProperty(ref field, MTLFunctionDescriptorBindings.SetSpecializedName, value);
    }

    /// <summary>The set of constant values assigned to the function constants.</summary>
    public MTLFunctionConstantValues ConstantValues
    {
        get => GetProperty(ref field, MTLFunctionDescriptorBindings.ConstantValues);
        set => SetProperty(ref field, MTLFunctionDescriptorBindings.SetConstantValues, value);
    }

    /// <summary>Flags specifying how Metal should create the new function object.</summary>
    public MTLFunctionOptions Options
    {
        get => (MTLFunctionOptions)ObjectiveC.MsgSendULong(NativePtr, MTLFunctionDescriptorBindings.Options);
        set => ObjectiveC.MsgSend(NativePtr, MTLFunctionDescriptorBindings.SetOptions, (nuint)value);
    }

    /// <summary>The binary archives to search for a previously-compiled version of this function.</summary>
    public MTLBinaryArchive[] BinaryArchives
    {
        get => GetArrayProperty<MTLBinaryArchive>(MTLFunctionDescriptorBindings.BinaryArchives);
        set => SetArrayProperty(MTLFunctionDescriptorBindings.SetBinaryArchives, value);
    }
    #endregion

    public static MTLFunctionDescriptor FunctionDescriptor()
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(MTLFunctionDescriptorBindings.Class, MTLFunctionDescriptorBindings.FunctionDescriptor);

        return new(nativePtr, NativeObjectOwnership.Owned);
    }
}

file static class MTLFunctionDescriptorBindings
{
    public static readonly nint Class = ObjectiveC.GetClass("MTLFunctionDescriptor");

    public static readonly Selector BinaryArchives = "binaryArchives";

    public static readonly Selector ConstantValues = "constantValues";

    public static readonly Selector FunctionDescriptor = "functionDescriptor";

    public static readonly Selector Name = "name";

    public static readonly Selector Options = "options";

    public static readonly Selector SetBinaryArchives = "setBinaryArchives:";

    public static readonly Selector SetConstantValues = "setConstantValues:";

    public static readonly Selector SetName = "setName:";

    public static readonly Selector SetOptions = "setOptions:";

    public static readonly Selector SetSpecializedName = "setSpecializedName:";

    public static readonly Selector SpecializedName = "specializedName";
}
