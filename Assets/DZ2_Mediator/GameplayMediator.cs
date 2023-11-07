using UnityEngine;
using Zenject;

namespace Assets.Patterns.DZ2_Mediator
{
    public class GameplayMediator
    {
        private HealthViewer _healthViewer;
        private LevelViewer _levelViewer;
        private RestartPanel _restartPanel;
        private Player _player;

        [Inject]
        private void Construct(Player player, HealthViewer healthViewer, LevelViewer levelViewer,
            RestartPanel restartPanel)
        {
            _player = player;
            _healthViewer = healthViewer;
            _levelViewer = levelViewer;
            _restartPanel = restartPanel;

            _player.Died += OnPlayerDied;
            _player.HealthChanged += _healthViewer.OnChanged;
            _player.LevelChanged += _levelViewer.OnChanged;
        }

        private void OnDisable()
        {
            _player.Died += OnPlayerDied;
            _player.HealthChanged += _healthViewer.OnChanged;
            _player.LevelChanged += _levelViewer.OnChanged;
        }

        public void RestartLevel()
        {
            _restartPanel.Hide();
            _player.ResetStats();
        }

        private void OnPlayerDied()
        {
            _restartPanel.Show();
        }
    }
}