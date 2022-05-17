using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

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
    private TextMeshProUGUI TMP_speedAttack;
    private TextMeshProUGUI TMP_radiusAttack;
    private TextMeshProUGUI TMP_damage;

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
                    characterSkills = itemPanel.transform.Find("CharacterSkills").gameObject;
                    TMP_damage = characterSkills.transform.Find("Damage").GetComponent<TextMeshProUGUI>();
                    TMP_speedAttack = characterSkills.transform.Find("SpeedAttack").GetComponent <TextMeshProUGUI>();
                    TMP_radiusAttack = characterSkills.transform.Find("RadiusAttack").GetComponent<TextMeshProUGUI>();

                    buyCharacterButton = itemPanel.transform.Find("CharacterBuyButton").gameObject;
                    buyCharacterButton.GetComponent<CharacterSpawn>().characterPrefab = prefab;
                    buyCharacterButton.GetComponent<Button>().onClick.AddListener(buyCharacterButton.GetComponent<CharacterSpawn>().onClick);

                    if (prefab.GetComponent<Image>() != null)
                        img.GetComponent<Image>().sprite = prefab.GetComponent<Image>().sprite;
                    nameCharacter.GetComponent<Text>().text = prefab.name;
                    buyCharacterButton.GetComponentInChildren<Text>().text = costToBuy.ToString();
                    TMP_damage.text = attackDamage.ToString();
                    TMP_speedAttack.text = attackSpeed.ToString();
                    TMP_radiusAttack.text = radiusHit.ToString();
                }
            }
        }
    }
    //#endif
}
