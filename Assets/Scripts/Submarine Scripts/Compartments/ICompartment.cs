using QuestSystem;

public interface ICompartment
{
    Box Work();

    Person ReturnPerson(Person person);
    void SendToWork(Person person);
}