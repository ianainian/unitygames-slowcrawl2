using UnityEngine;

public class FootstepSounds : MonoBehaviour
{
    public AudioClip[] concreteFootsteps;
    public AudioClip[] grassFootsteps;
    public AudioClip[] woodFootsteps;

    private AudioSource audioSource;
    private CharacterController characterController;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        characterController = GetComponent<CharacterController>();
    }

    private void Update()
    {
        if (characterController.velocity.magnitude > 0 && characterController.isGrounded)
        {
            PlayFootstepSound();
        }
    }

    private void PlayFootstepSound()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, -Vector3.up, out hit, 1.0f))
        {
            Debug.Log("Hit object: " + hit.collider.gameObject.name);

            if (hit.collider.CompareTag("Concrete"))
            {
                Debug.Log("Concrete detected");
                PlayRandomFootstepSound(concreteFootsteps);
            }
            else if (hit.collider.CompareTag("Grass"))
            {
                Debug.Log("Grass detected");
                PlayRandomFootstepSound(grassFootsteps);
            }
            else if (hit.collider.CompareTag("Wood"))
            {
                Debug.Log("Wood detected");
                PlayRandomFootstepSound(woodFootsteps);
            }
        }
    }

    private void PlayRandomFootstepSound(AudioClip[] clips)
    {
        if (clips.Length > 0)
        {
            AudioClip clipToPlay = clips[Random.Range(0, clips.Length)];
            audioSource.PlayOneShot(clipToPlay);
        }
    }
}
