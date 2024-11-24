using System.Collections;
using UnityEngine;

public class BumperTrapEffect : MonoBehaviour, ITrapEffect
{
    [SerializeField]
    private float bounceForce;
    public void ExecuteEffect(CharacterMover characterMover)
    {
        Rigidbody characterRb = characterMover.GetComponent<Rigidbody>();
        Vector3 launchDirection = new Vector3(Random.Range(-1f, 1f), 0.95f, Random.Range(-1f, 1f));
        characterRb.AddForce(launchDirection * bounceForce, ForceMode.Impulse);
        StartCoroutine(pausePlayerMovement(characterMover));
    }

    public void ExecuteReaction(TrapBehavior trapBehavior)
    {
        StartCoroutine(BumperBounce(trapBehavior.transform));
    }

    IEnumerator BumperBounce(Transform bumper)
    {
        Vector3 defaultScale = bumper.localScale;
        bumper.localScale = defaultScale * 1.5f;
        yield return new WaitForSeconds(0.1f);
        bumper.localScale = defaultScale;
    }

    IEnumerator pausePlayerMovement(CharacterMover charaterMover)
    {
        charaterMover.canMove = false;
        yield return new WaitForSeconds(1f);
        charaterMover.canMove = true;
    }
}
