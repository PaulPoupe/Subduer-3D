using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace QuestSystem
{
    public enum Stage
    {
        notStarted,
        performed,
        completed
    }


    public abstract class Quest
    {
        public int id { get; private set; }
        public string name { get; private set; }
        public string description { get; private set; }
        public float time { get; private set; }
        protected List<Profession> profession;

        public Person[] workers { get; protected set; }
        public Stage stage { get; private set; }
        public float currentTime { get; protected set; }

        protected Quest(QuestSample sample)
        {
            id = (int)sample.id;
            name = sample.name;
            description = sample.description;
            time = sample.time;
            workers = new Person[sample.workersCount];
            profession = sample.profession;

            OnStarted += SetPerwormed;
            OnCompleted += SetCompleted;
        }

        public abstract IEnumerator StartQuest();
        protected abstract float SpeedMultiplier();
        protected void Timer(float speedMultiplier) => currentTime += Time.deltaTime * speedMultiplier;
        private void SetPerwormed() => stage = Stage.performed;
        private void SetCompleted() => stage = Stage.completed;

        public abstract event Action OnStarted;
        public abstract event Action OnUpdate;
        public abstract event Action OnCompleted;
    }
}

