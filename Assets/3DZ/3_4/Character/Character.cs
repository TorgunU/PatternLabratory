using UnityEngine;
namespace Assets.Patterns.DZ_3_4
{
    public class Character : MonoBehaviour
    {
        private CharacterStats _stats;
        private IStatProvider _statProvider;

        public void InjectStats(CharacterStats stats, IStatProvider statProvider)
        {
            _stats = stats;
            _statProvider = statProvider;
        }
    }
}