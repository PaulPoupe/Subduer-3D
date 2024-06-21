using System.Collections.Generic;

public class foodStorage
{

    private List<Box<Eat>> foodShelf;

    private int maxCapicity;

    public foodStorage(int maxCapicity)
    {
        this.maxCapicity = maxCapicity;
        foodShelf = new List<Box<Eat>>(maxCapicity);
    }



    public IReadOnlyList<Box<Eat>> GetEat() => foodShelf;

    public void AddFood(Box<Eat> foodBox)
    {
        if (CapacityCount())
        {
            foreach (Box<Eat> box in foodShelf)
            {
                if (box.Add(foodBox))
                    return;
            }
            foodShelf.Add(foodBox);
        }

        bool CapacityCount()
        {
            int capacity = 0;
            foreach (Box<Eat> box in foodShelf)
            {
                capacity += box.resource.size * box.count;
            }
            capacity += foodBox.resource.size * foodBox.count;

            return capacity <= maxCapicity;
        }
    }


}