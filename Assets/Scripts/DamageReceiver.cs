using UnityEngine;

public class DamageReceiver : MonoBehaviour
{
    [Tooltip("Número de impactos antes de destruir el GameObject")]
    public int impactosParaDestruir = 3;

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
        if (other.CompareTag("daño") )
        {
           
            contadorImpactos++;

            int dañoPorGolpe = Mathf.RoundToInt(playerMovement.vidaMaxima / 3f);
            playerMovement.vida -= dañoPorGolpe;
            playerMovement.vida = Mathf.Clamp(playerMovement.vida, 0, playerMovement.vidaMaxima);

            Debug.Log($"Daño recibido: -{dañoPorGolpe}. Vida actual: {playerMovement.vida}. Impactos: {contadorImpactos}/{impactosParaDestruir}");

            Destroy(other.gameObject);

            if (contadorImpactos >= impactosParaDestruir)
            {
                Debug.Log("Se alcanzó el límite de impactos. Destruyendo el GameObject.");
                Destroy(gameObject);
            }
        }
        else if (other.CompareTag("vida"))
        {
            int vidaRecuperada = Mathf.RoundToInt(playerMovement.vidaMaxima / 3f);
            playerMovement.vida += vidaRecuperada;
            playerMovement.vida = Mathf.Clamp(playerMovement.vida, 0, playerMovement.vidaMaxima);

            Debug.Log($"Vida recuperada: +{vidaRecuperada}. Vida actual: {playerMovement.vida}");

            Destroy(other.gameObject); // Opcional: destruye el objeto de vida al recogerlo
        }
    }
}