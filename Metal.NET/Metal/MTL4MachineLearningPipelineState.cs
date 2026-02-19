namespace Metal.NET;

public class MTL4MachineLearningPipelineState(nint nativePtr) : NativeObject(nativePtr)
{
    public MTLDevice? Device
    {
        get
        {
            nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTL4MachineLearningPipelineStateBindings.Device);

            if (ptr == 0)
            {
                return field = null;
            }

            if (field is null || field.NativePtr != ptr)
            {
                field = new MTLDevice(ptr);
            }

            return field;
        }
    }

    public nuint IntermediatesHeapSize
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTL4MachineLearningPipelineStateBindings.IntermediatesHeapSize);
    }

    public NSString? Label
    {
        get
        {
            nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTL4MachineLearningPipelineStateBindings.Label);

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

    public MTL4MachineLearningPipelineReflection? Reflection
    {
        get
        {
            nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTL4MachineLearningPipelineStateBindings.Reflection);

            if (ptr == 0)
            {
                return field = null;
            }

            if (field is null || field.NativePtr != ptr)
            {
                field = new MTL4MachineLearningPipelineReflection(ptr);
            }

            return field;
        }
    }
}

file static class MTL4MachineLearningPipelineStateBindings
{
    public static readonly Selector Device = Selector.Register("device");

    public static readonly Selector IntermediatesHeapSize = Selector.Register("intermediatesHeapSize");

    public static readonly Selector Label = Selector.Register("label");

    public static readonly Selector Reflection = Selector.Register("reflection");
}
