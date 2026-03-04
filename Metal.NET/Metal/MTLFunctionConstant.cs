namespace Metal.NET;

public class MTLFunctionConstant(nint nativePtr, NativeObjectOwnership ownership) : ObjectiveCObject(nativePtr, ownership), INativeObject<MTLFunctionConstant>
{
    #region INativeObject
    public static MTLFunctionConstant Null { get; } = new(0, NativeObjectOwnership.Borrowed);

    public static MTLFunctionConstant New(nint nativePtr, NativeObjectOwnership ownership)
    {
        return new(nativePtr, ownership);
    }
    #endregion

    public MTLFunctionConstant() : this(ObjectiveC.AllocInit(MTLFunctionConstantBindings.Class), NativeObjectOwnership.Managed)
    {
    }

    public nuint Index
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTLFunctionConstantBindings.Index);
    }

    public NSString Name
    {
        get => GetProperty(ref field, MTLFunctionConstantBindings.Name);
    }

    public Bool8 Required
    {
        get => ObjectiveC.MsgSendBool(NativePtr, MTLFunctionConstantBindings.Required);
    }

    public MTLDataType Type
    {
        get => (MTLDataType)ObjectiveC.MsgSendULong(NativePtr, MTLFunctionConstantBindings.Type);
    }
}

file static class MTLFunctionConstantBindings
{
    public static readonly nint Class = ObjectiveC.GetClass("MTLFunctionConstant");

    public static readonly Selector Index = "index";

    public static readonly Selector Name = "name";

    public static readonly Selector Required = "required";

    public static readonly Selector Type = "type";
}
