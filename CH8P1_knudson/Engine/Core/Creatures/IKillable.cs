namespace Engine.Core.Creatures
{
    public interface IKillable
    {
        bool IsAlive();

        void TakeDamage(int damage);

    }
}
