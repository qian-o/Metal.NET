using System.Runtime.InteropServices;

namespace Metal.NET;

public partial class MTLLibrary
{
    /// <summary>
    /// Asynchronously creates a function with constant values.
    /// </summary>
    /// <param name="name">The function name.</param>
    /// <param name="constantValues">The function constant values.</param>
    /// <param name="completionHandler">The handler called when creation completes.</param>
    public unsafe void NewFunction(NSString name, MTLFunctionConstantValues constantValues, MTLNewFunctionCompletionHandler completionHandler)
    {
        GCHandle gch = GCHandle.Alloc(completionHandler);
        BlockLiteral block = BlockLiteral.Create((nint)(delegate* unmanaged[Cdecl]<nint, nint, nint, void>)&NewFunctionTrampoline, GCHandle.ToIntPtr(gch));

        ObjectiveCRuntime.MsgSend(NativePtr, MTLLibraryHandlerBindings.NewFunctionWithNameConstantValuesCompletionHandler, name.NativePtr, constantValues.NativePtr, (nint)(&block));
    }

    /// <summary>
    /// Asynchronously creates a function from a descriptor.
    /// </summary>
    /// <param name="descriptor">The function descriptor.</param>
    /// <param name="completionHandler">The handler called when creation completes.</param>
    public unsafe void NewFunction(MTLFunctionDescriptor descriptor, MTLNewFunctionCompletionHandler completionHandler)
    {
        GCHandle gch = GCHandle.Alloc(completionHandler);
        BlockLiteral block = BlockLiteral.Create((nint)(delegate* unmanaged[Cdecl]<nint, nint, nint, void>)&NewFunctionTrampoline, GCHandle.ToIntPtr(gch));

        ObjectiveCRuntime.MsgSend(NativePtr, MTLLibraryHandlerBindings.NewFunctionWithDescriptorCompletionHandler, descriptor.NativePtr, (nint)(&block));
    }

    /// <summary>
    /// Asynchronously creates an intersection function from a descriptor.
    /// </summary>
    /// <param name="descriptor">The intersection function descriptor.</param>
    /// <param name="completionHandler">The handler called when creation completes.</param>
    public unsafe void NewIntersectionFunction(MTLIntersectionFunctionDescriptor descriptor, MTLNewFunctionCompletionHandler completionHandler)
    {
        GCHandle gch = GCHandle.Alloc(completionHandler);
        BlockLiteral block = BlockLiteral.Create((nint)(delegate* unmanaged[Cdecl]<nint, nint, nint, void>)&NewFunctionTrampoline, GCHandle.ToIntPtr(gch));

        ObjectiveCRuntime.MsgSend(NativePtr, MTLLibraryHandlerBindings.NewIntersectionFunctionWithDescriptorCompletionHandler, descriptor.NativePtr, (nint)(&block));
    }

    [UnmanagedCallersOnly(CallConvs = [typeof(System.Runtime.CompilerServices.CallConvCdecl)])]
    private static void NewFunctionTrampoline(nint blockPtr, nint functionPtr, nint errorPtr)
    {
        unsafe
        {
            BlockLiteral* block = (BlockLiteral*)blockPtr;
            GCHandle gch = GCHandle.FromIntPtr(block->Context);
            MTLNewFunctionCompletionHandler handler = (MTLNewFunctionCompletionHandler)gch.Target!;

            MTLFunction? function = functionPtr != 0 ? new MTLFunction(functionPtr, NativeObjectOwnership.Owned) : null;
            NSError? error = errorPtr != 0 ? new NSError(errorPtr, NativeObjectOwnership.Borrowed) : null;

            handler(function, error);

            gch.Free();
        }
    }
}

file static class MTLLibraryHandlerBindings
{
    public static readonly Selector NewFunctionWithNameConstantValuesCompletionHandler = "newFunctionWithName:constantValues:completionHandler:";

    public static readonly Selector NewFunctionWithDescriptorCompletionHandler = "newFunctionWithDescriptor:completionHandler:";

    public static readonly Selector NewIntersectionFunctionWithDescriptorCompletionHandler = "newIntersectionFunctionWithDescriptor:completionHandler:";
}
