namespace Metal.NET;

public class MTLStructType : IDisposable
{
    public MTLStructType(nint nativePtr)
    {
        ObjectiveCRuntime.Retain(NativePtr = nativePtr);
    }

    ~MTLStructType()
    {
        Release();
    }

    public nint NativePtr { get; }

    public NSArray Members => new(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLStructTypeSelector.Members));

    public MTLStructMember MemberByName(NSString name)
    {
        MTLStructMember result = new(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLStructTypeSelector.MemberByName, name.NativePtr));

        return result;
    }

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

}

file class MTLStructTypeSelector
{
    public static readonly Selector Members = Selector.Register("members");

    public static readonly Selector MemberByName = Selector.Register("memberByName:");
}
