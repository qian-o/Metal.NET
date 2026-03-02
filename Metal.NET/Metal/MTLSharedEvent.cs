using System.Runtime.InteropServices;

namespace Metal.NET;

public partial class MTLSharedEvent(nint nativePtr, NativeObjectOwnership ownership) : MTLEvent(nativePtr, ownership), INativeObject<MTLSharedEvent>
{
    public static new MTLSharedEvent Null { get; } = new(0, NativeObjectOwnership.Borrowed);

    public static new MTLSharedEvent Create(nint nativePtr, NativeObjectOwnership ownership) => new(nativePtr, ownership);

    public ulong SignaledValue
    {
        get => ObjectiveCRuntime.MsgSendULong(NativePtr, MTLSharedEventBindings.SignaledValue);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLSharedEventBindings.SetSignaledValue, value);
    }

    public MTLSharedEventHandle NewSharedEventHandle()
    {
        nint nativePtr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLSharedEventBindings.NewSharedEventHandle);

        return new(nativePtr, NativeObjectOwnership.Owned);
    }

    public bool WaitUntilSignaledValue(ulong value, ulong milliseconds)
    {
        return ObjectiveCRuntime.MsgSendBool(NativePtr, MTLSharedEventBindings.WaitUntilSignaledValue, (nuint)value, (nuint)milliseconds);
    }


    public delegate void MTLSharedEventNotificationBlock(MTLSharedEvent pEvent, ulong value);

    public unsafe void NotifyListener(MTLSharedEventListener listener, ulong value, MTLSharedEventNotificationBlock handler)
    {
        GCHandle gch = GCHandle.Alloc(handler);
        BlockLiteral block = BlockLiteral.Create((nint)(delegate* unmanaged[Cdecl]<nint, nint, ulong, void>)&SharedEventNotificationBlock_Trampoline, GCHandle.ToIntPtr(gch));

        ObjectiveCRuntime.MsgSend(NativePtr, MTLSharedEventBindings.NotifyListeneratValueblock, listener.NativePtr, value, (nint)(&block));
    }

    [UnmanagedCallersOnly(CallConvs = [typeof(System.Runtime.CompilerServices.CallConvCdecl)])]
    private static unsafe void SharedEventNotificationBlock_Trampoline(nint blockPtr, nint arg0, ulong arg1)
    {
        BlockLiteral* block = (BlockLiteral*)blockPtr;
        GCHandle gch = GCHandle.FromIntPtr(block->Context);
        MTLSharedEventNotificationBlock handler = (MTLSharedEventNotificationBlock)gch.Target!;

        handler(new MTLSharedEvent(arg0, NativeObjectOwnership.Borrowed), arg1);

        gch.Free();
    }
}

file static class MTLSharedEventBindings
{
    public static readonly Selector NewSharedEventHandle = "newSharedEventHandle";

    public static readonly Selector NotifyListeneratValueblock = "notifyListener:atValue:block:";

    public static readonly Selector SetSignaledValue = "setSignaledValue:";

    public static readonly Selector SignaledValue = "signaledValue";

    public static readonly Selector WaitUntilSignaledValue = "waitUntilSignaledValue:timeoutMS:";
}
