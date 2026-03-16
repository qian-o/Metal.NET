namespace Metal.NET;

/// <summary>Contains views over resources of a specific type, and allows you to manage those views.</summary>
public class MTLResourceViewPool(nint nativePtr, NativeObjectOwnership ownership) : NSObject(nativePtr, ownership), INativeObject<MTLResourceViewPool>
{
    #region INativeObject
    public static new MTLResourceViewPool Null { get; } = new(0, NativeObjectOwnership.Borrowed);

    public static new MTLResourceViewPool New(nint nativePtr, NativeObjectOwnership ownership)
    {
        return new(nativePtr, ownership);
    }
    #endregion

    #region Instance Properties - Properties

    /// <summary>Obtains the resource ID corresponding to the resource view at index 0 in this resource view pool.</summary>
    public MTLResourceID BaseResourceID
    {
        get => ObjectiveC.MsgSendMTLResourceID(NativePtr, MTLResourceViewPoolBindings.BaseResourceID);
    }

    /// <summary>Obtains a reference to the GPU device this pool belongs to.</summary>
    public MTLDevice Device
    {
        get => GetProperty(ref field, MTLResourceViewPoolBindings.Device);
    }

    /// <summary>Queries the optional debug label of this resource view pool.</summary>
    public NSString Label
    {
        get => GetProperty(ref field, MTLResourceViewPoolBindings.Label);
    }

    /// <summary>Queries the number of resource views that this pool contains.</summary>
    public nuint ResourceViewCount
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTLResourceViewPoolBindings.ResourceViewCount);
    }
    #endregion

    #region Instance Methods - Methods

    /// <summary>Copies a range of resource views from a source view pool to a destination location in this view pool.</summary>
    public MTLResourceID CopyResourceViewsFromPool(MTLResourceViewPool sourcePool, NSRange sourceRange, nuint destinationIndex)
    {
        return ObjectiveC.MsgSendMTLResourceID(NativePtr, MTLResourceViewPoolBindings.CopyResourceViewsFromPool, sourcePool.NativePtr, sourceRange, destinationIndex);
    }
    #endregion
}

file static class MTLResourceViewPoolBindings
{
    public static readonly Selector BaseResourceID = "baseResourceID";

    public static readonly Selector CopyResourceViewsFromPool = "copyResourceViewsFromPool:sourceRange:destinationIndex:";

    public static readonly Selector Device = "device";

    public static readonly Selector Label = "label";

    public static readonly Selector ResourceViewCount = "resourceViewCount";
}
