namespace Metal.NET;

/// <summary>
/// A description of an intersection function that performs an intersection test.
/// </summary>
public class MTLIntersectionFunctionDescriptor(nint nativePtr, NativeObjectOwnership ownership) : MTLFunctionDescriptor(nativePtr, ownership), INativeObject<MTLIntersectionFunctionDescriptor>
{
    #region INativeObject
    public static new MTLIntersectionFunctionDescriptor Null { get; } = new(0, NativeObjectOwnership.Borrowed);

    public static new MTLIntersectionFunctionDescriptor New(nint nativePtr, NativeObjectOwnership ownership)
    {
        return new(nativePtr, ownership);
    }
    #endregion

    public MTLIntersectionFunctionDescriptor() : this(ObjectiveC.AllocInit(MTLIntersectionFunctionDescriptorBindings.Class), NativeObjectOwnership.Managed)
    {
    }
}

file static class MTLIntersectionFunctionDescriptorBindings
{
    public static readonly nint Class = ObjectiveC.GetClass("MTLIntersectionFunctionDescriptor");
}
