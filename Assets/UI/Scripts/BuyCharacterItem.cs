using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class BuyCharacterItem : MonoBehaviour
{
    private int costToBuy;
    private int attackDamage;
    private float radiusHit;
    private float attackSpeed;
    private float startItemPosition = 510;
    private GameObject img;
    private GameObject nameCharacter;
    private GameObject characterSkills;
    private GameObject buyCharacterButton;

    [SerializeField] private GameObject ItemPanel;

    void Start()
    {
        List<GameObject> prefabs = new List<GameObject>();

        // Get all prefabs like gameobject from directory: Assets/Character/Prefabs and add in List
        foreach (var asset in AssetDatabase.FindAssets("t: prefab",new[] { "Assets/Character/Prefabs" }))
        {
            var path = AssetDatabase.GUIDToAssetPath(asset);
            prefabs.Add((GameObject)AssetDatabase.LoadMainAssetAtPath(path));
        }

        if(prefabs.Count > 0)
        {
            foreach (GameObject prefab in prefabs)
            {
                if (prefab.GetComponent<Character>() != null)
                {
                    costToBuy = (int)prefab.GetComponent<Character>().getField(DataManager.CharacterFileds.costToBuy);
                    attackDamage = (int)prefab.GetComponent<Character>().getField(DataManager.CharacterFileds.attackDamage);
                    attackSpeed = prefab.GetComponent<Character>().getField(DataManager.CharacterFileds.attackSpeed);
                    radiusHit = prefab.GetComponent<Character>().getField(DataManager.CharacterFileds.radiusHit);

                    // Create new ItemPanel and fill it with prefab's information.
                    GameObject itemPanel = Instantiate(ItemPanel);
                    itemPanel.transform.SetParent(transform);
                    itemPanel.transform.localPosition = new Vector3(0 , startItemPosition, 0);
                    startItemPosition -= itemPanel.GetComponent<RectTransform>().rect.height;

                    img = itemPanel.transform.Find("ImageCharacter").gameObject;
                    nameCharacter = itemPanel.transform.Find("NameCharacter").gameObject;
                    characterSkills = itemPanel.transform.Find("ÑharacterSkills").gameObject;
                    buyCharacterButton = itemPanel.transform.Find("CharacterBuyButton").gameObject;
                    buyCharacterButton.GetComponent<CharacterSpawn>().characterPrefab = prefab;

                    nameCharacter.GetComponent<Text>().text = prefab.name;
                    buyCharacterButton.GetComponentInChildren<Text>().text = costToBuy.ToString();
                    img.GetComponent<Image>().sprite = prefab.GetComponent<Image>().sprite;
                    characterSkills.GetComponent<Text>().text =
                        $"Damage: {attackDamage}\n" +
                        $"Radius Hit: {radiusHit}\n" +
                        $"Attack Speed: {attackSpeed}\n";
                }
            }
        }
    }
}
