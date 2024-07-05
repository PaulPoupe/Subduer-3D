public class Tank : LimitedBox<Resource>
{
    public Tank(int maxCapicity) : base(maxCapicity) { }

    public Tank(int maxCapicity, Resource item) : base(maxCapicity, item, 0) { }

    public Tank(int maxCapicity, Resource item, int count) : base(maxCapicity, item, count) { }

    public override void Clear()
    {
        count = 0;
    }
}