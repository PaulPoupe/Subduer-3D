using System;
using System.Collections.Generic;
using UnityEngine;

namespace QuestSystem
{
    public class QuestCatalog : MonoBehaviour
    {
        [SerializeField]
        private QuestSample[] samples;

        private List<Quest> notUploadedQuests = new List<Quest>();
        private List<Quest> uploadedQuests = new List<Quest>();

        private void Awake()
        {
            CreateQuests();
        }

        public void Apload(Quest quest)
        {
            notUploadedQuests.Remove(quest);
            uploadedQuests.Add(quest);
        }

        public IReadOnlyList<Quest> GetNotUploaded() => notUploadedQuests;
        public IReadOnlyList<Quest> GetUploaded() => uploadedQuests;

        private void CreateQuests()
        {
            foreach (QuestSample sample in samples)
            {
                switch (sample.type)
                {
                    case Type.Simple:
                        notUploadedQuests.Add(new SimpleQuest(sample));
                        break;
                    case Type.Normal:
                        break;
                    case Type.Hard:
                        break;
                }
            }
        }
    }
}