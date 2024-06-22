
using System;
using UnityEngine;

public class Box
{
    public Box(Item item, int count)
    {
        if (count >= 0)
        {
            this.item = item;
            this.count = count;
        }
        else throw new ArgumentOutOfRangeException();
    }

    public Box(Item item)
    {
        this.item = item;
    }

    public Box() { }

    public Item item { get; private set; }
    public int count { get; private set; }

    public virtual bool Add(Box addebleBox)
    {
        if (item != null)
        {
            if (addebleBox.item == item)
            {
                count += addebleBox.count;
                return true;
            }
            else return false;
        }
        else
        {
            item = addebleBox.item;
            count += addebleBox.count;
            return true;
        }
    }

    public Box Take(int count)
    {
        if (this.count >= count)
        {
            this.count -= count;
            return new Box(item, count);
        }
        Debug.Log("Не хватает ресурса" + item.name);
        return new Box(item);
    }

    public int Capicity() => count * item.size;
}