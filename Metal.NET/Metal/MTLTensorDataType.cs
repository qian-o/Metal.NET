namespace Metal.NET;

public enum MTLTensorDataType : long
{
    MTLTensorDataTypeNone = 0,
    MTLTensorDataTypeFloat32 = 3,
    MTLTensorDataTypeFloat16 = 16,
    MTLTensorDataTypeBFloat16 = 121,
    MTLTensorDataTypeInt8 = 45,
    MTLTensorDataTypeUInt8 = 49,
    MTLTensorDataTypeInt16 = 37,
    MTLTensorDataTypeUInt16 = 41,
    MTLTensorDataTypeInt32 = 29,
    MTLTensorDataTypeUInt32 = 33
}
