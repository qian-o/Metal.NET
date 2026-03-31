namespace Metal.NET;

public class MTLLinkedFunctions(nint nativePtr, NativeObjectOwnership ownership) : NSObject(nativePtr, ownership), INativeObject<MTLLinkedFunctions>
{
    #region INativeObject
    public static new MTLLinkedFunctions Null { get; } = new(0, NativeObjectOwnership.Borrowed);

    public static new MTLLinkedFunctions New(nint nativePtr, NativeObjectOwnership ownership)
    {
        return new(nativePtr, ownership);
    }
    #endregion

    public MTLLinkedFunctions() : this(ObjectiveC.AllocInit(MTLLinkedFunctionsBindings.Class), NativeObjectOwnership.Managed)
    {
    }

    public NSArray<MTLFunction> Functions
    {
        get => GetProperty(ref field, MTLLinkedFunctionsBindings.Functions);
        set => SetProperty(ref field, MTLLinkedFunctionsBindings.SetFunctions, value);
    }

    public NSArray<MTLFunction> BinaryFunctions
    {
        get => GetProperty(ref field, MTLLinkedFunctionsBindings.BinaryFunctions);
        set => SetProperty(ref field, MTLLinkedFunctionsBindings.SetBinaryFunctions, value);
    }

    public NSDictionary Groups
    {
        get => GetProperty(ref field, MTLLinkedFunctionsBindings.Groups);
        set => SetProperty(ref field, MTLLinkedFunctionsBindings.SetGroups, value);
    }

    public NSArray<MTLFunction> PrivateFunctions
    {
        get => GetProperty(ref field, MTLLinkedFunctionsBindings.PrivateFunctions);
        set => SetProperty(ref field, MTLLinkedFunctionsBindings.SetPrivateFunctions, value);
    }

    public static MTLLinkedFunctions LinkedFunctions()
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(MTLLinkedFunctionsBindings.Class, MTLLinkedFunctionsBindings.LinkedFunctions);

        return new(nativePtr, NativeObjectOwnership.Owned);
    }
}

file static class MTLLinkedFunctionsBindings
{
    public static readonly nint Class = ObjectiveC.GetClass("MTLLinkedFunctions");

    public static readonly Selector BinaryFunctions = "binaryFunctions";

    public static readonly Selector Functions = "functions";

    public static readonly Selector Groups = "groups";

    public static readonly Selector LinkedFunctions = "linkedFunctions";

    public static readonly Selector PrivateFunctions = "privateFunctions";

    public static readonly Selector SetBinaryFunctions = "setBinaryFunctions:";

    public static readonly Selector SetFunctions = "setFunctions:";

    public static readonly Selector SetGroups = "setGroups:";

    public static readonly Selector SetPrivateFunctions = "setPrivateFunctions:";
}
