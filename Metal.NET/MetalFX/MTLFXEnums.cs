namespace Metal.NET;

/// <summary>
/// The color space modes for the input and output textures you use with a spatial scaling effect instance.
/// </summary>
public enum MTLFXSpatialScalerColorProcessingMode : long
{
    /// <summary>
    /// Indicates your input and output textures use a perceptual color space.
    /// </summary>
    Perceptual = 0,

    /// <summary>
    /// Indicates your input and output textures use a linear color space.
    /// </summary>
    Linear = 1,

    /// <summary>
    /// Indicates your input and output textures use a high dynamic range color space.
    /// </summary>
    HDR = 2
}
