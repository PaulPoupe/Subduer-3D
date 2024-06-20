using QuestSystem;

public interface ICompartment
{
    Box<T> Work<T>() where T : AnyResource;

    Person ReturnPerson(Person person);
    void SendToWork(Person person);
}