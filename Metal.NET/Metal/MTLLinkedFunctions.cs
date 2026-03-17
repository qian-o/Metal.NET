namespace Metal.NET;

/// <summary>
/// A set of related functions that Metal links to when necessary to create the function instance.
/// </summary>
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

    #region Specifying related functions - Properties

    /// <summary>
    /// An array of function objects to link to the new function.
    /// </summary>
    public MTLFunction[] Functions
    {
        get => GetArrayProperty<MTLFunction>(MTLLinkedFunctionsBindings.Functions);
        set => SetArrayProperty(MTLLinkedFunctionsBindings.SetFunctions, value);
    }

    /// <summary>
    /// An array of function objects already compiled to a binary representation to link.
    /// </summary>
    public MTLFunction[] BinaryFunctions
    {
        get => GetArrayProperty<MTLFunction>(MTLLinkedFunctionsBindings.BinaryFunctions);
        set => SetArrayProperty(MTLLinkedFunctionsBindings.SetBinaryFunctions, value);
    }

    /// <summary>
    /// An optional list of groups specifying which functions your shader can call at each call site.
    /// </summary>
    public NSDictionary Groups
    {
        get => GetProperty(ref field, MTLLinkedFunctionsBindings.Groups);
        set => SetProperty(ref field, MTLLinkedFunctionsBindings.SetGroups, value);
    }

    /// <summary>
    /// An array of function objects to link to the new function, without exporting the functions publicly.
    /// </summary>
    public MTLFunction[] PrivateFunctions
    {
        get => GetArrayProperty<MTLFunction>(MTLLinkedFunctionsBindings.PrivateFunctions);
        set => SetArrayProperty(MTLLinkedFunctionsBindings.SetPrivateFunctions, value);
    }
    #endregion

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
