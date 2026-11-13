using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace Metal.NET;

public sealed unsafe class MTL4CommitFeedbackHandler(Action<MTL4CommitFeedback> callback) : NativeBlock((nint)(delegate* unmanaged[Cdecl]<nint, nint, void>)&Trampoline, callback)
{
    [UnmanagedCallersOnly(CallConvs = [typeof(CallConvCdecl)])]
    private static void Trampoline(nint block, nint mTL4CommitFeedback)
    {
        Action<MTL4CommitFeedback> callback = GetContext<Action<MTL4CommitFeedback>>(block);

        callback(new MTL4CommitFeedback(mTL4CommitFeedback));
    }
}

public sealed unsafe class MTL4NewBinaryFunctionCompletionHandler(Action<MTL4BinaryFunction, NSError> callback) : NativeBlock((nint)(delegate* unmanaged[Cdecl]<nint, nint, nint, void>)&Trampoline, callback)
{
    [UnmanagedCallersOnly(CallConvs = [typeof(CallConvCdecl)])]
    private static void Trampoline(nint block, nint mTL4BinaryFunction, nint nSError)
    {
        Action<MTL4BinaryFunction, NSError> callback = GetContext<Action<MTL4BinaryFunction, NSError>>(block);

        callback(new MTL4BinaryFunction(mTL4BinaryFunction), new NSError(nSError));
    }
}

public sealed unsafe class MTL4NewMachineLearningPipelineStateCompletionHandler(Action<MTL4MachineLearningPipelineState, NSError> callback) : NativeBlock((nint)(delegate* unmanaged[Cdecl]<nint, nint, nint, void>)&Trampoline, callback)
{
    [UnmanagedCallersOnly(CallConvs = [typeof(CallConvCdecl)])]
    private static void Trampoline(nint block, nint mTL4MachineLearningPipelineState, nint nSError)
    {
        Action<MTL4MachineLearningPipelineState, NSError> callback = GetContext<Action<MTL4MachineLearningPipelineState, NSError>>(block);

        callback(new MTL4MachineLearningPipelineState(mTL4MachineLearningPipelineState), new NSError(nSError));
    }
}

public sealed unsafe class MTLAddLogHandlerBlock(Action<NSString, NSString, long, NSString> callback) : NativeBlock((nint)(delegate* unmanaged[Cdecl]<nint, nint, nint, long, nint, void>)&Trampoline, callback)
{
    [UnmanagedCallersOnly(CallConvs = [typeof(CallConvCdecl)])]
    private static void Trampoline(nint block, nint nSString, nint nSString2, long param2, nint nSString3)
    {
        Action<NSString, NSString, long, NSString> callback = GetContext<Action<NSString, NSString, long, NSString>>(block);

        callback(new NSString(nSString), new NSString(nSString2), param2, new NSString(nSString3));
    }
}

public sealed unsafe class MTLCommandBufferHandler(Action<MTLCommandBuffer> callback) : NativeBlock((nint)(delegate* unmanaged[Cdecl]<nint, nint, void>)&Trampoline, callback)
{
    [UnmanagedCallersOnly(CallConvs = [typeof(CallConvCdecl)])]
    private static void Trampoline(nint block, nint mTLCommandBuffer)
    {
        Action<MTLCommandBuffer> callback = GetContext<Action<MTLCommandBuffer>>(block);

        callback(new MTLCommandBuffer(mTLCommandBuffer));
    }
}

public sealed unsafe class MTLDeviceNotificationHandler(Action<MTLDevice, long> callback) : NativeBlock((nint)(delegate* unmanaged[Cdecl]<nint, nint, long, void>)&Trampoline, callback)
{
    [UnmanagedCallersOnly(CallConvs = [typeof(CallConvCdecl)])]
    private static void Trampoline(nint block, nint mTLDevice, long param1)
    {
        Action<MTLDevice, long> callback = GetContext<Action<MTLDevice, long>>(block);

        callback(new MTLDevice(mTLDevice), param1);
    }
}

public sealed unsafe class MTLDrawablePresentedHandler(Action<MTLDrawable> callback) : NativeBlock((nint)(delegate* unmanaged[Cdecl]<nint, nint, void>)&Trampoline, callback)
{
    [UnmanagedCallersOnly(CallConvs = [typeof(CallConvCdecl)])]
    private static void Trampoline(nint block, nint mTLDrawable)
    {
        Action<MTLDrawable> callback = GetContext<Action<MTLDrawable>>(block);

        callback(new MTLDrawable(mTLDrawable));
    }
}

public sealed unsafe class MTLIOCommandBufferHandler(Action<MTLIOCommandBuffer> callback) : NativeBlock((nint)(delegate* unmanaged[Cdecl]<nint, nint, void>)&Trampoline, callback)
{
    [UnmanagedCallersOnly(CallConvs = [typeof(CallConvCdecl)])]
    private static void Trampoline(nint block, nint mTLIOCommandBuffer)
    {
        Action<MTLIOCommandBuffer> callback = GetContext<Action<MTLIOCommandBuffer>>(block);

        callback(new MTLIOCommandBuffer(mTLIOCommandBuffer));
    }
}

public sealed unsafe class MTLNewBufferWithBytesNoCopyDeallocator(Action<nint, nuint> callback) : NativeBlock((nint)(delegate* unmanaged[Cdecl]<nint, nint, nuint, void>)&Trampoline, callback)
{
    [UnmanagedCallersOnly(CallConvs = [typeof(CallConvCdecl)])]
    private static void Trampoline(nint block, nint pointer, nuint value)
    {
        Action<nint, nuint> callback = GetContext<Action<nint, nuint>>(block);

        callback(pointer, value);
    }
}

public sealed unsafe class MTLNewComputePipelineStateCompletionHandler(Action<MTLComputePipelineState, NSError> callback) : NativeBlock((nint)(delegate* unmanaged[Cdecl]<nint, nint, nint, void>)&Trampoline, callback)
{
    [UnmanagedCallersOnly(CallConvs = [typeof(CallConvCdecl)])]
    private static void Trampoline(nint block, nint mTLComputePipelineState, nint nSError)
    {
        Action<MTLComputePipelineState, NSError> callback = GetContext<Action<MTLComputePipelineState, NSError>>(block);

        callback(new MTLComputePipelineState(mTLComputePipelineState), new NSError(nSError));
    }
}

public sealed unsafe class MTLNewComputePipelineStateWithReflectionCompletionHandler(Action<MTLComputePipelineState, MTLComputePipelineReflection, NSError> callback) : NativeBlock((nint)(delegate* unmanaged[Cdecl]<nint, nint, nint, nint, void>)&Trampoline, callback)
{
    [UnmanagedCallersOnly(CallConvs = [typeof(CallConvCdecl)])]
    private static void Trampoline(nint block, nint mTLComputePipelineState, nint mTLComputePipelineReflection, nint nSError)
    {
        Action<MTLComputePipelineState, MTLComputePipelineReflection, NSError> callback = GetContext<Action<MTLComputePipelineState, MTLComputePipelineReflection, NSError>>(block);

        callback(new MTLComputePipelineState(mTLComputePipelineState), new MTLComputePipelineReflection(mTLComputePipelineReflection), new NSError(nSError));
    }
}

public sealed unsafe class MTLNewDynamicLibraryCompletionHandler(Action<MTLDynamicLibrary, NSError> callback) : NativeBlock((nint)(delegate* unmanaged[Cdecl]<nint, nint, nint, void>)&Trampoline, callback)
{
    [UnmanagedCallersOnly(CallConvs = [typeof(CallConvCdecl)])]
    private static void Trampoline(nint block, nint mTLDynamicLibrary, nint nSError)
    {
        Action<MTLDynamicLibrary, NSError> callback = GetContext<Action<MTLDynamicLibrary, NSError>>(block);

        callback(new MTLDynamicLibrary(mTLDynamicLibrary), new NSError(nSError));
    }
}

public sealed unsafe class MTLNewFunctionWithNameCompletionHandler(Action<MTLFunction, NSError> callback) : NativeBlock((nint)(delegate* unmanaged[Cdecl]<nint, nint, nint, void>)&Trampoline, callback)
{
    [UnmanagedCallersOnly(CallConvs = [typeof(CallConvCdecl)])]
    private static void Trampoline(nint block, nint mTLFunction, nint nSError)
    {
        Action<MTLFunction, NSError> callback = GetContext<Action<MTLFunction, NSError>>(block);

        callback(new MTLFunction(mTLFunction), new NSError(nSError));
    }
}

public sealed unsafe class MTLNewLibraryCompletionHandler(Action<MTLLibrary, NSError> callback) : NativeBlock((nint)(delegate* unmanaged[Cdecl]<nint, nint, nint, void>)&Trampoline, callback)
{
    [UnmanagedCallersOnly(CallConvs = [typeof(CallConvCdecl)])]
    private static void Trampoline(nint block, nint mTLLibrary, nint nSError)
    {
        Action<MTLLibrary, NSError> callback = GetContext<Action<MTLLibrary, NSError>>(block);

        callback(new MTLLibrary(mTLLibrary), new NSError(nSError));
    }
}

public sealed unsafe class MTLNewRenderPipelineStateCompletionHandler(Action<MTLRenderPipelineState, NSError> callback) : NativeBlock((nint)(delegate* unmanaged[Cdecl]<nint, nint, nint, void>)&Trampoline, callback)
{
    [UnmanagedCallersOnly(CallConvs = [typeof(CallConvCdecl)])]
    private static void Trampoline(nint block, nint mTLRenderPipelineState, nint nSError)
    {
        Action<MTLRenderPipelineState, NSError> callback = GetContext<Action<MTLRenderPipelineState, NSError>>(block);

        callback(new MTLRenderPipelineState(mTLRenderPipelineState), new NSError(nSError));
    }
}

public sealed unsafe class MTLNewRenderPipelineStateWithReflectionCompletionHandler(Action<MTLRenderPipelineState, MTLRenderPipelineReflection, NSError> callback) : NativeBlock((nint)(delegate* unmanaged[Cdecl]<nint, nint, nint, nint, void>)&Trampoline, callback)
{
    [UnmanagedCallersOnly(CallConvs = [typeof(CallConvCdecl)])]
    private static void Trampoline(nint block, nint mTLRenderPipelineState, nint mTLRenderPipelineReflection, nint nSError)
    {
        Action<MTLRenderPipelineState, MTLRenderPipelineReflection, NSError> callback = GetContext<Action<MTLRenderPipelineState, MTLRenderPipelineReflection, NSError>>(block);

        callback(new MTLRenderPipelineState(mTLRenderPipelineState), new MTLRenderPipelineReflection(mTLRenderPipelineReflection), new NSError(nSError));
    }
}

public sealed unsafe class MTLSharedEventNotificationBlock(Action<MTLSharedEvent, ulong> callback) : NativeBlock((nint)(delegate* unmanaged[Cdecl]<nint, nint, ulong, void>)&Trampoline, callback)
{
    [UnmanagedCallersOnly(CallConvs = [typeof(CallConvCdecl)])]
    private static void Trampoline(nint block, nint mTLSharedEvent, ulong value)
    {
        Action<MTLSharedEvent, ulong> callback = GetContext<Action<MTLSharedEvent, ulong>>(block);

        callback(new MTLSharedEvent(mTLSharedEvent), value);
    }
}
