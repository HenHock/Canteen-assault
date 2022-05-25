using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public enum PanelType
{
    schoolPanel,
    canteenPanel,
    detailLevelPanel,
};

public class UIController : MonoBehaviour
{
    /*
     * Скрипт для настройки UI элементов в меню.
     */
    [SerializeField] private PanelController schoolPanel;
    [SerializeField] private PanelController canteenPanel;
    [SerializeField] private PanelController detailLevelPanel;
    [SerializeField] private UIDocument UIDocument;
    [SerializeField] private GameObject EventSystem;

    private IDictionary<PanelType, PanelController> panels;

    public static Action<PanelType> onOpenPanel;
    public static Action<PanelType> onClosePanel;
    public static Func<PanelType, GameObject> onGetPanel;

    private void Start()
    {
        panels = new Dictionary<PanelType, PanelController>()
        {
            {PanelType.schoolPanel, schoolPanel},
            {PanelType.canteenPanel, canteenPanel},
            {PanelType.detailLevelPanel, detailLevelPanel},
        };

        foreach(var panel in panels.Values)
            panel.gameObject.SetActive(false);

        onOpenPanel = OpenPanel;
        onClosePanel = ClosePanel;
        onGetPanel = GetGameObjectPanel;

        var root = UIDocument.rootVisualElement;
        Button startButton = root.Q<Button>("button-play");
        startButton.clicked += StartButton_Click;

    }

    private void OpenPanel(PanelType panel)
    {
        panels[panel].Open();
    }

    private void ClosePanel(PanelType panel)
    {
        panels[panel].Close();
    }

    private GameObject GetGameObjectPanel(PanelType panel)
    {
        return panels[panel].gameObject;
    }

    private void StartButton_Click()
    {
        Destroy(UIDocument.gameObject);
        EventSystem.SetActive(true);
    }

}