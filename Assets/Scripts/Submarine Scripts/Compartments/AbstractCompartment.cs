using System.Collections.Generic;
using QuestSystem;
using Unity.VisualScripting;
using UnityEngine;

public abstract class AbstractCompartment : MonoBehaviour, ICompartment
{
    [field: SerializeField]
    protected string Name { get; private set; }
    protected List<Person> workers;
    [SerializeField]
    private int maxWorkersCapacity;

    public Person ReturnPerson(Person person)
    {
        workers.Remove(person);
        return person;
    }

    public void SendToWork(Person person)
    {
        if (person.position == null && workers.Count <= maxWorkersCapacity)
            workers.Add(person);
    }

    public abstract Box<Item> Work();
}