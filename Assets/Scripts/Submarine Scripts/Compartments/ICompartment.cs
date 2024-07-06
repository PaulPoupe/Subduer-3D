using QuestSystem;

public interface ICompartment
{
    Box<Item> Work();

    Person ReturnPerson(Person person);
    void SendToWork(Person person);
}