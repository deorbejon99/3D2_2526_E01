using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadSceneOnDestroy : MonoBehaviour
{
    public string sceneToLoad;
    public bool isPlayer = false; // Solo Player puede cargar escena

    private static bool sceneAlreadyLoaded = false; // Evita conflictos

    private void OnDestroy()
    {
        if (!isPlayer) return; // Solo carga Player
        if (sceneAlreadyLoaded) return; // Evita que otros componentes interfieran
        if (string.IsNullOrEmpty(sceneToLoad)) return;

        sceneAlreadyLoaded = true;

        // Retrasar la carga de la escena un frame para evitar interferencias
        Invoke(nameof(LoadSceneDelayed), 0.01f);
    }

    private void LoadSceneDelayed()
    {
        SceneManager.LoadScene(sceneToLoad);
    }
}
