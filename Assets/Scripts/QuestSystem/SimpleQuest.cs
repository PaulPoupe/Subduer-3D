using UnityEngine;
using System.Collections;
using System;

namespace QuestSystem
{
    [CreateAssetMenu(fileName = "Simple Quest", menuName = "Quests")]
    public class SimpleQuest : Quest
    {
        public override event Action OnStarted;
        public override event Action OnUpdate;
        public override event Action OnCompleted;

        public override IEnumerator StartQuest()
        {
            float workForce = WorkForce();

            OnStarted.Invoke();
            stage = Stage.performed;

            while (timeInWork < timeNeed)
            {
                timeInWork += Time.deltaTime * workForce;
                OnUpdate.Invoke();
                yield return null;
            }
            OnCompleted.Invoke();
            stage = Stage.completed;
        }
    }
}
