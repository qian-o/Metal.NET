using System.Runtime.InteropServices;

namespace Metal.NET;

public partial class MTL4Compiler(nint nativePtr, NativeObjectOwnership ownership) : NativeObject(nativePtr, ownership), INativeObject<MTL4Compiler>
{
    public static MTL4Compiler Null { get; } = new(0, NativeObjectOwnership.Borrowed);

    public static MTL4Compiler Create(nint nativePtr, NativeObjectOwnership ownership) => new(nativePtr, ownership);

    public MTLDevice Device
    {
        get => GetProperty(ref field, MTL4CompilerBindings.Device);
    }

    public NSString Label
    {
        get => GetProperty(ref field, MTL4CompilerBindings.Label);
    }

    public MTL4PipelineDataSetSerializer PipelineDataSetSerializer
    {
        get => GetProperty(ref field, MTL4CompilerBindings.PipelineDataSetSerializer);
    }

    public MTL4BinaryFunction NewBinaryFunction(MTL4BinaryFunctionDescriptor descriptor, MTL4CompilerTaskOptions compilerTaskOptions, out NSError error)
    {
        nint nativePtr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTL4CompilerBindings.NewBinaryFunction, descriptor.NativePtr, compilerTaskOptions.NativePtr, out nint errorPtr);

        error = new(errorPtr, NativeObjectOwnership.Owned);

        return new(nativePtr, NativeObjectOwnership.Owned);
    }

    public MTLComputePipelineState NewComputePipelineState(MTL4ComputePipelineDescriptor descriptor, MTL4CompilerTaskOptions compilerTaskOptions, out NSError error)
    {
        nint nativePtr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTL4CompilerBindings.NewComputePipelineState, descriptor.NativePtr, compilerTaskOptions.NativePtr, out nint errorPtr);

        error = new(errorPtr, NativeObjectOwnership.Owned);

        return new(nativePtr, NativeObjectOwnership.Owned);
    }

    public MTLComputePipelineState NewComputePipelineState(MTL4ComputePipelineDescriptor descriptor, MTL4PipelineStageDynamicLinkingDescriptor dynamicLinkingDescriptor, MTL4CompilerTaskOptions compilerTaskOptions, out NSError error)
    {
        nint nativePtr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTL4CompilerBindings.NewComputePipelineStateWithDescriptordynamicLinkingDescriptorcompilerTaskOptionserror, descriptor.NativePtr, dynamicLinkingDescriptor.NativePtr, compilerTaskOptions.NativePtr, out nint errorPtr);

        error = new(errorPtr, NativeObjectOwnership.Owned);

        return new(nativePtr, NativeObjectOwnership.Owned);
    }

    public MTLDynamicLibrary NewDynamicLibrary(MTLLibrary library, out NSError error)
    {
        nint nativePtr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTL4CompilerBindings.NewDynamicLibrary, library.NativePtr, out nint errorPtr);

        error = new(errorPtr, NativeObjectOwnership.Owned);

        return new(nativePtr, NativeObjectOwnership.Owned);
    }

    public MTLDynamicLibrary NewDynamicLibrary(NSURL url, out NSError error)
    {
        nint nativePtr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTL4CompilerBindings.NewDynamicLibraryWithURLerror, url.NativePtr, out nint errorPtr);

        error = new(errorPtr, NativeObjectOwnership.Owned);

        return new(nativePtr, NativeObjectOwnership.Owned);
    }

    public MTLLibrary NewLibrary(MTL4LibraryDescriptor descriptor, out NSError error)
    {
        nint nativePtr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTL4CompilerBindings.NewLibrary, descriptor.NativePtr, out nint errorPtr);

        error = new(errorPtr, NativeObjectOwnership.Owned);

        return new(nativePtr, NativeObjectOwnership.Owned);
    }

    public MTL4MachineLearningPipelineState NewMachineLearningPipelineState(MTL4MachineLearningPipelineDescriptor descriptor, out NSError error)
    {
        nint nativePtr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTL4CompilerBindings.NewMachineLearningPipelineState, descriptor.NativePtr, out nint errorPtr);

        error = new(errorPtr, NativeObjectOwnership.Owned);

        return new(nativePtr, NativeObjectOwnership.Owned);
    }

    public MTLRenderPipelineState NewRenderPipelineState(MTL4PipelineDescriptor descriptor, MTL4CompilerTaskOptions compilerTaskOptions, out NSError error)
    {
        nint nativePtr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTL4CompilerBindings.NewRenderPipelineState, descriptor.NativePtr, compilerTaskOptions.NativePtr, out nint errorPtr);

        error = new(errorPtr, NativeObjectOwnership.Owned);

        return new(nativePtr, NativeObjectOwnership.Owned);
    }

    public MTLRenderPipelineState NewRenderPipelineState(MTL4PipelineDescriptor descriptor, MTL4RenderPipelineDynamicLinkingDescriptor dynamicLinkingDescriptor, MTL4CompilerTaskOptions compilerTaskOptions, out NSError error)
    {
        nint nativePtr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTL4CompilerBindings.NewRenderPipelineStateWithDescriptordynamicLinkingDescriptorcompilerTaskOptionserror, descriptor.NativePtr, dynamicLinkingDescriptor.NativePtr, compilerTaskOptions.NativePtr, out nint errorPtr);

        error = new(errorPtr, NativeObjectOwnership.Owned);

        return new(nativePtr, NativeObjectOwnership.Owned);
    }

    public MTLRenderPipelineState NewRenderPipelineStateBySpecialization(MTL4PipelineDescriptor descriptor, MTLRenderPipelineState pipeline, out NSError error)
    {
        nint nativePtr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTL4CompilerBindings.NewRenderPipelineStateBySpecialization, descriptor.NativePtr, pipeline.NativePtr, out nint errorPtr);

        error = new(errorPtr, NativeObjectOwnership.Owned);

        return new(nativePtr, NativeObjectOwnership.Owned);
    }


    public delegate void MTL4NewBinaryFunctionCompletionHandler(MTL4BinaryFunction binaryFunction, NSError error);

    public unsafe void NewBinaryFunction(MTL4BinaryFunctionDescriptor descriptor, MTL4CompilerTaskOptions compilerTaskOptions, MTL4NewBinaryFunctionCompletionHandler handler)
    {
        GCHandle gch = GCHandle.Alloc(handler);
        BlockLiteral block = BlockLiteral.Create((nint)(delegate* unmanaged[Cdecl]<nint, nint, nint, void>)&NewBinaryFunctionCompletionHandler_Trampoline, GCHandle.ToIntPtr(gch));

        ObjectiveCRuntime.MsgSend(NativePtr, MTL4CompilerBindings.NewBinaryFunctionWithDescriptorcompilerTaskOptionscompletionHandler, descriptor.NativePtr, compilerTaskOptions.NativePtr, (nint)(&block));
    }

    [UnmanagedCallersOnly(CallConvs = [typeof(System.Runtime.CompilerServices.CallConvCdecl)])]
    private static unsafe void NewBinaryFunctionCompletionHandler_Trampoline(nint blockPtr, nint arg0, nint arg1)
    {
        BlockLiteral* block = (BlockLiteral*)blockPtr;
        GCHandle gch = GCHandle.FromIntPtr(block->Context);
        MTL4NewBinaryFunctionCompletionHandler handler = (MTL4NewBinaryFunctionCompletionHandler)gch.Target!;

        handler(new MTL4BinaryFunction(arg0, NativeObjectOwnership.Borrowed), new NSError(arg1, NativeObjectOwnership.Borrowed));

        gch.Free();
    }


    public delegate void MTLNewComputePipelineStateCompletionHandler(MTLComputePipelineState computePipelineState, NSError error);

    public unsafe void NewComputePipelineState(MTL4ComputePipelineDescriptor descriptor, MTL4CompilerTaskOptions compilerTaskOptions, MTLNewComputePipelineStateCompletionHandler handler)
    {
        GCHandle gch = GCHandle.Alloc(handler);
        BlockLiteral block = BlockLiteral.Create((nint)(delegate* unmanaged[Cdecl]<nint, nint, nint, void>)&NewComputePipelineStateCompletionHandler_Trampoline, GCHandle.ToIntPtr(gch));

        ObjectiveCRuntime.MsgSend(NativePtr, MTL4CompilerBindings.NewComputePipelineStateWithDescriptorcompilerTaskOptionscompletionHandler, descriptor.NativePtr, compilerTaskOptions.NativePtr, (nint)(&block));
    }

    [UnmanagedCallersOnly(CallConvs = [typeof(System.Runtime.CompilerServices.CallConvCdecl)])]
    private static unsafe void NewComputePipelineStateCompletionHandler_Trampoline(nint blockPtr, nint arg0, nint arg1)
    {
        BlockLiteral* block = (BlockLiteral*)blockPtr;
        GCHandle gch = GCHandle.FromIntPtr(block->Context);
        MTLNewComputePipelineStateCompletionHandler handler = (MTLNewComputePipelineStateCompletionHandler)gch.Target!;

        handler(new MTLComputePipelineState(arg0, NativeObjectOwnership.Borrowed), new NSError(arg1, NativeObjectOwnership.Borrowed));

        gch.Free();
    }


    public unsafe void NewComputePipelineState(MTL4ComputePipelineDescriptor descriptor, MTL4PipelineStageDynamicLinkingDescriptor dynamicLinkingDescriptor, MTL4CompilerTaskOptions compilerTaskOptions, MTLNewComputePipelineStateCompletionHandler handler)
    {
        GCHandle gch = GCHandle.Alloc(handler);
        BlockLiteral block = BlockLiteral.Create((nint)(delegate* unmanaged[Cdecl]<nint, nint, nint, void>)&NewComputePipelineStateCompletionHandler_Trampoline, GCHandle.ToIntPtr(gch));

        ObjectiveCRuntime.MsgSend(NativePtr, MTL4CompilerBindings.NewComputePipelineStateWithDescriptordynamicLinkingDescriptorcompilerTaskOptionscompletionHandler, descriptor.NativePtr, dynamicLinkingDescriptor.NativePtr, compilerTaskOptions.NativePtr, (nint)(&block));
    }


    public delegate void MTLNewDynamicLibraryCompletionHandler(MTLDynamicLibrary dynamicLibrary, NSError error);

    public unsafe void NewDynamicLibrary(MTLLibrary library, MTLNewDynamicLibraryCompletionHandler handler)
    {
        GCHandle gch = GCHandle.Alloc(handler);
        BlockLiteral block = BlockLiteral.Create((nint)(delegate* unmanaged[Cdecl]<nint, nint, nint, void>)&NewDynamicLibraryCompletionHandler_Trampoline, GCHandle.ToIntPtr(gch));

        ObjectiveCRuntime.MsgSend(NativePtr, MTL4CompilerBindings.NewDynamicLibrarycompletionHandler, library.NativePtr, (nint)(&block));
    }

    [UnmanagedCallersOnly(CallConvs = [typeof(System.Runtime.CompilerServices.CallConvCdecl)])]
    private static unsafe void NewDynamicLibraryCompletionHandler_Trampoline(nint blockPtr, nint arg0, nint arg1)
    {
        BlockLiteral* block = (BlockLiteral*)blockPtr;
        GCHandle gch = GCHandle.FromIntPtr(block->Context);
        MTLNewDynamicLibraryCompletionHandler handler = (MTLNewDynamicLibraryCompletionHandler)gch.Target!;

        handler(new MTLDynamicLibrary(arg0, NativeObjectOwnership.Borrowed), new NSError(arg1, NativeObjectOwnership.Borrowed));

        gch.Free();
    }


    public unsafe void NewDynamicLibrary(NSURL url, MTLNewDynamicLibraryCompletionHandler handler)
    {
        GCHandle gch = GCHandle.Alloc(handler);
        BlockLiteral block = BlockLiteral.Create((nint)(delegate* unmanaged[Cdecl]<nint, nint, nint, void>)&NewDynamicLibraryCompletionHandler_Trampoline, GCHandle.ToIntPtr(gch));

        ObjectiveCRuntime.MsgSend(NativePtr, MTL4CompilerBindings.NewDynamicLibraryWithURLcompletionHandler, url.NativePtr, (nint)(&block));
    }


    public delegate void MTLNewLibraryCompletionHandler(MTLLibrary library, NSError error);

    public unsafe void NewLibrary(MTL4LibraryDescriptor descriptor, MTLNewLibraryCompletionHandler handler)
    {
        GCHandle gch = GCHandle.Alloc(handler);
        BlockLiteral block = BlockLiteral.Create((nint)(delegate* unmanaged[Cdecl]<nint, nint, nint, void>)&NewLibraryCompletionHandler_Trampoline, GCHandle.ToIntPtr(gch));

        ObjectiveCRuntime.MsgSend(NativePtr, MTL4CompilerBindings.NewLibraryWithDescriptorcompletionHandler, descriptor.NativePtr, (nint)(&block));
    }

    [UnmanagedCallersOnly(CallConvs = [typeof(System.Runtime.CompilerServices.CallConvCdecl)])]
    private static unsafe void NewLibraryCompletionHandler_Trampoline(nint blockPtr, nint arg0, nint arg1)
    {
        BlockLiteral* block = (BlockLiteral*)blockPtr;
        GCHandle gch = GCHandle.FromIntPtr(block->Context);
        MTLNewLibraryCompletionHandler handler = (MTLNewLibraryCompletionHandler)gch.Target!;

        handler(new MTLLibrary(arg0, NativeObjectOwnership.Borrowed), new NSError(arg1, NativeObjectOwnership.Borrowed));

        gch.Free();
    }


    public delegate void MTL4NewMachineLearningPipelineStateCompletionHandler(MTL4MachineLearningPipelineState machineLearningPipelineState, NSError error);

    public unsafe void NewMachineLearningPipelineState(MTL4MachineLearningPipelineDescriptor descriptor, MTL4NewMachineLearningPipelineStateCompletionHandler handler)
    {
        GCHandle gch = GCHandle.Alloc(handler);
        BlockLiteral block = BlockLiteral.Create((nint)(delegate* unmanaged[Cdecl]<nint, nint, nint, void>)&NewMachineLearningPipelineStateCompletionHandler_Trampoline, GCHandle.ToIntPtr(gch));

        ObjectiveCRuntime.MsgSend(NativePtr, MTL4CompilerBindings.NewMachineLearningPipelineStateWithDescriptorcompletionHandler, descriptor.NativePtr, (nint)(&block));
    }

    [UnmanagedCallersOnly(CallConvs = [typeof(System.Runtime.CompilerServices.CallConvCdecl)])]
    private static unsafe void NewMachineLearningPipelineStateCompletionHandler_Trampoline(nint blockPtr, nint arg0, nint arg1)
    {
        BlockLiteral* block = (BlockLiteral*)blockPtr;
        GCHandle gch = GCHandle.FromIntPtr(block->Context);
        MTL4NewMachineLearningPipelineStateCompletionHandler handler = (MTL4NewMachineLearningPipelineStateCompletionHandler)gch.Target!;

        handler(new MTL4MachineLearningPipelineState(arg0, NativeObjectOwnership.Borrowed), new NSError(arg1, NativeObjectOwnership.Borrowed));

        gch.Free();
    }


    public delegate void MTLNewRenderPipelineStateCompletionHandler(MTLRenderPipelineState renderPipelineState, NSError error);

    public unsafe void NewRenderPipelineState(MTL4PipelineDescriptor descriptor, MTL4CompilerTaskOptions compilerTaskOptions, MTLNewRenderPipelineStateCompletionHandler handler)
    {
        GCHandle gch = GCHandle.Alloc(handler);
        BlockLiteral block = BlockLiteral.Create((nint)(delegate* unmanaged[Cdecl]<nint, nint, nint, void>)&NewRenderPipelineStateCompletionHandler_Trampoline, GCHandle.ToIntPtr(gch));

        ObjectiveCRuntime.MsgSend(NativePtr, MTL4CompilerBindings.NewRenderPipelineStateWithDescriptorcompilerTaskOptionscompletionHandler, descriptor.NativePtr, compilerTaskOptions.NativePtr, (nint)(&block));
    }

    [UnmanagedCallersOnly(CallConvs = [typeof(System.Runtime.CompilerServices.CallConvCdecl)])]
    private static unsafe void NewRenderPipelineStateCompletionHandler_Trampoline(nint blockPtr, nint arg0, nint arg1)
    {
        BlockLiteral* block = (BlockLiteral*)blockPtr;
        GCHandle gch = GCHandle.FromIntPtr(block->Context);
        MTLNewRenderPipelineStateCompletionHandler handler = (MTLNewRenderPipelineStateCompletionHandler)gch.Target!;

        handler(new MTLRenderPipelineState(arg0, NativeObjectOwnership.Borrowed), new NSError(arg1, NativeObjectOwnership.Borrowed));

        gch.Free();
    }


    public unsafe void NewRenderPipelineState(MTL4PipelineDescriptor descriptor, MTL4RenderPipelineDynamicLinkingDescriptor dynamicLinkingDescriptor, MTL4CompilerTaskOptions compilerTaskOptions, MTLNewRenderPipelineStateCompletionHandler handler)
    {
        GCHandle gch = GCHandle.Alloc(handler);
        BlockLiteral block = BlockLiteral.Create((nint)(delegate* unmanaged[Cdecl]<nint, nint, nint, void>)&NewRenderPipelineStateCompletionHandler_Trampoline, GCHandle.ToIntPtr(gch));

        ObjectiveCRuntime.MsgSend(NativePtr, MTL4CompilerBindings.NewRenderPipelineStateWithDescriptordynamicLinkingDescriptorcompilerTaskOptionscompletionHandler, descriptor.NativePtr, dynamicLinkingDescriptor.NativePtr, compilerTaskOptions.NativePtr, (nint)(&block));
    }


    public unsafe void NewRenderPipelineStateBySpecialization(MTL4PipelineDescriptor descriptor, MTLRenderPipelineState pipeline, MTLNewRenderPipelineStateCompletionHandler handler)
    {
        GCHandle gch = GCHandle.Alloc(handler);
        BlockLiteral block = BlockLiteral.Create((nint)(delegate* unmanaged[Cdecl]<nint, nint, nint, void>)&NewRenderPipelineStateCompletionHandler_Trampoline, GCHandle.ToIntPtr(gch));

        ObjectiveCRuntime.MsgSend(NativePtr, MTL4CompilerBindings.NewRenderPipelineStateBySpecializationWithDescriptorpipelinecompletionHandler, descriptor.NativePtr, pipeline.NativePtr, (nint)(&block));
    }
}

file static class MTL4CompilerBindings
{
    public static readonly Selector Device = "device";

    public static readonly Selector Label = "label";

    public static readonly Selector NewBinaryFunction = "newBinaryFunctionWithDescriptor:compilerTaskOptions:error:";

    public static readonly Selector NewBinaryFunctionWithDescriptorcompilerTaskOptionscompletionHandler = "newBinaryFunctionWithDescriptor:compilerTaskOptions:completionHandler:";

    public static readonly Selector NewComputePipelineState = "newComputePipelineStateWithDescriptor:compilerTaskOptions:error:";

    public static readonly Selector NewComputePipelineStateWithDescriptorcompilerTaskOptionscompletionHandler = "newComputePipelineStateWithDescriptor:compilerTaskOptions:completionHandler:";

    public static readonly Selector NewComputePipelineStateWithDescriptordynamicLinkingDescriptorcompilerTaskOptionscompletionHandler = "newComputePipelineStateWithDescriptor:dynamicLinkingDescriptor:compilerTaskOptions:completionHandler:";

    public static readonly Selector NewComputePipelineStateWithDescriptordynamicLinkingDescriptorcompilerTaskOptionserror = "newComputePipelineStateWithDescriptor:dynamicLinkingDescriptor:compilerTaskOptions:error:";

    public static readonly Selector NewDynamicLibrary = "newDynamicLibrary:error:";

    public static readonly Selector NewDynamicLibrarycompletionHandler = "newDynamicLibrary:completionHandler:";

    public static readonly Selector NewDynamicLibraryWithURLcompletionHandler = "newDynamicLibraryWithURL:completionHandler:";

    public static readonly Selector NewDynamicLibraryWithURLerror = "newDynamicLibraryWithURL:error:";

    public static readonly Selector NewLibrary = "newLibraryWithDescriptor:error:";

    public static readonly Selector NewLibraryWithDescriptorcompletionHandler = "newLibraryWithDescriptor:completionHandler:";

    public static readonly Selector NewMachineLearningPipelineState = "newMachineLearningPipelineStateWithDescriptor:error:";

    public static readonly Selector NewMachineLearningPipelineStateWithDescriptorcompletionHandler = "newMachineLearningPipelineStateWithDescriptor:completionHandler:";

    public static readonly Selector NewRenderPipelineState = "newRenderPipelineStateWithDescriptor:compilerTaskOptions:error:";

    public static readonly Selector NewRenderPipelineStateBySpecialization = "newRenderPipelineStateBySpecializationWithDescriptor:pipeline:error:";

    public static readonly Selector NewRenderPipelineStateBySpecializationWithDescriptorpipelinecompletionHandler = "newRenderPipelineStateBySpecializationWithDescriptor:pipeline:completionHandler:";

    public static readonly Selector NewRenderPipelineStateWithDescriptorcompilerTaskOptionscompletionHandler = "newRenderPipelineStateWithDescriptor:compilerTaskOptions:completionHandler:";

    public static readonly Selector NewRenderPipelineStateWithDescriptordynamicLinkingDescriptorcompilerTaskOptionscompletionHandler = "newRenderPipelineStateWithDescriptor:dynamicLinkingDescriptor:compilerTaskOptions:completionHandler:";

    public static readonly Selector NewRenderPipelineStateWithDescriptordynamicLinkingDescriptorcompilerTaskOptionserror = "newRenderPipelineStateWithDescriptor:dynamicLinkingDescriptor:compilerTaskOptions:error:";

    public static readonly Selector PipelineDataSetSerializer = "pipelineDataSetSerializer";
}
