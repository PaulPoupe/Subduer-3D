using System;
using UnityEngine.UI;

namespace QuestSystem
{
    public class Person
    {
        public int? position = null;

        private Image image;

        public string name { get; private set; }
        public string surename { get; private set; }
        public string gender { get; private set; }
        public int age { get; private set; }

        public float fatigue { get; private set; } = 100.0f;
        public float health { get; private set; } = 100.0f;
        public float comunicationSkill { get; private set; }

        public float mentalStability { get; private set; }

        public Job job { get; private set; }

        public Person()
        {
            Random random = new Random();

            name = PersonsData.maleNames[random.Next(PersonsData.maleNames.Count)];
            surename = PersonsData.surenames[random.Next(PersonsData.surenames.Count)];
            age = random.Next(18, 48);
            job = new Job();
            comunicationSkill = random.Next(0, 5);
            mentalStability = random.Next(0, 5);

        }
    }
}




