using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerBehavior : MonoBehaviour
{
    [HideInInspector]
    public float timeTag;
    [HideInInspector]
    public float previousSpawnTime;

    public float deltaSpawnTime;


	// Use this for initialization
	void Start ()
	{
	    timeTag = Time.time;
	}
	
	// Update is called once per frame
	void Update () {
	    ResourceManager.instance.spawnTimer = Time.time - timeTag;
        if (Time.time - timeTag > deltaSpawnTime)
	    {
	        print("приехали колонисты");
	        timeTag = Time.time;
	        ResourceManager.instance.peopleAmount += ResourceManager.instance.amountOfPeopleInShip;
	        ResourceManager.instance.food += ResourceManager.instance.currentFoodGrowth;
	        ResourceManager.instance.food -=
	            ResourceManager.instance.peopleAmount * ResourceManager.instance.onePersonConsumes;
	    }



	}
}
