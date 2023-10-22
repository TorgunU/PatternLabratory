
namespace Assets.Patterns.Stratagy.Example
{
    public interface IMover
    {
        void StartMove();
        void StopMove();
        void UpdateTarget(float deltaTime);
    }
}