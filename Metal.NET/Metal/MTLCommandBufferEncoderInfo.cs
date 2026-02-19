namespace Metal.NET;

public class MTLCommandBufferEncoderInfo(nint nativePtr) : NativeObject(nativePtr)
{
    public NSArray? DebugSignposts
    {
        get
        {
            nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLCommandBufferEncoderInfoBindings.DebugSignposts);

            if (ptr == 0)
            {
                return field = null;
            }

            if (field is null || field.NativePtr != ptr)
            {
                field = new NSArray(ptr);
            }

            return field;
        }
    }

    public MTLCommandEncoderErrorState ErrorState
    {
        get => (MTLCommandEncoderErrorState)ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLCommandBufferEncoderInfoBindings.ErrorState);
    }

    public NSString? Label
    {
        get
        {
            nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLCommandBufferEncoderInfoBindings.Label);

            if (ptr == 0)
            {
                return field = null;
            }

            if (field is null || field.NativePtr != ptr)
            {
                field = new NSString(ptr);
            }

            return field;
        }
    }
}

file static class MTLCommandBufferEncoderInfoBindings
{
    public static readonly Selector DebugSignposts = Selector.Register("debugSignposts");

    public static readonly Selector ErrorState = Selector.Register("errorState");

    public static readonly Selector Label = Selector.Register("label");
}
