using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace Metal.NET;

public sealed unsafe class MTL4CommitFeedbackHandler(Action<nint> callback) : NativeBlock((nint)(delegate* unmanaged[Cdecl]<nint, nint, void>)&Trampoline, callback)
{
    [UnmanagedCallersOnly(CallConvs = [typeof(CallConvCdecl)])]
    private static void Trampoline(nint block, nint mTL4CommitFeedback)
    {
        Action<nint> callback = GetContext<Action<nint>>(block);

        callback(mTL4CommitFeedback);
    }
}

public sealed unsafe class MTL4NewBinaryFunctionCompletionHandler(Action<nint, NSError> callback) : NativeBlock((nint)(delegate* unmanaged[Cdecl]<nint, nint, nint, void>)&Trampoline, callback)
{
    [UnmanagedCallersOnly(CallConvs = [typeof(CallConvCdecl)])]
    private static void Trampoline(nint block, nint mTL4BinaryFunction, nint nSError)
    {
        Action<nint, NSError> callback = GetContext<Action<nint, NSError>>(block);

        callback(mTL4BinaryFunction, new NSError(nSError, NativeObjectOwnership.Borrowed));
    }
}

public sealed unsafe class MTL4NewMachineLearningPipelineStateCompletionHandler(Action<nint, NSError> callback) : NativeBlock((nint)(delegate* unmanaged[Cdecl]<nint, nint, nint, void>)&Trampoline, callback)
{
    [UnmanagedCallersOnly(CallConvs = [typeof(CallConvCdecl)])]
    private static void Trampoline(nint block, nint mTL4MachineLearningPipelineState, nint nSError)
    {
        Action<nint, NSError> callback = GetContext<Action<nint, NSError>>(block);

        callback(mTL4MachineLearningPipelineState, new NSError(nSError, NativeObjectOwnership.Borrowed));
    }
}

public sealed unsafe class MTLAddLogHandlerBlock(Action<NSString, NSString, long, NSString> callback) : NativeBlock((nint)(delegate* unmanaged[Cdecl]<nint, nint, nint, long, nint, void>)&Trampoline, callback)
{
    [UnmanagedCallersOnly(CallConvs = [typeof(CallConvCdecl)])]
    private static void Trampoline(nint block, nint nSString, nint nSString2, long param2, nint nSString3)
    {
        Action<NSString, NSString, long, NSString> callback = GetContext<Action<NSString, NSString, long, NSString>>(block);

        callback(new NSString(nSString, NativeObjectOwnership.Borrowed), new NSString(nSString2, NativeObjectOwnership.Borrowed), param2, new NSString(nSString3, NativeObjectOwnership.Borrowed));
    }
}

public sealed unsafe class MTLCommandBufferHandler(Action<nint> callback) : NativeBlock((nint)(delegate* unmanaged[Cdecl]<nint, nint, void>)&Trampoline, callback)
{
    [UnmanagedCallersOnly(CallConvs = [typeof(CallConvCdecl)])]
    private static void Trampoline(nint block, nint mTLCommandBuffer)
    {
        Action<nint> callback = GetContext<Action<nint>>(block);

        callback(mTLCommandBuffer);
    }
}

public sealed unsafe class MTLDeviceNotificationHandler(Action<nint, long> callback) : NativeBlock((nint)(delegate* unmanaged[Cdecl]<nint, nint, long, void>)&Trampoline, callback)
{
    [UnmanagedCallersOnly(CallConvs = [typeof(CallConvCdecl)])]
    private static void Trampoline(nint block, nint mTLDevice, long param1)
    {
        Action<nint, long> callback = GetContext<Action<nint, long>>(block);

        callback(mTLDevice, param1);
    }
}

public sealed unsafe class MTLDrawablePresentedHandler(Action<nint> callback) : NativeBlock((nint)(delegate* unmanaged[Cdecl]<nint, nint, void>)&Trampoline, callback)
{
    [UnmanagedCallersOnly(CallConvs = [typeof(CallConvCdecl)])]
    private static void Trampoline(nint block, nint mTLDrawable)
    {
        Action<nint> callback = GetContext<Action<nint>>(block);

        callback(mTLDrawable);
    }
}

public sealed unsafe class MTLIOCommandBufferHandler(Action<nint> callback) : NativeBlock((nint)(delegate* unmanaged[Cdecl]<nint, nint, void>)&Trampoline, callback)
{
    [UnmanagedCallersOnly(CallConvs = [typeof(CallConvCdecl)])]
    private static void Trampoline(nint block, nint mTLIOCommandBuffer)
    {
        Action<nint> callback = GetContext<Action<nint>>(block);

        callback(mTLIOCommandBuffer);
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

public sealed unsafe class MTLNewComputePipelineStateCompletionHandler(Action<nint, NSError> callback) : NativeBlock((nint)(delegate* unmanaged[Cdecl]<nint, nint, nint, void>)&Trampoline, callback)
{
    [UnmanagedCallersOnly(CallConvs = [typeof(CallConvCdecl)])]
    private static void Trampoline(nint block, nint mTLComputePipelineState, nint nSError)
    {
        Action<nint, NSError> callback = GetContext<Action<nint, NSError>>(block);

        callback(mTLComputePipelineState, new NSError(nSError, NativeObjectOwnership.Borrowed));
    }
}

public sealed unsafe class MTLNewComputePipelineStateWithReflectionCompletionHandler(Action<nint, MTLComputePipelineReflection, NSError> callback) : NativeBlock((nint)(delegate* unmanaged[Cdecl]<nint, nint, nint, nint, void>)&Trampoline, callback)
{
    [UnmanagedCallersOnly(CallConvs = [typeof(CallConvCdecl)])]
    private static void Trampoline(nint block, nint mTLComputePipelineState, nint mTLComputePipelineReflection, nint nSError)
    {
        Action<nint, MTLComputePipelineReflection, NSError> callback = GetContext<Action<nint, MTLComputePipelineReflection, NSError>>(block);

        callback(mTLComputePipelineState, new MTLComputePipelineReflection(mTLComputePipelineReflection, NativeObjectOwnership.Borrowed), new NSError(nSError, NativeObjectOwnership.Borrowed));
    }
}

public sealed unsafe class MTLNewDynamicLibraryCompletionHandler(Action<nint, NSError> callback) : NativeBlock((nint)(delegate* unmanaged[Cdecl]<nint, nint, nint, void>)&Trampoline, callback)
{
    [UnmanagedCallersOnly(CallConvs = [typeof(CallConvCdecl)])]
    private static void Trampoline(nint block, nint mTLDynamicLibrary, nint nSError)
    {
        Action<nint, NSError> callback = GetContext<Action<nint, NSError>>(block);

        callback(mTLDynamicLibrary, new NSError(nSError, NativeObjectOwnership.Borrowed));
    }
}

public sealed unsafe class MTLNewFunctionWithNameCompletionHandler(Action<nint, NSError> callback) : NativeBlock((nint)(delegate* unmanaged[Cdecl]<nint, nint, nint, void>)&Trampoline, callback)
{
    [UnmanagedCallersOnly(CallConvs = [typeof(CallConvCdecl)])]
    private static void Trampoline(nint block, nint mTLFunction, nint nSError)
    {
        Action<nint, NSError> callback = GetContext<Action<nint, NSError>>(block);

        callback(mTLFunction, new NSError(nSError, NativeObjectOwnership.Borrowed));
    }
}

public sealed unsafe class MTLNewLibraryCompletionHandler(Action<nint, NSError> callback) : NativeBlock((nint)(delegate* unmanaged[Cdecl]<nint, nint, nint, void>)&Trampoline, callback)
{
    [UnmanagedCallersOnly(CallConvs = [typeof(CallConvCdecl)])]
    private static void Trampoline(nint block, nint mTLLibrary, nint nSError)
    {
        Action<nint, NSError> callback = GetContext<Action<nint, NSError>>(block);

        callback(mTLLibrary, new NSError(nSError, NativeObjectOwnership.Borrowed));
    }
}

public sealed unsafe class MTLNewRenderPipelineStateCompletionHandler(Action<nint, NSError> callback) : NativeBlock((nint)(delegate* unmanaged[Cdecl]<nint, nint, nint, void>)&Trampoline, callback)
{
    [UnmanagedCallersOnly(CallConvs = [typeof(CallConvCdecl)])]
    private static void Trampoline(nint block, nint mTLRenderPipelineState, nint nSError)
    {
        Action<nint, NSError> callback = GetContext<Action<nint, NSError>>(block);

        callback(mTLRenderPipelineState, new NSError(nSError, NativeObjectOwnership.Borrowed));
    }
}

public sealed unsafe class MTLNewRenderPipelineStateWithReflectionCompletionHandler(Action<nint, MTLRenderPipelineReflection, NSError> callback) : NativeBlock((nint)(delegate* unmanaged[Cdecl]<nint, nint, nint, nint, void>)&Trampoline, callback)
{
    [UnmanagedCallersOnly(CallConvs = [typeof(CallConvCdecl)])]
    private static void Trampoline(nint block, nint mTLRenderPipelineState, nint mTLRenderPipelineReflection, nint nSError)
    {
        Action<nint, MTLRenderPipelineReflection, NSError> callback = GetContext<Action<nint, MTLRenderPipelineReflection, NSError>>(block);

        callback(mTLRenderPipelineState, new MTLRenderPipelineReflection(mTLRenderPipelineReflection, NativeObjectOwnership.Borrowed), new NSError(nSError, NativeObjectOwnership.Borrowed));
    }
}

public sealed unsafe class MTLSharedEventNotificationBlock(Action<nint, ulong> callback) : NativeBlock((nint)(delegate* unmanaged[Cdecl]<nint, nint, ulong, void>)&Trampoline, callback)
{
    [UnmanagedCallersOnly(CallConvs = [typeof(CallConvCdecl)])]
    private static void Trampoline(nint block, nint mTLSharedEvent, ulong value)
    {
        Action<nint, ulong> callback = GetContext<Action<nint, ulong>>(block);

        callback(mTLSharedEvent, value);
    }
}
