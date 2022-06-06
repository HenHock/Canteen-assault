using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
using System.Collections.Generic;
using Game.Tasks_at_level;
using TMPro;
using UI;

/*
 * ������ ��� ��������� UI � �������
 */

public class UIManager : MonoBehaviour
{
    public GameObject sceneIgnoring;
    public PanelController buyCharacterPanelController;
    public PanelController updateCharacterPanel;
    public PanelController endGamePanel;
    public PanelController pausePanel;
    
    [SerializeField] private GameObject Blur;
    [SerializeField] private TMP_Text titleEndGameText;
    [SerializeField] private TMP_Text starCountText;
    [SerializeField] private Image Stars;

    [SerializeField] private Button nextLevelButton;
    [SerializeField] private Button resetButton;

    [SerializeField] private UITaskDisplay firstTask;
    [SerializeField] private UITaskDisplay secondTask;
    [SerializeField] private TaskManager Tasks;

    public static Action<bool> OnBlurAction;

    private void Awake()
    {
        Blur.SetActive(false);

        DataManager.uIController = this;
        sceneIgnoring.SetActive(false);

        nextLevelButton.gameObject.SetActive(false);
        buyCharacterPanelController.Close();
        endGamePanel.Close();
        updateCharacterPanel.Close();
        pausePanel.Close();

        OnBlurAction = (bool flag) => { Blur.SetActive(flag); };
    }

    public void Win()
    {
        endGamePanel.Open();
        titleEndGameText.text = "You win!";
        
        int starSave = 0;
        int starCount = 1;
        
       UpdateTasksData();

        if (!Tasks.getLevelInfo().finished)
        {
            Tasks.getLevelInfo().LevelFinish();
            starSave++;
        }
        
        if (Tasks.TaskDescription(0).CheckIfComplete())
        {
            starCount++;
            if (!Tasks.getLevelInfo().firstTask)
            {
                Tasks.getLevelInfo().CompleteTask(1);
                starSave++;
            }
        }
        if (Tasks.TaskDescription(1).CheckIfComplete())
        {
            starCount++;
            if (!Tasks.getLevelInfo().secondTask)
            {
                Tasks.getLevelInfo().CompleteTask(2);
                starSave++;
            }
        }
        ResourcesManager.Change(ResourceType.Star, starSave); // ��������� ������ �� ������
        Stars.sprite = StarsIcon.GetIcon(starCount); // ������������� ����� ������ � ����������� �� ���������� �����
        starCountText.text = starCount.ToString() + "/3";

        nextLevelButton.gameObject.SetActive(true);

        if(starCount == 3)
            resetButton.gameObject.SetActive(false);
    }

    public void Lose()
    {
        UpdateTasksData();

        endGamePanel.Open();
        titleEndGameText.text = "You lose";
        //statisticsEndGameText.GetComponent<TextMeshProUGUI>().text = "You can try again!";

        nextLevelButton.gameObject.SetActive(false);
        resetButton.gameObject.SetActive(true);
    }

    /// <summary>
    /// ��������� ���� ������ ��������� �� UI �������
    /// </summary>
    /// <returns>true or false</returns>
    public static bool IsPointerOverUIObject()
    {
        PointerEventData eventDataCurrentPosition = new PointerEventData(EventSystem.current);
        eventDataCurrentPosition.position = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        List<RaycastResult> results = new List<RaycastResult>();
        EventSystem.current.RaycastAll(eventDataCurrentPosition, results);
        return results.Count > 0;
    }

    private void UpdateTasksData()
    {
        firstTask.SetData(Tasks.TaskDescription(0).GetTextTask());
        secondTask.SetData(Tasks.TaskDescription(1).GetTextTask());
        
        firstTask.UpdateState(Tasks.TaskDescription(0).CheckIfComplete());
        secondTask.UpdateState(Tasks.TaskDescription(1).CheckIfComplete());
    }
    
}
