using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class BombTrapEffect : MonoBehaviour, ITrapEffect
{
    [SerializeField]
    private float bounceForce;
    [SerializeField]
    private GameObject explosion;
    public void ExecuteEffect(CharacterMover characterMover)
    {
        Rigidbody characterRb = characterMover.GetComponent<Rigidbody>();
        Vector3 launchDirection = (characterMover.transform.position - transform.position).normalized;
        launchDirection = launchDirection + Vector3.up;
        characterRb.AddForce(launchDirection * bounceForce, ForceMode.Impulse);
        StartCoroutine(pausePlayerMovement(characterMover));
    }

    public void ExecuteReaction(TrapBehavior trapBehavior)
    {
        trapBehavior.gameObject.SetActive(false);
        GameObject particle = Instantiate(explosion, trapBehavior.transform.position, Quaternion.identity);
    }

    IEnumerator pausePlayerMovement(CharacterMover charaterMover)
    {
        charaterMover.canMove = false;
        yield return new WaitForSeconds(1f);
        charaterMover.canMove = true;
    }
}
