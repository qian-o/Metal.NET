namespace Metal.NET;

public readonly struct MTLStructType(nint nativePtr) : IDisposable
{
    public readonly nint NativePtr = nativePtr;

    public bool IsNull => NativePtr is 0;

    public static implicit operator MTLType(MTLStructType value) => new(value.NativePtr);

    public static implicit operator NSObject(MTLStructType value) => new(value.NativePtr);

    public MTLStructType Retain()
    {
        return new(ObjectiveC.Retain(NativePtr));
    }

    public void Release()
    {
        ObjectiveC.Release(NativePtr);
    }

    public void Dispose()
    {
        Release();
    }

    public NSArray<MTLStructMember> Members
    {
        get => new(ObjectiveC.MsgSendNInt(NativePtr, MTLStructTypeBindings.Members));
    }

    public MTLDataType DataType
    {
        get => (MTLDataType)ObjectiveC.MsgSendULong(NativePtr, MTLStructTypeBindings.DataType);
    }

    public MTLStructMember MemberByName(NSString name)
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(NativePtr, MTLStructTypeBindings.MemberByName, name.NativePtr);

        return new(nativePtr);
    }
}

file static class MTLStructTypeBindings
{
    public static readonly Selector DataType = "dataType";

    public static readonly Selector MemberByName = "memberByName:";

    public static readonly Selector Members = "members";
}
