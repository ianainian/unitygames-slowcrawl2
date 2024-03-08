using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerDoorController : MonoBehaviour
{
	[SerializeField] private Animator myDoor = null;
	public AudioSource playSound;

	[SerializeField] private bool openTrigger = false;
	[SerializeField] private bool closeTrigger = false;

	private void OnTriggerEnter(Collider other)
	{
		playSound.Play();
		
		if(other.CompareTag("Player"))
		{
			if(openTrigger)
			{
				myDoor.Play("DoorOpen", 0, 0.0f);
				gameObject.SetActive(false);
			}
			
			if(closeTrigger)
			{
				myDoor.Play("DoorClose", 0, 0.0f);
				gameObject.SetActive(false);
			}
		}

	}
}
