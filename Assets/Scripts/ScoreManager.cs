using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instancia;
    public int puntos = 0;
    public TextMeshProUGUI textoPuntos;

    void Awake()
    {
        if (instancia == null)
        {
            instancia = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void SumarPunto()
    {
        puntos++;
        textoPuntos.text = $"Score: {puntos}";

        if (puntos >= 10)
        {
            CargarEscenaWin();
        }
    }

    void CargarEscenaWin()
    {
        Debug.Log("ScoreManager: vamos a win");

        // Desactivar cualquier LoadSceneOnDestroy que no sea Player
        foreach (var loader in FindObjectsOfType<LoadSceneOnDestroy>())
        {
            if (!loader.isPlayer) loader.enabled = false;
        }

        // Cargar la escena win
        SceneManager.LoadScene("win");
    }
}
