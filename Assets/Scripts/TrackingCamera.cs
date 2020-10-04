using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackingCamera : MonoBehaviour
{
    public float distanceAwayFromObject = 5;
    Transform trackingObject;

    // Update is called once per frame
    void Update()
    {
        if(trackingObject)
        {
            transform.position = trackingObject.position - new Vector3(0, 0, distanceAwayFromObject);
        }
    }

    public void TrackGameObject(GameObject gameObject)
    {
        trackingObject = gameObject.transform;   
    }
}
