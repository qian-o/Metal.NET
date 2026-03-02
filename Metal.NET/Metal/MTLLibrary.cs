using System.Runtime.InteropServices;

namespace Metal.NET;

public partial class MTLLibrary(nint nativePtr, NativeObjectOwnership ownership) : NativeObject(nativePtr, ownership), INativeObject<MTLLibrary>
{
    public static MTLLibrary Null { get; } = new(0, NativeObjectOwnership.Borrowed);

    public static MTLLibrary Create(nint nativePtr, NativeObjectOwnership ownership) => new(nativePtr, ownership);

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
        get => (MTLLibraryType)ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLLibraryBindings.Type);
    }

    public MTLFunction NewFunction(NSString functionName)
    {
        nint nativePtr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLLibraryBindings.NewFunction, functionName.NativePtr);

        return new(nativePtr, NativeObjectOwnership.Owned);
    }

    public MTLFunction NewFunction(NSString name, MTLFunctionConstantValues constantValues, out NSError error)
    {
        nint nativePtr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLLibraryBindings.NewFunctionWithNameconstantValueserror, name.NativePtr, constantValues.NativePtr, out nint errorPtr);

        error = new(errorPtr, NativeObjectOwnership.Owned);

        return new(nativePtr, NativeObjectOwnership.Owned);
    }

    public MTLFunction NewFunction(MTLFunctionDescriptor descriptor, out NSError error)
    {
        nint nativePtr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLLibraryBindings.NewFunction, descriptor.NativePtr, out nint errorPtr);

        error = new(errorPtr, NativeObjectOwnership.Owned);

        return new(nativePtr, NativeObjectOwnership.Owned);
    }

    public MTLFunction NewIntersectionFunction(MTLIntersectionFunctionDescriptor descriptor, out NSError error)
    {
        nint nativePtr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLLibraryBindings.NewIntersectionFunction, descriptor.NativePtr, out nint errorPtr);

        error = new(errorPtr, NativeObjectOwnership.Owned);

        return new(nativePtr, NativeObjectOwnership.Owned);
    }

    public MTLFunctionReflection ReflectionForFunction(NSString functionName)
    {
        nint nativePtr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLLibraryBindings.ReflectionForFunction, functionName.NativePtr);

        return new(nativePtr, NativeObjectOwnership.Owned);
    }


    public delegate void MTL__InlineBlock_completionHandler(MTLFunction param0, NSError param1);

    public unsafe void NewFunction(NSString name, MTLFunctionConstantValues constantValues, MTL__InlineBlock_completionHandler handler)
    {
        GCHandle gch = GCHandle.Alloc(handler);
        BlockLiteral block = BlockLiteral.Create((nint)(delegate* unmanaged[Cdecl]<nint, nint, nint, void>)&__InlineBlock_completionHandler_Trampoline, GCHandle.ToIntPtr(gch));

        ObjectiveCRuntime.MsgSend(NativePtr, MTLLibraryBindings.NewFunction, name.NativePtr, constantValues.NativePtr, (nint)(&block));
    }

    [UnmanagedCallersOnly(CallConvs = [typeof(System.Runtime.CompilerServices.CallConvCdecl)])]
    private static unsafe void __InlineBlock_completionHandler_Trampoline(nint blockPtr, nint arg0, nint arg1)
    {
        BlockLiteral* block = (BlockLiteral*)blockPtr;
        GCHandle gch = GCHandle.FromIntPtr(block->Context);
        MTL__InlineBlock_completionHandler handler = (MTL__InlineBlock_completionHandler)gch.Target!;

        handler(new MTLFunction(arg0, NativeObjectOwnership.Borrowed), new NSError(arg1, NativeObjectOwnership.Borrowed));

        gch.Free();
    }


    public unsafe void NewFunction(MTLFunctionDescriptor descriptor, MTL__InlineBlock_completionHandler handler)
    {
        GCHandle gch = GCHandle.Alloc(handler);
        BlockLiteral block = BlockLiteral.Create((nint)(delegate* unmanaged[Cdecl]<nint, nint, nint, void>)&__InlineBlock_completionHandler_Trampoline, GCHandle.ToIntPtr(gch));

        ObjectiveCRuntime.MsgSend(NativePtr, MTLLibraryBindings.NewFunctionWithDescriptorerror, descriptor.NativePtr, (nint)(&block));
    }


    public unsafe void NewIntersectionFunction(MTLIntersectionFunctionDescriptor descriptor, MTL__InlineBlock_completionHandler handler)
    {
        GCHandle gch = GCHandle.Alloc(handler);
        BlockLiteral block = BlockLiteral.Create((nint)(delegate* unmanaged[Cdecl]<nint, nint, nint, void>)&__InlineBlock_completionHandler_Trampoline, GCHandle.ToIntPtr(gch));

        ObjectiveCRuntime.MsgSend(NativePtr, MTLLibraryBindings.NewIntersectionFunctionWithDescriptorerror, descriptor.NativePtr, (nint)(&block));
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

    public static readonly Selector NewIntersectionFunction = "newIntersectionFunction::";

    public static readonly Selector NewIntersectionFunctionWithDescriptorerror = "newIntersectionFunctionWithDescriptor:error:";

    public static readonly Selector ReflectionForFunction = "reflectionForFunctionWithName:";

    public static readonly Selector SetLabel = "setLabel:";

    public static readonly Selector Type = "type";
}
