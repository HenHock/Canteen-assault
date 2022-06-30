using System;
using System.Collections;
using System.Collections.Generic;
using UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EducationController : MonoBehaviour
{
    /*
     * Script for controll left and right dialog panel on the MainMenu scene
     */

    [SerializeField] List<Scenario> Steps;
    [SerializeField] private DialogPanel leftDialogPanel;
    [SerializeField] private DialogPanel rightDialogPanel;
    [SerializeField] private GameObject animatedButton;

    public static int step { set; get; } = 1;

    private void Start()
    {
        OnMouseDown();
    }

    // Called when the player first clicks on the school button.
    public void SchoolEnter()
    {
        if (Steps[2].isNext())
        {
            Phrases phrase = Steps[2].GetNextPhrases();

            bool flag = leftDialogPanel.gameObject.activeInHierarchy;
            leftDialogPanel.gameObject.SetActive(!flag);
            rightDialogPanel.gameObject.SetActive(flag);

            if (!flag)
                leftDialogPanel.ChangeInformation(phrase);
            else rightDialogPanel.ChangeInformation(phrase);
        }
    }

    private void OnMouseDown()
    {
        Phrases phrase = new Phrases();

        switch (step)
        {
            case 1:
                {
                    foreach (AnimationButton animation in animatedButton.GetComponentsInChildren<AnimationButton>())
                            animation.DeactibvateAnimatedButton();

                    animatedButton.GetComponentInChildren<ScaleAnimationButton>()?.gameObject.SetActive(false);

                    if (Steps[step-1].isNext())
                    {
                        phrase = Steps[step-1].GetNextPhrases();


                        bool flag = leftDialogPanel.gameObject.activeInHierarchy;
                        leftDialogPanel.gameObject.SetActive(!flag);
                        rightDialogPanel.gameObject.SetActive(flag);

                        if (!flag)
                            leftDialogPanel.ChangeInformation(phrase);
                        else rightDialogPanel.ChangeInformation(phrase);
                    }
                    else
                    {
                        step++;
                        SceneManager.LoadScene("Level 1");
                    }
                    break;
                }
                case 2:
                {
                    if (Steps[step - 1].isNext())
                    {
                        foreach (AnimationButton animation in animatedButton.GetComponentsInChildren<AnimationButton>())
                            if (!animation.gameObject.name.Equals("SchoolButton"))
                                animation.DeactibvateAnimatedButton();

                        animatedButton.GetComponentInChildren<ScaleAnimationButton>()?.gameObject.SetActive(false);
                        transform.Find("Blur").gameObject.SetActive(false);

                        phrase = Steps[step - 1].GetNextPhrases();

                        bool flag = leftDialogPanel.gameObject.activeInHierarchy;
                        leftDialogPanel.gameObject.SetActive(!flag);
                        rightDialogPanel.gameObject.SetActive(flag);

                        if (!flag)
                            leftDialogPanel.ChangeInformation(phrase);
                        else rightDialogPanel.ChangeInformation(phrase);
                    }
                    break;
                }
            case 3:
                {
                    if (Steps[step].isNext())
                    {
                        UIController.onGetPanel(PanelType.schoolPanel).GetComponent<PanelController>().Close();

                        foreach (AnimationButton animation in animatedButton.GetComponentsInChildren<AnimationButton>()) {
                            if (!animation.gameObject.name.Equals("PlayButton"))
                                animation.DeactibvateAnimatedButton();
                        }

                        animatedButton.GetComponentInChildren<ScaleAnimationButton>()?.gameObject.SetActive(true);

                        phrase = Steps[step].GetNextPhrases();

                        bool flag = leftDialogPanel.gameObject.activeInHierarchy;
                        leftDialogPanel.gameObject.SetActive(!flag);
                        rightDialogPanel.gameObject.SetActive(flag);

                        if (!flag)
                            leftDialogPanel.ChangeInformation(phrase);
                        else rightDialogPanel.ChangeInformation(phrase);
                    }
                    else
                    {
                        step++;
                        SceneManager.LoadScene("Level 2");
                    }
                    break;
                }
            case 4:
                {
                    ES3.Save("IsFirstLaunch", !GlobalApplicationData.IsFirstLaunch);
                    gameObject.SetActive(false);
                    break;
                }
        }
    }
}
