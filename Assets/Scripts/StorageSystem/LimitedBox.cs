using System;

public class LimitedBox<T> : Box<T> where T : Item
{
    private void SetMaxCaicity(int maxCapicity)
    {
        if (maxCapicity <= 0)
            throw new ArgumentOutOfRangeException();

        this.maxCapicity = maxCapicity;
    }

    public LimitedBox(int maxCapicity, T item, int count) : base(item, count)
    {
        SetMaxCaicity(maxCapicity);
    }

    public LimitedBox(int maxCapicity) : base()
    {
        SetMaxCaicity(maxCapicity);
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