using System.Collections.Generic;
using UnityEngine;

namespace QuestSystem
{
    public enum Type
    {
        Simple,
        Normal,
        Hard,
    }

    [CreateAssetMenu(fileName = "Simple quest", menuName = "Quests/Simple quest")]
    public class QuestSample : ScriptableObject
    {
        public Type type;
        public uint id;
        [Space]
        public new string name;
        public string description;
        [Range(min: 0, max: 600)]
        public float time;

        public uint workersCount;
        public List<Profession> profession;
    }
}