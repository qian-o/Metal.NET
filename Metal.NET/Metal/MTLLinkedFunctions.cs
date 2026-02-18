namespace Metal.NET;

public partial class MTLLinkedFunctions : NativeObject
{
    private static readonly nint Class = ObjectiveCRuntime.GetClass("MTLLinkedFunctions");

    public MTLLinkedFunctions(nint nativePtr) : base(nativePtr)
    {
    }

    public NSArray? BinaryFunctions
    {
        get
        {
            nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLLinkedFunctionsSelector.BinaryFunctions);
            return ptr is not 0 ? new(ptr) : null;
        }
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLLinkedFunctionsSelector.SetBinaryFunctions, value?.NativePtr ?? 0);
    }

    public NSArray? Functions
    {
        get
        {
            nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLLinkedFunctionsSelector.Functions);
            return ptr is not 0 ? new(ptr) : null;
        }
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLLinkedFunctionsSelector.SetFunctions, value?.NativePtr ?? 0);
    }

    public nint Groups
    {
        get => ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLLinkedFunctionsSelector.Groups);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLLinkedFunctionsSelector.SetGroups, value);
    }

    public NSArray? PrivateFunctions
    {
        get
        {
            nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLLinkedFunctionsSelector.PrivateFunctions);
            return ptr is not 0 ? new(ptr) : null;
        }
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLLinkedFunctionsSelector.SetPrivateFunctions, value?.NativePtr ?? 0);
    }

    public static MTLLinkedFunctions? LinkedFunctions()
    {
        nint ptr = ObjectiveCRuntime.MsgSendPtr(Class, MTLLinkedFunctionsSelector.LinkedFunctions);
        return ptr is not 0 ? new(ptr) : null;
    }
}

file static class MTLLinkedFunctionsSelector
{
    public static readonly Selector BinaryFunctions = Selector.Register("binaryFunctions");

    public static readonly Selector Functions = Selector.Register("functions");

    public static readonly Selector Groups = Selector.Register("groups");

    public static readonly Selector LinkedFunctions = Selector.Register("linkedFunctions");

    public static readonly Selector PrivateFunctions = Selector.Register("privateFunctions");

    public static readonly Selector SetBinaryFunctions = Selector.Register("setBinaryFunctions:");

    public static readonly Selector SetFunctions = Selector.Register("setFunctions:");

    public static readonly Selector SetGroups = Selector.Register("setGroups:");

    public static readonly Selector SetPrivateFunctions = Selector.Register("setPrivateFunctions:");
}
