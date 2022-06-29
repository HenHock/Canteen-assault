using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System;

public class DialogPanel : MonoBehaviour
{
    /*
     * Script to controll information on the dialog panel
     * 
     * PARAM:
     * speaker - the name of the person who says something
     * body - directly the text that the speaker says
     * note - some note, for example, when speaker do something and talk, you can use note to show that speaker do something
     * image - image of the speaker
     */

    [SerializeField] private TextMeshProUGUI speaker;
    [SerializeField] private TextMeshProUGUI body;
    [SerializeField] private TextMeshProUGUI note;
    [SerializeField] private Image speakerImage;

    public void ChangeInformation(string speaker, string body, string note, Sprite speakerSprite)
    {
        this.speaker.text = speaker;
        this.body.text = body;
        this.note.text = note;
        speakerImage.sprite = speakerSprite;
    }

    public void ChangeInformation(string speaker, string body, string note)
    {
        this.speaker.text = speaker;
        this.body.text = body;
        this.note.text = note;
    }

    public void ChangeInformation(string speaker, string body)
    {
        this.speaker.text = speaker;
        this.body.text = body;
    }

    public void ChangeInformation(string body)
    {
        this.body.text = body;
    }
}
