using System.Runtime.InteropServices;

namespace Metal.NET;

public static partial class MTLFunctions
{
    [LibraryImport("/System/Library/Frameworks/Metal.framework/Metal", EntryPoint = "MTLCreateSystemDefaultDevice")]
    private static partial nint MTLCreateSystemDefaultDevice();

    public static MTLDevice? CreateSystemDefaultDevice()
    {
        nint ptr = MTLCreateSystemDefaultDevice();
        return ptr is not 0 ? new MTLDevice(ptr) : null;
    }

    [LibraryImport("/System/Library/Frameworks/Metal.framework/Metal", EntryPoint = "MTLCopyAllDevices")]
    private static partial nint MTLCopyAllDevices();

    public static NSArray? CopyAllDevices()
    {
        nint ptr = MTLCopyAllDevices();
        return ptr is not 0 ? new NSArray(ptr) : null;
    }
}
