using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace Metal.NET;

public sealed unsafe class MTL4CommitFeedbackHandler(Action<MTL4CommitFeedback> callback) : NativeBlock((nint)(delegate* unmanaged[Cdecl]<nint, nint, void>)&Trampoline, callback)
{
    [UnmanagedCallersOnly(CallConvs = [typeof(CallConvCdecl)])]
    private static void Trampoline(nint block, nint commitFeedback)
    {
        Action<MTL4CommitFeedback> callback = GetContext<Action<MTL4CommitFeedback>>(block);

        callback(new MTL4CommitFeedback(commitFeedback, NativeObjectOwnership.Borrowed));
    }
}

public sealed unsafe class MTL4NewBinaryFunctionCompletionHandler(Action<MTL4BinaryFunction, NSError> callback) : NativeBlock((nint)(delegate* unmanaged[Cdecl]<nint, nint, nint, void>)&Trampoline, callback)
{
    [UnmanagedCallersOnly(CallConvs = [typeof(CallConvCdecl)])]
    private static void Trampoline(nint block, nint binaryFunction, nint error)
    {
        Action<MTL4BinaryFunction, NSError> callback = GetContext<Action<MTL4BinaryFunction, NSError>>(block);

        callback(new MTL4BinaryFunction(binaryFunction, NativeObjectOwnership.Borrowed), new NSError(error, NativeObjectOwnership.Borrowed));
    }
}

public sealed unsafe class MTL4NewComputePipelineStateCompletionHandler(Action<MTLComputePipelineState, NSError> callback) : NativeBlock((nint)(delegate* unmanaged[Cdecl]<nint, nint, nint, void>)&Trampoline, callback)
{
    [UnmanagedCallersOnly(CallConvs = [typeof(CallConvCdecl)])]
    private static void Trampoline(nint block, nint computePipelineState, nint error)
    {
        Action<MTLComputePipelineState, NSError> callback = GetContext<Action<MTLComputePipelineState, NSError>>(block);

        callback(new MTLComputePipelineState(computePipelineState, NativeObjectOwnership.Borrowed), new NSError(error, NativeObjectOwnership.Borrowed));
    }
}

public sealed unsafe class MTL4NewMachineLearningPipelineStateCompletionHandler(Action<MTL4MachineLearningPipelineState, NSError> callback) : NativeBlock((nint)(delegate* unmanaged[Cdecl]<nint, nint, nint, void>)&Trampoline, callback)
{
    [UnmanagedCallersOnly(CallConvs = [typeof(CallConvCdecl)])]
    private static void Trampoline(nint block, nint machineLearningPipelineState, nint error)
    {
        Action<MTL4MachineLearningPipelineState, NSError> callback = GetContext<Action<MTL4MachineLearningPipelineState, NSError>>(block);

        callback(new MTL4MachineLearningPipelineState(machineLearningPipelineState, NativeObjectOwnership.Borrowed), new NSError(error, NativeObjectOwnership.Borrowed));
    }
}

public sealed unsafe class MTL4NewRenderPipelineStateCompletionHandler(Action<MTLRenderPipelineState, NSError> callback) : NativeBlock((nint)(delegate* unmanaged[Cdecl]<nint, nint, nint, void>)&Trampoline, callback)
{
    [UnmanagedCallersOnly(CallConvs = [typeof(CallConvCdecl)])]
    private static void Trampoline(nint block, nint renderPipelineState, nint error)
    {
        Action<MTLRenderPipelineState, NSError> callback = GetContext<Action<MTLRenderPipelineState, NSError>>(block);

        callback(new MTLRenderPipelineState(renderPipelineState, NativeObjectOwnership.Borrowed), new NSError(error, NativeObjectOwnership.Borrowed));
    }
}

public sealed unsafe class MTLCommandBufferHandler(Action<MTLCommandBuffer> callback) : NativeBlock((nint)(delegate* unmanaged[Cdecl]<nint, nint, void>)&Trampoline, callback)
{
    [UnmanagedCallersOnly(CallConvs = [typeof(CallConvCdecl)])]
    private static void Trampoline(nint block, nint commandBuffer)
    {
        Action<MTLCommandBuffer> callback = GetContext<Action<MTLCommandBuffer>>(block);

        callback(new MTLCommandBuffer(commandBuffer, NativeObjectOwnership.Borrowed));
    }
}

public sealed unsafe class MTLDeallocator(Action<nint, nuint> callback) : NativeBlock((nint)(delegate* unmanaged[Cdecl]<nint, nint, nuint, void>)&Trampoline, callback)
{
    [UnmanagedCallersOnly(CallConvs = [typeof(CallConvCdecl)])]
    private static void Trampoline(nint block, nint pointer, nuint length)
    {
        Action<nint, nuint> callback = GetContext<Action<nint, nuint>>(block);

        callback(pointer, length);
    }
}

public sealed unsafe class MTLDrawablePresentedHandler(Action<MTLDrawable> callback) : NativeBlock((nint)(delegate* unmanaged[Cdecl]<nint, nint, void>)&Trampoline, callback)
{
    [UnmanagedCallersOnly(CallConvs = [typeof(CallConvCdecl)])]
    private static void Trampoline(nint block, nint drawable)
    {
        Action<MTLDrawable> callback = GetContext<Action<MTLDrawable>>(block);

        callback(new MTLDrawable(drawable, NativeObjectOwnership.Borrowed));
    }
}

public sealed unsafe class MTLIOCommandBufferHandler(Action<MTLIOCommandBuffer> callback) : NativeBlock((nint)(delegate* unmanaged[Cdecl]<nint, nint, void>)&Trampoline, callback)
{
    [UnmanagedCallersOnly(CallConvs = [typeof(CallConvCdecl)])]
    private static void Trampoline(nint block, nint iOCommandBuffer)
    {
        Action<MTLIOCommandBuffer> callback = GetContext<Action<MTLIOCommandBuffer>>(block);

        callback(new MTLIOCommandBuffer(iOCommandBuffer, NativeObjectOwnership.Borrowed));
    }
}

public sealed unsafe class MTLLogHandler(Action<NSString, NSString, long, NSString> callback) : NativeBlock((nint)(delegate* unmanaged[Cdecl]<nint, nint, nint, long, nint, void>)&Trampoline, callback)
{
    [UnmanagedCallersOnly(CallConvs = [typeof(CallConvCdecl)])]
    private static void Trampoline(nint block, nint subsystem, nint category, long logLevel, nint message)
    {
        Action<NSString, NSString, long, NSString> callback = GetContext<Action<NSString, NSString, long, NSString>>(block);

        callback(new NSString(subsystem, NativeObjectOwnership.Borrowed), new NSString(category, NativeObjectOwnership.Borrowed), logLevel, new NSString(message, NativeObjectOwnership.Borrowed));
    }
}

public sealed unsafe class MTLNewComputePipelineStateCompletionHandler(Action<MTLComputePipelineState, NSError> callback) : NativeBlock((nint)(delegate* unmanaged[Cdecl]<nint, nint, nint, void>)&Trampoline, callback)
{
    [UnmanagedCallersOnly(CallConvs = [typeof(CallConvCdecl)])]
    private static void Trampoline(nint block, nint computePipelineState, nint error)
    {
        Action<MTLComputePipelineState, NSError> callback = GetContext<Action<MTLComputePipelineState, NSError>>(block);

        callback(new MTLComputePipelineState(computePipelineState, NativeObjectOwnership.Borrowed), new NSError(error, NativeObjectOwnership.Borrowed));
    }
}

public sealed unsafe class MTLNewComputePipelineStateWithReflectionCompletionHandler(Action<MTLComputePipelineState, MTLComputePipelineReflection, NSError> callback) : NativeBlock((nint)(delegate* unmanaged[Cdecl]<nint, nint, nint, nint, void>)&Trampoline, callback)
{
    [UnmanagedCallersOnly(CallConvs = [typeof(CallConvCdecl)])]
    private static void Trampoline(nint block, nint computePipelineState, nint computePipelineReflection, nint error)
    {
        Action<MTLComputePipelineState, MTLComputePipelineReflection, NSError> callback = GetContext<Action<MTLComputePipelineState, MTLComputePipelineReflection, NSError>>(block);

        callback(new MTLComputePipelineState(computePipelineState, NativeObjectOwnership.Borrowed), new MTLComputePipelineReflection(computePipelineReflection, NativeObjectOwnership.Borrowed), new NSError(error, NativeObjectOwnership.Borrowed));
    }
}

public sealed unsafe class MTLNewDynamicLibraryCompletionHandler(Action<MTLDynamicLibrary, NSError> callback) : NativeBlock((nint)(delegate* unmanaged[Cdecl]<nint, nint, nint, void>)&Trampoline, callback)
{
    [UnmanagedCallersOnly(CallConvs = [typeof(CallConvCdecl)])]
    private static void Trampoline(nint block, nint dynamicLibrary, nint error)
    {
        Action<MTLDynamicLibrary, NSError> callback = GetContext<Action<MTLDynamicLibrary, NSError>>(block);

        callback(new MTLDynamicLibrary(dynamicLibrary, NativeObjectOwnership.Borrowed), new NSError(error, NativeObjectOwnership.Borrowed));
    }
}

public sealed unsafe class MTLNewFunctionCompletionHandler(Action<MTLFunction, NSError> callback) : NativeBlock((nint)(delegate* unmanaged[Cdecl]<nint, nint, nint, void>)&Trampoline, callback)
{
    [UnmanagedCallersOnly(CallConvs = [typeof(CallConvCdecl)])]
    private static void Trampoline(nint block, nint function, nint error)
    {
        Action<MTLFunction, NSError> callback = GetContext<Action<MTLFunction, NSError>>(block);

        callback(new MTLFunction(function, NativeObjectOwnership.Borrowed), new NSError(error, NativeObjectOwnership.Borrowed));
    }
}

public sealed unsafe class MTLNewLibraryCompletionHandler(Action<MTLLibrary, NSError> callback) : NativeBlock((nint)(delegate* unmanaged[Cdecl]<nint, nint, nint, void>)&Trampoline, callback)
{
    [UnmanagedCallersOnly(CallConvs = [typeof(CallConvCdecl)])]
    private static void Trampoline(nint block, nint library, nint error)
    {
        Action<MTLLibrary, NSError> callback = GetContext<Action<MTLLibrary, NSError>>(block);

        callback(new MTLLibrary(library, NativeObjectOwnership.Borrowed), new NSError(error, NativeObjectOwnership.Borrowed));
    }
}

public sealed unsafe class MTLNewRenderPipelineStateCompletionHandler(Action<MTLRenderPipelineState, NSError> callback) : NativeBlock((nint)(delegate* unmanaged[Cdecl]<nint, nint, nint, void>)&Trampoline, callback)
{
    [UnmanagedCallersOnly(CallConvs = [typeof(CallConvCdecl)])]
    private static void Trampoline(nint block, nint renderPipelineState, nint error)
    {
        Action<MTLRenderPipelineState, NSError> callback = GetContext<Action<MTLRenderPipelineState, NSError>>(block);

        callback(new MTLRenderPipelineState(renderPipelineState, NativeObjectOwnership.Borrowed), new NSError(error, NativeObjectOwnership.Borrowed));
    }
}

public sealed unsafe class MTLNewRenderPipelineStateWithReflectionCompletionHandler(Action<MTLRenderPipelineState, MTLRenderPipelineReflection, NSError> callback) : NativeBlock((nint)(delegate* unmanaged[Cdecl]<nint, nint, nint, nint, void>)&Trampoline, callback)
{
    [UnmanagedCallersOnly(CallConvs = [typeof(CallConvCdecl)])]
    private static void Trampoline(nint block, nint renderPipelineState, nint renderPipelineReflection, nint error)
    {
        Action<MTLRenderPipelineState, MTLRenderPipelineReflection, NSError> callback = GetContext<Action<MTLRenderPipelineState, MTLRenderPipelineReflection, NSError>>(block);

        callback(new MTLRenderPipelineState(renderPipelineState, NativeObjectOwnership.Borrowed), new MTLRenderPipelineReflection(renderPipelineReflection, NativeObjectOwnership.Borrowed), new NSError(error, NativeObjectOwnership.Borrowed));
    }
}

public sealed unsafe class MTLSharedEventNotificationBlock(Action<MTLSharedEvent, ulong> callback) : NativeBlock((nint)(delegate* unmanaged[Cdecl]<nint, nint, ulong, void>)&Trampoline, callback)
{
    [UnmanagedCallersOnly(CallConvs = [typeof(CallConvCdecl)])]
    private static void Trampoline(nint block, nint @event, ulong value)
    {
        Action<MTLSharedEvent, ulong> callback = GetContext<Action<MTLSharedEvent, ulong>>(block);

        callback(new MTLSharedEvent(@event, NativeObjectOwnership.Borrowed), value);
    }
}
