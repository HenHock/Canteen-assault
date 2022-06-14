using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using System;
using UnityEngine.UI;

public class LevelListGenerator : MonoBehaviour
{
    [SerializeField] private GameObject levelItemPrefab;
    [SerializeField] private GameObject scrollbar;
    private int levelCount = 1;

    private void Start()
    {
        // Регуляроное вырожения для поиска всех сцен, в которых присутсвует слово level 
        Regex regex = new Regex(@"level\w*", RegexOptions.IgnoreCase);

        // Получаем все пути к сценам
        var sceneNumber = SceneManager.sceneCountInBuildSettings;
        string sceneName;

        LevelInfo[] levelsInformation = Resources.LoadAll<LevelInfo>(@"Data/Items/LevelInfo");

        bool ifPrevFinished = false;
        
        for (int i = 0; i < sceneNumber; i++)
        {
            sceneName = System.IO.Path.GetFileNameWithoutExtension(SceneUtility.GetScenePathByBuildIndex(i));

            // Все сцена, которые имеют в имени слово level добавляем на сцену
            if (regex.IsMatch(sceneName))
            {
                GameObject newLevelItem = Instantiate(levelItemPrefab);
                newLevelItem.transform.SetParent(transform);
                newLevelItem.GetComponentInChildren<TextMeshProUGUI>().text = levelCount.ToString();
                int index = Array.FindIndex(levelsInformation, x => x.sceneName.Equals(sceneName));
                if (index != -1)
                {
                    Debug.Log("d");
                    newLevelItem.GetComponent<Level>().Create(levelsInformation[index], ifPrevFinished, levelsInformation[index].finished, levelCount);
                    newLevelItem.transform.GetChild(1).GetComponent<Image>().sprite = StarsIcon.GetIcon(levelsInformation[index].countStarsRecieved);
                    ifPrevFinished = levelsInformation[index].finished;
                }
                levelCount++;
            }
        }

        StartCoroutine(resetScrollPos());
    }

    IEnumerator resetScrollPos()
    {
        yield return null; // Waiting just one frame is probably good enough, yield return null does that
        scrollbar.GetComponent<Scrollbar>().value = 1;
    }
}
