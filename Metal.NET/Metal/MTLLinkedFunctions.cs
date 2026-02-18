namespace Metal.NET;

public class MTLLinkedFunctions(nint nativePtr) : NativeObject(nativePtr)
{
    public MTLLinkedFunctions() : this(ObjectiveCRuntime.AllocInit(MTLLinkedFunctionsSelector.Class))
    {
    }

    public NSArray? BinaryFunctions
    {
        get => GetNullableObject<NSArray>(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLLinkedFunctionsSelector.BinaryFunctions));
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLLinkedFunctionsSelector.SetBinaryFunctions, value?.NativePtr ?? 0);
    }

    public NSArray? Functions
    {
        get => GetNullableObject<NSArray>(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLLinkedFunctionsSelector.Functions));
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLLinkedFunctionsSelector.SetFunctions, value?.NativePtr ?? 0);
    }

    public NSArray? PrivateFunctions
    {
        get => GetNullableObject<NSArray>(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLLinkedFunctionsSelector.PrivateFunctions));
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLLinkedFunctionsSelector.SetPrivateFunctions, value?.NativePtr ?? 0);
    }

    public static MTLLinkedFunctions? LinkedFunctions()
    {
        return GetNullableObject<MTLLinkedFunctions>(ObjectiveCRuntime.MsgSendPtr(MTLLinkedFunctionsSelector.Class, MTLLinkedFunctionsSelector.LinkedFunctions));
    }
}

file static class MTLLinkedFunctionsSelector
{
    public static readonly nint Class = ObjectiveCRuntime.GetClass("MTLLinkedFunctions");

    public static readonly Selector BinaryFunctions = Selector.Register("binaryFunctions");

    public static readonly Selector Functions = Selector.Register("functions");

    public static readonly Selector LinkedFunctions = Selector.Register("linkedFunctions");

    public static readonly Selector PrivateFunctions = Selector.Register("privateFunctions");

    public static readonly Selector SetBinaryFunctions = Selector.Register("setBinaryFunctions:");

    public static readonly Selector SetFunctions = Selector.Register("setFunctions:");

    public static readonly Selector SetPrivateFunctions = Selector.Register("setPrivateFunctions:");
}
