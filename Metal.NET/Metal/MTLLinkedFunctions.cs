namespace Metal.NET;

public readonly struct MTLLinkedFunctions(nint nativePtr) : IDisposable
{
    public readonly nint NativePtr = nativePtr;

    public bool IsNull => NativePtr is 0;

    public static implicit operator NSObject(MTLLinkedFunctions value) => new(value.NativePtr);

    public MTLLinkedFunctions() : this(ObjectiveC.AllocInit(MTLLinkedFunctionsBindings.Class))
    {
    }

    public MTLLinkedFunctions Retain()
    {
        return new(ObjectiveC.Retain(NativePtr));
    }

    public void Dispose()
    {
        ObjectiveC.Release(NativePtr);
    }

    public NSArray<MTLFunction> Functions
    {
        get => new(ObjectiveC.MsgSendNInt(NativePtr, MTLLinkedFunctionsBindings.Functions));
        set => ObjectiveC.MsgSend(NativePtr, MTLLinkedFunctionsBindings.SetFunctions, value.NativePtr);
    }

    public NSArray<MTLFunction> BinaryFunctions
    {
        get => new(ObjectiveC.MsgSendNInt(NativePtr, MTLLinkedFunctionsBindings.BinaryFunctions));
        set => ObjectiveC.MsgSend(NativePtr, MTLLinkedFunctionsBindings.SetBinaryFunctions, value.NativePtr);
    }

    public NSDictionary Groups
    {
        get => new(ObjectiveC.MsgSendNInt(NativePtr, MTLLinkedFunctionsBindings.Groups));
        set => ObjectiveC.MsgSend(NativePtr, MTLLinkedFunctionsBindings.SetGroups, value.NativePtr);
    }

    public NSArray<MTLFunction> PrivateFunctions
    {
        get => new(ObjectiveC.MsgSendNInt(NativePtr, MTLLinkedFunctionsBindings.PrivateFunctions));
        set => ObjectiveC.MsgSend(NativePtr, MTLLinkedFunctionsBindings.SetPrivateFunctions, value.NativePtr);
    }

    public static MTLLinkedFunctions LinkedFunctions()
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(MTLLinkedFunctionsBindings.Class, MTLLinkedFunctionsBindings.LinkedFunctions);

        return new(nativePtr);
    }
}

file static class MTLLinkedFunctionsBindings
{
    public static readonly nint Class = ObjectiveC.GetClass("MTLLinkedFunctions");

    public static readonly Selector BinaryFunctions = "binaryFunctions";

    public static readonly Selector Functions = "functions";

    public static readonly Selector Groups = "groups";

    public static readonly Selector LinkedFunctions = "linkedFunctions";

    public static readonly Selector PrivateFunctions = "privateFunctions";

    public static readonly Selector SetBinaryFunctions = "setBinaryFunctions:";

    public static readonly Selector SetFunctions = "setFunctions:";

    public static readonly Selector SetGroups = "setGroups:";

    public static readonly Selector SetPrivateFunctions = "setPrivateFunctions:";
}
