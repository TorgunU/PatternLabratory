using System;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Patterns.DZ2_Mediator
{
    public class RestartPanel : MonoBehaviour
    {
        [SerializeField] private Button _restartButton;

        public event Action Restarted;

        private void OnEnable()
        {
            _restartButton.onClick.AddListener(OnRestartClicked);
        }

        private void OnDisable()
        {
            _restartButton.onClick.RemoveListener(OnRestartClicked);
        }

        public void OnPlayerDied()
        {
            Show();
        }

        private void Show()
        { 
            gameObject.SetActive(true);
        }

        public void Hide()
        {
            gameObject.SetActive(false);
        }

        private void OnRestartClicked()
        {
            Restarted.Invoke();
            Hide();
        }
    }
}