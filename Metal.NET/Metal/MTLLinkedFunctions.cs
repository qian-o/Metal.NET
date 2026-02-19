namespace Metal.NET;

public readonly struct MTLLinkedFunctions(nint nativePtr)
{
    public readonly nint NativePtr = nativePtr;

    public MTLLinkedFunctions() : this(ObjectiveCRuntime.AllocInit(MTLLinkedFunctionsBindings.Class))
    {
    }

    public NSArray? BinaryFunctions
    {
        get
        {
            nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLLinkedFunctionsBindings.BinaryFunctions);
            return ptr is not 0 ? new NSArray(ptr) : default;
        }
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLLinkedFunctionsBindings.SetBinaryFunctions, value?.NativePtr ?? 0);
    }

    public NSArray? Functions
    {
        get
        {
            nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLLinkedFunctionsBindings.Functions);
            return ptr is not 0 ? new NSArray(ptr) : default;
        }
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLLinkedFunctionsBindings.SetFunctions, value?.NativePtr ?? 0);
    }

    public NSArray? PrivateFunctions
    {
        get
        {
            nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLLinkedFunctionsBindings.PrivateFunctions);
            return ptr is not 0 ? new NSArray(ptr) : default;
        }
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLLinkedFunctionsBindings.SetPrivateFunctions, value?.NativePtr ?? 0);
    }

    public static MTLLinkedFunctions? LinkedFunctions()
    {
        nint ptr = ObjectiveCRuntime.MsgSendPtr(MTLLinkedFunctionsBindings.Class, MTLLinkedFunctionsBindings.LinkedFunctions);
        return ptr is not 0 ? new MTLLinkedFunctions(ptr) : default;
    }
}

file static class MTLLinkedFunctionsBindings
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
