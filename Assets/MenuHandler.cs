using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuHandler : MonoBehaviour
{

    public Text populationText;
    public Text spawnerTimerText;
    public Text populationGrowthText;
    public Text foodAmountText;
    public Text foodGrowthText;
    public Text numberOfBedsText;

    public Slider angerSlider;

	// Use this for initialization
	void Start () {
		
	}

    public void DisplayIndicators()
    {
        if (populationText.text != ResourceManager.instance.peopleAmount.ToString())
        {
            populationText.text = ResourceManager.instance.peopleAmount.ToString();
        }

        spawnerTimerText.text = ResourceManager.instance.spawnTimer.ToString();
        populationGrowthText.text = ResourceManager.instance.currentPopulationGrowth.ToString();
        foodAmountText.text = ResourceManager.instance.food.ToString();
        foodGrowthText.text = ResourceManager.instance.currentFoodGrowth.ToString();
        numberOfBedsText.text = ResourceManager.instance.peopleCapacity.ToString();
        angerSlider.value = ResourceManager.instance.anger;
    }


	
	// Update is called once per frame
	void Update () {
        DisplayIndicators();
	}
}
