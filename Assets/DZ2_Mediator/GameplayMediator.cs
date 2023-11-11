using System;
using UnityEngine;
using Zenject;

namespace Assets.Patterns.DZ2_Mediator
{
    public class GameplayMediator : IDisposable
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
            _player.HealthChanged += OnHealthChanged;
            _player.LevelChanged += OnLevelChanged;
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

        private void OnHealthChanged(float health)
        {
            _healthViewer.SetText(health);
        }

        private void OnLevelChanged(int level)
        {
            _levelViewer.SetText(level);
        }

        public void Dispose()
        {
            _player.Died -= OnPlayerDied;
            _player.HealthChanged -= OnHealthChanged;
            _player.LevelChanged -= OnLevelChanged;
        }
    }
}