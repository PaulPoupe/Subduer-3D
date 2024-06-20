public class LimitedBox<T> : Box<T> where T : AnyResource
{
    public LimitedBox(int maxCount, int count) : base(count)
    {
        this.maxCount = maxCount;
    }

    public int maxCount { get; private set; }

    public override void Add(Box<T> resourceBox)
    {
        if (maxCount <= count + resourceBox.count)
            base.Add(resourceBox);
    }
}