using UnityEngine;

public class TrapBehavior : MonoBehaviour
{
    [SerializeField]
    private TrapTargetType trapType;
    
    private Trap trap;

    private void Awake()
    {
        trap = new Trap();
    }
    private void OnTriggerEnter(Collider other)
    {
        var characterMover = other.GetComponent<CharacterMover>();
        trap.HandleCharacterEntered(characterMover, trapType);
    }
}

public class Trap
{
    public void HandleCharacterEntered(ICharacter characterMover, TrapTargetType trapTargetType)
    {
        if (characterMover.IsPlayer)
        {
            if (trapTargetType == TrapTargetType.Player)
            {
                characterMover.Health--;
            }
        }
        else
        {
            if (trapTargetType == TrapTargetType.Npc)
            {
                characterMover.Health--;
            }
        }
    }
}

public enum TrapTargetType { Player, Npc }