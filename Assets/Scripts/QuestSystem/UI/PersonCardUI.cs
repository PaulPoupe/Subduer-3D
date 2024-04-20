using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PersonCardUI : MonoBehaviour
{
    public Person person = new Person();
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

    private void Awake()
    {
        Inittialize();
    }

    private void Inittialize()
    {
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
