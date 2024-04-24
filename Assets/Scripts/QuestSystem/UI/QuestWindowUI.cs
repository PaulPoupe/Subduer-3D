using System.Collections.Generic;
using TMPro;
using UnityEngine;

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
        questSlots = CreatePersonSlots(quest.peopleCount, personSlotsPanel, true);
        CreateStaffSlots(manager.staffList, staffSlotsPanel);

        Subscribe(quest);

        void Subscribe(Quest quest)
        {
            quest.OnCompleted += ReturnPersonCards;
            quest.OnStarted += RemovePersonCards;
        }
    }

    private GameObject[] CreatePersonSlots(int peopleCount, Transform parent, bool indexing)
    {
        GameObject[] slots = new GameObject[peopleCount];
        PersonSlot personSlot;

        for (int i = 0; i < peopleCount; i++)
        {
            slots[i] = Instantiate(personSlotPrefab, parent);
            personSlot = slots[i].GetComponent<PersonSlot>();
            personSlot.OnPastPerson += PastePerson;
            if (indexing) { personSlot.index = i; }
            else { personSlot.index = null; }
        }
        return slots;
    }

    private GameObject[] CreateStaffSlots(List<Person> persons, Transform parent)
    {
        GameObject[] slots = CreatePersonSlots(persons.Count, parent, false);

        for (int i = 0; i < slots.Length; i++)
        {
            GameObject slot = slots[i];
            PersonCardUI personCardUI = Instantiate(personCardPrefab, slot.transform).GetComponent<PersonCardUI>();
            personCardUI.Inittialize(persons[i]);
        }
        return slots;
    }

    private void PastePerson(GameObject card, int slotNumber)
    {
        Person person = card.GetComponent<PersonCardUI>().person;

        card.GetComponent<CardMoving>().OnDeletePerson += DeletePerson;
        quest.workers[slotNumber] = person;
        person.position = slotNumber;
        Debug.Log("Слот № " + slotNumber + " вставлен");
    }

    private void RemovePersonCards()
    {
        manager.busyStaffList.AddRange(quest.workers);
        foreach (Person person in quest.workers)
        {
            manager.staffList.Remove(person);
        }
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
        if (person.position != null && quest.workers[(int)person.position] != null)
        {
            Debug.Log("Удален слот № " + person.position);
            quest.workers[(int)person.position] = null;
            person.position = null;
        }
    }

    private void CloseWindow()
    {
        ClearWorkers(quest.stage);
        Destroy(gameObject);
    }

    private void ClearWorkers(Stage stage)
    {
        if (stage == Stage.notStarted)
        {
            for (int i = 0; i < quest.workers.Length; i++)
            {
                try
                {
                    Person worker = quest.workers[i];
                    worker.position = null;
                    worker = null;
                    Debug.Log("Рабочий № " + i + " очищен");
                }
                catch { }
            }

        }
    }

    public void EceptQuest()
    {
        manager.StartQuest(quest);
        CloseWindow();
    }
}
