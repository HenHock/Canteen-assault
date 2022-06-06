using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
using UI;

public class LevelDisplay : MonoBehaviour
{
    [SerializeField] private UITaskDisplay firstTaskDisplay;
    [SerializeField] private UITaskDisplay secondTaskDisplay;
    [SerializeField] private GameObject playButton;
    [SerializeField] private GameObject countOfStars;
    [SerializeField] private TextMeshProUGUI title;

    public Level levelInfo { private get; set; }

    private void OnEnable()
    {
        firstTaskDisplay.SetData(levelInfo.task_1.GetTextTask());
        secondTaskDisplay.SetData(levelInfo.task_2.GetTextTask());

        firstTaskDisplay.UpdateState(levelInfo.task_1Finished);
        secondTaskDisplay.UpdateState(levelInfo.task_2Finished);

        title.text = levelInfo.levelID.ToString();
        playButton.GetComponent<Button>().onClick.AddListener(() => SceneManager.LoadScene(levelInfo.sceneName));
    }
}
