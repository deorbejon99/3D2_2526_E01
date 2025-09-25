using UnityEngine;

public class DamageReceiver : MonoBehaviour
{
    [Tooltip("Número de impactos antes de destruir el GameObject")]
    public int impactosParaDestruir = 20;

    private int contadorImpactos = 0;
    private PlayerMovement playerMovement;

    void Start()
    {
        playerMovement = GetComponent<PlayerMovement>();

        if (playerMovement == null)
        {
            Debug.LogError("No se encontró el componente PlayerMovement en este GameObject.");
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("daño"))
        {
            // Aumenta el contador de impactos
            contadorImpactos++;

            // Daño proporcional a la cantidad de impactos
            int dañoPorGolpe = Mathf.RoundToInt(playerMovement.vidaMaxima / (float)impactosParaDestruir);
            playerMovement.vida -= dañoPorGolpe;
            playerMovement.vida = Mathf.Clamp(playerMovement.vida, 0, playerMovement.vidaMaxima);

            Debug.Log($"[Daño] Recibido: -{dañoPorGolpe}. Vida: {playerMovement.vida}. Impactos: {contadorImpactos}/{impactosParaDestruir}");

            // Destruye el proyectil inmediatamente
            Destroy(other.gameObject);

            // Comprueba si debe destruirse el objeto
            if (contadorImpactos >= impactosParaDestruir || playerMovement.vida <= 0)
            {
                Debug.Log("Destruido por impactos o por quedarse sin vida.");
                Destroy(gameObject);
            }
        }
        else if (other.CompareTag("vida"))
        {
            int vidaRecuperada = Mathf.RoundToInt(playerMovement.vidaMaxima / (float)impactosParaDestruir);
            playerMovement.vida += vidaRecuperada;
            playerMovement.vida = Mathf.Clamp(playerMovement.vida, 0, playerMovement.vidaMaxima);

            Debug.Log($"[Vida] Recuperada: +{vidaRecuperada}. Vida actual: {playerMovement.vida}");

            Destroy(other.gameObject);
        }
    }
}
