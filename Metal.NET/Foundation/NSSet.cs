namespace Metal.NET;

/// <summary>
/// A static unordered collection of unique objects.
/// </summary>
public static class NSSet
{
    public static nint FromArray<T>(T[] array) where T : NativeObject
    {
        nint arrayPtr = NSArray.FromArray(array);

        nint setPtr = ObjectiveC.MsgSendNInt(ObjectiveC.Alloc(NSSetBindings.Class), NSSetBindings.InitWithArray, arrayPtr);

        ObjectiveC.Release(arrayPtr);

        return setPtr;
    }
}

file static class NSSetBindings
{
    public static readonly nint Class = ObjectiveC.GetClass("NSSet");

    public static readonly Selector InitWithArray = "initWithArray:";
}
