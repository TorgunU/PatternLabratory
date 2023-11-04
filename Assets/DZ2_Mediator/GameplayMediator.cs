using UnityEngine;

namespace Assets.Patterns.DZ2_Mediator
{
    public class GameplayMediator : MonoBehaviour
    {
        [SerializeField] private Player _player;
        [SerializeField] private HealthViewer _healthViewer;
        [SerializeField] private LevelViewer _levelViewer;
        [SerializeField] private RestartPanel _restartPanel;

        private void Awake()
        {
            _player.HealthChanged += _healthViewer.OnChanged;
            _player.LevelChanged += _levelViewer.OnChanged;
            _player.Died += _restartPanel.OnPlayerDied;
            _restartPanel.Restarted += _player.ResetStats;
        }
    }
}