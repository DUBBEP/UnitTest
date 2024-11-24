using System.Collections;
using UnityEngine;

public class SpikeTrapEffect : MonoBehaviour, ITrapEffect
{
    [SerializeField]
    private float bounceForce;
    public void ExecuteEffect(CharacterMover characterMover)
    {
        Rigidbody characterRb = characterMover.GetComponent<Rigidbody>();
        Renderer characterRenderer = characterMover.GetComponent<Renderer>();
        Color characterMaterialColor = characterRenderer.material.color;
        Vector3 launchDirection = (characterMover.transform.position - transform.position).normalized;
        launchDirection = launchDirection + Vector3.up;
        characterRb.AddForce(launchDirection * bounceForce, ForceMode.Impulse);
        StartCoroutine(pausePlayerMovement(characterMover));
        StartCoroutine(DamageFlash(characterRenderer, characterMaterialColor));
    }

    public void ExecuteReaction(TrapBehavior trapBehavior)
    {

    }

    IEnumerator DamageFlash(Renderer renderer, Color defaultColor)
    {
        renderer.material.color = Color.red;
        yield return new WaitForSeconds(0.5f);
        renderer.material.color = defaultColor;
    }

    IEnumerator pausePlayerMovement(CharacterMover charaterMover)
    {
        charaterMover.canMove = false;
        yield return new WaitForSeconds(1f);
        charaterMover.canMove = true;
    }
}
