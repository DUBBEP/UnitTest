using System.Collections;
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
        Vector3 launchDirection = new Vector3(Random.Range(-1f, 1f), 0.85f, Random.Range(-1f, 1f));
        characterRb.AddForce(launchDirection * bounceForce, ForceMode.Impulse);
        StartCoroutine(pausePlayerMovement(characterMover));
    }

    public void ExecuteReaction(TrapBehavior trapBehavior)
    {
        trapBehavior.gameObject.SetActive(false);
        GameObject particle = Instantiate(explosion, trapBehavior.transform);
        Destroy(particle, 5f);
    }

    IEnumerator pausePlayerMovement(CharacterMover charaterMover)
    {
        charaterMover.canMove = false;
        yield return new WaitForSeconds(1f);
        charaterMover.canMove = true;
    }
}
