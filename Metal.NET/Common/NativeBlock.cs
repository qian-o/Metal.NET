using System.Runtime.InteropServices;

namespace Metal.NET;

public abstract unsafe class NativeBlock : NativeObject
{
    private static readonly nint isa;
    private static readonly nint descriptor;

    static NativeBlock()
    {
        isa = NativeLibrary.GetExport(NativeLibrary.Load("/usr/lib/libobjc.A.dylib"), "_NSConcreteGlobalBlock");
        descriptor = (nint)NativeMemory.Alloc((uint)(sizeof(nuint) * 2));

        new nuint[] { 0, (nuint)sizeof(Block) }.CopyTo(new Span<nuint>((void*)descriptor, 2));
    }

    private readonly GCHandle handle;

    protected NativeBlock(nint invoke, object context) : base(AllocBlock(invoke, context, out GCHandle handle), NativeObjectOwnership.Managed)
    {
        this.handle = handle;
    }

    protected override void ReleaseNative()
    {
        NativeMemory.Free((void*)NativePtr);

        handle.Free();
    }

    protected static T GetContext<T>(nint block) where T : class
    {
        return (T)GCHandle.FromIntPtr(((Block*)block)->Context).Target!;
    }

    private static nint AllocBlock(nint invoke, object context, out GCHandle handle)
    {
        Block* block = (Block*)NativeMemory.Alloc((nuint)sizeof(Block));
        block->Isa = isa;
        block->Flags = 1 << 29;
        block->Reserved = 0;
        block->Invoke = invoke;
        block->Descriptor = descriptor;
        block->Context = GCHandle.ToIntPtr(handle = GCHandle.Alloc(context));

        return (nint)block;
    }
}

[StructLayout(LayoutKind.Sequential)]
file struct Block
{
    public nint Isa;

    public int Flags;

    public int Reserved;

    public nint Invoke;

    public nint Descriptor;

    public nint Context;
}
