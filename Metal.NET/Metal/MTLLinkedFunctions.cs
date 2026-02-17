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

    public static MTLLinkedFunctions New()
    {
        var ptr = ObjectiveCRuntime.MsgSendPtr(s_class, Selector.Register("alloc"));
        ptr = ObjectiveCRuntime.MsgSendPtr(ptr, Selector.Register("init"));

        return new MTLLinkedFunctions(ptr);
    }

    public void SetBinaryFunctions(NSArray binaryFunctions)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLLinkedFunctionsSelector.SetBinaryFunctions, binaryFunctions.NativePtr);
    }

    public void SetFunctions(NSArray functions)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLLinkedFunctionsSelector.SetFunctions, functions.NativePtr);
    }

    public void SetGroups(int groups)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLLinkedFunctionsSelector.SetGroups, groups);
    }

    public void SetPrivateFunctions(NSArray privateFunctions)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLLinkedFunctionsSelector.SetPrivateFunctions, privateFunctions.NativePtr);
    }

    public static MTLLinkedFunctions LinkedFunctions()
    {
        MTLLinkedFunctions result = new(ObjectiveCRuntime.MsgSendPtr(s_class, MTLLinkedFunctionsSelector.LinkedFunctions));

        return result;
    }

}

file class MTLLinkedFunctionsSelector
{
    public static readonly Selector SetBinaryFunctions = Selector.Register("setBinaryFunctions:");

    public static readonly Selector SetFunctions = Selector.Register("setFunctions:");

    public static readonly Selector SetGroups = Selector.Register("setGroups:");

    public static readonly Selector SetPrivateFunctions = Selector.Register("setPrivateFunctions:");

    public static readonly Selector LinkedFunctions = Selector.Register("linkedFunctions");
}
