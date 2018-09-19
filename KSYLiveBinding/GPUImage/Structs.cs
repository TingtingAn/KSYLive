using System;
using System.Runtime.InteropServices;

namespace GPUImage
{
	[StructLayout (LayoutKind.Sequential)]
public struct GPUTextureOptions
{
    public uint minFilter;

    public uint magFilter;

    public uint wrapS;

    public uint wrapT;

    public uint internalFormat;

    public uint format;

    public uint type;
}

public enum GPUImageRotationMode : uint
{
    NoRotation,
    RotateLeft,
    RotateRight,
    FlipVertical,
    FlipHorizonal,
    RotateRightFlipVertical,
    RotateRightFlipHorizontal,
    Rotate180
}


public enum GPUImageFillModeType : uint
{
    Stretch,
    PreserveAspectRatio,
    PreserveAspectRatioAndFill
}

public enum GPUPixelFormat : uint
{
    Bgra = 32993,
    Rgba = 6408,
    Rgb = 6407,
    Luminance = 6409
}

public enum GPUPixelType : uint
{
    UByte = 5121,
    Float = 5126
}

[StructLayout (LayoutKind.Sequential)]
public struct GPUByteColorVector
{
    public byte red;

    public byte green;

    public byte blue;

    public byte alpha;
}

[StructLayout (LayoutKind.Sequential)]
public struct GPUVector4
{
    public float one;

    public float two;

    public float three;

    public float four;
}

[StructLayout (LayoutKind.Sequential)]
public struct GPUVector3
{
    public float one;

    public float two;

    public float three;
}

[StructLayout (LayoutKind.Sequential)]
public struct GPUMatrix4x4
{
    public GPUVector4 one;

    public GPUVector4 two;

    public GPUVector4 three;

    public GPUVector4 four;
}

[StructLayout (LayoutKind.Sequential)]
public struct GPUMatrix3x3
{
    public GPUVector3 one;

    public GPUVector3 two;

    public GPUVector3 three;
}

public enum GPUImageHistogramType : uint
{
    Red,
    Green,
    Blue,
    Rgb,
    Luminance
}

public enum GPUImageFASTDetectorType : uint
{
    kGPUImageFAST12Contiguous,
    NonMaximumSuppressed
}

}
