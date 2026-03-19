namespace Metal.NET;

public partial class MTLFunctionConstant(nint nativePtr, NativeObjectOwnership ownership) : NSObject(nativePtr, ownership), INativeObject<MTLFunctionConstant>
{
    #region INativeObject
    public static new MTLFunctionConstant Null { get; } = new(0, NativeObjectOwnership.Borrowed);

    public static new MTLFunctionConstant New(nint nativePtr, NativeObjectOwnership ownership)
    {
        return new(nativePtr, ownership);
    }
    #endregion

    public NSString Name
    {
        get => GetProperty(ref field, MTLFunctionConstantBindings.Name);
    }

    public MTLDataType Type
    {
        get => (MTLDataType)ObjectiveC.MsgSendULong(NativePtr, MTLFunctionConstantBindings.Type);
    }

    public nuint Index
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTLFunctionConstantBindings.Index);
    }

    public Bool8 Required
    {
        get => ObjectiveC.MsgSendBool(NativePtr, MTLFunctionConstantBindings.Required);
    }
}

file static class MTLFunctionConstantBindings
{
    public static readonly Selector Index = "index";

    public static readonly Selector Name = "name";

    public static readonly Selector Required = "required";

    public static readonly Selector Type = "type";
}
