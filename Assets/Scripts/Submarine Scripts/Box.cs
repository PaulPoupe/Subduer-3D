
using UnityEngine;

public class Box<T> where T : AnyResource
{
    public Box(int count, T resource)
    {
        this.count = count;
        this.resource = resource;
    }

    public Box() { }

    public T resource { get; private set; }
    public int count { get; private set; }


    public int Take(int count)
    {
        if (this.count >= count)
        {
            this.count -= count;
            return count;
        }
        Debug.Log("Не хватает ресурса" + resource.name);
        return 0;
    }

    public virtual bool Add(Box<T> resourceBox)
    {
        if (resource != null)
        {
            if (resourceBox.resource.GetType() == resource.GetType())
            {
                count += resourceBox.count;
                return true;
            }
            else return false;
        }
        else
        {
            resource = resourceBox.resource;
            count += resourceBox.count;
            return true;
        }
    }
}