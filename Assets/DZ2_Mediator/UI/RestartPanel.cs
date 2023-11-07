using System;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Assets.Patterns.DZ2_Mediator
{
    public class RestartPanel : MonoBehaviour
    {
        [SerializeField] private Button _restartButton;

        private GameplayMediator _mediator;

        [Inject]
        public void Construct(GameplayMediator mediator)
        {
            _mediator = mediator;
        }

        private void OnEnable()
        {
            _restartButton.onClick.AddListener(OnRestartClicked);
        }

        private void OnDisable()
        {
            _restartButton.onClick.RemoveListener(OnRestartClicked);
        }

        public void Show()
        { 
            gameObject.SetActive(true);
        }

        public void Hide()
        {
            gameObject.SetActive(false);
        }

        private void OnRestartClicked()
        {
            _mediator.RestartLevel();
        }
    }
}