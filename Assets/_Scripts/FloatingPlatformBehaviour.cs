using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// FloatingPlatformBehaviour.cs
/// Michael Denkovski 101222288
/// Last Edit Dec 15, 2020
/// Script that moves the platform up and down slightly and will cause the platform to shrink when the player gets on it
/// - added floating behaviour between 2 points
/// </summary>
public class FloatingPlatformBehaviour : MonoBehaviour
{
    //the segments of the platform that will casue it to shrink
    [Header("Segments")]
    public GameObject Segment1;
    public GameObject Segment2;
    public GameObject Segment3;
    public GameObject Segment4;
    public GameObject Segment5;

    [Header("Floating Parameters")]
    public Transform start;
    public Transform end;
    private Vector3 distance;

    public bool isActive;

    // Start is called before the first frame update
    void Start()
    {
        distance = end.position - start.position;
    }

    // Update is called once per frame
    void Update()
    {
        _Float();
    }

    private void _Float()
    {
        var distanceX = (distance.x > 0) ? start.position.x + Mathf.PingPong(Time.time*0.5f, distance.x) : start.position.x;
        var distanceY = (distance.y > 0) ? start.position.y + Mathf.PingPong(Time.time * 0.5f, distance.y) : start.position.y;

        transform.position = new Vector3(distanceX, distanceY, 0.0f);
    }

}
