using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class LogbookManager : MonoBehaviour
{
    [SerializeField]
    private List<Quest> questList = new List<Quest>();
    private List<Quest> uploadedQuests = new List<Quest>();

    private const int staffCount = 10;
    public static List<Person> freeStaff = new List<Person>();
    public static List<Person> busyStaff = new List<Person>();

    public static event Action<Quest> OnAddQuest;
    public static Action<Quest> OnStartQuest;

    private void Awake()
    {
        OnStartQuest += StartQuest;
        CreateNewStaff();
    }

    private void CreateNewStaff()
    {
        for (int i = 0; i < staffCount; i++)
            freeStaff.Add(new Person());
    }

    private void AddQuest(Quest quest)
    {
        if (!uploadedQuests.Any(q => q.id == quest.id))
        {
            ResetQuest(quest);

            uploadedQuests.Add(quest);
            quest.Inittialize();
            OnAddQuest.Invoke(quest);
            questList.Remove(quest);

            void ResetQuest(Quest quest)
            {
                quest.stage = Stage.notStarted;
                quest.timeInWork = 0;
            }
        }
    }

    public void InstantiateRandomQuest()
    {
        try
        {
            System.Random random = new System.Random();
            AddQuest(questList[random.Next(questList.Count)]);
        }
        catch
        {
            Debug.LogWarning("Нет новых квестов");
        }
    }

    private void StartQuest(Quest quest)
    {
        StartCoroutine(quest.StartQuest());
    }
}
