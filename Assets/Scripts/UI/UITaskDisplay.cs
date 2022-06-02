using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class UITaskDisplay : MonoBehaviour
    {
        [SerializeField] private TMP_Text descriptionLabel;
        [SerializeField] private Image icon;
        [SerializeField] private Sprite[] stateSprites;

        public void SetData(string text)
        {
            descriptionLabel.text = text;
        }

        public void UpdateState(bool isComplete)
        {
            icon.sprite = stateSprites[isComplete ? 1 : 0];
        }
    }
}
