using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBunnies : MonoBehaviour
{
    public bool debug = true;

    public GameObject zombieBunny;
    public Transform currentZone;   // The invisible Zombie Creation Zone
    public Transform bunHolder;     // assign the clone to this object's transform
    public GameObject gameManager;

    public int litterSize = 8;
    public bool canReproduce = true;
    public float reproRate = 12f;      // base time before respawning

    //public int currentBunCount = 0;

    float minX;
    float maxX;
    float minZ;
    float maxZ;

    // Start is called before the first frame update
    
    void Start()
    {
        if(zombieBunny == null)
        {
            Debug.Log("SpawnBunnies script in Zombie Spawn Manager does not have a reference to the ZombieBunny prefab");
        }
        if (currentZone == null)
        {
            Debug.Log("SpawnBunnies script in Zombie Spawn Manager does not have a reference to the Zombie Creation Zone object");
        }
        gameManager = GameObject.Find("Game Manager");
        if(gameManager == null)
        {
            Debug.Log("SpawnBunnies script failed to find an object named Game Manager!");
        }

        minX = currentZone.position.x - currentZone.localScale.x / 2;
        maxX = currentZone.position.x + currentZone.localScale.x / 2;
        minZ = currentZone.position.z - currentZone.localScale.z / 2;
        maxZ = currentZone.position.z + currentZone.localScale.z / 2;
        if(debug)
        {
            Debug.Log("DropZone established minX: " + minX + ", maxX: " + maxX + ", minZ: " + minZ + ", maxZ " + maxZ);
        }
        // make first drop larger than normal
        // 
        int tempLitterSize = litterSize * 3;
        PopulateGardenBunnies(tempLitterSize);

        float tempRate = reproRate * 2; // alow extra time before the second drop
        StartCoroutine(StartReproducing(tempRate));
    }

    void PopulateGardenBunnies(int count)
    {
        count = Random.Range(count * 3 / 4, count + 1);
        if(debug)
        {
            Debug.Log("PopulateGardenBunnies called to make " + count + " bunnies");
        }
        for(int i = 0; i < count; i++)
        {
            
            GameObject zBunny = (GameObject)Instantiate(zombieBunny, new Vector3(Random.Range(minX, maxX), 1.0f, Random.Range(minZ, maxZ)), Quaternion.identity);
            // randomize rotations
            Vector3 rot = zBunny.transform.localEulerAngles;
            rot.y = Random.Range(1, 261);
            zBunny.transform.localEulerAngles = rot;
            // randomize the animation clip
            zBunny.GetComponent<Animator>().Play("Bunny Eat", 0, Random.Range(0.0f, 1.0f));
            // assign to the parent
            zBunny.transform.parent = bunHolder;
        }
        gameManager.SendMessage("UpdateCount", count, SendMessageOptions.DontRequireReceiver);
        //currentBunCount += count;
        if(debug)
        {
            //Debug.Log("Current bun count is " + currentBunCount);
        }
    }

    IEnumerator StartReproducing(float minTime)
    {
        // wait this much time before going on
        float adjustedTime = Random.Range(minTime, minTime + 5f);
        // original wait yield return new WaitForSeconds(adjustedTime);
        // now wait, audio cue three seconds before drop, wait
        yield return new WaitForSeconds(adjustedTime - 3f);
        GetComponent<AudioSource>().Play();
        yield return new WaitForSeconds(3f);
        // having waited, make more zombies
        PopulateGardenBunnies(litterSize);
        // and start the coroutine again, if necessary
        if(canReproduce)
        {
            StartCoroutine(StartReproducing(reproRate));
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
