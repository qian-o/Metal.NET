namespace Metal.NET;

public class MTLLinkedFunctions(nint nativePtr, NativeObjectOwnership ownership) : ObjectiveCObject(nativePtr, ownership), INativeObject<MTLLinkedFunctions>
{
    #region INativeObject
    public static MTLLinkedFunctions Null { get; } = new(0, NativeObjectOwnership.Borrowed);

    public static MTLLinkedFunctions New(nint nativePtr, NativeObjectOwnership ownership)
    {
        return new(nativePtr, ownership);
    }
    #endregion

    public MTLLinkedFunctions() : this(ObjectiveC.AllocInit(MTLLinkedFunctionsBindings.Class), NativeObjectOwnership.Managed)
    {
    }

    public MTLFunction[] BinaryFunctions
    {
        get => GetArrayProperty<MTLFunction>(MTLLinkedFunctionsBindings.BinaryFunctions);
        set => SetArrayProperty(MTLLinkedFunctionsBindings.SetBinaryFunctions, value);
    }

    public MTLFunction[] Functions
    {
        get => GetArrayProperty<MTLFunction>(MTLLinkedFunctionsBindings.Functions);
        set => SetArrayProperty(MTLLinkedFunctionsBindings.SetFunctions, value);
    }

    public NSDictionary Groups
    {
        get => GetProperty(ref field, MTLLinkedFunctionsBindings.Groups);
        set => SetProperty(ref field, MTLLinkedFunctionsBindings.SetGroups, value);
    }

    public MTLFunction[] PrivateFunctions
    {
        get => GetArrayProperty<MTLFunction>(MTLLinkedFunctionsBindings.PrivateFunctions);
        set => SetArrayProperty(MTLLinkedFunctionsBindings.SetPrivateFunctions, value);
    }

    public static MTLLinkedFunctions LinkedFunctions()
    {
        nint nativePtr = ObjectiveC.MsgSendPtr(MTLLinkedFunctionsBindings.Class, MTLLinkedFunctionsBindings.LinkedFunctions);

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
