using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EducationMainMenuController : MonoBehaviour
{
    /*
     * Script for controll left and right dialog panel on the MainMenu scene
     */

    public enum speakersSprite{
        kitchener,
        chimie,
        students,
        lit_teacher
    }

    [Serializable]
    public struct speakerSprites
    {
        public speakersSprite speaker;
        public Sprite sprite;
    }

    [SerializeField] private List<speakerSprites> _speakerSprites;
    [SerializeField] private DialogPanel leftDialogPanel;
    [SerializeField] private DialogPanel rightDialogPanel;
    [SerializeField] private int countOfSteps = 0;

    private int step;

    private void Start()
    {
        step = 1;
    }

    private void OnMouseDown()
    {
        if (step < countOfSteps)
        {
            step++;
            switch (step)
            {
                case 1:
                    {
                        leftDialogPanel.ChangeInformation("Kitchener", "Pum-purum-pum-pum...", "*decorates the cake*", _speakerSprites.Find(e => e.speaker == speakersSprite.kitchener).sprite);
                        break;
                    }
                case 2:
                    {
                        rightDialogPanel.ChangeInformation("Literature teacher:", "The director will definitely love his birthday cake!", "", _speakerSprites.Find(e => e.speaker == speakersSprite.lit_teacher).sprite);
                        break;
                    }
                case 3:
                    {
                        leftDialogPanel.ChangeInformation("Chimie", "Do you here it?", "", _speakerSprites.Find(e => e.speaker == speakersSprite.chimie).sprite);
                        break;
                    }
                case 4:
                    {
                        rightDialogPanel.ChangeInformation("Students", "Ca-a-ke!", "", _speakerSprites.Find(e => e.speaker == speakersSprite.students).sprite);
                        break;
                    }
                case 5:
                    {
                        leftDialogPanel.ChangeInformation("Literature teacher", "Oh no! They'll ruin our present!", "", _speakerSprites.Find(e => e.speaker == speakersSprite.lit_teacher).sprite);
                        break;
                    }
                case 6:
                    {
                        rightDialogPanel.ChangeInformation("Kitchener", "This cannot be allowed.", "", _speakerSprites.Find(e => e.speaker == speakersSprite.kitchener).sprite);
                        break;
                    }
                case 7:
                    {
                        leftDialogPanel.ChangeInformation("Chimie", "To the defense!", "", _speakerSprites.Find(e => e.speaker == speakersSprite.chimie).sprite);
                        break;
                    }
            }

            bool flag = leftDialogPanel.gameObject.activeInHierarchy;
            rightDialogPanel.gameObject.SetActive(flag);
            leftDialogPanel.gameObject.SetActive(!flag);
        }
        else SceneManager.LoadScene("Level 1");
    }
}
