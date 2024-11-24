using UnityEngine;

public class TrapBehavior : MonoBehaviour
{
    [SerializeField]
    private TrapTargetType trapTargetType;
    [SerializeField]
    private TrapEffectType trapEffectType;
    [SerializeField]
    private ITrapEffect trapEffect;

    private Trap trap;

    private void Awake()
    {
        trap = new Trap();
        trapEffect = GetComponent<ITrapEffect>();
    }
    private void OnTriggerEnter(Collider other)
    {
        var characterMover = other.GetComponent<CharacterMover>();
        trap.HandleCharacterEntered(characterMover, trapEffectType, trapTargetType);
        trapEffect.ExecuteEffect(characterMover);
        trapEffect.ExecuteReaction(this);
    }
}

public class Trap
{
    public void HandleCharacterEntered(ICharacter characterMover, TrapEffectType trapEffectType, TrapTargetType trapTargetType)
    {
        if (characterMover.IsPlayer && trapTargetType == TrapTargetType.Player)
        {
            EvaluateEffectType(characterMover, trapEffectType);
        }
        else
        {
            if (trapTargetType == TrapTargetType.Npc)
            {
                EvaluateEffectType(characterMover, trapEffectType);
            }
        }
    }

    void EvaluateEffectType(ICharacter characterMover, TrapEffectType trapEffectType)
    {
        switch (trapEffectType)
        {
            case TrapEffectType.Spike:
                characterMover.Health--;
                characterMover.CheckHealth();
                break;
            case TrapEffectType.Bumper:

                break;
            case TrapEffectType.Bomb:
                characterMover.Health = 0;
                characterMover.CheckHealth();
                break;
        }
    }
}

public enum TrapTargetType { Player, Npc }
public enum TrapEffectType { Spike, Bumper, Bomb }