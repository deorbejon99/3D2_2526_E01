using UnityEngine;
using UnityEngine.SceneManagement;

public class CambiarEscena : MonoBehaviour
{
    public string nombreDeLaEscena;

    public void CambiarEscenaPorNombre()
    {
        SceneManager.LoadScene(nombreDeLaEscena);
    }
}
