using System.Collections;
using UnityEngine;
using System;

namespace QuestSystem
{
    public enum Stage
    {
        notStarted,
        performed,
        completed
    }


    public abstract class Quest : ScriptableObject
    {

        public Stage stage { get; /*protected*/ set; }
        [field: SerializeField]
        public int id { get; protected set; }
        [field: SerializeField]
        public new string name { get; protected set; }
        [field: SerializeField]
        public string requirements { get; protected set; }
        [field: SerializeField, TextArea]
        public string describtion { get; protected set; }
        [field: SerializeField]
        public int peopleCount { get; protected set; }
        [field: SerializeField]
        public float timeNeed { get; protected set; }
        [field: SerializeField]
        protected Profession profession;

        [HideInInspector]
        public float timeInWork;
        public Person[] workers { get; protected set; }

        public abstract IEnumerator StartQuest();

        public abstract event Action OnStarted;
        public abstract event Action OnUpdate;
        public abstract event Action OnCompleted;

        protected float WorkForce()
        {
            int trueLength = 0;
            int kooficent;
            float workersForce = 0.0f;

            for (int i = 0; i < workers.LongLength; i++)
            {
                if (workers[i] != null)
                {
                    trueLength++;
                    kooficent = workers[i].job.profession == profession ? 1 : 0;
                    workersForce += kooficent * workers[i].job.skill + (1 - kooficent) * workers[i].job.skillfulness;
                }
            }
            return (float)Math.Sqrt(workersForce / trueLength);
        }

        public void Inittialize()
        {
            workers = new Person[peopleCount];
        }
    }
}

