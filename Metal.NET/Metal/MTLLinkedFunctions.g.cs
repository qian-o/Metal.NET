namespace Metal.NET;

file class MTLLinkedFunctionsSelector
{
    public static readonly Selector SetBinaryFunctions_ = Selector.Register("setBinaryFunctions:");
    public static readonly Selector SetFunctions_ = Selector.Register("setFunctions:");
    public static readonly Selector SetGroups_ = Selector.Register("setGroups:");
    public static readonly Selector SetPrivateFunctions_ = Selector.Register("setPrivateFunctions:");
    public static readonly Selector LinkedFunctions = Selector.Register("linkedFunctions");
}

public class MTLLinkedFunctions : IDisposable
{
    public MTLLinkedFunctions(nint nativePtr)
    {
        NativePtr = nativePtr;
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
        var ptr = ObjectiveCRuntime.intptr_objc_msgSend(s_class, Selector.Register("alloc"));
        ptr = ObjectiveCRuntime.intptr_objc_msgSend(ptr, Selector.Register("init"));

        return new MTLLinkedFunctions(ptr);
    }

    public void SetBinaryFunctions(NSArray binaryFunctions)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLLinkedFunctionsSelector.SetBinaryFunctions_, binaryFunctions.NativePtr);
    }

    public void SetFunctions(NSArray functions)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLLinkedFunctionsSelector.SetFunctions_, functions.NativePtr);
    }

    public void SetGroups(nint groups)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLLinkedFunctionsSelector.SetGroups_, groups);
    }

    public void SetPrivateFunctions(NSArray privateFunctions)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLLinkedFunctionsSelector.SetPrivateFunctions_, privateFunctions.NativePtr);
    }

    public static MTLLinkedFunctions LinkedFunctions()
    {
        var result = new MTLLinkedFunctions(ObjectiveCRuntime.intptr_objc_msgSend(s_class, MTLLinkedFunctionsSelector.LinkedFunctions));

        return result;
    }

}
