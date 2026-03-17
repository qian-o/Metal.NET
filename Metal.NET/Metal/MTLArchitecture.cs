namespace Metal.NET;

/// <summary>
/// A class that contains the architectural details of a GPU device.
/// </summary>
public class MTLArchitecture(nint nativePtr, NativeObjectOwnership ownership) : NSObject(nativePtr, ownership), INativeObject<MTLArchitecture>
{
    #region INativeObject
    public static new MTLArchitecture Null { get; } = new(0, NativeObjectOwnership.Borrowed);

    public static new MTLArchitecture New(nint nativePtr, NativeObjectOwnership ownership)
    {
        return new(nativePtr, ownership);
    }
    #endregion

    public MTLArchitecture() : this(ObjectiveC.AllocInit(MTLArchitectureBindings.Class), NativeObjectOwnership.Managed)
    {
    }

    #region Inspecting a GPU device’s architecture details - Properties

    /// <summary>
    /// The name of a GPU device’s architecture.
    /// </summary>
    public NSString Name
    {
        get => GetProperty(ref field, MTLArchitectureBindings.Name);
    }
    #endregion
}

file static class MTLArchitectureBindings
{
    public static readonly nint Class = ObjectiveC.GetClass("MTLArchitecture");

    public static readonly Selector Name = "name";
}
