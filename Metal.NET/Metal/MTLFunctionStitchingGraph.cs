namespace Metal.NET;

public class MTLFunctionStitchingGraph(nint nativePtr) : NativeObject(nativePtr)
{
    public MTLFunctionStitchingGraph() : this(ObjectiveCRuntime.AllocInit(MTLFunctionStitchingGraphBindings.Class))
    {
    }

    public NSArray? Attributes
    {
        get
        {
            nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLFunctionStitchingGraphBindings.Attributes);

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
        set
        {
            ObjectiveCRuntime.MsgSend(NativePtr, MTLFunctionStitchingGraphBindings.SetAttributes, value?.NativePtr ?? 0);
            field = value;
        }
    }

    public NSString? FunctionName
    {
        get
        {
            nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLFunctionStitchingGraphBindings.FunctionName);

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
        set
        {
            ObjectiveCRuntime.MsgSend(NativePtr, MTLFunctionStitchingGraphBindings.SetFunctionName, value?.NativePtr ?? 0);
            field = value;
        }
    }

    public NSArray? Nodes
    {
        get
        {
            nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLFunctionStitchingGraphBindings.Nodes);

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
        set
        {
            ObjectiveCRuntime.MsgSend(NativePtr, MTLFunctionStitchingGraphBindings.SetNodes, value?.NativePtr ?? 0);
            field = value;
        }
    }

    public MTLFunctionStitchingFunctionNode? OutputNode
    {
        get
        {
            nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLFunctionStitchingGraphBindings.OutputNode);

            if (ptr == 0)
            {
                return field = null;
            }

            if (field is null || field.NativePtr != ptr)
            {
                field = new MTLFunctionStitchingFunctionNode(ptr);
            }

            return field;
        }
        set
        {
            ObjectiveCRuntime.MsgSend(NativePtr, MTLFunctionStitchingGraphBindings.SetOutputNode, value?.NativePtr ?? 0);
            field = value;
        }
    }
}

file static class MTLFunctionStitchingGraphBindings
{
    public static readonly nint Class = ObjectiveCRuntime.GetClass("MTLFunctionStitchingGraph");

    public static readonly Selector Attributes = Selector.Register("attributes");

    public static readonly Selector FunctionName = Selector.Register("functionName");

    public static readonly Selector Nodes = Selector.Register("nodes");

    public static readonly Selector OutputNode = Selector.Register("outputNode");

    public static readonly Selector SetAttributes = Selector.Register("setAttributes:");

    public static readonly Selector SetFunctionName = Selector.Register("setFunctionName:");

    public static readonly Selector SetNodes = Selector.Register("setNodes:");

    public static readonly Selector SetOutputNode = Selector.Register("setOutputNode:");
}
