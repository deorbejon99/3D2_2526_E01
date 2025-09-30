using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerGameOverManager : MonoBehaviour
{
    [Tooltip("Referencia al Player en la escena")]
    public GameObject player;

    [Tooltip("Nombre de la escena Game Over")]
    public string gameOverSceneName = "gameov";

    private bool gameOverTriggered = false;

    void Update()
    {
        // Si el Player ya no existe y aún no se ha cargado GameOver
        if (!gameOverTriggered && player == null)
        {
            gameOverTriggered = true; // Evita múltiples cargas
            SceneManager.LoadScene(gameOverSceneName);
        }
    }
}
