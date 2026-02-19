namespace Metal.NET;

public class MTLHeap(nint nativePtr) : NativeObject(nativePtr)
{
    public MTLCPUCacheMode CpuCacheMode
    {
        get => (MTLCPUCacheMode)ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLHeapBindings.CpuCacheMode);
    }

    public nuint CurrentAllocatedSize
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLHeapBindings.CurrentAllocatedSize);
    }

    public MTLDevice? Device
    {
        get
        {
            nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLHeapBindings.Device);

            if (ptr == 0)
            {
                return field = null;
            }

            if (field is null || field.NativePtr != ptr)
            {
                field = new MTLDevice(ptr);
            }

            return field;
        }
    }

    public MTLHazardTrackingMode HazardTrackingMode
    {
        get => (MTLHazardTrackingMode)ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLHeapBindings.HazardTrackingMode);
    }

    public NSString? Label
    {
        get
        {
            nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLHeapBindings.Label);

            if (ptr == 0)
            {
                return field = null;
            }

            if (field is null || field.NativePtr != ptr)
            {
                field = new NSString(ptr);
            }

            return field;
        }
        set
        {
            ObjectiveCRuntime.MsgSend(NativePtr, MTLHeapBindings.SetLabel, value?.NativePtr ?? 0);
            field = value;
        }
    }

    public MTLResourceOptions ResourceOptions
    {
        get => (MTLResourceOptions)ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLHeapBindings.ResourceOptions);
    }

    public nuint Size
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLHeapBindings.Size);
    }

    public MTLStorageMode StorageMode
    {
        get => (MTLStorageMode)ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLHeapBindings.StorageMode);
    }

    public MTLHeapType Type
    {
        get => (MTLHeapType)ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLHeapBindings.Type);
    }

    public nuint UsedSize
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLHeapBindings.UsedSize);
    }

    public nuint MaxAvailableSize(nuint alignment)
    {
        return ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLHeapBindings.MaxAvailableSize, alignment);
    }

    public MTLAccelerationStructure? NewAccelerationStructure(nuint size)
    {
        nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLHeapBindings.NewAccelerationStructure, size);
        return ptr is not 0 ? new MTLAccelerationStructure(ptr) : null;
    }

    public MTLAccelerationStructure? NewAccelerationStructure(MTLAccelerationStructureDescriptor descriptor)
    {
        nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLHeapBindings.NewAccelerationStructure, descriptor.NativePtr);
        return ptr is not 0 ? new MTLAccelerationStructure(ptr) : null;
    }

    public MTLAccelerationStructure? NewAccelerationStructure(nuint size, nuint offset)
    {
        nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLHeapBindings.NewAccelerationStructure, size, offset);
        return ptr is not 0 ? new MTLAccelerationStructure(ptr) : null;
    }

    public MTLAccelerationStructure? NewAccelerationStructure(MTLAccelerationStructureDescriptor descriptor, nuint offset)
    {
        nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLHeapBindings.NewAccelerationStructure, descriptor.NativePtr, offset);
        return ptr is not 0 ? new MTLAccelerationStructure(ptr) : null;
    }

    public MTLBuffer? NewBuffer(nuint length, MTLResourceOptions options)
    {
        nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLHeapBindings.NewBuffer, length, (nuint)options);
        return ptr is not 0 ? new MTLBuffer(ptr) : null;
    }

    public MTLBuffer? NewBuffer(nuint length, MTLResourceOptions options, nuint offset)
    {
        nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLHeapBindings.NewBuffer, length, (nuint)options, offset);
        return ptr is not 0 ? new MTLBuffer(ptr) : null;
    }

    public MTLTexture? NewTexture(MTLTextureDescriptor descriptor)
    {
        nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLHeapBindings.NewTexture, descriptor.NativePtr);
        return ptr is not 0 ? new MTLTexture(ptr) : null;
    }

    public MTLTexture? NewTexture(MTLTextureDescriptor descriptor, nuint offset)
    {
        nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLHeapBindings.NewTexture, descriptor.NativePtr, offset);
        return ptr is not 0 ? new MTLTexture(ptr) : null;
    }

    public MTLPurgeableState SetPurgeableState(MTLPurgeableState state)
    {
        return (MTLPurgeableState)ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLHeapBindings.SetPurgeableState, (nuint)state);
    }
}

file static class MTLHeapBindings
{
    public static readonly Selector CpuCacheMode = Selector.Register("cpuCacheMode");

    public static readonly Selector CurrentAllocatedSize = Selector.Register("currentAllocatedSize");

    public static readonly Selector Device = Selector.Register("device");

    public static readonly Selector HazardTrackingMode = Selector.Register("hazardTrackingMode");

    public static readonly Selector Label = Selector.Register("label");

    public static readonly Selector MaxAvailableSize = Selector.Register("maxAvailableSizeWithAlignment:");

    public static readonly Selector NewAccelerationStructure = Selector.Register("newAccelerationStructureWithSize:");

    public static readonly Selector NewBuffer = Selector.Register("newBufferWithLength:options:");

    public static readonly Selector NewTexture = Selector.Register("newTextureWithDescriptor:");

    public static readonly Selector ResourceOptions = Selector.Register("resourceOptions");

    public static readonly Selector SetLabel = Selector.Register("setLabel:");

    public static readonly Selector SetPurgeableState = Selector.Register("setPurgeableState:");

    public static readonly Selector Size = Selector.Register("size");

    public static readonly Selector StorageMode = Selector.Register("storageMode");

    public static readonly Selector Type = Selector.Register("type");

    public static readonly Selector UsedSize = Selector.Register("usedSize");
}
