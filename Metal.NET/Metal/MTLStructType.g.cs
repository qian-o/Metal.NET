namespace Metal.NET;

file class MTLStructTypeSelector
{
    public static readonly Selector MemberByName_ = Selector.Register("memberByName:");
}

public class MTLStructType : IDisposable
{
    public MTLStructType(nint nativePtr)
    {
        NativePtr = nativePtr;
    }

    ~MTLStructType()
    {
        Release();
    }

    public nint NativePtr { get; }

    public static implicit operator nint(MTLStructType value)
    {
        return value.NativePtr;
    }

    public static implicit operator MTLStructType(nint value)
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

    public MTLStructMember MemberByName(NSString name)
    {
        var result = new MTLStructMember(ObjectiveCRuntime.intptr_objc_msgSend(NativePtr, MTLStructTypeSelector.MemberByName_, name.NativePtr));

        return result;
    }

}
