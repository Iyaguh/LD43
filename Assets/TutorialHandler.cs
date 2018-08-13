using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;


public class TutorialHandler : MonoBehaviour
{

    public bool isTutorialOn = true;

	// Use this for initialization
    public TutorialMenu tutorialMenu;

    private void Awake()
    {
        tutorialMenu = FindObjectOfType<TutorialMenu>();
    }


    void Start () {


	    DontDestroyOnLoad(this.gameObject);
	    if (FindObjectsOfType(GetType()).Length > 1)
	    {
	        Destroy(gameObject);
	    }


     //   if (isTutorialOn)
	    //{
     //       tutorialMenu.OpenTutorial();
     //   }

    }



    public void StartTutorial(int tutorialNumber)
    {
        if (!isTutorialOn)
        {
            return;
        }
        ResourceManager.instance.StopPlayTheGame();


    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
