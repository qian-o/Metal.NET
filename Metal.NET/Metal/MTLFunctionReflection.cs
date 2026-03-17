namespace Metal.NET;

/// <summary>
/// Represents a reflection object containing information about a function in a Metal library.
/// </summary>
public class MTLFunctionReflection(nint nativePtr, NativeObjectOwnership ownership) : NSObject(nativePtr, ownership), INativeObject<MTLFunctionReflection>
{
    #region INativeObject
    public static new MTLFunctionReflection Null { get; } = new(0, NativeObjectOwnership.Borrowed);

    public static new MTLFunctionReflection New(nint nativePtr, NativeObjectOwnership ownership)
    {
        return new(nativePtr, ownership);
    }
    #endregion

    public MTLFunctionReflection() : this(ObjectiveC.AllocInit(MTLFunctionReflectionBindings.Class), NativeObjectOwnership.Managed)
    {
    }

    #region Instance Properties - Properties

    /// <summary>
    /// Provides a list of inputs and outputs of the function.
    /// </summary>
    public MTLBinding[] Bindings
    {
        get => GetArrayProperty<MTLBinding>(MTLFunctionReflectionBindings.Bindings);
    }
    #endregion
}

file static class MTLFunctionReflectionBindings
{
    public static readonly nint Class = ObjectiveC.GetClass("MTLFunctionReflection");

    public static readonly Selector Bindings = "bindings";
}
