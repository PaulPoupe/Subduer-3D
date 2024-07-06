using System.Collections.Generic;
using UnityEngine;


namespace QuestSystem
{
    public class LogbookUi : MonoBehaviour
    {
        private List<GameObject> questPanels = new List<GameObject>();

        [SerializeField]
        private GameObject QuestPanelPrefab;
        [SerializeField]
        private Transform questPanel;

        private void Awake()
        {
            Logbook.OnAddQuest += AddQuest;
        }

        public void AddQuest(Quest quest)
        {
            questPanels.Add(Instantiate(QuestPanelPrefab, questPanel));
            questPanels[questPanels.Count - 1].GetComponent<LogbookQuestUI>().Inittialize(quest);
        }
    }
}
