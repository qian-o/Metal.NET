namespace Metal.NET;

/// <summary>
/// Provides helper methods not expressible via the JSON definitions.
/// </summary>
public static class MTLDeviceHelper
{
    /// <summary>
    /// Creates the system default MTLDevice via MTLCreateSystemDefaultDevice().
    /// </summary>
    public static MTLDevice CreateSystemDefaultDevice()
        => new(MetalNative.MTLCreateSystemDefaultDevice());
}
