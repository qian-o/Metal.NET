using System.Runtime.InteropServices;

namespace Metal.NET;

public partial class MTLLogState(nint nativePtr, NativeObjectOwnership ownership) : NativeObject(nativePtr, ownership), INativeObject<MTLLogState>
{
    public static MTLLogState Null { get; } = new(0, NativeObjectOwnership.Borrowed);

    public static MTLLogState Create(nint nativePtr, NativeObjectOwnership ownership) => new(nativePtr, ownership);


    public delegate void MTL__InlineBlock_block(NSString param0, NSString param1, MTLLogLevel param2, NSString param3);

    public unsafe void AddLogHandler(MTL__InlineBlock_block handler)
    {
        GCHandle gch = GCHandle.Alloc(handler);
        BlockLiteral block = BlockLiteral.Create((nint)(delegate* unmanaged[Cdecl]<nint, nint, nint, MTLLogLevel, nint, void>)&__InlineBlock_block_Trampoline, GCHandle.ToIntPtr(gch));

        ObjectiveCRuntime.MsgSend(NativePtr, MTLLogStateBindings.AddLogHandler, (nint)(&block));
    }

    [UnmanagedCallersOnly(CallConvs = [typeof(System.Runtime.CompilerServices.CallConvCdecl)])]
    private static unsafe void __InlineBlock_block_Trampoline(nint blockPtr, nint arg0, nint arg1, MTLLogLevel arg2, nint arg3)
    {
        BlockLiteral* block = (BlockLiteral*)blockPtr;
        GCHandle gch = GCHandle.FromIntPtr(block->Context);
        MTL__InlineBlock_block handler = (MTL__InlineBlock_block)gch.Target!;

        handler(new NSString(arg0, NativeObjectOwnership.Borrowed), new NSString(arg1, NativeObjectOwnership.Borrowed), arg2, new NSString(arg3, NativeObjectOwnership.Borrowed));

        gch.Free();
    }
}

file static class MTLLogStateBindings
{
    public static readonly Selector AddLogHandler = "addLogHandler:";
}
