namespace Metal.NET;

/// <summary>
/// Geometry data for a specific keyframe to use in a moving instance.
/// </summary>
public class MTLMotionKeyframeData(nint nativePtr, NativeObjectOwnership ownership) : NSObject(nativePtr, ownership), INativeObject<MTLMotionKeyframeData>
{
    #region INativeObject
    public static new MTLMotionKeyframeData Null { get; } = new(0, NativeObjectOwnership.Borrowed);

    public static new MTLMotionKeyframeData New(nint nativePtr, NativeObjectOwnership ownership)
    {
        return new(nativePtr, ownership);
    }
    #endregion

    public MTLMotionKeyframeData() : this(ObjectiveC.AllocInit(MTLMotionKeyframeDataBindings.Class), NativeObjectOwnership.Managed)
    {
    }

    #region Specifying the keyframe data - Properties

    /// <summary>
    /// The buffer that holds the geometry data.
    /// </summary>
    public MTLBuffer Buffer
    {
        get => GetProperty(ref field, MTLMotionKeyframeDataBindings.Buffer);
        set => SetProperty(ref field, MTLMotionKeyframeDataBindings.SetBuffer, value);
    }

    /// <summary>
    /// The offset, in bytes, to the keyframe data.
    /// </summary>
    public nuint Offset
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTLMotionKeyframeDataBindings.Offset);
        set => ObjectiveC.MsgSend(NativePtr, MTLMotionKeyframeDataBindings.SetOffset, value);
    }
    #endregion

    public static MTLMotionKeyframeData Data()
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(MTLMotionKeyframeDataBindings.Class, MTLMotionKeyframeDataBindings.Data);

        return new(nativePtr, NativeObjectOwnership.Owned);
    }
}

file static class MTLMotionKeyframeDataBindings
{
    public static readonly nint Class = ObjectiveC.GetClass("MTLMotionKeyframeData");

    public static readonly Selector Buffer = "buffer";

    public static readonly Selector Data = "data";

    public static readonly Selector Offset = "offset";

    public static readonly Selector SetBuffer = "setBuffer:";

    public static readonly Selector SetOffset = "setOffset:";
}
