using System.Runtime.InteropServices;

namespace Metal.NET;

[StructLayout(LayoutKind.Sequential)]
internal struct BlockDescriptor
{
    public nuint Reserved;

    public nuint Size;
}

[StructLayout(LayoutKind.Sequential)]
internal unsafe struct Block
{
    public nint Isa;

    public int Flags;

    public int Reserved;

    public nint Invoke;

    public BlockDescriptor* Descriptor;

    public nint Context;
}

public abstract unsafe class NativeBlock : NativeObject
{
    private static readonly nint isa;
    private static readonly BlockDescriptor* descriptor;

    static NativeBlock()
    {
        isa = NativeLibrary.GetExport(NativeLibrary.Load("/usr/lib/libobjc.A.dylib"), "_NSConcreteGlobalBlock");

        descriptor = (BlockDescriptor*)NativeMemory.Alloc((nuint)sizeof(BlockDescriptor));
        descriptor->Reserved = 0;
        descriptor->Size = (nuint)sizeof(Block);
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
        block->Invoke = invoke;
        block->Descriptor = descriptor;
        block->Context = GCHandle.ToIntPtr(handle = GCHandle.Alloc(context));

        return (nint)block;
    }
}
