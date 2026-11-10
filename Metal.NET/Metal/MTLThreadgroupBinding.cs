namespace Metal.NET;

public readonly struct MTLThreadgroupBinding(nint nativePtr) : IDisposable
{
    public readonly nint NativePtr = nativePtr;

    public static implicit operator MTLBinding(MTLThreadgroupBinding value) => new(value.NativePtr);

    public static implicit operator NSObject(MTLThreadgroupBinding value) => new(value.NativePtr);

    public MTLThreadgroupBinding Retain()
    {
        return new(ObjectiveC.Retain(NativePtr));
    }

    public void Dispose()
    {
        ObjectiveC.Release(NativePtr);
    }

    public nuint ThreadgroupMemoryAlignment
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTLThreadgroupBindingBindings.ThreadgroupMemoryAlignment);
    }

    public nuint ThreadgroupMemoryDataSize
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTLThreadgroupBindingBindings.ThreadgroupMemoryDataSize);
    }

    public NSString Name
    {
        get => new(ObjectiveC.MsgSendNInt(NativePtr, MTLThreadgroupBindingBindings.Name));
    }

    public MTLBindingType Type
    {
        get => (MTLBindingType)ObjectiveC.MsgSendLong(NativePtr, MTLThreadgroupBindingBindings.Type);
    }

    public MTLBindingAccess Access
    {
        get => (MTLBindingAccess)ObjectiveC.MsgSendULong(NativePtr, MTLThreadgroupBindingBindings.Access);
    }

    public nuint Index
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTLThreadgroupBindingBindings.Index);
    }

    public Bool8 IsUsed
    {
        get => ObjectiveC.MsgSendBool(NativePtr, MTLThreadgroupBindingBindings.IsUsed);
    }

    public Bool8 IsArgument
    {
        get => ObjectiveC.MsgSendBool(NativePtr, MTLThreadgroupBindingBindings.IsArgument);
    }
}

file static class MTLThreadgroupBindingBindings
{
    public static readonly Selector Access = "access";

    public static readonly Selector Index = "index";

    public static readonly Selector IsArgument = "isArgument";

    public static readonly Selector IsUsed = "isUsed";

    public static readonly Selector Name = "name";

    public static readonly Selector ThreadgroupMemoryAlignment = "threadgroupMemoryAlignment";

    public static readonly Selector ThreadgroupMemoryDataSize = "threadgroupMemoryDataSize";

    public static readonly Selector Type = "type";
}
