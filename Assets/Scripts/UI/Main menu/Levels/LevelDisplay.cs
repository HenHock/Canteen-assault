using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class LevelDisplay : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI task_1;
    [SerializeField] private TextMeshProUGUI task_2;
    [SerializeField] private GameObject playButton;
    [SerializeField] private GameObject countOfStars;

    public Level levelInfo { private get; set; }

    private void OnEnable()
    {
        task_1.text = levelInfo.task_1.GetTextTask();
        task_2.text = levelInfo.task_2.GetTextTask();

        playButton.GetComponent<Button>().onClick.AddListener(() => SceneManager.LoadScene(levelInfo.sceneName));
    }
}
