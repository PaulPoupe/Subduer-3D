using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace QuestSystem
{
    public class PersonCardUI : MonoBehaviour
    {
        public Person person;
        [SerializeField]
        private Image image;
        [SerializeField]
        private new TMP_Text name;
        [SerializeField]
        private TMP_Text surename;
        [SerializeField]
        private TMP_Text age;

        [SerializeField]
        private TMP_Text specialization;
        [SerializeField]
        private TMP_Text profesionalCategory;
        [SerializeField]
        private Slider fatigue;
        [SerializeField]
        private Slider health;

        public void Inittialize(Person person)
        {
            this.person = person;
            name.text = person.name;
            surename.text = person.surename;
            age.text = person.age.ToString();

            specialization.text = person.job.profession.ToString();
            profesionalCategory.text = person.job.skill.ToString();

            fatigue.maxValue = person.fatigue;
            fatigue.value = person.fatigue;

            health.maxValue = person.health;
            health.value = person.health;
        }
    }
}
