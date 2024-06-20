
using UnityEngine;

public class Box<T> where T : AnyResource
{
    public Box(int count)
    {
        this.count = count;
    }

    public T resource { get; private set; }
    public int count { get; private set; }


    public int Take(int count)
    {
        if (this.count >= count)
        {
            this.count -= count;
            return count;
        }
        Debug.Log("Не хватает ресурса" + resource.Name);
        return 0;
    }

    public virtual void Add(Box<T> resourceBox)
    {
        if (resourceBox is Box<T>)
        {
            count += resourceBox.count;
        }
    }
}