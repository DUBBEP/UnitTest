using NSubstitute;
using NUnit.Framework;

public class TrapTests
{
    [Test]
    public void PlayerEntering_PlayerTargetedTrap_ReducesHealthByOne()
    {
        Trap trap = new Trap();
        ICharacter characterMover = Substitute.For<ICharacter>();
        characterMover.IsPlayer.Returns(true);

        trap.HandleCharacterEntered(characterMover, TrapTargetType.Player);
        
        Assert.AreEqual(-1, characterMover.Health);
    }

    [Test]
    public void NpcEntering_NpcTargetedTrap_ReducesHealthByOne()
    {
        Trap trap = new Trap();
        ICharacter characterMover = Substitute.For<ICharacter>();
        
        trap.HandleCharacterEntered(characterMover, TrapTargetType.Npc);
        
        Assert.AreEqual(-1, characterMover.Health);
    }
}
