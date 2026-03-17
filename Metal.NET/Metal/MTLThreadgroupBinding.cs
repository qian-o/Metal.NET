namespace Metal.NET;

public class MTLThreadgroupBinding(nint nativePtr, NativeObjectOwnership ownership) : MTLBinding(nativePtr, ownership), INativeObject<MTLThreadgroupBinding>
{
    #region INativeObject
    public static new MTLThreadgroupBinding Null { get; } = new(0, NativeObjectOwnership.Borrowed);

    public static new MTLThreadgroupBinding New(nint nativePtr, NativeObjectOwnership ownership)
    {
        return new(nativePtr, ownership);
    }
    #endregion

    #region Instance Properties - Properties

    public nuint ThreadgroupMemoryAlignment
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTLThreadgroupBindingBindings.ThreadgroupMemoryAlignment);
    }

    public nuint ThreadgroupMemoryDataSize
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTLThreadgroupBindingBindings.ThreadgroupMemoryDataSize);
    }
    #endregion
}

file static class MTLThreadgroupBindingBindings
{
    public static readonly Selector ThreadgroupMemoryAlignment = "threadgroupMemoryAlignment";

    public static readonly Selector ThreadgroupMemoryDataSize = "threadgroupMemoryDataSize";
}
