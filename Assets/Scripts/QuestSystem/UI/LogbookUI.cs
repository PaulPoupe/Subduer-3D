using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LogbookUI : MonoBehaviour
{
    private Quest quest;

    [SerializeField]
    TMP_Text tmpQuestName;
    [SerializeField]
    TMP_Text tmpQuestDescription;
    [SerializeField]
    GameObject prefabQuestWindow;
    [SerializeField]
    GameObject timer;
    [SerializeField]
    GameObject batton;
    [SerializeField]
    Image marker;
    [SerializeField]
    Sprite finishedFlag;


    public void Inittialize(Quest quest)
    {
        tmpQuestName.text = quest.name;
        tmpQuestDescription.text = quest.requirements;
        this.quest = quest;

        Subscribe(quest);

        void Subscribe(Quest quest)
        {
            quest.OnStarted += TimerGuiStart;
            quest.OnCompleted += TimerGuiFinish;
            quest.OnUpdate += TimerGuiUpdate;
        }
    }

    public void OpenQuestWindow()
    {
        Transform canvas = transform.root;
        GameObject window = Instantiate(prefabQuestWindow, canvas);
        window.GetComponent<QuestWindowUI>().Inittialize(quest);
    }

    private void TimerGuiStart()
    {
        timer.SetActive(true);
        timer.GetComponent<Slider>().maxValue = quest.timeNeed;
        batton.SetActive(false);
    }

    private void TimerGuiUpdate()
    {
        timer.GetComponent<Slider>().value = quest.timeInWork;
    }

    private void TimerGuiFinish()
    {
        timer.SetActive(false);
        batton.SetActive(false);
        marker.gameObject.SetActive(true);
        marker.sprite = finishedFlag;
    }
}
