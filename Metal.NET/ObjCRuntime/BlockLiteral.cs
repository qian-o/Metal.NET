using System.Runtime.InteropServices;

namespace Metal.NET;

/// <summary>
/// Represents the Objective-C block ABI layout (Block_literal_1) with an additional
/// context field for storing a managed delegate reference.
/// </summary>
/// <remarks>
/// See: https://clang.llvm.org/docs/Block-ABI-Apple.html
/// The layout is: isa, flags, reserved, invoke, descriptor, [captured variables...].
/// We add a single captured variable (<see cref="Context"/>) after the descriptor pointer
/// to hold a <see cref="GCHandle"/> to the managed delegate.
/// </remarks>
[StructLayout(LayoutKind.Sequential)]
public unsafe struct BlockLiteral
{
    /// <summary>Pointer to the block's "isa" class (always _NSConcreteStackBlock for stack blocks).</summary>
    public nint Isa;

    /// <summary>Block flags.</summary>
    public int Flags;

    /// <summary>Reserved, must be zero.</summary>
    public int Reserved;

    /// <summary>Function pointer to the block's invoke function (the trampoline).</summary>
    public nint Invoke;

    /// <summary>Pointer to the block descriptor.</summary>
    public nint Descriptor;

    /// <summary>
    /// Context captured variable — stores a <see cref="GCHandle"/> (as <see cref="nint"/>)
    /// to the managed delegate. The unmanaged trampoline reads this to invoke the delegate.
    /// </summary>
    public nint Context;

    /// <summary>
    /// Creates a stack block that wraps a managed delegate via a trampoline function pointer.
    /// </summary>
    /// <param name="trampoline">
    /// An unmanaged function pointer whose first parameter is <c>BlockLiteral*</c>.
    /// Obtained via <c>(nint)(delegate* unmanaged[Cdecl]&lt;...&gt;)&amp;Method</c>.
    /// </param>
    /// <param name="contextHandle">
    /// A <see cref="GCHandle"/> (as <see cref="nint"/>) to the managed delegate.
    /// The trampoline will read this from <see cref="Context"/> to invoke the delegate.
    /// </param>
    /// <returns>A <see cref="BlockLiteral"/> that can be passed to <c>objc_msgSend</c>.</returns>
    public static BlockLiteral Create(nint trampoline, nint contextHandle)
    {
        return new BlockLiteral
        {
            Isa = BlockDescriptor.NSConcreteStackBlock,
            Flags = 0,
            Reserved = 0,
            Invoke = trampoline,
            Descriptor = (nint)BlockDescriptor.SharedDescriptor,
            Context = contextHandle
        };
    }
}

/// <summary>
/// Minimal block descriptor (Block_descriptor_1).
/// </summary>
[StructLayout(LayoutKind.Sequential)]
file unsafe struct BlockDescriptor
{
    public nuint Reserved;
    public nuint Size;

    /// <summary>
    /// Pointer to _NSConcreteStackBlock, loaded from libobjc at startup.
    /// </summary>
    public static readonly nint NSConcreteStackBlock = NativeLibrary.GetExport(
        NativeLibrary.Load("/usr/lib/libobjc.A.dylib"),
        "_NSConcreteStackBlock");

    private static readonly BlockDescriptor s_shared = new()
    {
        Reserved = 0,
        Size = (nuint)sizeof(BlockLiteral)
    };

    public static BlockDescriptor* SharedDescriptor
    {
        get
        {
            fixed (BlockDescriptor* p = &s_shared)
            {
                return p;
            }
        }
    }
}
