using System.Collections;
using UnityEngine;

internal interface ITrapEffect
{
    void ExecuteEffect(CharacterMover characterMover);

    void ExecuteReaction(TrapBehavior trapBehavior);
}