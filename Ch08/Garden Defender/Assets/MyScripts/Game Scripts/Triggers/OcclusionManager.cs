using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OcclusionManager : MonoBehaviour
{
    public bool state;
    public GameObject[] myArea;

	/*
	 * Occluders 2a are in the garden and turn the Staging Area objects on and off. Occluders 2b are in the staging area and turn the Garden objects
	 * on and off. The ones closest to the door set objects visible and the ones farther away turn them off
	 * 2a Off: Staging Area Off
	 * 2a On: Staging Area On
	 * 2b On: Garden Area On
	 * 2b Off: Garden Area Off
	 */

	public bool debug = true;

    private void Awake()
    {
		if(debug)
		{
			Debug.Log(this.gameObject.name + " has awakened");
		}
		string objName = this.gameObject.name;
		if(objName == "Occluder 2a Off")
        {
			if (state != false || myArea[0].gameObject.name != "Staging Area")
				Debug.Log(objName + " appears misconfigured");
        }
		if (objName == "Occluder 2a On")
		{
			if (state != true || myArea[0].gameObject.name != "Staging Area")
				Debug.Log(objName + " appears misconfigured");
		}
		if (objName == "Occluder 2b On")
		{
			if (state != true || myArea[0].gameObject.name != "CornerGarden")
				Debug.Log(objName + " appears misconfigured");
		}
		if (objName == "Occluder 2b Off")
		{
			if (state != false || myArea[0].gameObject.name != "CornerGarden")
				Debug.Log(objName + " appears misconfigured");
		}
	}


	void OnTriggerEnter(Collider defender)
	{
		if (debug)
		{
			print("Occlusion Trigger Entered");
		}
		if (defender.gameObject.tag == "Player")
		{
			if (debug)
			{
				print("by player");
			}
			foreach (GameObject theElement in myArea)
				theElement.SetActive(state);
		}
	}

	// close the gates
	//void OnTriggerExit(Collider defender)
	//{
		//print("Occlusion Trigger Exited");
		//if (defender.gameObject.tag == "Player")
		//{
			//print("by player");
		//}

	//}
}
