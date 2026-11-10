namespace Metal.NET;

public readonly struct MTL4BinaryFunction(nint nativePtr) : IDisposable
{
    public readonly nint NativePtr = nativePtr;

    public static implicit operator NSObject(MTL4BinaryFunction value) => new(value.NativePtr);

    public MTL4BinaryFunction Retain()
    {
        return new(ObjectiveC.Retain(NativePtr));
    }

    public void Dispose()
    {
        ObjectiveC.Release(NativePtr);
    }

    public NSString Name
    {
        get => new(ObjectiveC.MsgSendNInt(NativePtr, MTL4BinaryFunctionBindings.Name));
    }

    public MTLFunctionType FunctionType
    {
        get => (MTLFunctionType)ObjectiveC.MsgSendULong(NativePtr, MTL4BinaryFunctionBindings.FunctionType);
    }
}

file static class MTL4BinaryFunctionBindings
{
    public static readonly Selector FunctionType = "functionType";

    public static readonly Selector Name = "name";
}
