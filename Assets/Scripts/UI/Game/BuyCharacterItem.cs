using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BuyCharacterItem : MonoBehaviour
{
    [SerializeField]
    private List<TeacherInfo> teachers;

    private GameObject img;
    private GameObject nameCharacter;
    private GameObject buyCharacterButton;
    private TextMeshProUGUI TMP_speedAttack;
    private TextMeshProUGUI TMP_radiusAttack;
    private TextMeshProUGUI TMP_damage;

    [SerializeField] private GameObject ItemPanel;
    
    //#if UNITY_EDITOR
    void Start()
    {
        foreach (TeacherInfo info in teachers)
        {
            if (info != null)
            {
                // Create new ItemPanel and fill it with prefab's information.
                GameObject itemPanel = Instantiate(ItemPanel);
                itemPanel.transform.SetParent(transform);

                img = itemPanel.transform.Find("ImageCharacter").gameObject;
                nameCharacter = itemPanel.transform.Find("NameCharacter").gameObject;
                TMP_damage = itemPanel.transform.Find("Damage").GetComponent<TextMeshProUGUI>();
                TMP_speedAttack = itemPanel.transform.Find("SpeedAttack").GetComponent <TextMeshProUGUI>();
                TMP_radiusAttack = itemPanel.transform.Find("RadiusAttack").GetComponent<TextMeshProUGUI>();

                buyCharacterButton = itemPanel.transform.Find("CharacterBuyButton").gameObject;
                buyCharacterButton.GetComponent<CharacterSpawn>().characterPrefab = info.prefab;
                buyCharacterButton.GetComponent<Button>().onClick.AddListener(buyCharacterButton.GetComponent<CharacterSpawn>().onClick);

                if (info.image != null)
                    img.GetComponent<Image>().sprite = info.image;

                nameCharacter.GetComponent<TextMeshProUGUI>().text = info.nameTeacher;
                buyCharacterButton.GetComponentInChildren<TextMeshProUGUI>().text = info.costToBuy.ToString();
                TMP_damage.text = info.damage.ToString();
                TMP_speedAttack.text = info.attackSpeed.ToString();
                TMP_radiusAttack.text = info.attackRadius.ToString();
            }
        }
    }
    //#endif
}
