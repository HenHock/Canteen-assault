using System;
using System.Collections.Generic;
using UI;
using UnityEngine;

public enum PanelType
{
    schoolPanel,
    canteenPanel,
    detailLevelPanel,
    confirmPanel,
    messageBoxPanel
};

public class UIController : MonoBehaviour
{
    /*
     * Скрипт для настройки UI элементов в меню.
     */
    [SerializeField] private PanelController schoolPanel;
    [SerializeField] private PanelController canteenPanel;
    [SerializeField] private PanelController detailLevelPanel;
    [SerializeField] private PanelController confirmPanel;
    [SerializeField] private PanelController messageBoxPanel;
    [SerializeField] private GameObject Blur;
    [SerializeField] private GameObject educationCanvas;

    private IDictionary<PanelType, PanelController> panels;

    public static Action<PanelType> onOpenPanel;
    public static Action<bool> onBlurAction;
    public static Action<PanelType> onClosePanel;
    public static Func<PanelType, GameObject> onGetPanel;

    public void SetBlurActivety(bool flag)
    {
        Blur.SetActive(flag);
    }

    private void Start()
    {
        educationCanvas.SetActive(GlobalApplicationData.IsFirstLaunch);
    }

    private void Awake()
    {
        Blur.SetActive(false);

        panels = new Dictionary<PanelType, PanelController>()
        {
            {PanelType.schoolPanel, schoolPanel},
            {PanelType.canteenPanel, canteenPanel},
            {PanelType.detailLevelPanel, detailLevelPanel},
            {PanelType.confirmPanel, confirmPanel},
            {PanelType.messageBoxPanel, messageBoxPanel},
        };

        foreach(var panel in panels.Values)
            panel.gameObject.SetActive(false);

        onOpenPanel = OpenPanel;
        onClosePanel = ClosePanel;
        onGetPanel = GetGameObjectPanel;
        onBlurAction = SetBlurActivety;
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
}