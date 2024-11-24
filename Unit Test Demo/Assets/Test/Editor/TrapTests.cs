using NSubstitute;
using NUnit.Framework;

public class TrapTests
{
    [Test]
    public void PlayerEntering_PlayerTargetedTrap_SpikeTrap_ReducesHealthByOne()
    {
        Trap trap = new Trap();
        ICharacter characterMover = Substitute.For<ICharacter>();
        characterMover.IsPlayer.Returns(true);
        int startingHealth = characterMover.Health;


        trap.HandleCharacterEntered(characterMover, TrapEffectType.Spike, TrapTargetType.Player);

        Assert.AreEqual(startingHealth - 1, characterMover.Health);
    }

    [Test]
    public void PlayerEntering_PlayerTargetedTrap_BombTrap_ReducesHealthByOne()
    {
        Trap trap = new Trap();
        ICharacter characterMover = Substitute.For<ICharacter>();
        characterMover.IsPlayer.Returns(true);

        trap.HandleCharacterEntered(characterMover, TrapEffectType.Bomb, TrapTargetType.Player);

        Assert.AreEqual(0, characterMover.Health);
    }

    [Test]
    public void PlayerEntering_PlayerTargetedTrap_BumperTrap_ReducesHealthByOne()
    {
        Trap trap = new Trap();
        ICharacter characterMover = Substitute.For<ICharacter>();
        characterMover.IsPlayer.Returns(true);
        int startingHealth = characterMover.Health;

        trap.HandleCharacterEntered(characterMover, TrapEffectType.Bumper, TrapTargetType.Player);

        Assert.AreEqual(startingHealth, characterMover.Health);
    }

    [Test]
    public void NpcEntering_NpcTargetedTrap_SpikeTrap_ReducesHealthByOne()
    {
        Trap trap = new Trap();
        ICharacter characterMover = Substitute.For<ICharacter>();
        int startingHealth = characterMover.Health;

        trap.HandleCharacterEntered(characterMover, TrapEffectType.Spike, TrapTargetType.Npc);

        Assert.AreEqual(startingHealth - 1, characterMover.Health);
    }

    [Test]
    public void NpcEntering_NpcTargetedTrap_BombTrap_ReducesHealthByOne()
    {
        Trap trap = new Trap();
        ICharacter characterMover = Substitute.For<ICharacter>();

        trap.HandleCharacterEntered(characterMover, TrapEffectType.Bomb, TrapTargetType.Npc);

        Assert.AreEqual(0, characterMover.Health);
    }

    [Test]
    public void NpcEntering_NpcTargetedTrap_BumperTrap_ReducesHealthByOne()
    {
        Trap trap = new Trap();
        ICharacter characterMover = Substitute.For<ICharacter>();
        int startingHealth = characterMover.Health;

        trap.HandleCharacterEntered(characterMover, TrapEffectType.Bumper, TrapTargetType.Npc);

        Assert.AreEqual(startingHealth, characterMover.Health);
    }
}
