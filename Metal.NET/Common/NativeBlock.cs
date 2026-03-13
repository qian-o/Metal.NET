// Common/NativeBlock.cs
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace Metal.NET;

[StructLayout(LayoutKind.Sequential)]
internal struct BlockDescriptor
{
    public nuint Reserved;

    public nuint Size;
}

[StructLayout(LayoutKind.Sequential)]
internal unsafe struct BlockLiteral
{
    public nint Isa;

    public int Flags;

    public int Reserved;

    public nint Invoke;

    public BlockDescriptor* Descriptor;

    public nint Context;
}

public abstract unsafe partial class NativeBlock : NativeObject
{
    private static readonly nint isa;

    private static readonly unsafe BlockDescriptor* descriptor;

    static NativeBlock()
    {
        nint libobjc = NativeLibrary.Load("/usr/lib/libobjc.A.dylib");

        isa = NativeLibrary.GetExport(libobjc, "_NSConcreteGlobalBlock");

        descriptor = (BlockDescriptor*)NativeMemory.Alloc((nuint)sizeof(BlockDescriptor));
        descriptor->Reserved = 0;
        descriptor->Size = (nuint)sizeof(BlockLiteral);
    }

    private readonly GCHandle contextHandle;

    protected NativeBlock(nint invoke, object context) : base(AllocBlock(invoke, context, out GCHandle handle), NativeObjectOwnership.Managed)
    {
        contextHandle = handle;
    }

    protected override void ReleaseNative()
    {
        NativeMemory.Free((void*)NativePtr);

        if (contextHandle.IsAllocated)
        {
            contextHandle.Free();
        }
    }

    protected static T GetContext<T>(nint blockPtr) where T : class
    {
        BlockLiteral* block = (BlockLiteral*)blockPtr;
        GCHandle handle = GCHandle.FromIntPtr(block->Context);

        return (T)handle.Target!;
    }

    private static nint AllocBlock(nint invoke, object context, out GCHandle handle)
    {
        handle = GCHandle.Alloc(context);

        BlockLiteral* block = (BlockLiteral*)NativeMemory.AllocZeroed((nuint)sizeof(BlockLiteral));
        block->Isa = isa;
        block->Flags = 1 << 29; // BLOCK_IS_GLOBAL
        block->Invoke = invoke;
        block->Descriptor = descriptor;
        block->Context = GCHandle.ToIntPtr(handle);

        return (nint)block;
    }
}
