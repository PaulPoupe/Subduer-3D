using System.Collections;
using UnityEngine;
using System;
using UnityEngine.PlayerLoop;

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

    [HideInInspector]
    public float timeInWork;
    public Person[] workers { get; protected set; }

    public abstract IEnumerator StartQuest();

    public abstract event Action OnStarted;
    public abstract event Action OnUpdate;
    public abstract event Action OnCompleted;


    public void Inittialize()
    {
        workers = new Person[peopleCount];
    }
}
