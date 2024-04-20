using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class LogbookManager : MonoBehaviour
{
    private List<GameObject> questPanels = new List<GameObject> { };
    private List<Quest> quests = new List<Quest> { };
    public List<Quest> questList = new List<Quest>();

    [SerializeField]
    private GameObject prefab;
    [SerializeField]
    private Transform logbook;

    private void AddQuest(Quest quest)
    {
        if (!quests.Any(q => q.id == quest.id))
        {
            ResetQuest(quest);
            quests.Add(quest);
            questPanels.Add(Instantiate(prefab, logbook));
            quest.Inittialize();
            questPanels[questPanels.Count - 1].GetComponent<LogbookUI>().Inittialize(quest);
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
        System.Random random = new System.Random();
        AddQuest(questList[random.Next(questList.Count)]);
    }
}
