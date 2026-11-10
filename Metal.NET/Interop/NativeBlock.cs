using System.Runtime.InteropServices;

namespace Metal.NET;

/// <summary>
/// Base class for Objective-C block wrappers. Allocates a native block struct
/// on the unmanaged heap that conforms to the Objective-C block ABI.
/// </summary>
public abstract unsafe class NativeBlock : IDisposable
{
    private static readonly nint isa;
    private static readonly nint descriptor;

    static NativeBlock()
    {
        isa = NativeLibrary.GetExport(NativeLibrary.Load("/usr/lib/libobjc.A.dylib"), "_NSConcreteGlobalBlock");
        descriptor = (nint)NativeMemory.Alloc((uint)(sizeof(nuint) * 2));

        new nuint[] { 0, (nuint)sizeof(Block) }.CopyTo(new Span<nuint>((void*)descriptor, 2));
    }

    private GCHandle handle;
    private uint disposed;

    protected NativeBlock(nint invoke, object context)
    {
        NativePtr = AllocBlock(invoke, context, out handle);
    }

    ~NativeBlock()
    {
        Release();
    }

    public nint NativePtr { get; }

    public bool IsNull => NativePtr is 0;

    public void Dispose()
    {
        if (IsNull)
        {
            return;
        }

        Release();

        GC.SuppressFinalize(this);
    }

    private void Release()
    {
        if (Interlocked.Exchange(ref disposed, 1) is not 0)
        {
            return;
        }

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

/// <summary>
/// Native layout of an Objective-C block with an appended context field.
/// </summary>
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
