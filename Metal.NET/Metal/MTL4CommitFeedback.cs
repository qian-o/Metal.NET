namespace Metal.NET;

public class MTL4CommitFeedback(nint nativePtr) : NativeObject(nativePtr)
{
    public NSError? Error
    {
        get
        {
            nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTL4CommitFeedbackBindings.Error);

            if (ptr == 0)
            {
                return field = null;
            }

            if (field is null || field.NativePtr != ptr)
            {
                field = new NSError(ptr);
            }

            return field;
        }
    }

    public double GPUEndTime
    {
        get => ObjectiveCRuntime.MsgSendDouble(NativePtr, MTL4CommitFeedbackBindings.GPUEndTime);
    }

    public double GPUStartTime
    {
        get => ObjectiveCRuntime.MsgSendDouble(NativePtr, MTL4CommitFeedbackBindings.GPUStartTime);
    }
}

file static class MTL4CommitFeedbackBindings
{
    public static readonly Selector Error = Selector.Register("error");

    public static readonly Selector GPUEndTime = Selector.Register("GPUEndTime");

    public static readonly Selector GPUStartTime = Selector.Register("GPUStartTime");
}
