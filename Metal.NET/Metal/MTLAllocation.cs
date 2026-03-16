namespace Metal.NET;

/// <summary>A memory allocation from a Metal GPU device, such as a memory heap, texture, or data buffer.</summary>
public class MTLAllocation(nint nativePtr, NativeObjectOwnership ownership) : NSObject(nativePtr, ownership), INativeObject<MTLAllocation>
{
    #region INativeObject
    public static new MTLAllocation Null { get; } = new(0, NativeObjectOwnership.Borrowed);

    public static new MTLAllocation New(nint nativePtr, NativeObjectOwnership ownership)
    {
        return new(nativePtr, ownership);
    }
    #endregion

    #region Inspecting an allocation - Properties

    /// <summary>The amount of memory, in byes, a resource consumes, such as for a buffer, texture, or heap.</summary>
    public nuint AllocatedSize
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTLAllocationBindings.AllocatedSize);
    }
    #endregion
}

file static class MTLAllocationBindings
{
    public static readonly Selector AllocatedSize = "allocatedSize";
}
