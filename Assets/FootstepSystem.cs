using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootstepSystem : MonoBehaviour
{
	public AudioSource AudioSource;
	
	public AudioClip concrete;
	public AudioClip metal;
	public AudioClip wood;
	
	RaycastHit hit;
	public Transform RayStart;
	public float range;
	public LayerMask layerMask;
	
	
	public void Footstep()
	{
		if(Physics.Raycast(RayStart.position, Vector3.down, out hit, range, layerMask))
		{
			if (hit.collider.CompareTag("concrete"))
			{
				PlayFootstepSoundL(concrete);
				Debug.Log("Walking on concrete.");
			}
			if (hit.collider.CompareTag("metal"))
			{
				PlayFootstepSoundL(metal);
				Debug.Log("Walking on metal.");
			}
			if (hit.collider.CompareTag("wood"))
			{
				PlayFootstepSoundL(wood);
				Debug.Log("Walking on wood.");
			}
			
		}
		
	}
	
	void PlayFootstepSoundL(AudioClip audio)
	{
		AudioSource.pitch = Random.Range(0.8f, 1f);
		AudioSource.PlayOneShot(audio);
	}
	
	private void Update()
	{
		Debug.DrawRay(RayStart.position, RayStart.transform.up * range * -1, Color.green);
	}
}