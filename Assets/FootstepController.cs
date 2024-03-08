using UnityEngine;

public class FootstepController : MonoBehaviour
{
    public AudioClip defaultFootstepSound;
    public AudioClip woodFootstepSound;
    public AudioClip metalFootstepSound;
    public AudioClip grassFootstepSound;

    private AudioSource audioSource;
    private float raycastDistance = 0.1f; // Adjust this based on your player's height

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        // Cast a ray downwards to detect the ground
        RaycastHit hit;
        if (Physics.Raycast(transform.position, Vector3.down, out hit, raycastDistance))
        {
            // Debug.DrawRay to visualize the raycast
            Debug.DrawRay(transform.position, Vector3.down * raycastDistance, Color.green);

            // Check the material of the ground
            if (hit.collider.CompareTag("Wood"))
            {
                PlayFootstepSound(woodFootstepSound);
                Debug.Log("Walking on wood.");
            }
            else if (hit.collider.CompareTag("Grass"))
            {
                PlayFootstepSound(grassFootstepSound);
                Debug.Log("Walking on grass.");
            }
            else
            {
                // If no specific material is matched, play the default footstep sound
                PlayFootstepSound(defaultFootstepSound);
                Debug.Log("Walking on unknown material.");
            }
        }
    }

    private void PlayFootstepSound(AudioClip footstepSound)
    {
        if (footstepSound != null)
        {
            audioSource.clip = footstepSound;
            audioSource.Play();
        }
    }
}
