using UnityEngine;

namespace Assets.Patterns.DZ_3_4
{
    public class Bootstrapper : MonoBehaviour
    {
        [SerializeField] private Character _character;

        private void Awake()
        {
            CreateRandomCharater();
        }

        private void CreateRandomCharater()
        {
            CharacterStats stats = new CharacterStats(new Strength(5), new Agility(5), new Intelligent(5));

            Debug.Log("Before:" + stats.ToString());

            IStatProvider statProvider = new RaceProvider(stats, (RaceType)Random.Range(0, 3));
            statProvider = new SpecializationProvider(statProvider, (SpecializationType)Random.Range(0, 3));
            statProvider = new PassiveAbillityProvider(statProvider, (PassiveAbillityType)Random.Range(0, 3));

            stats = statProvider.GetCharacterStats();
            _character.InjectStats(stats, statProvider);

            Debug.Log("After: " + stats.ToString());
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                CreateRandomCharater();
            }
        }
    }
}