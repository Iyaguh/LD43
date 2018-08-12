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
    public Slider populationSlider;
    public Slider populationSliderFood;
    public Slider populationSliderBeds;
    public Text populationSliderText;
    public Text populationSliderBedsText;
    public Text populationSliderFoodText;

    // Use this for initialization
    void Start ()
	{
	    populationSlider.maxValue = ResourceManager.instance.totalPopulationToCome;
	    populationSliderFood.maxValue = ResourceManager.instance.totalPopulationToCome;
	    populationSliderBeds.maxValue = ResourceManager.instance.totalPopulationToCome;
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
        populationSliderText.text = ResourceManager.instance.FormDataForPopulationIndicator();
        populationSlider.value = ResourceManager.instance.peopleAmount;



        //        populationSliderFood.value = ResourceManager.instance.food;
        populationSliderFood.value = ResourceManager.instance.currentFoodGrowth;
        populationSliderBeds.value = ResourceManager.instance.peopleCapacity;
        populationSliderBedsText.text = ResourceManager.instance.FormDataForBedsIndicator();
        populationSliderFoodText.text = ResourceManager.instance.FormDataForFoodIndicator();

    }


	
	// Update is called once per frame
	void Update () {
        DisplayIndicators();
	}
}
