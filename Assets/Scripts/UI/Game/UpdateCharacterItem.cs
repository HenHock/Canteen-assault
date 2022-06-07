using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UpdateCharacterItem : MonoBehaviour
{
    private GameObject img;
    private GameObject nameCharacter;
    private GameObject updateCharacterButton;
    private TextMeshProUGUI TMP_speedAttack;
    private TextMeshProUGUI TMP_radiusAttack;
    private TextMeshProUGUI TMP_damage;

    [SerializeField] private GameObject description;
    [SerializeField] private GameObject ItemPanel;

    void OnEnable()
    {
        if (transform.childCount > 0)
            Destroy(transform.GetChild(0).gameObject);

        TeacherInfo info = DataManager.selectedCharacter.GetComponent<Character>().GetNextTeacherInfo();

        if (info != null && info.available)
        {
            description.SetActive(false);
            // Create new ItemPanel and fill it with prefab's information.
            GameObject itemPanel = Instantiate(ItemPanel);
            itemPanel.transform.SetParent(transform);

            img = itemPanel.transform.Find("ImageCharacter").gameObject;
            nameCharacter = itemPanel.transform.Find("NameCharacter").gameObject;
            TMP_damage = itemPanel.transform.Find("Damage").GetComponent<TextMeshProUGUI>();
            TMP_speedAttack = itemPanel.transform.Find("SpeedAttack").GetComponent<TextMeshProUGUI>();
            TMP_radiusAttack = itemPanel.transform.Find("RadiusAttack").GetComponent<TextMeshProUGUI>();

            updateCharacterButton = itemPanel.transform.Find("CharacterBuyButton").gameObject;
            updateCharacterButton.GetComponent<CharacterUpdate>().characterPrefab = info.prefab;
            updateCharacterButton.GetComponent<Button>().onClick.AddListener(updateCharacterButton.GetComponent<CharacterUpdate>().onClick);

            if (info.image != null)
                img.GetComponent<Image>().sprite = info.image;

            nameCharacter.GetComponent<TextMeshProUGUI>().text = info.nameTeacher;
            updateCharacterButton.GetComponentInChildren<TextMeshProUGUI>().text = info.costToBuy.ToString();
            TMP_damage.text = info.damage.ToString();
            TMP_speedAttack.text = info.attackSpeed.ToString();
            TMP_radiusAttack.text = info.attackRadius.ToString();
        }
        else
        {
            description.SetActive(true);
        }
    }
}
