namespace Metal.NET;

public class MTLStitchedLibraryDescriptor(nint nativePtr) : NativeObject(nativePtr)
{
    public MTLStitchedLibraryDescriptor() : this(ObjectiveCRuntime.AllocInit(MTLStitchedLibraryDescriptorBindings.Class))
    {
    }

    public NSArray? BinaryArchives
    {
        get
        {
            nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLStitchedLibraryDescriptorBindings.BinaryArchives);

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
            ObjectiveCRuntime.MsgSend(NativePtr, MTLStitchedLibraryDescriptorBindings.SetBinaryArchives, value?.NativePtr ?? 0);
            field = value;
        }
    }

    public NSArray? FunctionGraphs
    {
        get
        {
            nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLStitchedLibraryDescriptorBindings.FunctionGraphs);

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
            ObjectiveCRuntime.MsgSend(NativePtr, MTLStitchedLibraryDescriptorBindings.SetFunctionGraphs, value?.NativePtr ?? 0);
            field = value;
        }
    }

    public NSArray? Functions
    {
        get
        {
            nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLStitchedLibraryDescriptorBindings.Functions);

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
            ObjectiveCRuntime.MsgSend(NativePtr, MTLStitchedLibraryDescriptorBindings.SetFunctions, value?.NativePtr ?? 0);
            field = value;
        }
    }

    public MTLStitchedLibraryOptions Options
    {
        get => (MTLStitchedLibraryOptions)ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLStitchedLibraryDescriptorBindings.Options);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLStitchedLibraryDescriptorBindings.SetOptions, (nuint)value);
    }
}

file static class MTLStitchedLibraryDescriptorBindings
{
    public static readonly nint Class = ObjectiveCRuntime.GetClass("MTLStitchedLibraryDescriptor");

    public static readonly Selector BinaryArchives = Selector.Register("binaryArchives");

    public static readonly Selector FunctionGraphs = Selector.Register("functionGraphs");

    public static readonly Selector Functions = Selector.Register("functions");

    public static readonly Selector Options = Selector.Register("options");

    public static readonly Selector SetBinaryArchives = Selector.Register("setBinaryArchives:");

    public static readonly Selector SetFunctionGraphs = Selector.Register("setFunctionGraphs:");

    public static readonly Selector SetFunctions = Selector.Register("setFunctions:");

    public static readonly Selector SetOptions = Selector.Register("setOptions:");
}
