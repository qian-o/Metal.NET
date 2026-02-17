namespace Metal.NET;

/// <summary>
/// Wraps an Objective-C NSArray pointer.
/// </summary>
public class NSArray : IDisposable
{
    public NSArray(nint nativePtr)
    {
        ObjectiveCRuntime.Retain(NativePtr = nativePtr);
    }

    ~NSArray()
    {
        Release();
    }

    public nint NativePtr { get; }

    public nuint Count => ObjectiveCRuntime.MsgSendNUInt(NativePtr, NSArraySelector.Count);

    public static implicit operator nint(NSArray value)
    {
        return value.NativePtr;
    }

    public static implicit operator NSArray(nint value)
    {
        return new(value);
    }

    public nint ObjectAtIndex(int index)
    {
        return ObjectiveCRuntime.MsgSendPtr(NativePtr, NSArraySelector.ObjectAtIndex, index);
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

file class NSArraySelector
{
    public static readonly Selector Count = Selector.Register("count");

    public static readonly Selector ObjectAtIndex = Selector.Register("objectAtIndex:");
}