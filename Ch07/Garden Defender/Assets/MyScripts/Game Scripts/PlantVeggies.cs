using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantVeggies : MonoBehaviour
{
    public GameObject veggie;   // the plant prefab
    public Transform plantParent;   // the Plant Zone Parent
    public int rows = 6;
    public int columns = 6;
    public bool debug = false;

    public int percentEaten = 15;    // some plants will be missing -- the bunnies are eating them!

    float minX;
    float minZ;
    float spacingX;
    float spacingZ;

    float yFudgeFactor = 0.12f;

    // Start is called before the first frame update
    void Start()
    {
        if(veggie == null)
        {
            Debug.Log("PlantVeggies() failed to find a plant prefab");
        }
        if (plantParent == null)
        {
            Debug.Log("PlantVeggies() failed to find the parent transform");
        }
        // do all the math to get the grid numbers
        minX = transform.position.x - transform.localScale.x / 2;
        minZ = transform.position.z - transform.localScale.z / 2;
        spacingX = transform.localScale.x / rows;
        spacingZ = transform.localScale.z / columns;
        PopulateBed();
    }

    private void PopulateBed()
    {
        if (debug)
            Debug.Log("PopulateBed()");
        float y = transform.position.y; // ground level
        for(int x = 0; x < columns; x++)
        {
            for(int z = 0; z < rows; z++)
            {
                
                Vector3 pos = new Vector3(x * spacingX + minX + spacingX / 2, y+yFudgeFactor, z * spacingZ + minZ + spacingZ / 2);
                // maybe plant?
                int rPercent = UnityEngine.Random.Range(1, 101);
                if(rPercent > percentEaten)
                {
                    GameObject newVeggie = (GameObject)Instantiate(veggie, pos, Quaternion.identity);
                    // add a random rotation
                    Vector3 rot = newVeggie.transform.localEulerAngles;
                    rot.y = UnityEngine.Random.Range(1, 361);
                    newVeggie.transform.localEulerAngles = rot;
                    // add a random scale
                    //Vector3 scale = newVeggie.transform.localScale;
                    //float rScale = UnityEngine.Random.Range(0.8f, 1.1f);
                    //scale = new Vector3(rScale, rScale, rScale);
                   // newVeggie.transform.localScale = scale;

                    newVeggie.transform.parent = plantParent;
                }

            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
