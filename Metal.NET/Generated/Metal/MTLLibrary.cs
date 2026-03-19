namespace Metal.NET;

public partial class MTLLibrary(nint nativePtr, NativeObjectOwnership ownership) : NSObject(nativePtr, ownership), INativeObject<MTLLibrary>
{
    #region INativeObject
    public static new MTLLibrary Null { get; } = new(0, NativeObjectOwnership.Borrowed);

    public static new MTLLibrary New(nint nativePtr, NativeObjectOwnership ownership)
    {
        return new(nativePtr, ownership);
    }
    #endregion

    public NSString Label
    {
        get => GetProperty(ref field, MTLLibraryBindings.Label);
        set => SetProperty(ref field, MTLLibraryBindings.SetLabel, value);
    }

    public MTLDevice Device
    {
        get => GetProperty(ref field, MTLLibraryBindings.Device);
    }

    public NSString[] FunctionNames
    {
        get => GetArrayProperty<NSString>(MTLLibraryBindings.FunctionNames);
    }

    public MTLLibraryType Type
    {
        get => (MTLLibraryType)ObjectiveC.MsgSendLong(NativePtr, MTLLibraryBindings.Type);
    }

    public NSString InstallName
    {
        get => GetProperty(ref field, MTLLibraryBindings.InstallName);
    }

    public MTLFunction MakeFunction(NSString functionName)
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(NativePtr, MTLLibraryBindings.NewFunctionWithName, functionName.NativePtr);

        return new(nativePtr, NativeObjectOwnership.Owned);
    }

    public MTLFunction MakeFunction(NSString name, MTLFunctionConstantValues constantValues, out NSError error)
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(NativePtr, MTLLibraryBindings.NewFunctionWithNameConstantValuesError, name.NativePtr, constantValues.NativePtr, out nint errorPtr);

        error = new(errorPtr, NativeObjectOwnership.Owned);

        return new(nativePtr, NativeObjectOwnership.Owned);
    }

    public MTLFunctionReflection Reflection(NSString functionName)
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(NativePtr, MTLLibraryBindings.ReflectionForFunctionWithName, functionName.NativePtr);

        return new(nativePtr, NativeObjectOwnership.Owned);
    }

    public MTLFunction MakeFunction(MTLFunctionDescriptor descriptor, out NSError error)
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(NativePtr, MTLLibraryBindings.NewFunctionWithDescriptorError, descriptor.NativePtr, out nint errorPtr);

        error = new(errorPtr, NativeObjectOwnership.Owned);

        return new(nativePtr, NativeObjectOwnership.Owned);
    }

    public MTLFunction MakeIntersectionFunction(MTLIntersectionFunctionDescriptor descriptor, out NSError error)
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(NativePtr, MTLLibraryBindings.NewIntersectionFunctionWithDescriptorError, descriptor.NativePtr, out nint errorPtr);

        error = new(errorPtr, NativeObjectOwnership.Owned);

        return new(nativePtr, NativeObjectOwnership.Owned);
    }
}

file static class MTLLibraryBindings
{
    public static readonly Selector Device = "device";

    public static readonly Selector FunctionNames = "functionNames";

    public static readonly Selector InstallName = "installName";

    public static readonly Selector Label = "label";

    public static readonly Selector NewFunctionWithDescriptorError = "newFunctionWithDescriptor:error:";

    public static readonly Selector NewFunctionWithName = "newFunctionWithName:";

    public static readonly Selector NewFunctionWithNameConstantValuesError = "newFunctionWithName:constantValues:error:";

    public static readonly Selector NewIntersectionFunctionWithDescriptorError = "newIntersectionFunctionWithDescriptor:error:";

    public static readonly Selector ReflectionForFunctionWithName = "reflectionForFunctionWithName:";

    public static readonly Selector SetLabel = "setLabel:";

    public static readonly Selector Type = "type";
}
