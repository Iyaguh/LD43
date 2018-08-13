using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//[ExecuteInEditMode]
public class ResourceManager : MonoBehaviour {

    public static ResourceManager instance;
    [Header("Изначальные параметры")]
    public int food = 0;
    public int peopleCapacity = 0;
    public int peopleAmount = 0;
    public int peopleOccupied = 0;
    [HideInInspector]
    public float spawnTimer = 0;
    public int amountOfPeopleInShip = 0;
    public int startPopulationGrowth = 0;
    public int startFoodGrowth = 0;
    [HideInInspector]
    public int currentPopulationGrowth = 0;
    [HideInInspector]
    public int currentFoodGrowth = 0;

    public float anger = 0f;
    public float angerGrowthRate = 2f;
    public int totalPopulationToCome = 50;

    public bool isPaused = false;
    public bool disableHomeAnger = false;




    public float fightSpeed = 5f;
    public int personConsumtion = 1;

    [Header("Цвета локаций")]
    public Color occupiedPlaceColor;
    public Color vacantPlaceColor;
    public Color enemiesPlaceColor;
    public Color fightingPlaceColor;





    [Header("Спрайты локаций")]
    public Sprite placeForestSprite;
    public Sprite placeShelterSprite;
    public Sprite placeEnemySprite;

    [HideInInspector]
    public PlaceBehavior[] placeBehaviors;

    public MenuHandler menuHandler;

    private void Awake()
    {
        anger = 0f;
        instance = this;
        menuHandler.DisplayIndicators();
        placeBehaviors = FindObjectsOfType<PlaceBehavior>();
        CollectDataFromPlaceBehaviors();
        print("одно место");
//        isPaused = true;
    }

    public void CheckIfNotEnoughFood()
    {
        //if (food < 0)
        //{
        //    GrowAngerEnemies();
        //}

        if (currentFoodGrowth < peopleAmount)
        {
            GrowAngerEnemies();
        }


        if (peopleCapacity < peopleAmount & !disableHomeAnger)
        {
            GrowAngerEnemies();
        }
    }

    public void GrowAngerEnemies()
    {
        anger += angerGrowthRate * Time.deltaTime;
    }

    public void StopPlayTheGame ()
    {
        isPaused = !isPaused;
    }

    public void GrowAngerFood()
    {
        anger += angerGrowthRate * Time.deltaTime;
    }
    public void GrowAngerPopulation()
    {
        anger += angerGrowthRate * Time.deltaTime;
    }




    public void CollectDataFromPlaceBehaviors()
    {
        currentFoodGrowth = startFoodGrowth;
        currentPopulationGrowth = startPopulationGrowth;

        foreach (var placeBehavior in placeBehaviors)
        {
            if (placeBehavior.placeState == PlaceBehavior.PlaceState.taken)
            {
                AddResourceSurplace(placeBehavior);
            }
        }
    }

    public void AddResourceSurplace(PlaceBehavior placeBehavior)
    {
        if (placeBehavior.buildingType == PlaceBehavior.BuildingType.forest)
        {
            currentFoodGrowth += placeBehavior.resourceSurplace;
        }

        if (placeBehavior.buildingType == PlaceBehavior.BuildingType.shelter)
        {
            peopleCapacity += placeBehavior.resourceSurplace;
        }
    }

    public void UpdatePeopleAmount()
    {
        //if (totalPopulationToCome - amountOfPeopleInShip - peopleAmount >= 0)
        //{
        //    peopleAmount += amountOfPeopleInShip;
        //}
        peopleAmount += amountOfPeopleInShip;
    }

    

    public string FormDataForPopulationIndicator()
    {
        string stringData;
        stringData = peopleAmount.ToString() + "/" + totalPopulationToCome.ToString();
        return stringData;
    }

    public string FormDataForBedsIndicator()
    {
        return (peopleCapacity - peopleAmount).ToString();
    }

    public string FormDataForFoodIndicator()
    {
        // return (food - peopleAmount * personConsumtion).ToString();
        return (currentFoodGrowth - peopleAmount).ToString();
    }

    public void CheckForVictory()
    {
        if (totalPopulationToCome - peopleAmount <= 0)
        {
            StartVictorySequence();
        }
    }

    public void StartVictorySequence()
    {
        SceneManager.LoadScene(2);
    }
}
