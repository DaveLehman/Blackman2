using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SensorDoors : MonoBehaviour
{
	public AnimationClip clipOpen; // the open animation
	public AnimationClip clipClose; // the close animation


	// open the gates
	void OnTriggerEnter(Collider defender)
	{
		print("Trigger Entered");
		if (defender.gameObject.tag == "Player")
		{
			print("by player");
			GetComponent<Animation>().Play(clipOpen.name);
			GetComponent<AudioSource>().Play(); // play the clip loaded in the audio component	
		}
	}

	// close the gates
	void OnTriggerExit(Collider defender)
	{
		print("Trigger Exited");
		if (defender.gameObject.tag == "Player")
		{
			print("by player");
			GetComponent<Animation>().Play(clipClose.name);
			GetComponent<AudioSource>().Play(); // play the clip loaded in the audio component
		}
	}
}
