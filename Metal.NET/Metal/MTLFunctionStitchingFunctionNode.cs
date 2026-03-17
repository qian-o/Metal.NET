namespace Metal.NET;

public class MTLFunctionStitchingFunctionNode(nint nativePtr, NativeObjectOwnership ownership) : NSObject(nativePtr, ownership), INativeObject<MTLFunctionStitchingFunctionNode>
{
    #region INativeObject
    public static new MTLFunctionStitchingFunctionNode Null { get; } = new(0, NativeObjectOwnership.Borrowed);

    public static new MTLFunctionStitchingFunctionNode New(nint nativePtr, NativeObjectOwnership ownership)
    {
        return new(nativePtr, ownership);
    }
    #endregion

    public NSString Name
    {
        get => GetProperty(ref field, MTLFunctionStitchingFunctionNodeBindings.Name);
        set => SetProperty(ref field, MTLFunctionStitchingFunctionNodeBindings.SetName, value);
    }

    public NSString Name
    {
        get => GetProperty(ref field, MTLFunctionStitchingFunctionNodeBindings.Name);
        set => SetProperty(ref field, MTLFunctionStitchingFunctionNodeBindings.SetName, value);
    }

    public void SetName(NSString name)
    {
        ObjectiveC.MsgSend(NativePtr, MTLFunctionStitchingFunctionNodeBindings.SetName, name.NativePtr);
    }
}

file static class MTLFunctionStitchingFunctionNodeBindings
{
    public static readonly Selector Name = "name";

    public static readonly Selector SetName = "setName:";
}
