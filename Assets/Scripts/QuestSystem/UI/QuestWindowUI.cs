using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace QuestSystem
{
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

        private Quest quest;

        public void Inittialize(Quest quest)
        {
            this.quest = quest;
            Subscribe(quest);

            tmpName.text = quest.name;
            tmpDescription.text = quest.description;

            CreatePersonSlots(quest.workers.Length, personSlotsPanel, true);
            CreateStaffSlots(StaffCatalog.GetFreeStaff(), staffSlotsPanel);

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

        private GameObject[] CreateStaffSlots(IReadOnlyList<Person> persons, Transform parent)
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
            foreach (Person person in quest.workers)
                StaffCatalog.AddToBusy(person);
        }

        private void ReturnPersonCards()
        {
            foreach (Person person in quest.workers)
                StaffCatalog.AddToFree(person);
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
            Logbook.OnStartQuest.Invoke(quest);
            CloseWindow();
        }
    }
}
