using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

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
        string[] scenes = EditorBuildSettings.scenes
             .Where(scene => scene.enabled)
             .Select(scene => scene.path)
             .ToArray();
        Debug.Log(scenes.Length);
        // Все сцена, которые имеют в имени слово level добавляем на сцену
        foreach (string scene in scenes)
            if(regex.IsMatch(scene))
            {
                GameObject newLevelItem = Instantiate(levelItemPrefab);
                newLevelItem.transform.SetParent(transform);
                newLevelItem.GetComponentInChildren<TextMeshProUGUI>().text = levelCount.ToString();
                newLevelItem.GetComponent<Level>().Create(scene, "", "", 0);

                levelCount++;
            }
    }
}
