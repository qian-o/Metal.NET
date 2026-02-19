namespace Metal.NET;

/// <summary>
/// Base class for all Objective-C native object wrappers.
/// Lightweight wrapper with no reference counting overhead.
/// </summary>
public abstract class NativeObject(nint nativePtr)
{
    /// <summary>
    /// The underlying Objective-C pointer.
    /// </summary>
    public nint NativePtr { get; } = nativePtr;
}
