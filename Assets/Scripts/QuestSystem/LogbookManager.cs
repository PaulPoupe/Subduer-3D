using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using Unity.VisualScripting;
using UnityEngine;

public class LogbookManager : MonoBehaviour
{
    private List<GameObject> questPanels = new List<GameObject>();
    private List<Quest> quests = new List<Quest>();
    public List<Quest> questList = new List<Quest>();
    public List<Person> staffList = new List<Person>();
    public List<Person> busyStaffList = new List<Person>();

    [SerializeField]
    private GameObject prefab;
    [SerializeField]
    private Transform logbookQuestPanel;

    private const int staffCount = 10;


    private void Awake()
    {
        CreateNewStaff();
    }

    private void CreateNewStaff()
    {
        for (int i = 0; i < staffCount; i++)
        {
            staffList.Add(new Person());
        }
    }

    private void AddQuest(Quest quest)
    {
        if (!quests.Any(q => q.id == quest.id))
        {
            ResetQuest(quest);
            quests.Add(quest);
            questPanels.Add(Instantiate(prefab, logbookQuestPanel));
            quest.Inittialize();
            questPanels[questPanels.Count - 1].GetComponent<LogbookUI>().Inittialize(quest);
            questList.Remove(quest);
        }
    }
    public void StartQuest(Quest quest)
    {
        StartCoroutine(quest.StartQuest());
    }

    // В дальнейшем поидее оно должно не сбрасываться а загружаться из сохранения
    private void ResetQuest(Quest quest)
    {
        quest.stage = Stage.notStarted;
        quest.timeInWork = 0;
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
            Debug.LogAssertion("Нет новых квестов");
        }
    }
}
