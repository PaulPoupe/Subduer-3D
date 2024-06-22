using System;
using System.Collections.Generic;

public class Storage
{

    private List<Box> shelf;

    private int maxCapicity;

    public Storage(int maxCapicity)
    {
        if (maxCapicity >= 0)
        {
            this.maxCapicity = maxCapicity;
            shelf = new List<Box>(maxCapicity);
        }
        else throw new ArgumentOutOfRangeException();
    }

    public IReadOnlyList<Box> Get() => shelf;

    public void Add(Box AddebleBox)
    {
        if (CapacityCount())
        {
            foreach (Box box in shelf)
            {
                if (box.Add(AddebleBox))
                    return;
            }
            shelf.Add(AddebleBox);
        }

        bool CapacityCount()
        {
            int capacity = 0;
            foreach (Box box in shelf)
            {
                capacity += box.Capicity();
            }
            capacity += AddebleBox.Capicity();

            return capacity <= maxCapicity;
        }
    }


}