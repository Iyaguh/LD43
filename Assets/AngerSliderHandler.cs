using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.UIElements;

public class AngerSliderHandler : MonoBehaviour
{
    public Slider slider;




	// Use this for initialization
	void Start ()
	{
	    slider.value = ResourceManager.instance.anger;
	}
	
	// Update is called once per frame
	void Update () {
		
        



	}
}
