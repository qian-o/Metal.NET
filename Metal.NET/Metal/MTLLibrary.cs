namespace Metal.NET;

public class MTLLibrary(nint nativePtr) : NativeObject(nativePtr)
{
    public MTLDevice? Device
    {
        get
        {
            nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLLibraryBindings.Device);

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

    public NSArray? FunctionNames
    {
        get
        {
            nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLLibraryBindings.FunctionNames);

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

    public NSString? InstallName
    {
        get
        {
            nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLLibraryBindings.InstallName);

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

    public NSString? Label
    {
        get
        {
            nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLLibraryBindings.Label);

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
            ObjectiveCRuntime.MsgSend(NativePtr, MTLLibraryBindings.SetLabel, value?.NativePtr ?? 0);
            field = value;
        }
    }

    public MTLLibraryType Type
    {
        get => (MTLLibraryType)ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLLibraryBindings.Type);
    }

    public MTLFunction? NewFunction(NSString functionName)
    {
        nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLLibraryBindings.NewFunction, functionName.NativePtr);
        return ptr is not 0 ? new MTLFunction(ptr) : null;
    }

    public MTLFunction? NewFunction(NSString name, MTLFunctionConstantValues constantValues, out NSError? error)
    {
        nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLLibraryBindings.NewFunction, name.NativePtr, constantValues.NativePtr, out nint errorPtr);
        error = errorPtr is not 0 ? new NSError(errorPtr) : null;
        return ptr is not 0 ? new MTLFunction(ptr) : null;
    }

    public MTLFunction? NewFunction(MTLFunctionDescriptor descriptor, out NSError? error)
    {
        nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLLibraryBindings.NewFunction, descriptor.NativePtr, out nint errorPtr);
        error = errorPtr is not 0 ? new NSError(errorPtr) : null;
        return ptr is not 0 ? new MTLFunction(ptr) : null;
    }

    public MTLFunction? NewIntersectionFunction(MTLIntersectionFunctionDescriptor descriptor, out NSError? error)
    {
        nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLLibraryBindings.NewIntersectionFunction, descriptor.NativePtr, out nint errorPtr);
        error = errorPtr is not 0 ? new NSError(errorPtr) : null;
        return ptr is not 0 ? new MTLFunction(ptr) : null;
    }

    public MTLFunctionReflection? ReflectionForFunction(NSString functionName)
    {
        nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLLibraryBindings.ReflectionForFunction, functionName.NativePtr);
        return ptr is not 0 ? new MTLFunctionReflection(ptr) : null;
    }
}

file static class MTLLibraryBindings
{
    public static readonly Selector Device = Selector.Register("device");

    public static readonly Selector FunctionNames = Selector.Register("functionNames");

    public static readonly Selector InstallName = Selector.Register("installName");

    public static readonly Selector Label = Selector.Register("label");

    public static readonly Selector NewFunction = Selector.Register("newFunctionWithName:");

    public static readonly Selector NewIntersectionFunction = Selector.Register("newIntersectionFunctionWithDescriptor:error:");

    public static readonly Selector ReflectionForFunction = Selector.Register("reflectionForFunctionWithName:");

    public static readonly Selector SetLabel = Selector.Register("setLabel:");

    public static readonly Selector Type = Selector.Register("type");
}
