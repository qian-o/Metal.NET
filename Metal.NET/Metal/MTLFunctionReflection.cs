namespace Metal.NET;

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

    public MTLBinding[] Bindings
    {
        get => GetArrayProperty<MTLBinding>(MTLFunctionReflectionBindings.Bindings);
    }
}

file static class MTLFunctionReflectionBindings
{
    public static readonly nint Class = ObjectiveC.GetClass("MTLFunctionReflection");

    public static readonly Selector Bindings = "bindings";
}
