using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ConnectorBehavior : MonoBehaviour
{

    public PlaceBehavior placeBehavior1;
    public PlaceBehavior placeBehavior2;
    public Image connectorImage;

    // Use this for initialization
    void Start ()
    {
        connectorImage = this.GetComponent<Image>();
    }
	
	// Update is called once per frame
	void Update () {
	    if (placeBehavior1 != null & placeBehavior2 != null)
	    {
	        if (placeBehavior1.placeState == PlaceBehavior.PlaceState.taken &
	            placeBehavior2.placeState == PlaceBehavior.PlaceState.taken)
	        {
                connectorImage.color = Color.green;
	        }
	        if (placeBehavior1.placeState == PlaceBehavior.PlaceState.taken &
	            placeBehavior2.placeState == PlaceBehavior.PlaceState.vacant)
	        {
	            connectorImage.color = Color.yellow;
	        }
	        if (placeBehavior1.placeState == PlaceBehavior.PlaceState.vacant &
	            placeBehavior2.placeState == PlaceBehavior.PlaceState.taken)
	        {
	            connectorImage.color = Color.yellow;
	        }
	        if (placeBehavior1.placeState == PlaceBehavior.PlaceState.vacant &
	            placeBehavior2.placeState == PlaceBehavior.PlaceState.vacant)
	        {
	            connectorImage.color = Color.gray;
	        }
	        if (placeBehavior1.placeState == PlaceBehavior.PlaceState.taken &
	            placeBehavior2.placeState == PlaceBehavior.PlaceState.enemies)
	        {
	            connectorImage.color = Color.red;
	        }
	        if (placeBehavior1.placeState == PlaceBehavior.PlaceState.enemies &
	            placeBehavior2.placeState == PlaceBehavior.PlaceState.taken)
	        {
	            connectorImage.color = Color.red;
	        }

        }




	}
}
