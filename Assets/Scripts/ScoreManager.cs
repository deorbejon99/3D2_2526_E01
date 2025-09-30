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
        Debug.Log("winwinwin");
        SceneManager.LoadScene("win"); // <-- Carga directamente la escena llamada "win"
    }
}
