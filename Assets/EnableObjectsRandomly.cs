using UnityEngine;
using System.Collections;

public class EnableObjectsRandomly : MonoBehaviour
{
    public GameObject[] objectsToEnable; // Array to hold game objects to be enabled
    private bool triggered = false;
    public AudioSource fadeOutAudioSource;
    public AudioSource fadeInAudioSource;
    public AudioClip fadeInAudioClip;
    public float fadeOutDuration = 1.5f;
    public float fadeInDuration = 1.5f;

    void Start()
    {
        if (fadeOutAudioSource && fadeInAudioSource && fadeInAudioClip)
        {
            // Set the clip to fade in
            fadeInAudioSource.clip = fadeInAudioClip;
            // Start playing the audio
            fadeInAudioSource.Play();
            // Set the initial volume to 0
            fadeInAudioSource.volume = 0;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !triggered) // Check if the trigger collider has been triggered by a GameObject tagged as "Player"
        {
            triggered = true;
            StartCoroutine(EnableObjectsRandomlyCoroutine());
            StartCoroutine(FadeOutAudioCoroutine());
            StartCoroutine(FadeInAudioCoroutine());
        }
    }

    IEnumerator EnableObjectsRandomlyCoroutine()
    {
        yield return new WaitForSeconds(Random.Range(1f, 3f)); // Wait for a random time between 1 to 3 seconds

        // Enable each game object in the array at random times
        foreach (GameObject obj in objectsToEnable)
        {
            obj.SetActive(true);
            yield return new WaitForSeconds(Random.Range(0.1f, 0.5f)); // Random delay between enabling each object
        }
    }

    IEnumerator FadeOutAudioCoroutine()
    {
        // Make sure we have a valid audio source
        if (fadeOutAudioSource != null)
        {
            // Gradually decrease the volume over a period of time
            float startVolume = fadeOutAudioSource.volume;
            float currentTime = 0;

            while (currentTime < fadeOutDuration)
            {
                currentTime += Time.deltaTime;
                fadeOutAudioSource.volume = Mathf.Lerp(startVolume, 0, currentTime / fadeOutDuration);
                yield return null;
            }

            // Make sure the volume is set to 0 when the fade is done
            fadeOutAudioSource.volume = 0;
            // Optionally, stop the audio
            fadeOutAudioSource.Stop();
        }
    }

    IEnumerator FadeInAudioCoroutine()
    {
        // Make sure we have a valid audio source and audio clip
        if (fadeInAudioSource != null && fadeInAudioClip != null)
        {
            // Gradually increase the volume over a period of time
            float currentTime = 0;

            while (currentTime < fadeInDuration)
            {
                currentTime += Time.deltaTime;
                fadeInAudioSource.volume = Mathf.Lerp(0, 0.2f, currentTime / fadeInDuration);
                yield return null;
            }

            // Make sure the volume is set to 1 when the fade is done
            fadeInAudioSource.volume = 0.2f;
        }
    }
}