using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadSceneOnDestroy : MonoBehaviour
{
    [Tooltip("Nombre de la escena a cargar cuando este objeto sea destruido.")]
    public string sceneToLoad;

    private void OnDestroy()
    {
        // Verifica que se haya especificado una escena v�lida
        if (!string.IsNullOrEmpty(sceneToLoad))
        {
            // Carga la escena
            SceneManager.LoadScene(sceneToLoad);
        }
        else
        {
            Debug.LogWarning("No se ha especificado el nombre de la escena a cargar.");
        }
    }
}
