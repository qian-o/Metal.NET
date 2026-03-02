using System.Runtime.InteropServices;

namespace Metal.NET;

public partial class MTLDevice
{
    /// <summary>
    /// Asynchronously creates a new library by compiling the specified source string.
    /// </summary>
    /// <param name="source">The Metal shading language source code.</param>
    /// <param name="options">Compile options, or null for defaults.</param>
    /// <param name="completionHandler">The handler called when compilation completes.</param>
    public unsafe void NewLibrary(NSString source, MTLCompileOptions? options, MTLNewLibraryCompletionHandler completionHandler)
    {
        GCHandle gch = GCHandle.Alloc(completionHandler);
        BlockLiteral block = BlockLiteral.Create((nint)(delegate* unmanaged[Cdecl]<nint, nint, nint, void>)&NewLibraryTrampoline, GCHandle.ToIntPtr(gch));

        ObjectiveCRuntime.MsgSend(NativePtr, MTLDeviceHandlerBindings.NewLibraryWithSourceOptionsCompletionHandler, source.NativePtr, options?.NativePtr ?? 0, (nint)(&block));
    }

    /// <summary>
    /// Asynchronously creates a new render pipeline state.
    /// </summary>
    /// <param name="descriptor">The render pipeline descriptor.</param>
    /// <param name="completionHandler">The handler called when creation completes.</param>
    public unsafe void NewRenderPipelineState(MTLRenderPipelineDescriptor descriptor, MTLNewRenderPipelineStateCompletionHandler completionHandler)
    {
        GCHandle gch = GCHandle.Alloc(completionHandler);
        BlockLiteral block = BlockLiteral.Create((nint)(delegate* unmanaged[Cdecl]<nint, nint, nint, void>)&NewRenderPipelineStateTrampoline, GCHandle.ToIntPtr(gch));

        ObjectiveCRuntime.MsgSend(NativePtr, MTLDeviceHandlerBindings.NewRenderPipelineStateWithDescriptorCompletionHandler, descriptor.NativePtr, (nint)(&block));
    }

    /// <summary>
    /// Asynchronously creates a new compute pipeline state.
    /// </summary>
    /// <param name="function">The compute function.</param>
    /// <param name="completionHandler">The handler called when creation completes.</param>
    public unsafe void NewComputePipelineState(MTLFunction function, MTLNewComputePipelineStateCompletionHandler completionHandler)
    {
        GCHandle gch = GCHandle.Alloc(completionHandler);
        BlockLiteral block = BlockLiteral.Create((nint)(delegate* unmanaged[Cdecl]<nint, nint, nint, void>)&NewComputePipelineStateTrampoline, GCHandle.ToIntPtr(gch));

        ObjectiveCRuntime.MsgSend(NativePtr, MTLDeviceHandlerBindings.NewComputePipelineStateWithFunctionCompletionHandler, function.NativePtr, (nint)(&block));
    }

    [UnmanagedCallersOnly(CallConvs = [typeof(System.Runtime.CompilerServices.CallConvCdecl)])]
    private static void NewLibraryTrampoline(nint blockPtr, nint libraryPtr, nint errorPtr)
    {
        unsafe
        {
            BlockLiteral* block = (BlockLiteral*)blockPtr;
            GCHandle gch = GCHandle.FromIntPtr(block->Context);
            MTLNewLibraryCompletionHandler handler = (MTLNewLibraryCompletionHandler)gch.Target!;

            MTLLibrary? library = libraryPtr != 0 ? new MTLLibrary(libraryPtr, NativeObjectOwnership.Owned) : null;
            NSError? error = errorPtr != 0 ? new NSError(errorPtr, NativeObjectOwnership.Borrowed) : null;

            handler(library, error);

            gch.Free();
        }
    }

    [UnmanagedCallersOnly(CallConvs = [typeof(System.Runtime.CompilerServices.CallConvCdecl)])]
    private static void NewRenderPipelineStateTrampoline(nint blockPtr, nint pipelineStatePtr, nint errorPtr)
    {
        unsafe
        {
            BlockLiteral* block = (BlockLiteral*)blockPtr;
            GCHandle gch = GCHandle.FromIntPtr(block->Context);
            MTLNewRenderPipelineStateCompletionHandler handler = (MTLNewRenderPipelineStateCompletionHandler)gch.Target!;

            MTLRenderPipelineState? state = pipelineStatePtr != 0 ? new MTLRenderPipelineState(pipelineStatePtr, NativeObjectOwnership.Owned) : null;
            NSError? error = errorPtr != 0 ? new NSError(errorPtr, NativeObjectOwnership.Borrowed) : null;

            handler(state, error);

            gch.Free();
        }
    }

    [UnmanagedCallersOnly(CallConvs = [typeof(System.Runtime.CompilerServices.CallConvCdecl)])]
    private static void NewComputePipelineStateTrampoline(nint blockPtr, nint pipelineStatePtr, nint errorPtr)
    {
        unsafe
        {
            BlockLiteral* block = (BlockLiteral*)blockPtr;
            GCHandle gch = GCHandle.FromIntPtr(block->Context);
            MTLNewComputePipelineStateCompletionHandler handler = (MTLNewComputePipelineStateCompletionHandler)gch.Target!;

            MTLComputePipelineState? state = pipelineStatePtr != 0 ? new MTLComputePipelineState(pipelineStatePtr, NativeObjectOwnership.Owned) : null;
            NSError? error = errorPtr != 0 ? new NSError(errorPtr, NativeObjectOwnership.Borrowed) : null;

            handler(state, error);

            gch.Free();
        }
    }
}

file static class MTLDeviceHandlerBindings
{
    public static readonly Selector NewLibraryWithSourceOptionsCompletionHandler = "newLibraryWithSource:options:completionHandler:";

    public static readonly Selector NewRenderPipelineStateWithDescriptorCompletionHandler = "newRenderPipelineStateWithDescriptor:completionHandler:";

    public static readonly Selector NewComputePipelineStateWithFunctionCompletionHandler = "newComputePipelineStateWithFunction:completionHandler:";
}
