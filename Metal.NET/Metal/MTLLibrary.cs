namespace Metal.NET;

public class MTLLibrary(nint nativePtr, NativeObjectOwnership ownership) : NSObject(nativePtr, ownership), INativeObject<MTLLibrary>
{
    #region INativeObject
    public static new MTLLibrary Null { get; } = new(0, NativeObjectOwnership.Borrowed);

    public static new MTLLibrary New(nint nativePtr, NativeObjectOwnership ownership)
    {
        return new(nativePtr, ownership);
    }
    #endregion

    public MTLDevice Device
    {
        get => GetProperty(ref field, MTLLibraryBindings.Device);
    }

    public NSString[] FunctionNames
    {
        get => GetArrayProperty<NSString>(MTLLibraryBindings.FunctionNames);
    }

    public NSString InstallName
    {
        get => GetProperty(ref field, MTLLibraryBindings.InstallName);
    }

    public NSString Label
    {
        get => GetProperty(ref field, MTLLibraryBindings.Label);
        set => SetProperty(ref field, MTLLibraryBindings.SetLabel, value);
    }

    public MTLLibraryType Type
    {
        get => (MTLLibraryType)ObjectiveC.MsgSendLong(NativePtr, MTLLibraryBindings.Type);
    }

    public MTLFunction NewFunction(NSString functionName)
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(NativePtr, MTLLibraryBindings.NewFunction, functionName.NativePtr);

        return new(nativePtr, NativeObjectOwnership.Owned);
    }

    public MTLFunction NewFunction(NSString name, MTLFunctionConstantValues constantValues, out NSError error)
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(NativePtr, MTLLibraryBindings.NewFunctionWithNameconstantValueserror, name.NativePtr, constantValues.NativePtr, out nint errorPtr);

        error = new(errorPtr, NativeObjectOwnership.Owned);

        return new(nativePtr, NativeObjectOwnership.Owned);
    }

    public void NewFunction(NSString name, MTLFunctionConstantValues constantValues, MTLNewFunctionCompletionHandler completionHandler)
    {
        ObjectiveC.MsgSend(NativePtr, MTLLibraryBindings.NewFunction, name.NativePtr, constantValues.NativePtr, completionHandler.NativePtr);
    }

    public void NewFunction(MTLFunctionDescriptor descriptor, MTLNewFunctionCompletionHandler completionHandler)
    {
        ObjectiveC.MsgSend(NativePtr, MTLLibraryBindings.NewFunctionWithDescriptorerror, descriptor.NativePtr, completionHandler.NativePtr);
    }

    public MTLFunction NewFunction(MTLFunctionDescriptor descriptor, out NSError error)
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(NativePtr, MTLLibraryBindings.NewFunction, descriptor.NativePtr, out nint errorPtr);

        error = new(errorPtr, NativeObjectOwnership.Owned);

        return new(nativePtr, NativeObjectOwnership.Owned);
    }

    public void NewIntersectionFunction(MTLIntersectionFunctionDescriptor descriptor, MTLNewFunctionCompletionHandler completionHandler)
    {
        ObjectiveC.MsgSend(NativePtr, MTLLibraryBindings.NewIntersectionFunction, descriptor.NativePtr, completionHandler.NativePtr);
    }

    public MTLFunction NewIntersectionFunction(MTLIntersectionFunctionDescriptor descriptor, out NSError error)
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(NativePtr, MTLLibraryBindings.NewIntersectionFunction, descriptor.NativePtr, out nint errorPtr);

        error = new(errorPtr, NativeObjectOwnership.Owned);

        return new(nativePtr, NativeObjectOwnership.Owned);
    }

    public MTLFunctionReflection ReflectionForFunction(NSString functionName)
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(NativePtr, MTLLibraryBindings.ReflectionForFunction, functionName.NativePtr);

        return new(nativePtr, NativeObjectOwnership.Owned);
    }
}

file static class MTLLibraryBindings
{
    public static readonly Selector Device = "device";

    public static readonly Selector FunctionNames = "functionNames";

    public static readonly Selector InstallName = "installName";

    public static readonly Selector Label = "label";

    public static readonly Selector NewFunction = "newFunctionWithName:";

    public static readonly Selector NewFunctionWithDescriptorerror = "newFunctionWithDescriptor:error:";

    public static readonly Selector NewFunctionWithNameconstantValueserror = "newFunctionWithName:constantValues:error:";

    public static readonly Selector NewIntersectionFunction = "newIntersectionFunctionWithDescriptor:error:";

    public static readonly Selector ReflectionForFunction = "reflectionForFunctionWithName:";

    public static readonly Selector SetLabel = "setLabel:";

    public static readonly Selector Type = "type";
}
