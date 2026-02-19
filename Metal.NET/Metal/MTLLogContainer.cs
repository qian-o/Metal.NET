namespace Metal.NET;

public readonly struct MTLLogContainer(nint nativePtr)
{
    public readonly nint NativePtr = nativePtr;
}

file static class MTLLogContainerBindings
{
}
