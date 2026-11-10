using System.Runtime.CompilerServices;

namespace Metal.NET;

/// <summary>
/// A typed ordered collection of objects backed by an Objective-C NSArray.
/// </summary>
public readonly struct NSArray<T>(nint nativePtr) : IDisposable where T : unmanaged, IDisposable
{
    public readonly nint NativePtr = nativePtr;

    public bool IsNull => NativePtr is 0;

    public static implicit operator NSObject(NSArray<T> value) => new(value.NativePtr);

    public unsafe NSArray(ReadOnlySpan<T> span) : this(Create(span))
    {
    }

    public NSArray<T> Retain()
    {
        return new(ObjectiveC.Retain(NativePtr));
    }

    public void Dispose()
    {
        ObjectiveC.Release(NativePtr);
    }

    public nuint Count
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, NSArrayBindings.Count);
    }

    public T this[nuint index]
    {
        get
        {
            nint nativePtr = ObjectiveC.MsgSendNInt(NativePtr, NSArrayBindings.ObjectAtIndex, index);

            return Unsafe.BitCast<nint, T>(nativePtr);
        }
    }

    public static implicit operator T[](NSArray<T> array)
    {
        int count = (int)array.Count;

        T[] result = new T[count];

        for (int i = 0; i < count; i++)
        {
            result[i] = array[(uint)i];
        }

        return result;
    }

    public Enumerator GetEnumerator()
    {
        return new(this);
    }

    private static unsafe nint Create(ReadOnlySpan<T> span)
    {
        fixed (T* pNativePtrs = span)
        {
            return ObjectiveC.MsgSendNInt(ObjectiveC.Alloc(NSArrayBindings.Class), NSArrayBindings.InitWithObjects_Count, (nint)pNativePtrs, (nuint)span.Length);
        }
    }

    public struct Enumerator(NSArray<T> array)
    {
        private int index = -1;

        public readonly T Current
        {
            get => array[(uint)index];
        }

        public bool MoveNext()
        {
            return ++index < (int)array.Count;
        }
    }
}

file static class NSArrayBindings
{
    public static readonly nint Class = ObjectiveC.GetClass("NSArray");

    public static readonly Selector Count = "count";

    public static readonly Selector InitWithObjects_Count = "initWithObjects:count:";

    public static readonly Selector ObjectAtIndex = "objectAtIndex:";
}