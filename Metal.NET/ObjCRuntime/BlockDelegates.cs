namespace Metal.NET;

/// <summary>
/// Delegate for <c>MTLCommandBuffer</c> completion and scheduling handlers.
/// </summary>
/// <param name="commandBuffer">The command buffer that completed or was scheduled.</param>
public delegate void MTLCommandBufferHandler(MTLCommandBuffer commandBuffer);

/// <summary>
/// Delegate for <c>MTLDrawable</c> presented handlers.
/// </summary>
/// <param name="drawable">The drawable that was presented.</param>
public delegate void MTLDrawablePresentedHandler(MTLDrawable drawable);

/// <summary>
/// Delegate for <c>MTLSharedEvent</c> notification blocks.
/// </summary>
/// <param name="sharedEvent">The shared event that triggered the notification.</param>
/// <param name="value">The signal value that triggered the notification.</param>
public delegate void MTLSharedEventNotificationBlock(MTLSharedEvent sharedEvent, ulong value);

/// <summary>
/// Delegate for <c>MTLIOCommandBuffer</c> completion handlers.
/// </summary>
/// <param name="commandBuffer">The IO command buffer that completed.</param>
public delegate void MTLIOCommandBufferHandler(MTLIOCommandBuffer commandBuffer);

/// <summary>
/// Delegate for async library creation completion.
/// </summary>
/// <param name="library">The newly created library, or null on failure.</param>
/// <param name="error">The error if library creation failed, or null on success.</param>
public delegate void MTLNewLibraryCompletionHandler(MTLLibrary? library, NSError? error);

/// <summary>
/// Delegate for async function creation completion.
/// </summary>
/// <param name="function">The newly created function, or null on failure.</param>
/// <param name="error">The error if function creation failed, or null on success.</param>
public delegate void MTLNewFunctionCompletionHandler(MTLFunction? function, NSError? error);

/// <summary>
/// Delegate for async render pipeline state creation completion.
/// </summary>
/// <param name="pipelineState">The newly created pipeline state, or null on failure.</param>
/// <param name="error">The error if creation failed, or null on success.</param>
public delegate void MTLNewRenderPipelineStateCompletionHandler(MTLRenderPipelineState? pipelineState, NSError? error);

/// <summary>
/// Delegate for async render pipeline state creation with reflection completion.
/// </summary>
/// <param name="pipelineState">The newly created pipeline state, or null on failure.</param>
/// <param name="reflection">Reflection data for the pipeline, or null on failure.</param>
/// <param name="error">The error if creation failed, or null on success.</param>
public delegate void MTLNewRenderPipelineStateWithReflectionCompletionHandler(MTLRenderPipelineState? pipelineState, MTLRenderPipelineReflection? reflection, NSError? error);

/// <summary>
/// Delegate for async compute pipeline state creation completion.
/// </summary>
/// <param name="pipelineState">The newly created pipeline state, or null on failure.</param>
/// <param name="error">The error if creation failed, or null on success.</param>
public delegate void MTLNewComputePipelineStateCompletionHandler(MTLComputePipelineState? pipelineState, NSError? error);

/// <summary>
/// Delegate for async compute pipeline state creation with reflection completion.
/// </summary>
/// <param name="pipelineState">The newly created pipeline state, or null on failure.</param>
/// <param name="reflection">Reflection data for the pipeline, or null on failure.</param>
/// <param name="error">The error if creation failed, or null on success.</param>
public delegate void MTLNewComputePipelineStateWithReflectionCompletionHandler(MTLComputePipelineState? pipelineState, MTLComputePipelineReflection? reflection, NSError? error);
