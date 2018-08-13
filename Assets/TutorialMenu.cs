using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialMenu : MonoBehaviour
{

    public TutorialHandler tutorialHandler;
    public Animator animator;

	// Use this for initialization
	void Start ()
	{

        tutorialHandler = FindObjectOfType<TutorialHandler>();
	    ResourceManager.instance.StopPlayTheGame();
    }

    public void Unpause()
    {
        ResourceManager.instance.StopPlayTheGame();
    }

    public void SwitchMenuOff()
    {
        tutorialHandler.isTutorialOn = false;
       
    }

    public void GotIt()
    {
        Unpause();
        animator.SetBool("open", false);
    }

    public void OpenTutorial()
    {
        animator.SetBool("open", true);
    }

	
	// Update is called once per frame
	void Update () {
		
	}
}
