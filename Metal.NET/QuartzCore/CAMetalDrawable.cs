namespace Metal.NET;

public class CAMetalDrawable(nint nativePtr) : NativeObject(nativePtr)
{
    public CAMetalLayer? Layer
    {
        get
        {
            nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, CAMetalDrawableBindings.Layer);

            if (ptr == 0)
            {
                return field = null;
            }

            if (field is null || field.NativePtr != ptr)
            {
                field = new CAMetalLayer(ptr);
            }

            return field;
        }
    }

    public MTLTexture? Texture
    {
        get
        {
            nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, CAMetalDrawableBindings.Texture);

            if (ptr == 0)
            {
                return field = null;
            }

            if (field is null || field.NativePtr != ptr)
            {
                field = new MTLTexture(ptr);
            }

            return field;
        }
    }
}

file static class CAMetalDrawableBindings
{
    public static readonly Selector Layer = Selector.Register("layer");

    public static readonly Selector Texture = Selector.Register("texture");
}
