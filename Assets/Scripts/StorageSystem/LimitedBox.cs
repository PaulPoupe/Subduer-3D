using System;

public class LimitedBox<T> : Box<T> where T : Item
{
    public LimitedBox(int maxCapicity, T item, int count) : base(item, count)
    {
        this.maxCapicity = maxCapicity;
    }

    public LimitedBox(int maxCapicity, T item) : base(item)
    {
        this.maxCapicity = maxCapicity;
    }

    public LimitedBox(int maxCapicity) : base()
    {
        this.maxCapicity = maxCapicity;
    }

    public int maxCapicity { get; private set; }

    public override bool Add(Box<T> addebleBox)
    {
        if (maxCapicity <= Capicity() + addebleBox.Capicity())
            return base.Add(addebleBox);
        else
            return base.Add(new Box<T>(item, MaxItemCount() - count));
    }


    private int MaxItemCount()
    {
        return (int)Math.Floor((double)maxCapicity / item.size);
    }

}