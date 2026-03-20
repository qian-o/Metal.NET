namespace Metal.NET;

public partial class MTLFunctionReflection(nint nativePtr, NativeObjectOwnership ownership) : NSObject(nativePtr, ownership), INativeObject<MTLFunctionReflection>
{
    #region INativeObject
    public static new MTLFunctionReflection Null { get; } = new(0, NativeObjectOwnership.Borrowed);

    public static new MTLFunctionReflection New(nint nativePtr, NativeObjectOwnership ownership)
    {
        return new(nativePtr, ownership);
    }
    #endregion

    public MTLBinding[] Bindings
    {
        get => GetArrayProperty<MTLBinding>(MTLFunctionReflectionBindings.Bindings);
    }

    public NSString UserAnnotation
    {
        get => GetProperty(ref field, MTLFunctionReflectionBindings.UserAnnotation);
    }
}

file static class MTLFunctionReflectionBindings
{
    public static readonly Selector Bindings = "bindings";

    public static readonly Selector UserAnnotation = "userAnnotation";
}
