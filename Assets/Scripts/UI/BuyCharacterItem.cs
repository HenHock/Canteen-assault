using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class BuyCharacterItem : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> prefabs;

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
    
    //#if UNITY_EDITOR
    void Start()
    {
        if (prefabs.Count > 0)
        {
            foreach (GameObject prefab in prefabs)
            {
                if (prefab.GetComponent<Character>() != null)
                {
                    costToBuy = prefab.GetComponent<Character>().costToBuy;
                    attackDamage = prefab.GetComponent<Character>().attackDamage;
                    attackSpeed = prefab.GetComponent<Character>().attackSpeed;
                    radiusHit = prefab.GetComponent<Character>().radiusHit;

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
                    buyCharacterButton.GetComponent<Button>().onClick.AddListener(buyCharacterButton.GetComponent<CharacterSpawn>().onClick);

                    if (prefab.GetComponent<Image>() != null)
                        img.GetComponent<Image>().sprite = prefab.GetComponent<Image>().sprite;
                    nameCharacter.GetComponent<Text>().text = prefab.name;
                    buyCharacterButton.GetComponentInChildren<Text>().text = costToBuy.ToString();
                    characterSkills.GetComponent<Text>().text =
                        $"Damage: {attackDamage}\n" +
                        $"Radius Hit: {radiusHit}\n" +
                        $"Attack Speed: {attackSpeed}\n";
                }
            }
        }
        else Debug.Log("Did not find any more in Assets/Character/Prefabs/ Level 1.");
    }
    //#endif
}
