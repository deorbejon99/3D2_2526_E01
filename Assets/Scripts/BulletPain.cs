using UnityEngine;

public class BulletPain : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("punto"))
        {
            ScoreManager.instancia.SumarPunto();
            Destroy(other.gameObject); // Opcional: destruye el objeto de punto
            Destroy(gameObject);       // Opcional: destruye la bala tras impactar
        }
    }
}
