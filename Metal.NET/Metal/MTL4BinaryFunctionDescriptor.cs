namespace Metal.NET;

/// <summary>
/// Base interface for other function-derived interfaces.
/// </summary>
public class MTL4BinaryFunctionDescriptor(nint nativePtr, NativeObjectOwnership ownership) : NSObject(nativePtr, ownership), INativeObject<MTL4BinaryFunctionDescriptor>
{
    #region INativeObject
    public static new MTL4BinaryFunctionDescriptor Null { get; } = new(0, NativeObjectOwnership.Borrowed);

    public static new MTL4BinaryFunctionDescriptor New(nint nativePtr, NativeObjectOwnership ownership)
    {
        return new(nativePtr, ownership);
    }
    #endregion

    public MTL4BinaryFunctionDescriptor() : this(ObjectiveC.AllocInit(MTL4BinaryFunctionDescriptorBindings.Class), NativeObjectOwnership.Managed)
    {
    }

    #region Instance Properties - Properties

    /// <summary>
    /// Provides the function descriptor corresponding to the function to compile into a binary function.
    /// </summary>
    public MTL4FunctionDescriptor FunctionDescriptor
    {
        get => GetProperty(ref field, MTL4BinaryFunctionDescriptorBindings.FunctionDescriptor);
        set => SetProperty(ref field, MTL4BinaryFunctionDescriptorBindings.SetFunctionDescriptor, value);
    }

    /// <summary>
    /// Associates a string that uniquely identifies a binary function.
    /// </summary>
    public NSString Name
    {
        get => GetProperty(ref field, MTL4BinaryFunctionDescriptorBindings.Name);
        set => SetProperty(ref field, MTL4BinaryFunctionDescriptorBindings.SetName, value);
    }

    /// <summary>
    /// Configure the options to use at binary function creation time.
    /// </summary>
    public MTL4BinaryFunctionOptions Options
    {
        get => (MTL4BinaryFunctionOptions)ObjectiveC.MsgSendULong(NativePtr, MTL4BinaryFunctionDescriptorBindings.Options);
        set => ObjectiveC.MsgSend(NativePtr, MTL4BinaryFunctionDescriptorBindings.SetOptions, (nuint)value);
    }
    #endregion
}

file static class MTL4BinaryFunctionDescriptorBindings
{
    public static readonly nint Class = ObjectiveC.GetClass("MTL4BinaryFunctionDescriptor");

    public static readonly Selector FunctionDescriptor = "functionDescriptor";

    public static readonly Selector Name = "name";

    public static readonly Selector Options = "options";

    public static readonly Selector SetFunctionDescriptor = "setFunctionDescriptor:";

    public static readonly Selector SetName = "setName:";

    public static readonly Selector SetOptions = "setOptions:";
}
