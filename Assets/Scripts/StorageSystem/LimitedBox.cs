using System;

public class LimitedBox : Box
{
    public LimitedBox(int maxCapicity, Item item, int count) : base(item, count)
    {
        this.maxCapicity = maxCapicity;
    }

    public LimitedBox(int maxCapicity, Item item) : base(item)
    {
        this.maxCapicity = maxCapicity;
    }

    public LimitedBox(int maxCapicity) : base()
    {
        this.maxCapicity = maxCapicity;
    }

    public int maxCapicity { get; private set; }

    public override bool Add(Box addebleBox)
    {
        if (maxCapicity <= Capicity() + addebleBox.Capicity())
            return base.Add(addebleBox);
        else
            return base.Add(new Box(item, MaxItemCount() - count));
    }


    private int MaxItemCount()
    {
        return (int)Math.Floor((double)maxCapicity / item.size);
    }

}