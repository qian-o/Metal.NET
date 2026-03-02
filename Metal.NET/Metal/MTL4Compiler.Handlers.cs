using System.Runtime.InteropServices;

namespace Metal.NET;

public partial class MTL4Compiler
{
    /// <summary>
    /// Asynchronously compiles a library.
    /// </summary>
    /// <param name="source">The Metal shading language source code.</param>
    /// <param name="completionHandler">The handler called when compilation completes.</param>
    public unsafe void CompileLibrary(NSString source, MTLNewLibraryCompletionHandler completionHandler)
    {
        GCHandle gch = GCHandle.Alloc(completionHandler);
        BlockLiteral block = BlockLiteral.Create((nint)(delegate* unmanaged[Cdecl]<nint, nint, nint, void>)&CompileLibraryTrampoline, GCHandle.ToIntPtr(gch));

        ObjectiveCRuntime.MsgSend(NativePtr, MTL4CompilerHandlerBindings.CompileLibrary, source.NativePtr, (nint)(&block));
    }

    [UnmanagedCallersOnly(CallConvs = [typeof(System.Runtime.CompilerServices.CallConvCdecl)])]
    private static void CompileLibraryTrampoline(nint blockPtr, nint libraryPtr, nint errorPtr)
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
}

file static class MTL4CompilerHandlerBindings
{
    public static readonly Selector CompileLibrary = "compileLibraryWithSource:completionHandler:";
}
