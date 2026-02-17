#pragma once
namespace simd {
    struct float4x4 { float columns[4][4]; };
    struct float4 { float x, y, z, w; };
    struct float3 { float x, y, z; };
    struct float2 { float x, y; };
}
typedef simd::float4x4 simd_float4x4;
typedef simd::float4 simd_float4;
