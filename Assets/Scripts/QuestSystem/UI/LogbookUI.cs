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
    GameObject timerGui;
    [SerializeField]
    GameObject questBatton;
    [SerializeField]
    Image markerGui;
    [SerializeField]
    Sprite finishedFlag;


    public void Inittialize(Quest quest)
    {
        tmpQuestName.text = quest.name;
        tmpQuestDescription.text = quest.requirements;
        this.quest = quest;

        quest.OnStarted += TimerGuiStart;
        quest.OnCompleted += TimerGuiFinish;
        quest.OnUpdate += TimerGuiUpdate;
    }

    public void OpenQuestWindow()
    {
        Transform canvas = transform.root;
        GameObject window = Instantiate(prefabQuestWindow, canvas);
        window.GetComponent<QuestWindowUI>().Inittialize(quest);
    }

    private void TimerGuiStart()
    {
        timerGui.SetActive(true);
        timerGui.GetComponent<Slider>().maxValue = quest.timeNeed;
        questBatton.SetActive(false);
    }

    private void TimerGuiUpdate()
    {
        timerGui.GetComponent<Slider>().value = quest.timeInWork;
    }

    private void TimerGuiFinish()
    {
        timerGui.SetActive(false);
        questBatton.SetActive(false);
        markerGui.gameObject.SetActive(true);
        markerGui.sprite = finishedFlag;
    }
}
