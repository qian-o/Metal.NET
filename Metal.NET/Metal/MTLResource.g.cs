namespace Metal.NET;

file class MTLResourceSelector
{
    public static readonly Selector MakeAliasable = Selector.Register("makeAliasable");
    public static readonly Selector SetLabel_ = Selector.Register("setLabel:");
    public static readonly Selector SetOwner_ = Selector.Register("setOwner:");
    public static readonly Selector SetPurgeableState_ = Selector.Register("setPurgeableState:");
}

public class MTLResource : IDisposable
{
    public MTLResource(nint nativePtr)
    {
        NativePtr = nativePtr;
    }

    ~MTLResource()
    {
        Release();
    }

    public nint NativePtr { get; }

    public static implicit operator nint(MTLResource value)
    {
        return value.NativePtr;
    }

    public static implicit operator MTLResource(nint value)
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

    public void MakeAliasable()
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLResourceSelector.MakeAliasable);
    }

    public void SetLabel(NSString label)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLResourceSelector.SetLabel_, label.NativePtr);
    }

    public uint SetOwner(nint task_id_token)
    {
        var result = (uint)(ulong)ObjectiveCRuntime.intptr_objc_msgSend(NativePtr, MTLResourceSelector.SetOwner_, task_id_token);

        return result;
    }

    public MTLPurgeableState SetPurgeableState(MTLPurgeableState state)
    {
        var result = (MTLPurgeableState)(uint)(ulong)ObjectiveCRuntime.intptr_objc_msgSend(NativePtr, MTLResourceSelector.SetPurgeableState_, (nint)(uint)state);

        return result;
    }

}
