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
    private Transform personSlotsPanel;

    private LogbookManager Manager;
    private Quest quest;
    GameObject[] slots;

    // Где то тут сделать вставку фото


    public void Inittialize(Quest quest)
    {
        tmpName.text = quest.name;
        tmpDescription.text = quest.describtion;
        this.quest = quest;
        Manager = GameObject.Find("QuestManager").GetComponent<LogbookManager>(); // Не использовать Find
        CreatePersonSlots(quest.peopleCount);
    }

    private void CreatePersonSlots(int peopleCount)
    {
        slots = new GameObject[peopleCount];
        for (int i = 0; i < peopleCount; i++)
        {

            slots[i] = Instantiate(personSlotPrefab, personSlotsPanel);
            slots[i].GetComponent<PersonSlot>().index = i;
            slots[i].GetComponent<PersonSlot>().OnPastPerson += PastePerson;
        }
    }

    private void PastePerson(Person person, int slotNumber)
    {
        quest.workers[slotNumber] = person;
        Debug.Log("Слот № " + slotNumber + " вставлен");
    }

    private void CloseWindow()
    {
        Destroy(gameObject);
    }

    public void EceptQuest()
    {
        Manager.StartQuest(quest);
        CloseWindow();
    }
}
