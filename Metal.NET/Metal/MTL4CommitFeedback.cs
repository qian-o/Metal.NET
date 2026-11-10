namespace Metal.NET;

public readonly struct MTL4CommitFeedback(nint nativePtr) : IDisposable
{
    public readonly nint NativePtr = nativePtr;

    public bool IsNull => NativePtr is 0;

    public static implicit operator NSObject(MTL4CommitFeedback value) => new(value.NativePtr);

    public MTL4CommitFeedback Retain()
    {
        return new(ObjectiveC.Retain(NativePtr));
    }

    public void Dispose()
    {
        ObjectiveC.Release(NativePtr);
    }

    public NSError Error
    {
        get => new(ObjectiveC.MsgSendNInt(NativePtr, MTL4CommitFeedbackBindings.Error));
    }

    public double GpuStartTime
    {
        get => ObjectiveC.MsgSendDouble(NativePtr, MTL4CommitFeedbackBindings.GPUStartTime);
    }

    public double GpuEndTime
    {
        get => ObjectiveC.MsgSendDouble(NativePtr, MTL4CommitFeedbackBindings.GPUEndTime);
    }
}

file static class MTL4CommitFeedbackBindings
{
    public static readonly Selector Error = "error";

    public static readonly Selector GPUEndTime = "GPUEndTime";

    public static readonly Selector GPUStartTime = "GPUStartTime";
}
