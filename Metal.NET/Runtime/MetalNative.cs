using System.Runtime.InteropServices;

namespace Metal.NET;

/// <summary>
/// Native Metal framework entry points.
/// </summary>
internal static partial class MetalNative
{
    [DllImport("/System/Library/Frameworks/Metal.framework/Metal")]
    internal static extern IntPtr MTLCreateSystemDefaultDevice();
}
