using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

[ExecuteInEditMode]
public class PlaceBehavior : MonoBehaviour, IPointerClickHandler
{

    public bool isTaken = false;
    public enum PlaceState { taken, vacant, enemies, fighting}
    public PlaceState placeState;

    public enum BuildingType { forest, shelter }
    public BuildingType buildingType;

    public PlaceBehavior[] placeBehaviors;
    [HideInInspector]
    public bool isEnemiesHere = false;
    public int numberOfEnemies = 0;
    public int numberOfPeople = 0;

    public int resourceSurplace = 0;
    public Image placeIcon;
    public Text placeText;
    public Text placeOccupantsText;
    public Image placeIndicator;

    public float indicatorValue = 50;
    public Color thisPlaceColor;
    public Image thisPlaceImage;



    // Use this for initialization
    void Start ()
    {
        SetPlaceImage();
        thisPlaceColor = this.GetComponent<Image>().color;
        thisPlaceImage = this.GetComponent<Image>();
//        this.GetComponent<Image>().color = Color.black;


        SetColorForPlace();

    }

    private void SetColorForPlace()
    {
        switch (placeState)
        {
            case PlaceState.vacant:
                thisPlaceImage.color = ResourceManager.instance.vacantPlaceColor;
                return;
            case PlaceState.taken:
                thisPlaceImage.color = ResourceManager.instance.occupiedPlaceColor;
                return;

            case PlaceState.enemies:
                placeIndicator.fillAmount = indicatorValue * 0.01f;
                thisPlaceImage.color = ResourceManager.instance.enemiesPlaceColor;
                return;
            case PlaceState.fighting:
                thisPlaceImage.color = ResourceManager.instance.fightingPlaceColor;
                return;
        }
    }

    private void SetPlaceImage()
    {
        if (placeState != PlaceState.enemies)
        {
            if (buildingType == BuildingType.forest)
            {
                placeIcon.sprite = ResourceManager.instance.placeForestSprite;
                placeText.text = resourceSurplace.ToString();
            }
            else if (buildingType == BuildingType.shelter)
            {
                placeIcon.sprite = ResourceManager.instance.placeShelterSprite;
                placeText.text = resourceSurplace.ToString();
            }
        }
        else
        {
            placeIcon.sprite = ResourceManager.instance.placeEnemySprite;
            placeText.text = numberOfEnemies.ToString();
        }
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (isPlaceConnected())
        {
            if (eventData.button == PointerEventData.InputButton.Left)
            {
                ChangeNumberOfPeople(1);
                if (placeState == PlaceState.vacant)
                {
                    placeState = PlaceState.taken;
                    thisPlaceImage.color = ResourceManager.instance.occupiedPlaceColor;
                    ResourceManager.instance.AddResourceSurplace(this);
                }
                if (placeState == PlaceState.enemies & numberOfPeople >= numberOfEnemies)
                {
                    placeState = PlaceState.fighting;
                    thisPlaceImage.color = ResourceManager.instance.fightingPlaceColor;
                }
            }
            else if (eventData.button == PointerEventData.InputButton.Middle)
                Debug.Log("Middle click");
            else if (eventData.button == PointerEventData.InputButton.Right)
            {
                ChangeNumberOfPeople(-1);
                if (placeState == PlaceState.fighting & numberOfPeople < numberOfEnemies)
                {
                    placeState = PlaceState.enemies;
                }
            }
        }       
    }

    public bool isPlaceConnected()
    {
        foreach (var placeBehavior in placeBehaviors)
        {
            if (placeBehavior.placeState == PlaceState.taken)
            {
                return true;
            }
        }
        return false;
    }

    public void ChangeNumberOfPeople(int number)
    {
        numberOfPeople += number;
        if (numberOfPeople < 0)
        {
            numberOfPeople = 0;
        }

    }

    // Update is called once per frame
    void Update ()
    {
        placeOccupantsText.text = numberOfPeople.ToString();
        switch (placeState)
        {
            case PlaceState.vacant:

                return;
            case PlaceState.taken:

                return;

            case PlaceState.enemies:
                // show indicator             

                return;


            case PlaceState.fighting:
                // launch indicator
                indicatorValue += ResourceManager.instance.fightSpeed *Time.deltaTime;
                placeIndicator.fillAmount = indicatorValue * 0.01f;
                if (indicatorValue >= 100)
                {
                    placeState = PlaceState.taken;
                    SetColorForPlace();
                    ResourceManager.instance.AddResourceSurplace(this);
                }

                //

                return;
        }



    }
    


}
