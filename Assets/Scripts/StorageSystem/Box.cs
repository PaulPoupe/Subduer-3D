
using System;
using UnityEngine;

public class Box<T> where T : Item
{
    public Box(T item, int count)
    {
        if (count >= 0)
        {
            this.item = item;
            this.count = count;
        }
        else throw new ArgumentOutOfRangeException();
    }

    public Box(T item)
    {
        this.item = item;
    }

    public Box() { }

    public T item { get; private set; }
    public int count { get; private set; }

    public virtual bool Add(Box<T> addebleBox)
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

    public Box<T> Take(int count)
    {
        if (this.count >= count)
        {
            this.count -= count;
            return new Box<T>(item, count);
        }
        Debug.Log("Не хватает ресурса" + item.name);
        return new Box<T>(item);
    }

    public int Capicity() => count * item.size;
}