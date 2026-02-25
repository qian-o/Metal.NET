using System.Collections;

namespace Metal.NET;

/// <summary>
/// Typed wrapper around an Objective-C NSArray whose elements are <typeparamref name="T"/>.
/// </summary>
public class NSArray<T>(nint nativePtr, bool ownsReference) : NativeObject(nativePtr, ownsReference), INativeObject<NSArray<T>>, IEnumerable<T> where T : NativeObject, INativeObject<T>
{
    public static NSArray<T> Create(nint nativePtr, bool ownsReference) => new(nativePtr, ownsReference);

    public nuint Count
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, NSArrayBindings.Count);
    }

    /// <summary>
    /// Returns the object at the given index as a borrowed reference.
    /// </summary>
    public T this[nuint index]
    {
        get
        {
            nint nativePtr = ObjectiveCRuntime.MsgSendPtr(NativePtr, NSArrayBindings.ObjectAtIndex, index);

            return T.Create(nativePtr, false);
        }
    }

    public static unsafe implicit operator NSArray<T>(T[] array)
    {
        nint[] nativePtrs = new nint[array.Length];

        for (int i = 0; i < array.Length; i++)
        {
            nativePtrs[i] = array[i].NativePtr;
        }

        fixed (nint* ptrs = nativePtrs)
        {
            nint nativePtr = ObjectiveCRuntime.MsgSendPtr(ObjectiveCRuntime.Alloc(NSArrayBindings.Class), NSArrayBindings.InitWithObjectsCount, (nint)ptrs, (nuint)array.Length);

            return new(nativePtr, true);
        }
    }

    public IEnumerator<T> GetEnumerator()
    {
        for (nuint i = 0; i < Count; i++)
        {
            yield return this[i];
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}

file static class NSArrayBindings
{
    public static readonly nint Class = ObjectiveCRuntime.GetClass("NSArray");

    public static readonly Selector Count = "count";

    public static readonly Selector ObjectAtIndex = "objectAtIndex:";

    public static readonly Selector InitWithObjectsCount = "initWithObjects:count:";
}