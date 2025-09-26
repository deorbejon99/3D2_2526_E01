using UnityEngine;

public class PlaySoundOnDestroy : MonoBehaviour
{
    public AudioClip destroyClip;
    public float volume = 1f;

    private static GameObject audioPlayer;

    private void OnDestroy()
    {
        if (destroyClip == null) return;

        // Crear un objeto temporal si no existe
        if (audioPlayer == null)
        {
            audioPlayer = new GameObject("TempAudioPlayer");
            DontDestroyOnLoad(audioPlayer); // Para evitar que se destruya al cambiar de escena
            audioPlayer.AddComponent<AudioSource>();
        }

        // Configurar y reproducir el audio
        AudioSource source = audioPlayer.GetComponent<AudioSource>();
        source.clip = destroyClip;
        source.volume = volume;
        source.Play();
    }
}
