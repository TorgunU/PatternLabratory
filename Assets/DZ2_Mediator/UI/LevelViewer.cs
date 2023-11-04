using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace Assets.Patterns.DZ2_Mediator
{
    public class LevelViewer : MonoBehaviour
    {
        [SerializeField] private TMP_Text _text;

        private const string healthText = "Level :";

        public void OnChanged(int level)
        {
            _text.text = healthText + level;
        }
    }
}