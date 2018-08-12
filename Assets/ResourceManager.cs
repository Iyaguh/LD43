using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class ResourceManager : MonoBehaviour {

    public static ResourceManager instance;
    public MenuHandler menuHandler;
    public PlaceBehavior[] placeBehaviors;
    public Color occupiedPlaceColor;
    public Color vacantPlaceColor;
    public Color enemiesPlaceColor;
    public Color fightingPlaceColor;

    public int onePersonConsumes = 1;


    public int food = 0;
    public int peopleCapacity = 0;
    public int peopleAmount = 0;
    public float spawnTimer = 0;
    public int amountOfPeopleInShip = 0;
    public int startPopulationGrowth = 0;
    public int startFoodGrowth = 0;
    [HideInInspector]
    public int currentPopulationGrowth = 0;
    [HideInInspector]
    public int currentFoodGrowth = 0;

    public Sprite placeForestSprite;
    public Sprite placeShelterSprite;
    public Sprite placeEnemySprite;
    public float fightSpeed = 5f;



    private void Awake()
    {
        instance = this;
        menuHandler.DisplayIndicators();
        placeBehaviors = FindObjectsOfType<PlaceBehavior>();
        CollectDataFromPlaceBehaviors();
        print("одно место");
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
