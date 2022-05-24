using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UpdateCharacterItem : MonoBehaviour
{
    private int level;
    private int costToUpgrade;
    private int attackDamage;
    private float radiusHit;
    private float attackSpeed;
    private float startItemPosition;
    private GameObject img;
    private GameObject nameCharacter;
    private GameObject characterSkills;
    private GameObject updateCharacterButton;
    private TextMeshProUGUI TMP_speedAttack;
    private TextMeshProUGUI TMP_radiusAttack;
    private TextMeshProUGUI TMP_damage;

    [SerializeField] private GameObject ItemPanel;

    void OnEnable()
    {
        if (transform.childCount > 0)
            Destroy(transform.GetChild(0).gameObject);

        startItemPosition = 510;
        GameObject prefab = DataManager.selectedCharacter.GetComponent<Character>().nextLevelPrefab;


        if (prefab != null)
        {
            costToUpgrade = DataManager.selectedCharacter.GetComponent<Character>().costToUpgrade;
            attackDamage = prefab.GetComponent<Character>().attackDamage;
            attackSpeed = prefab.GetComponent<Character>().attackSpeed;
            radiusHit = prefab.GetComponent<Character>().radiusHit;

            // Create new ItemPanel and fill it with prefab's information.
            GameObject itemPanel = Instantiate(ItemPanel);
            itemPanel.transform.SetParent(transform);
            itemPanel.transform.localPosition = new Vector3(0, startItemPosition, 0);
            startItemPosition -= itemPanel.GetComponent<RectTransform>().rect.height;

            img = itemPanel.transform.Find("ImageCharacter").gameObject;
            nameCharacter = itemPanel.transform.Find("NameCharacter").gameObject;
            updateCharacterButton = itemPanel.transform.Find("CharacterBuyButton").gameObject;
            TMP_damage = itemPanel.transform.Find("Damage").GetComponent<TextMeshProUGUI>();
            TMP_speedAttack = itemPanel.transform.Find("SpeedAttack").GetComponent<TextMeshProUGUI>();
            TMP_radiusAttack = itemPanel.transform.Find("RadiusAttack").GetComponent<TextMeshProUGUI>();
            updateCharacterButton.GetComponent<CharacterUpdate>().characterPrefab = prefab;
            updateCharacterButton.GetComponent<Button>().onClick.AddListener(updateCharacterButton.GetComponent<CharacterUpdate>().onClick);

            if (prefab.GetComponent<Image>() != null)
                img.GetComponent<Image>().sprite = prefab.GetComponent<Image>().sprite;
            nameCharacter.GetComponent<TextMeshProUGUI>().text = prefab.name;
            updateCharacterButton.GetComponentInChildren<TextMeshProUGUI>().text = costToUpgrade.ToString();
            TMP_damage.text = attackDamage.ToString();
            TMP_speedAttack.text = attackSpeed.ToString();
            TMP_radiusAttack.text = radiusHit.ToString();
        }
    }
}
