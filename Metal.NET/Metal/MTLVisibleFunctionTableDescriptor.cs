namespace Metal.NET;

/// <summary>
/// A specification of how to create a visible function table.
/// </summary>
public class MTLVisibleFunctionTableDescriptor(nint nativePtr, NativeObjectOwnership ownership) : NSObject(nativePtr, ownership), INativeObject<MTLVisibleFunctionTableDescriptor>
{
    #region INativeObject
    public static new MTLVisibleFunctionTableDescriptor Null { get; } = new(0, NativeObjectOwnership.Borrowed);

    public static new MTLVisibleFunctionTableDescriptor New(nint nativePtr, NativeObjectOwnership ownership)
    {
        return new(nativePtr, ownership);
    }
    #endregion

    public MTLVisibleFunctionTableDescriptor() : this(ObjectiveC.AllocInit(MTLVisibleFunctionTableDescriptorBindings.Class), NativeObjectOwnership.Managed)
    {
    }

    #region Configuring the function table - Properties

    /// <summary>
    /// The number of entries in the function table.
    /// </summary>
    public nuint FunctionCount
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTLVisibleFunctionTableDescriptorBindings.FunctionCount);
        set => ObjectiveC.MsgSend(NativePtr, MTLVisibleFunctionTableDescriptorBindings.SetFunctionCount, value);
    }
    #endregion

    public static MTLVisibleFunctionTableDescriptor VisibleFunctionTableDescriptor()
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(MTLVisibleFunctionTableDescriptorBindings.Class, MTLVisibleFunctionTableDescriptorBindings.VisibleFunctionTableDescriptor);

        return new(nativePtr, NativeObjectOwnership.Owned);
    }
}

file static class MTLVisibleFunctionTableDescriptorBindings
{
    public static readonly nint Class = ObjectiveC.GetClass("MTLVisibleFunctionTableDescriptor");

    public static readonly Selector FunctionCount = "functionCount";

    public static readonly Selector SetFunctionCount = "setFunctionCount:";

    public static readonly Selector VisibleFunctionTableDescriptor = "visibleFunctionTableDescriptor";
}
