using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace Assets.Patterns.DZ2_Mediator
{
    public class HealthViewer : MonoBehaviour
    {
        [SerializeField] private TMP_Text _text;

        private const string healthText = "Health :";

        public void SetText(float healthV)
        {
            _text.text = healthText + healthV;
        }
    }
}