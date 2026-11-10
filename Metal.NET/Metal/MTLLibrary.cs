namespace Metal.NET;

public readonly struct MTLLibrary(nint nativePtr) : IDisposable
{
    public readonly nint NativePtr = nativePtr;

    public static implicit operator NSObject(MTLLibrary value) => new(value.NativePtr);

    public MTLLibrary Retain()
    {
        return new(ObjectiveC.Retain(NativePtr));
    }

    public void Dispose()
    {
        ObjectiveC.Release(NativePtr);
    }

    public NSString Label
    {
        get => new(ObjectiveC.MsgSendNInt(NativePtr, MTLLibraryBindings.Label));
        set => ObjectiveC.MsgSend(NativePtr, MTLLibraryBindings.SetLabel, value.NativePtr);
    }

    public MTLDevice Device
    {
        get => new(ObjectiveC.MsgSendNInt(NativePtr, MTLLibraryBindings.Device));
    }

    public NSArray<NSString> FunctionNames
    {
        get => new(ObjectiveC.MsgSendNInt(NativePtr, MTLLibraryBindings.FunctionNames));
    }

    public MTLLibraryType Type
    {
        get => (MTLLibraryType)ObjectiveC.MsgSendLong(NativePtr, MTLLibraryBindings.Type);
    }

    public NSString InstallName
    {
        get => new(ObjectiveC.MsgSendNInt(NativePtr, MTLLibraryBindings.InstallName));
    }

    public MTLFunction MakeFunction(NSString functionName)
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(NativePtr, MTLLibraryBindings.NewFunctionWithName, functionName.NativePtr);

        return new(nativePtr);
    }

    public MTLFunction MakeFunction(NSString name, MTLFunctionConstantValues constantValues, out NSError error)
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(NativePtr, MTLLibraryBindings.NewFunctionWithName_ConstantValues_Error, name.NativePtr, constantValues.NativePtr, out nint errorPtr);

        error = new(errorPtr);

        return new(nativePtr);
    }

    public void MakeFunction(NSString name, MTLFunctionConstantValues constantValues, MTLNewFunctionWithNameCompletionHandler completionHandler)
    {
        ObjectiveC.MsgSend(NativePtr, MTLLibraryBindings.NewFunctionWithName_ConstantValues_CompletionHandler, name.NativePtr, constantValues.NativePtr, completionHandler.NativePtr);
    }

    public MTLFunctionReflection Reflection(NSString functionName)
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(NativePtr, MTLLibraryBindings.ReflectionForFunctionWithName, functionName.NativePtr);

        return new(nativePtr);
    }

    public void MakeFunction(MTLFunctionDescriptor descriptor, MTLNewFunctionWithNameCompletionHandler completionHandler)
    {
        ObjectiveC.MsgSend(NativePtr, MTLLibraryBindings.NewFunctionWithDescriptor_CompletionHandler, descriptor.NativePtr, completionHandler.NativePtr);
    }

    public MTLFunction MakeFunction(MTLFunctionDescriptor descriptor, out NSError error)
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(NativePtr, MTLLibraryBindings.NewFunctionWithDescriptor_Error, descriptor.NativePtr, out nint errorPtr);

        error = new(errorPtr);

        return new(nativePtr);
    }

    public void MakeIntersectionFunction(MTLIntersectionFunctionDescriptor descriptor, MTLNewFunctionWithNameCompletionHandler completionHandler)
    {
        ObjectiveC.MsgSend(NativePtr, MTLLibraryBindings.NewIntersectionFunctionWithDescriptor_CompletionHandler, descriptor.NativePtr, completionHandler.NativePtr);
    }

    public MTLFunction MakeIntersectionFunction(MTLIntersectionFunctionDescriptor descriptor, out NSError error)
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(NativePtr, MTLLibraryBindings.NewIntersectionFunctionWithDescriptor_Error, descriptor.NativePtr, out nint errorPtr);

        error = new(errorPtr);

        return new(nativePtr);
    }
}

file static class MTLLibraryBindings
{
    public static readonly Selector Device = "device";

    public static readonly Selector FunctionNames = "functionNames";

    public static readonly Selector InstallName = "installName";

    public static readonly Selector Label = "label";

    public static readonly Selector NewFunctionWithDescriptor_CompletionHandler = "newFunctionWithDescriptor:completionHandler:";

    public static readonly Selector NewFunctionWithDescriptor_Error = "newFunctionWithDescriptor:error:";

    public static readonly Selector NewFunctionWithName = "newFunctionWithName:";

    public static readonly Selector NewFunctionWithName_ConstantValues_CompletionHandler = "newFunctionWithName:constantValues:completionHandler:";

    public static readonly Selector NewFunctionWithName_ConstantValues_Error = "newFunctionWithName:constantValues:error:";

    public static readonly Selector NewIntersectionFunctionWithDescriptor_CompletionHandler = "newIntersectionFunctionWithDescriptor:completionHandler:";

    public static readonly Selector NewIntersectionFunctionWithDescriptor_Error = "newIntersectionFunctionWithDescriptor:error:";

    public static readonly Selector ReflectionForFunctionWithName = "reflectionForFunctionWithName:";

    public static readonly Selector SetLabel = "setLabel:";

    public static readonly Selector Type = "type";
}
