using System.Collections;
using System;

namespace QuestSystem
{
    public class SimpleQuest : Quest
    {
        public SimpleQuest(QuestSample sample) : base(sample) { }


        public override event Action OnStarted;
        public override event Action OnUpdate;
        public override event Action OnCompleted;


        public override IEnumerator StartQuest()
        {
            float speedMultiplier = SpeedMultiplier();

            OnStarted.Invoke();
            while (currentTime < time)
            {
                Timer(speedMultiplier);
                OnUpdate.Invoke();
                yield return null;
            }
            OnCompleted.Invoke();
        }

        protected override float SpeedMultiplier()
        {
            int trueLength = 0;
            int kooficent;
            float workersForce = 0.0f;

            for (int i = 0; i < workers.LongLength; i++)
            {
                if (workers[i] != null)
                {
                    trueLength++;
                    kooficent = profession.Contains(workers[i].job.profession) ? 1 : 0;
                    workersForce += kooficent * workers[i].job.skill + (1 - kooficent) * workers[i].job.skillfulness;
                }
            }
            return (float)Math.Sqrt(workersForce / trueLength);
        }
    }
}
