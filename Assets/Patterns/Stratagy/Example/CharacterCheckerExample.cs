using System.Collections.Generic;
using UnityEngine;

namespace Assets.Patterns.Stratagy.Example
{
    public class CharacterCheckerExample : MonoBehaviour
    {
        [SerializeField] private Orc _orc;
        [SerializeField] private List<Human> humans;

        private void Awake()
        {
            foreach (Human human in humans)
            {
                human.Init(new NoViewPattern());
            }

            _orc.Init(new SearchGroundPattern(_orc.transform, 5));
        }

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.yellow;
            Gizmos.DrawWireSphere(_orc.transform.position, 5);
        }

    }
}