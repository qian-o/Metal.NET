using System.Runtime.InteropServices;

namespace Metal.NET;

public partial class MTLDrawable(nint nativePtr, NativeObjectOwnership ownership) : NativeObject(nativePtr, ownership), INativeObject<MTLDrawable>
{
    public static MTLDrawable Null { get; } = new(0, NativeObjectOwnership.Borrowed);

    public static MTLDrawable Create(nint nativePtr, NativeObjectOwnership ownership) => new(nativePtr, ownership);

    public nuint DrawableID
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLDrawableBindings.DrawableID);
    }

    public double PresentedTime
    {
        get => ObjectiveCRuntime.MsgSendDouble(NativePtr, MTLDrawableBindings.PresentedTime);
    }

    public void Present()
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLDrawableBindings.Present);
    }

    public void PresentAfterMinimumDuration(double duration)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLDrawableBindings.PresentAfterMinimumDuration, duration);
    }

    public void PresentAtTime(double presentationTime)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLDrawableBindings.PresentAtTime, presentationTime);
    }


    public delegate void MTLDrawablePresentedHandler(MTLDrawable param0);

    public unsafe void AddPresentedHandler(MTLDrawablePresentedHandler handler)
    {
        GCHandle gch = GCHandle.Alloc(handler);
        BlockLiteral block = BlockLiteral.Create((nint)(delegate* unmanaged[Cdecl]<nint, nint, void>)&DrawablePresentedHandler_Trampoline, GCHandle.ToIntPtr(gch));

        ObjectiveCRuntime.MsgSend(NativePtr, MTLDrawableBindings.AddPresentedHandler, (nint)(&block));
    }

    [UnmanagedCallersOnly(CallConvs = [typeof(System.Runtime.CompilerServices.CallConvCdecl)])]
    private static unsafe void DrawablePresentedHandler_Trampoline(nint blockPtr, nint arg0)
    {
        BlockLiteral* block = (BlockLiteral*)blockPtr;
        GCHandle gch = GCHandle.FromIntPtr(block->Context);
        MTLDrawablePresentedHandler handler = (MTLDrawablePresentedHandler)gch.Target!;

        handler(new MTLDrawable(arg0, NativeObjectOwnership.Borrowed));

        gch.Free();
    }
}

file static class MTLDrawableBindings
{
    public static readonly Selector AddPresentedHandler = "addPresentedHandler:";

    public static readonly Selector DrawableID = "drawableID";

    public static readonly Selector Present = "present";

    public static readonly Selector PresentAfterMinimumDuration = "presentAfterMinimumDuration:";

    public static readonly Selector PresentAtTime = "presentAtTime:";

    public static readonly Selector PresentedTime = "presentedTime";
}
