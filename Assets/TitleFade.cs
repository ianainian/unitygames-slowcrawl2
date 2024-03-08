using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CanvasFader : MonoBehaviour
{
    public CanvasGroup canvasGroup;
    public float fadeDelay = 3f; // Delay before starting to fade
    public float fadeDuration = 2f; // Duration of fading
    public float displayDuration = 5f; // Duration to display the canvas

    private IEnumerator Start()
    {
        yield return new WaitForSeconds(fadeDelay);

        // Fade in
        yield return FadeCanvas(canvasGroup, 1f, fadeDuration);

        // Wait for display duration
        yield return new WaitForSeconds(displayDuration);

        // Fade out
        yield return FadeCanvas(canvasGroup, 0f, fadeDuration);
    }

    private IEnumerator FadeCanvas(CanvasGroup canvasGroup, float targetAlpha, float duration)
    {
        float startAlpha = canvasGroup.alpha;
        float startTime = Time.time;

        while (Time.time - startTime < duration)
        {
            float percentage = (Time.time - startTime) / duration;
            canvasGroup.alpha = Mathf.Lerp(startAlpha, targetAlpha, percentage);
            yield return null;
        }

        canvasGroup.alpha = targetAlpha;
    }
}
