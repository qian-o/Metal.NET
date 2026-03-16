namespace Metal.NET;

/// <summary>Manages the memory backing the encoding of GPU commands into command buffers.</summary>
public class MTL4CommandAllocator(nint nativePtr, NativeObjectOwnership ownership) : NSObject(nativePtr, ownership), INativeObject<MTL4CommandAllocator>
{
    #region INativeObject
    public static new MTL4CommandAllocator Null { get; } = new(0, NativeObjectOwnership.Borrowed);

    public static new MTL4CommandAllocator New(nint nativePtr, NativeObjectOwnership ownership)
    {
        return new(nativePtr, ownership);
    }
    #endregion

    #region Instance Properties - Properties

    /// <summary>Returns the GPU device that this command allocator belongs to.</summary>
    public MTLDevice Device
    {
        get => GetProperty(ref field, MTL4CommandAllocatorBindings.Device);
    }

    /// <summary>Provides the optional label you specify at creation time for debug purposes.</summary>
    public NSString Label
    {
        get => GetProperty(ref field, MTL4CommandAllocatorBindings.Label);
    }
    #endregion

    #region Instance Methods - Methods

    /// <summary>Queries the size of the internal memory heaps of this command allocator that support encoding commands into command buffers.</summary>
    public ulong AllocatedSize()
    {
        return ObjectiveC.MsgSendULong(NativePtr, MTL4CommandAllocatorBindings.AllocatedSize);
    }

    /// <summary>Marks the command allocator’s heaps for reuse.</summary>
    public void Reset()
    {
        ObjectiveC.MsgSend(NativePtr, MTL4CommandAllocatorBindings.Reset);
    }
    #endregion
}

file static class MTL4CommandAllocatorBindings
{
    public static readonly Selector AllocatedSize = "allocatedSize";

    public static readonly Selector Device = "device";

    public static readonly Selector Label = "label";

    public static readonly Selector Reset = "reset";
}
