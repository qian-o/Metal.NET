using System.Runtime.InteropServices;

namespace Metal.NET;

[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
public delegate void MTL4CommitFeedbackHandler(nint block, nint commitFeedback);

[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
public delegate void MTL4NewBinaryFunctionCompletionHandler(nint block, nint binaryFunction, nint error);

[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
public delegate void MTL4NewComputePipelineStateCompletionHandler(nint block, nint computePipelineState, nint error);

[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
public delegate void MTL4NewMachineLearningPipelineStateCompletionHandler(nint block, nint machineLearningPipelineState, nint error);

[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
public delegate void MTL4NewRenderPipelineStateCompletionHandler(nint block, nint renderPipelineState, nint error);

[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
public delegate void MTLCommandBufferHandler(nint block, nint commandBuffer);

[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
public delegate void MTLDeallocator(nint block, nint pointer, nuint length);

[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
public delegate void MTLDrawablePresentedHandler(nint block, nint drawable);

[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
public delegate void MTLIOCommandBufferHandler(nint block, nint iOCommandBuffer);

[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
public delegate void MTLLogHandler(nint block, nint subsystem, nint category, long logLevel, nint message);

[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
public delegate void MTLNewComputePipelineStateCompletionHandler(nint block, nint computePipelineState, nint error);

[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
public delegate void MTLNewComputePipelineStateWithReflectionCompletionHandler(nint block, nint computePipelineState, nint computePipelineReflection, nint error);

[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
public delegate void MTLNewDynamicLibraryCompletionHandler(nint block, nint dynamicLibrary, nint error);

[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
public delegate void MTLNewFunctionCompletionHandler(nint block, nint function, nint error);

[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
public delegate void MTLNewLibraryCompletionHandler(nint block, nint library, nint error);

[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
public delegate void MTLNewRenderPipelineStateCompletionHandler(nint block, nint renderPipelineState, nint error);

[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
public delegate void MTLNewRenderPipelineStateWithReflectionCompletionHandler(nint block, nint renderPipelineState, nint renderPipelineReflection, nint error);

[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
public delegate void MTLSharedEventNotificationBlock(nint block, nint @event, ulong value);
