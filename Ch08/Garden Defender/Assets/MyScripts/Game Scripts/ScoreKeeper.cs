using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreKeeper : MonoBehaviour
{

    int currentBunCount = 0;
    

    public bool debug = true;

    void UpdateBunCount(int adjustment)
    {
        currentBunCount += adjustment;
        if (debug)
        {
            Debug.Log("Current bum count: " + currentBunCount);
        }
    }


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
