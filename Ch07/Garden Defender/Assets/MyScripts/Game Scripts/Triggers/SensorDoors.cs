using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SensorDoors : MonoBehaviour
{
	public AnimationClip clipOpen; // the open animation
	public AnimationClip clipClose; // the close animation

	public bool debug = true;

    private void Awake()
    {
		if(clipOpen == null)
        {
			Debug.Log("SensorDoors script failed to find the clipOpen animation script");
        }
		if (clipClose == null)
		{
			Debug.Log("SensorDoors script failed to find the clipClose animation script");
		}
	}
    // open the gates
    void OnTriggerEnter(Collider defender)
	{

		if (debug)
		{
			print("SensorDoors Trigger Entered");
		}
		if (defender.gameObject.tag == "Player")
		{
			if (debug)
			{
				print("by player");
			}
			GetComponent<Animation>().Play(clipOpen.name);
			GetComponent<AudioSource>().Play(); // play the clip loaded in the audio component	
		}
	}

	// close the gates
	void OnTriggerExit(Collider defender)
	{
		if (debug)
		{
			print("SensorDoors Trigger Exited");
		}
		if (defender.gameObject.tag == "Player")
		{
			if(debug)
            {
				print("by player");
			}
			
			GetComponent<Animation>().Play(clipClose.name);
			GetComponent<AudioSource>().Play(); // play the clip loaded in the audio component
		}
	}
}
