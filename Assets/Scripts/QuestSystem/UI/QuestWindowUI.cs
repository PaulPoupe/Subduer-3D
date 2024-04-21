using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;

public class QuestWindowUI : MonoBehaviour
{
    [SerializeField]
    private TMP_Text tmpName;
    [SerializeField]
    private TMP_Text tmpDescription;
    [SerializeField]
    private GameObject personSlotPrefab;
    [SerializeField]
    private GameObject personCardPrefab;
    [SerializeField]
    private Transform personSlotsPanel;
    [SerializeField]
    private Transform staffSlotsPanel;

    private LogbookManager manager;
    private Quest quest;

    List<GameObject> staffSlots = new List<GameObject>();
    GameObject[] questSlots;


    public void Inittialize(Quest quest)
    {
        tmpName.text = quest.name;
        tmpDescription.text = quest.describtion;
        this.quest = quest;
        manager = GameObject.Find("QuestManager").GetComponent<LogbookManager>(); // Не использовать Find
        questSlots = CreatePersonSlots(quest.peopleCount, personSlotsPanel);
        CreateStaffSlots(manager.staffList, staffSlotsPanel);
        quest.OnCompleted += ReturnPersonCards;
    }

    private GameObject[] CreatePersonSlots(int peopleCount, Transform parent)
    {
        GameObject[] slots = new GameObject[peopleCount];
        PersonSlot personSlot;

        for (int i = 0; i < peopleCount; i++)
        {
            slots[i] = Instantiate(personSlotPrefab, parent);
            personSlot = slots[i].GetComponent<PersonSlot>();
            personSlot.index = i;
            personSlot.OnPastPerson += PastePerson;
        }
        return slots;
    }

    private GameObject[] CreateStaffSlots(List<Person> persons, Transform parent)
    {
        GameObject[] slots = CreatePersonSlots(persons.Count, parent);

        for (int i = 0; i < slots.Length; i++)
        {
            GameObject slot = slots[i];
            PersonCardUI personCardUI = Instantiate(personCardPrefab, slot.transform).GetComponent<PersonCardUI>();
            personCardUI.Inittialize(persons[i]);
        }
        return slots;
    }

    private void PastePerson(GameObject replacedCard, int slotNumber)
    {
        Person person = replacedCard.GetComponent<PersonCardUI>().person;
        replacedCard.GetComponent<CardMoving>().OnDeletePerson += DeletePerson;

        quest.workers[slotNumber] = person;
        person.position = slotNumber;
        RemovePersonCards(person);
        Debug.Log("Слот № " + slotNumber + " вставлен");
    }

    private void RemovePersonCards(Person person)
    {
        manager.staffList.Remove(person);
        manager.busyStaffList.Add(person);
    }

    private void ReturnPersonCards()
    {
        manager.staffList.AddRange(quest.workers);
        foreach (Person person in quest.workers)
        {
            manager.busyStaffList.Remove(person);
        }
    }

    private void DeletePerson(Person person)
    {
        Debug.Log("OnDelete");
        if (/*quest.workers[person.position] == person &&*/ quest.workers[person.position] != null)
        {
            quest.workers[person.position] = null;
            Debug.Log("Удалено " + person.position);
            person.position = 6;
        }
    }

    private void CloseWindow()
    {
        Destroy(gameObject);
    }

    public void EceptQuest()
    {
        manager.StartQuest(quest);
        CloseWindow();
    }
}
