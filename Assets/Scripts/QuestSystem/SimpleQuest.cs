using UnityEngine;
using System.Collections;
using System;

[CreateAssetMenu(fileName = "Simple Quest", menuName = "Quests")]
public class SimpleQuest : Quest
{
    public override event Action OnStarted;
    public override event Action OnUpdate;
    public override event Action OnCompleted;

    public override IEnumerator StartQuest()
    {
        OnStarted.Invoke();
        stage = Stage.performed;
        while (timeInWork < timeNeed)
        {
            timeInWork += Time.deltaTime * WorkForce();
            OnUpdate.Invoke();
            yield return null;
        }
        OnCompleted.Invoke();
        stage = Stage.completed;
    }
    private float WorkForce()
    {
        float averageForce;
        float forceSum = 0.0f;
        int truePeopleCount = 0;
        foreach (var people in workers)
        {
            if (people != null)
            {
                forceSum += people.job.skill;
                truePeopleCount++;
            }
        }
        if (truePeopleCount != 0)
        {
            averageForce = forceSum / truePeopleCount;
            return averageForce;
        }
        else
        {
            throw new NotImplementedException("Не назначены люди");
        }
    }
}
