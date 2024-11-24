public interface ICharacter
{
    int Health { get; set; }
    bool IsPlayer { get; }

    void CheckHealth();
}