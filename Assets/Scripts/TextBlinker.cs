using UnityEngine;
using TMPro;

public class TextBlinker : MonoBehaviour
{
    public float blinkInterval = 0.5f; // Tiempo entre parpadeos

    private TextMeshProUGUI tmpText;
    private float timer;

    void Start()
    {
        tmpText = GetComponent<TextMeshProUGUI>();
        if (tmpText == null)
        {
            Debug.LogError("TextBlinker: No se encontró un componente TextMeshProUGUI.");
        }
    }

    void Update()
    {
        if (tmpText == null) return;

        timer += Time.deltaTime;

        if (timer >= blinkInterval)
        {
            tmpText.enabled = !tmpText.enabled;
            timer = 0f;
        }
    }
}
