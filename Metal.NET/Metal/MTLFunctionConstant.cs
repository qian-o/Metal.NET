namespace Metal.NET;

/// <summary>A constant that specializes the behavior of a shader.</summary>
public class MTLFunctionConstant(nint nativePtr, NativeObjectOwnership ownership) : NSObject(nativePtr, ownership), INativeObject<MTLFunctionConstant>
{
    #region INativeObject
    public static new MTLFunctionConstant Null { get; } = new(0, NativeObjectOwnership.Borrowed);

    public static new MTLFunctionConstant New(nint nativePtr, NativeObjectOwnership ownership)
    {
        return new(nativePtr, ownership);
    }
    #endregion

    public MTLFunctionConstant() : this(ObjectiveC.AllocInit(MTLFunctionConstantBindings.Class), NativeObjectOwnership.Managed)
    {
    }

    #region Reading the function constant’s properties - Properties

    /// <summary>The name of the function constant.</summary>
    public NSString Name
    {
        get => GetProperty(ref field, MTLFunctionConstantBindings.Name);
    }

    /// <summary>The data type of the function constant.</summary>
    public MTLDataType Type
    {
        get => (MTLDataType)ObjectiveC.MsgSendULong(NativePtr, MTLFunctionConstantBindings.Type);
    }

    /// <summary>The index of the function constant.</summary>
    public nuint Index
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTLFunctionConstantBindings.Index);
    }

    /// <summary>A Boolean value indicating whether the function constant needs to be provided to specialize the function.</summary>
    public Bool8 Required
    {
        get => ObjectiveC.MsgSendBool(NativePtr, MTLFunctionConstantBindings.Required);
    }
    #endregion
}

file static class MTLFunctionConstantBindings
{
    public static readonly nint Class = ObjectiveC.GetClass("MTLFunctionConstant");

    public static readonly Selector Index = "index";

    public static readonly Selector Name = "name";

    public static readonly Selector Required = "required";

    public static readonly Selector Type = "type";
}
