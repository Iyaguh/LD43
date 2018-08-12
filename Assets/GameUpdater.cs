using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameUpdater : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		ResourceManager.instance.CheckIfNotEnoughFood();
	    if (ResourceManager.instance.anger > 100)
	    {
            Debug.LogError("Вы проиграли");
	    }


    }
}
