namespace Metal.NET;

public readonly struct MTLDynamicLibrary(nint nativePtr) : IDisposable
{
    public readonly nint NativePtr = nativePtr;

    public bool IsNull => NativePtr is 0;

    public static implicit operator NSObject(MTLDynamicLibrary value) => new(value.NativePtr);

    public MTLDynamicLibrary Retain()
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

    public NSString Label
    {
        get => new(ObjectiveC.MsgSendNInt(NativePtr, MTLDynamicLibraryBindings.Label));
        set => ObjectiveC.MsgSend(NativePtr, MTLDynamicLibraryBindings.SetLabel, value.NativePtr);
    }

    public MTLDevice Device
    {
        get => new(ObjectiveC.MsgSendNInt(NativePtr, MTLDynamicLibraryBindings.Device));
    }

    public NSString InstallName
    {
        get => new(ObjectiveC.MsgSendNInt(NativePtr, MTLDynamicLibraryBindings.InstallName));
    }

    public bool Serialize(NSURL url, out NSError error)
    {
        bool result = ObjectiveC.MsgSendBool(NativePtr, MTLDynamicLibraryBindings.SerializeToURL_Error, url.NativePtr, out nint errorPtr);

        error = new(errorPtr);

        return result;
    }
}

file static class MTLDynamicLibraryBindings
{
    public static readonly Selector Device = "device";

    public static readonly Selector InstallName = "installName";

    public static readonly Selector Label = "label";

    public static readonly Selector SerializeToURL_Error = "serializeToURL:error:";

    public static readonly Selector SetLabel = "setLabel:";
}
