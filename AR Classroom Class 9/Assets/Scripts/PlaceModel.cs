using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class PlaceModel : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField]
    private GameObject place_object;

    [SerializeField]
    private ARSessionOrigin ar_session_origin;

    public List<ARRaycastHit> raycast_hits = new List<ARRaycastHit>();

    private GameObject obj = null;


    // Update is called once per frame
    void Update()
    {
        // Check for the tap on screen
        if(Input.GetMouseButton(0))
        {
            // Cast a ray from the touch position to the plane

            bool collision = ar_session_origin.GetComponent<ARRaycastManager>().Raycast(Input.mousePosition, raycast_hits, TrackableType.PlaneWithinPolygon);

            if(collision && obj == null)
            {
               obj =Instantiate(place_object);
            }
            obj.transform.position = raycast_hits[0].pose.position;
        }


    }
}
