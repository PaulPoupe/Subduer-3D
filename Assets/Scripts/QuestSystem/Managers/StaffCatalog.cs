using System;
using System.Collections.Generic;
using UnityEngine;

namespace QuestSystem
{
    public class StaffCatalog : MonoBehaviour
    {
        [SerializeField]
        private PersonSample[] personSamples;

        private static List<Person> freeStaff = new List<Person>();
        private static List<Person> busyStaff = new List<Person>();

        private void Awake()
        {
            CreateStaff();
        }

        public static void AddToBusy(Person person)
        {
            freeStaff.Remove(person);
            busyStaff.Add(person);
        }

        public static void AddToFree(Person person)
        {
            busyStaff.Remove(person);
            freeStaff.Add(person);
        }

        public static IReadOnlyList<Person> GetFreeStaff() => freeStaff.AsReadOnly();
        public static IReadOnlyList<Person> GetBusyStaff() => busyStaff.AsReadOnly();

        private void CreateStaff()
        {
            foreach (PersonSample sample in personSamples)
            {
                freeStaff.Add(new Person(sample));
            }
        }
    }
}