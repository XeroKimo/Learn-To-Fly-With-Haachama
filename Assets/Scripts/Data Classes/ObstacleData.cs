using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu()]
public class ObstacleData : ScriptableObject
{
    //The following 2 Vector2 is the range at which the obstacle can appear
    //If any min == max in any axis, the obstacle can appear anywhere
    public Vector2 minimumDistance = new Vector2(float.MinValue, 0);
    public Vector2 maximumDistance = Vector2.zero;

    public GameObstacle obstaclePrefab;
}
