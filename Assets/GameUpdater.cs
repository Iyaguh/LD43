using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameUpdater : MonoBehaviour
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
	void Update ()
    {
        if (!ResourceManager.instance.isPaused)
        {
            ManageGameCycle();
            CheckForGameEnd();
            ResourceManager.instance.CheckForVictory();

        }
    }

    

    private static void CheckForGameEnd()
    {
        ResourceManager.instance.CheckIfNotEnoughFood();
        if (ResourceManager.instance.anger > 100)
        {
            SceneManager.LoadScene(1);
        }
    }

    private void ManageGameCycle()
    {
        ResourceManager.instance.spawnTimer = Time.time - timeTag;
        if (Time.time - timeTag > deltaSpawnTime)
        {
            timeTag = Time.time;
            UpdateResources();
        }
    }

    private static void UpdateResources()
    {
        ResourceManager.instance.UpdatePeopleAmount();

        //ResourceManager.instance.food += ResourceManager.instance.currentFoodGrowth;
        //ResourceManager.instance.food -= 
        //ResourceManager.instance.peopleAmount * ResourceManager.instance.personConsumtion;
    }
}
