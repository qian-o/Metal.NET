namespace Metal.NET;

public class MTLResource : IDisposable
{
    public MTLResource(nint nativePtr)
    {
        ObjectiveCRuntime.Retain(NativePtr = nativePtr);
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
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLResourceSelector.SetLabel, label.NativePtr);
    }

    public uint SetOwner(int task_id_token)
    {
        var result = (uint)(ulong)ObjectiveCRuntime.intptr_objc_msgSend(NativePtr, MTLResourceSelector.SetOwner, task_id_token);

        return result;
    }

    public MTLPurgeableState SetPurgeableState(MTLPurgeableState state)
    {
        var result = (MTLPurgeableState)(uint)(ulong)ObjectiveCRuntime.intptr_objc_msgSend(NativePtr, MTLResourceSelector.SetPurgeableState, (nint)(uint)state);

        return result;
    }

}

file class MTLResourceSelector
{
    public static readonly Selector MakeAliasable = Selector.Register("makeAliasable");
    public static readonly Selector SetLabel = Selector.Register("setLabel:");
    public static readonly Selector SetOwner = Selector.Register("setOwner:");
    public static readonly Selector SetPurgeableState = Selector.Register("setPurgeableState:");
}
