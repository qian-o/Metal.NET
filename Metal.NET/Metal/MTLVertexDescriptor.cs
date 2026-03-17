namespace Metal.NET;

/// <summary>
/// An instance that describes how to organize and map data to a vertex function.
/// </summary>
public class MTLVertexDescriptor(nint nativePtr, NativeObjectOwnership ownership) : NSObject(nativePtr, ownership), INativeObject<MTLVertexDescriptor>
{
    #region INativeObject
    public static new MTLVertexDescriptor Null { get; } = new(0, NativeObjectOwnership.Borrowed);

    public static new MTLVertexDescriptor New(nint nativePtr, NativeObjectOwnership ownership)
    {
        return new(nativePtr, ownership);
    }
    #endregion

    public MTLVertexDescriptor() : this(ObjectiveC.AllocInit(MTLVertexDescriptorBindings.Class), NativeObjectOwnership.Managed)
    {
    }

    #region Accessing the vertex buffer layouts and vertex attributes - Properties

    /// <summary>
    /// An array of state data that describes how vertex attribute data is stored in memory and is mapped to arguments for a vertex shader function.
    /// </summary>
    public MTLVertexAttributeDescriptorArray Attributes
    {
        get => GetProperty(ref field, MTLVertexDescriptorBindings.Attributes);
    }

    /// <summary>
    /// An array of state data that describes how data are fetched by a vertex shader function when rendering primitives.
    /// </summary>
    public MTLVertexBufferLayoutDescriptorArray Layouts
    {
        get => GetProperty(ref field, MTLVertexDescriptorBindings.Layouts);
    }
    #endregion

    #region Setting default values - Methods

    /// <summary>
    /// Resets the default state for the vertex descriptor.
    /// </summary>
    public void Reset()
    {
        ObjectiveC.MsgSend(NativePtr, MTLVertexDescriptorBindings.Reset);
    }
    #endregion

    public static MTLVertexDescriptor VertexDescriptor()
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(MTLVertexDescriptorBindings.Class, MTLVertexDescriptorBindings.VertexDescriptor);

        return new(nativePtr, NativeObjectOwnership.Owned);
    }
}

file static class MTLVertexDescriptorBindings
{
    public static readonly nint Class = ObjectiveC.GetClass("MTLVertexDescriptor");

    public static readonly Selector Attributes = "attributes";

    public static readonly Selector Layouts = "layouts";

    public static readonly Selector Reset = "reset";

    public static readonly Selector VertexDescriptor = "vertexDescriptor";
}
