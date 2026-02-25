namespace Metal.NET;

public class MTLLinkedFunctions(nint nativePtr, bool ownsReference) : NativeObject(nativePtr, ownsReference), INativeObject<MTLLinkedFunctions>
{
    public static MTLLinkedFunctions Create(nint nativePtr, bool ownsReference) => new(nativePtr, ownsReference);

    public static MTLLinkedFunctions Null => new(0, false);

    public MTLLinkedFunctions() : this(ObjectiveCRuntime.AllocInit(MTLLinkedFunctionsBindings.Class), true)
    {
    }

    public MTLFunction[] BinaryFunctions
    {
        get => GetArrayProperty<MTLFunction>(MTLLinkedFunctionsBindings.BinaryFunctions);
        set => SetArrayProperty(MTLLinkedFunctionsBindings.SetBinaryFunctions, value);
    }

    public MTLFunction[] Functions
    {
        get => GetArrayProperty<MTLFunction>(MTLLinkedFunctionsBindings.Functions);
        set => SetArrayProperty(MTLLinkedFunctionsBindings.SetFunctions, value);
    }

    public MTLFunction[] PrivateFunctions
    {
        get => GetArrayProperty<MTLFunction>(MTLLinkedFunctionsBindings.PrivateFunctions);
        set => SetArrayProperty(MTLLinkedFunctionsBindings.SetPrivateFunctions, value);
    }

    public static MTLLinkedFunctions LinkedFunctions()
    {
        nint nativePtr = ObjectiveCRuntime.MsgSendPtr(MTLLinkedFunctionsBindings.Class, MTLLinkedFunctionsBindings.LinkedFunctions);

        return new(nativePtr, false);
    }
}

file static class MTLLinkedFunctionsBindings
{
    public static readonly nint Class = ObjectiveCRuntime.GetClass("MTLLinkedFunctions");

    public static readonly Selector BinaryFunctions = "binaryFunctions";

    public static readonly Selector Functions = "functions";

    public static readonly Selector LinkedFunctions = "linkedFunctions";

    public static readonly Selector PrivateFunctions = "privateFunctions";

    public static readonly Selector SetBinaryFunctions = "setBinaryFunctions:";

    public static readonly Selector SetFunctions = "setFunctions:";

    public static readonly Selector SetPrivateFunctions = "setPrivateFunctions:";
}
