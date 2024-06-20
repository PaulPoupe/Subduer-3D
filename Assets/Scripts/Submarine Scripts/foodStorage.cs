using System.Collections.Generic;

public class foodStorage
{

    private List<Box<Eat>> eat;

    private int maxCapicity;

    public foodStorage(int maxCapicity)
    {
        this.maxCapicity = maxCapicity;
    }

    private bool CapacityCount()
    {
        int capacity = 0;
        foreach (Box<Eat> box in eat)
        {
            capacity += box.resource.size * box.count;
        }
        return capacity <= maxCapicity;
    }

    public IReadOnlyList<Box<Eat>> GetEat() => eat;


    //Остановился методы присвоения 

}