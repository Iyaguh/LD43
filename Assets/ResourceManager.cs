﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class ResourceManager : MonoBehaviour {

    public static ResourceManager instance;
    [Header("Изначальные параметры")]
    public int food = 0;
    public int peopleCapacity = 0;
    public int peopleAmount = 0;
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




    public float fightSpeed = 5f;
    public int onePersonConsumes = 1;

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
        instance = this;
        menuHandler.DisplayIndicators();
        placeBehaviors = FindObjectsOfType<PlaceBehavior>();
        CollectDataFromPlaceBehaviors();
        print("одно место");
    }

    public void CheckIfNotEnoughFood()
    {
        if (food < 0)
        {
            GrowAngerEnemies();
        }

        if (peopleCapacity < peopleAmount)
        {
            GrowAngerEnemies();
        }
    }

    public void GrowAngerEnemies()
    {
        anger += angerGrowthRate * Time.deltaTime;
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
}
