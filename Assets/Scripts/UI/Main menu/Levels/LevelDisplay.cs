using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class LevelDisplay : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI task_1;
    [SerializeField] private Image task_1Img;
    [SerializeField] private TextMeshProUGUI task_2;
    [SerializeField] private Image task_2Img;
    [SerializeField] private GameObject playButton;
    [SerializeField] private GameObject countOfStars;
    [SerializeField] private Sprite completeTask;

    public Level levelInfo { private get; set; }

    private void OnEnable()
    {
        task_1.text = levelInfo.task_1.GetTextTask();
        task_2.text = levelInfo.task_2.GetTextTask();

        if (levelInfo.IsComplete)
        {
            if(levelInfo.task_1Finished)
                task_1Img.sprite = completeTask;
                    
            if(levelInfo.task_2Finished)
                task_2Img.sprite = completeTask;
        }


        playButton.GetComponent<Button>().onClick.AddListener(() => SceneManager.LoadScene(levelInfo.sceneName));
    }
}
