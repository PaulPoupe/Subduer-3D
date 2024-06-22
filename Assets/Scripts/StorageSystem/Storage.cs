using System;
using System.Collections.Generic;

public class Storage<T> where T : Item
{

    private List<Box<T>> shelf;

    private int maxCapicity;

    public Storage(int maxCapicity)
    {
        if (maxCapicity >= 0)
        {
            this.maxCapicity = maxCapicity;
            shelf = new List<Box<T>>(maxCapicity);
        }
        else throw new ArgumentOutOfRangeException();
    }

    public IReadOnlyList<Box<T>> GetShelf() => shelf;

    public void Add(Box<T> AddebleBox)
    {
        if (CapacityCount(AddebleBox))
        {
            foreach (var box in shelf)
            {
                if (box.Add(AddebleBox))
                    return;
            }
            shelf.Add(AddebleBox);
        }
    }

    private bool CapacityCount(Box<T> AddebleBox)
    {
        int capacity = 0;
        foreach (var box in shelf)
        {
            capacity += box.Capicity();
        }
        capacity += AddebleBox.Capicity();

        return capacity <= maxCapicity;
    }

}