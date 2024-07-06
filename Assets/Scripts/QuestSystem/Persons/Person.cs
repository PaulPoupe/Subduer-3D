using System;
using UnityEngine.UI;

namespace QuestSystem
{
    public enum Gender
    {
        male,
        female,
    }

    public class Person
    {
        public int? position = null;//Разобратся с позицией её не должно быть в классе персон

        private Image image;

        public Person(PersonSample sample)
        {
            image = sample.image;
            name = sample.name;
            surename = sample.surename;
            gender = sample.gender;
            age = sample.age;
            history = sample.history;
            job = new Job(sample);
        }

        public string name { get; private set; }
        public string surename { get; private set; }
        public Gender gender { get; private set; }
        public int age { get; private set; }

        public string history { get; private set; }
        public Job job { get; private set; }

        public float fatigue { get; private set; } = 100.0f;
        public float health { get; private set; } = 100.0f;

    }
}




