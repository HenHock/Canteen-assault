using System.Collections;
using System.Collections.Generic;
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

    [SerializeField] private GameObject ItemPanel;

    void OnEnable()
    {
        startItemPosition = 510;
        GameObject prefab = DataManager.selectedCharacter.GetComponent<Character>().nextLevelPrefab;

        if (prefab != null)
        {
            costToUpgrade = DataManager.selectedCharacter.GetComponent<Character>().costToUpgrade;
            attackDamage = (int)prefab.GetComponent<Character>().attackDamage;
            attackSpeed = prefab.GetComponent<Character>().attackSpeed;
            radiusHit = prefab.GetComponent<Character>().radiusHit;

            // Create new ItemPanel and fill it with prefab's information.
            GameObject itemPanel = Instantiate(ItemPanel);
            itemPanel.transform.SetParent(transform);
            itemPanel.transform.localPosition = new Vector3(0, startItemPosition, 0);
            startItemPosition -= itemPanel.GetComponent<RectTransform>().rect.height;

            img = itemPanel.transform.Find("ImageCharacter").gameObject;
            nameCharacter = itemPanel.transform.Find("NameCharacter").gameObject;
            characterSkills = itemPanel.transform.Find("ÑharacterSkills").gameObject;
            updateCharacterButton = itemPanel.transform.Find("CharacterBuyButton").gameObject;
            updateCharacterButton.GetComponent<CharacterUpdate>().characterPrefab = prefab;
            updateCharacterButton.GetComponent<Button>().onClick.AddListener(updateCharacterButton.GetComponent<CharacterUpdate>().onClick);

            if (prefab.GetComponent<Image>() != null)
                img.GetComponent<Image>().sprite = prefab.GetComponent<Image>().sprite;
            nameCharacter.GetComponent<Text>().text = prefab.name;
            updateCharacterButton.GetComponentInChildren<Text>().text = costToUpgrade.ToString();
            characterSkills.GetComponent<Text>().text =
                $"Damage: {attackDamage}\n" +
                $"Radius Hit: {radiusHit}\n" +
                $"Attack Speed: {attackSpeed}\n";
        }
    }
}
