using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameUI : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI healthText;

    public static GameUI instance;

    private void Awake() { instance = this; }

    public void UpdateHealthText(CharacterMover characterMover)
    {
        healthText.text = "Health: " + characterMover.Health.ToString();
    }

    public void OnReset()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
