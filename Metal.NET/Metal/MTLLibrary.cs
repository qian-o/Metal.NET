namespace Metal.NET;

/// <summary>A collection of Metal shader functions.</summary>
public class MTLLibrary(nint nativePtr, NativeObjectOwnership ownership) : NSObject(nativePtr, ownership), INativeObject<MTLLibrary>
{
    #region INativeObject
    public static new MTLLibrary Null { get; } = new(0, NativeObjectOwnership.Borrowed);

    public static new MTLLibrary New(nint nativePtr, NativeObjectOwnership ownership)
    {
        return new(nativePtr, ownership);
    }
    #endregion

    #region Querying basic library attributes - Properties

    /// <summary>The installation name for a dynamic library.</summary>
    public NSString InstallName
    {
        get => GetProperty(ref field, MTLLibraryBindings.InstallName);
    }

    /// <summary>The library’s basic type.</summary>
    public MTLLibraryType Type
    {
        get => (MTLLibraryType)ObjectiveC.MsgSendLong(NativePtr, MTLLibraryBindings.Type);
    }
    #endregion

    #region Querying library contents - Properties

    /// <summary>The names of all public functions in the library.</summary>
    public NSString[] FunctionNames
    {
        get => GetArrayProperty<NSString>(MTLLibraryBindings.FunctionNames);
    }
    #endregion

    #region Identifying the library - Properties

    /// <summary>The Metal device object that created the library.</summary>
    public MTLDevice Device
    {
        get => GetProperty(ref field, MTLLibraryBindings.Device);
    }

    /// <summary>A string that identifies the library.</summary>
    public NSString Label
    {
        get => GetProperty(ref field, MTLLibraryBindings.Label);
        set => SetProperty(ref field, MTLLibraryBindings.SetLabel, value);
    }
    #endregion

    #region Creating shader function instances - Methods

    /// <summary>Creates an instance that represents a shader function in the library.</summary>
    public MTLFunction NewFunction(NSString functionName)
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(NativePtr, MTLLibraryBindings.NewFunction, functionName.NativePtr);

        return new(nativePtr, NativeObjectOwnership.Owned);
    }

    /// <summary>Creates an instance that represents a shader function in the library.</summary>
    public MTLFunction NewFunction(NSString name, MTLFunctionConstantValues constantValues, out NSError error)
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(NativePtr, MTLLibraryBindings.NewFunctionWithNameconstantValueserror, name.NativePtr, constantValues.NativePtr, out nint errorPtr);

        error = new(errorPtr, NativeObjectOwnership.Owned);

        return new(nativePtr, NativeObjectOwnership.Owned);
    }

    /// <summary>Creates an instance that represents a shader function in the library.</summary>
    public void NewFunction(NSString name, MTLFunctionConstantValues constantValues, MTLNewFunctionCompletionHandler completionHandler)
    {
        ObjectiveC.MsgSend(NativePtr, MTLLibraryBindings.NewFunction, name.NativePtr, constantValues.NativePtr, completionHandler.NativePtr);
    }

    /// <summary>Creates an instance that represents a shader function in the library.</summary>
    public void NewFunction(MTLFunctionDescriptor descriptor, MTLNewFunctionCompletionHandler completionHandler)
    {
        ObjectiveC.MsgSend(NativePtr, MTLLibraryBindings.NewFunctionWithDescriptorerror, descriptor.NativePtr, completionHandler.NativePtr);
    }

    /// <summary>Creates an instance that represents a shader function in the library.</summary>
    public MTLFunction NewFunction(MTLFunctionDescriptor descriptor, out NSError error)
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(NativePtr, MTLLibraryBindings.NewFunction, descriptor.NativePtr, out nint errorPtr);

        error = new(errorPtr, NativeObjectOwnership.Owned);

        return new(nativePtr, NativeObjectOwnership.Owned);
    }
    #endregion

    #region Creating intersection function instances - Methods

    /// <summary>Asynchronously creates an object representing a ray-tracing intersection function, using the specified descriptor.</summary>
    public void NewIntersectionFunction(MTLIntersectionFunctionDescriptor descriptor, MTLNewFunctionCompletionHandler completionHandler)
    {
        ObjectiveC.MsgSend(NativePtr, MTLLibraryBindings.NewIntersectionFunction, descriptor.NativePtr, completionHandler.NativePtr);
    }

    /// <summary>Asynchronously creates an object representing a ray-tracing intersection function, using the specified descriptor.</summary>
    public MTLFunction NewIntersectionFunction(MTLIntersectionFunctionDescriptor descriptor, out NSError error)
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(NativePtr, MTLLibraryBindings.NewIntersectionFunction, descriptor.NativePtr, out nint errorPtr);

        error = new(errorPtr, NativeObjectOwnership.Owned);

        return new(nativePtr, NativeObjectOwnership.Owned);
    }
    #endregion

    #region Instance Methods - Methods

    /// <summary>Retrieves reflection information for a function in the library.</summary>
    public MTLFunctionReflection ReflectionForFunction(NSString functionName)
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(NativePtr, MTLLibraryBindings.ReflectionForFunction, functionName.NativePtr);

        return new(nativePtr, NativeObjectOwnership.Owned);
    }
    #endregion
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
