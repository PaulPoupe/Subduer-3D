using UnityEngine;
using UnityEngine.UI;

namespace QuestSystem
{
    [CreateAssetMenu(fileName = "Person", menuName = "Person")]
    public class PersonSample : ScriptableObject
    {
        public Image image;
        public new string name;
        public string surename;
        public Gender gender;
        [Range(0, 100)]
        public int age;
        [Space]
        public Profession profession;
        public float skill;
        public float skillfulness;
        [Space]
        [TextArea]
        public string history;
    }
}