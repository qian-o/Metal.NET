namespace Metal.NET;

public class MTLLibrary(nint nativePtr) : NativeObject(nativePtr)
{

    public MTLDevice? Device
    {
        get => GetNullableObject<MTLDevice>(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLLibrarySelector.Device));
    }

    public NSArray? FunctionNames
    {
        get => GetNullableObject<NSArray>(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLLibrarySelector.FunctionNames));
    }

    public NSString? InstallName
    {
        get => GetNullableObject<NSString>(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLLibrarySelector.InstallName));
    }

    public NSString? Label
    {
        get => GetNullableObject<NSString>(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLLibrarySelector.Label));
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLLibrarySelector.SetLabel, value?.NativePtr ?? 0);
    }

    public MTLLibraryType Type
    {
        get => (MTLLibraryType)ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLLibrarySelector.Type);
    }

    public MTLFunction? NewFunction(NSString functionName)
    {
        return GetNullableObject<MTLFunction>(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLLibrarySelector.NewFunction, functionName.NativePtr));
    }

    public MTLFunction? NewFunction(NSString name, MTLFunctionConstantValues constantValues, out NSError? error)
    {
        nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLLibrarySelector.NewFunction, name.NativePtr, constantValues.NativePtr, out nint errorPtr);
        error = GetNullableObject<NSError>(errorPtr);
        return GetNullableObject<MTLFunction>(ptr);
    }

    public MTLFunction? NewFunction(MTLFunctionDescriptor descriptor, out NSError? error)
    {
        nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLLibrarySelector.NewFunction, descriptor.NativePtr, out nint errorPtr);
        error = GetNullableObject<NSError>(errorPtr);
        return GetNullableObject<MTLFunction>(ptr);
    }

    public MTLFunction? NewIntersectionFunction(MTLIntersectionFunctionDescriptor descriptor, out NSError? error)
    {
        nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLLibrarySelector.NewIntersectionFunction, descriptor.NativePtr, out nint errorPtr);
        error = GetNullableObject<NSError>(errorPtr);
        return GetNullableObject<MTLFunction>(ptr);
    }

    public MTLFunctionReflection? ReflectionForFunction(NSString functionName)
    {
        return GetNullableObject<MTLFunctionReflection>(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLLibrarySelector.ReflectionForFunction, functionName.NativePtr));
    }
}

file static class MTLLibrarySelector
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
