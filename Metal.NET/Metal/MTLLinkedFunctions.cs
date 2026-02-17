namespace Metal.NET;

public class MTLLinkedFunctions : IDisposable
{
    public MTLLinkedFunctions(nint nativePtr)
    {
        ObjectiveCRuntime.Retain(NativePtr = nativePtr);
    }

    ~MTLLinkedFunctions()
    {
        Release();
    }

    public nint NativePtr { get; }

    public static implicit operator nint(MTLLinkedFunctions value)
    {
        return value.NativePtr;
    }

    public static implicit operator MTLLinkedFunctions(nint value)
    {
        return new(value);
    }

    public void Dispose()
    {
        Release();

        GC.SuppressFinalize(this);
    }

    private void Release()
    {
        if (NativePtr is not 0)
        {
            ObjectiveCRuntime.Release(NativePtr);
        }
    }

    private static readonly nint s_class = ObjectiveCRuntime.GetClass("MTLLinkedFunctions");

    public MTLLinkedFunctions() : this(ObjectiveCRuntime.MsgSendPtr(ObjectiveCRuntime.MsgSendPtr(s_class, Selector.Register("alloc")), Selector.Register("init")))
    {
    }

    public NSArray BinaryFunctions
    {
        get => new NSArray(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLLinkedFunctionsSelector.BinaryFunctions));
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLLinkedFunctionsSelector.SetBinaryFunctions, value.NativePtr);
    }

    public NSArray Functions
    {
        get => new NSArray(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLLinkedFunctionsSelector.Functions));
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLLinkedFunctionsSelector.SetFunctions, value.NativePtr);
    }

    public nint Groups
    {
        get => ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLLinkedFunctionsSelector.Groups);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLLinkedFunctionsSelector.SetGroups, value);
    }

    public NSArray PrivateFunctions
    {
        get => new NSArray(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLLinkedFunctionsSelector.PrivateFunctions));
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLLinkedFunctionsSelector.SetPrivateFunctions, value.NativePtr);
    }

    public static MTLLinkedFunctions LinkedFunctions()
    {
        MTLLinkedFunctions result = new(ObjectiveCRuntime.MsgSendPtr(s_class, MTLLinkedFunctionsSelector.LinkedFunctions));

        return result;
    }

}

file class MTLLinkedFunctionsSelector
{
    public static readonly Selector BinaryFunctions = Selector.Register("binaryFunctions");

    public static readonly Selector SetBinaryFunctions = Selector.Register("setBinaryFunctions:");

    public static readonly Selector Functions = Selector.Register("functions");

    public static readonly Selector SetFunctions = Selector.Register("setFunctions:");

    public static readonly Selector Groups = Selector.Register("groups");

    public static readonly Selector SetGroups = Selector.Register("setGroups:");

    public static readonly Selector PrivateFunctions = Selector.Register("privateFunctions");

    public static readonly Selector SetPrivateFunctions = Selector.Register("setPrivateFunctions:");

    public static readonly Selector LinkedFunctions = Selector.Register("linkedFunctions");
}
