namespace Metal.NET;

public readonly struct MTLLogState(nint nativePtr)
{
    public readonly nint NativePtr = nativePtr;
}

file static class MTLLogStateBindings
{
}
