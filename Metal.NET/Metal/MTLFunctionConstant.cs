namespace Metal.NET;

public readonly struct MTLFunctionConstant(nint nativePtr) : IDisposable
{
    public readonly nint NativePtr = nativePtr;

    public bool IsNull => NativePtr is 0;

    public static implicit operator NSObject(MTLFunctionConstant value) => new(value.NativePtr);

    public MTLFunctionConstant Retain()
    {
        return new(ObjectiveC.Retain(NativePtr));
    }

    public void Dispose()
    {
        ObjectiveC.Release(NativePtr);
    }

    public NSString Name
    {
        get => new(ObjectiveC.MsgSendNInt(NativePtr, MTLFunctionConstantBindings.Name));
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
