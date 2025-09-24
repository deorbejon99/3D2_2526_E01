using TMPro;
using UnityEngine;

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
    }
}
