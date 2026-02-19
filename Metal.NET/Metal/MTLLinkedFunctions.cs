namespace Metal.NET;

public class MTLLinkedFunctions(nint nativePtr, bool owned) : NativeObject(nativePtr, owned)
{
    public MTLLinkedFunctions() : this(ObjectiveCRuntime.AllocInit(MTLLinkedFunctionsBindings.Class), true)
    {
    }

    public NSArray? BinaryFunctions
    {
        get => GetProperty(ref field, MTLLinkedFunctionsBindings.BinaryFunctions);
        set => SetProperty(ref field, MTLLinkedFunctionsBindings.SetBinaryFunctions, value);
    }

    public NSArray? Functions
    {
        get => GetProperty(ref field, MTLLinkedFunctionsBindings.Functions);
        set => SetProperty(ref field, MTLLinkedFunctionsBindings.SetFunctions, value);
    }

    public NSArray? PrivateFunctions
    {
        get => GetProperty(ref field, MTLLinkedFunctionsBindings.PrivateFunctions);
        set => SetProperty(ref field, MTLLinkedFunctionsBindings.SetPrivateFunctions, value);
    }

    public static MTLLinkedFunctions? LinkedFunctions()
    {
        nint nativePtr = ObjectiveCRuntime.MsgSendPtr(MTLLinkedFunctionsBindings.Class, MTLLinkedFunctionsBindings.LinkedFunctions);

        return nativePtr is not 0 ? new(nativePtr, false) : null;
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
