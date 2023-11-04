using UnityEngine;

namespace Assets.Patterns.DZ2_Mediator
{
    public class LevelIncreaseZone : MonoBehaviour
    {
        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.TryGetComponent(out Player player))
            {
                player.IncreaseLevel();
            }
        }
    }
}