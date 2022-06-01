using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class LevelListGenerator : MonoBehaviour
{
    [SerializeField] private GameObject levelItemPrefab;
    private Vector2 startPosition = new Vector2(-290, 360);
    private int levelCount = 1;

    private void Start()
    {
        // Регуляроное вырожения для поиска всех сцен, в которых присутсвует слово level 
        Regex regex = new Regex(@"level\w*", RegexOptions.IgnoreCase);

        // Получаем все пути к сценам
        var sceneNumber = SceneManager.sceneCountInBuildSettings;
        string sceneName;
        for (int i = 0; i < sceneNumber; i++)
        {
            sceneName = System.IO.Path.GetFileNameWithoutExtension(SceneUtility.GetScenePathByBuildIndex(i));

            // Все сцена, которые имеют в имени слово level добавляем на сцену
            if (regex.IsMatch(sceneName))
            {
                GameObject newLevelItem = Instantiate(levelItemPrefab);
                newLevelItem.transform.SetParent(transform);
                newLevelItem.GetComponentInChildren<TextMeshProUGUI>().text = levelCount.ToString();
                newLevelItem.GetComponent<Level>().Create(sceneName, "", "", 0);

                levelCount++;
            }
        }
    }
}
