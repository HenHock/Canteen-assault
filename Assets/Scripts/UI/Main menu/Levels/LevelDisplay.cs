using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelDisplay : MonoBehaviour
{
    [SerializeField] private GameObject task_1;
    [SerializeField] private GameObject task_2;
    [SerializeField] private GameObject playButton;
    [SerializeField] private GameObject countOfStars;

    public Level levelInfo { private get; set; }

    private void OnEnable()
    {
        playButton.GetComponent<Button>().onClick.AddListener(() => SceneManager.LoadScene(levelInfo.sceneName));
    }
}
