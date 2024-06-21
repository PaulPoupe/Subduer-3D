using System;

public class LimitedBox<T> : Box<T> where T : AnyResource
{
    public LimitedBox(int count, int maxCount, T resource) : base(count, resource)
    {
        this.maxCount = maxCount;
    }
    public LimitedBox() : base() { }

    public int maxCount { get; private set; }

    public override bool Add(Box<T> resourceBox)
    {
        if (maxCount <= count + resourceBox.count)
            return base.Add(resourceBox);
        else
            throw new ArgumentException("переполнение ящика");

    }
}