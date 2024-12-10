using UnityEngine;

public class GameAudioController : MonoBehaviour
{
    public AudioClip winClip; // Sonido de victoria
    public AudioClip loseClip; // Sonido de derrota
    public AudioSource backgroundMusic; // AudioSource para la música de fondo
    private AudioSource audioSource;

    void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            Debug.LogError("No se encontró un AudioSource en el GameAudioController.");
        }

        if (backgroundMusic == null)
        {
            Debug.LogWarning("No se asignó un AudioSource para la música de fondo.");
        }
    }

    public void PlayWinSound()
    {
        // Detiene la música de fondo antes de reproducir el sonido de victoria
        if (backgroundMusic != null && backgroundMusic.isPlaying)
        {
            backgroundMusic.Stop();
        }

        if (winClip != null)
        {
            audioSource.PlayOneShot(winClip);
        }
    }

    public void PlayLoseSound()
    {
        // Detiene la música de fondo antes de reproducir el sonido de derrota
        if (backgroundMusic != null && backgroundMusic.isPlaying)
        {
            backgroundMusic.Stop();
        }

        if (loseClip != null)
        {
            audioSource.PlayOneShot(loseClip);
        }
    }
}


