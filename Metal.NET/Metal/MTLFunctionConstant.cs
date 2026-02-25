namespace Metal.NET;

public class MTLFunctionConstant(nint nativePtr, NativeObjectOwnership ownership) : NativeObject(nativePtr, ownership), INativeObject<MTLFunctionConstant>
{
    public static MTLFunctionConstant Null { get; } = new(0, NativeObjectOwnership.Borrowed);

    public static MTLFunctionConstant Create(nint nativePtr, NativeObjectOwnership ownership) => new(nativePtr, ownership);

    public MTLFunctionConstant() : this(ObjectiveCRuntime.AllocInit(MTLFunctionConstantBindings.Class), NativeObjectOwnership.Managed)
    {
    }

    public nuint Index
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLFunctionConstantBindings.Index);
    }

    public NSString Name
    {
        get => GetProperty(ref field, MTLFunctionConstantBindings.Name);
    }

    public Bool8 Required
    {
        get => ObjectiveCRuntime.MsgSendBool(NativePtr, MTLFunctionConstantBindings.Required);
    }

    public MTLDataType Type
    {
        get => (MTLDataType)ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLFunctionConstantBindings.Type);
    }
}

file static class MTLFunctionConstantBindings
{
    public static readonly nint Class = ObjectiveCRuntime.GetClass("MTLFunctionConstant");

    public static readonly Selector Index = "index";

    public static readonly Selector Name = "name";

    public static readonly Selector Required = "required";

    public static readonly Selector Type = "type";
}
