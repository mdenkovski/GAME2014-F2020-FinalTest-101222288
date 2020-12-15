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

    [Header("Shrinking Values")]
    public BoxCollider2D boxCollider;
    public bool isActive;
    IEnumerator ShrinkPlatform;

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

    public void StartShrinking()
    {
        
        ShrinkPlatform = ShrinkPlatformRoutine();
        StartCoroutine(ShrinkPlatform);
    }

    IEnumerator ShrinkPlatformRoutine()
    {
        yield return new WaitForSeconds(2.0f);
        Segment1.SetActive(false);
        Segment5.SetActive(false);
        boxCollider.size.Set(3.0f, 2.0f);
        yield return new WaitForSeconds(2.0f);
        Segment2.SetActive(false);
        Segment4.SetActive(false);
        boxCollider.size.Set(1.0f, 2.0f);
        yield return new WaitForSeconds(2.0f);
        Segment3.SetActive(false);
        boxCollider.enabled = false;
    }

    public void ResetPlatform()
    {
        //check if the shrinking routine is already happening
        if (ShrinkPlatform != null)
        {
            StopCoroutine(ShrinkPlatform);
        }
        StartCoroutine(RestorePlatform());
    }

    IEnumerator RestorePlatform()
    {
        yield return new WaitForSeconds(2.0f);
        boxCollider.enabled = true;
        boxCollider.size.Set(5.0f, 2.0f);
        Segment1.SetActive(true);
        Segment2.SetActive(true);
        Segment3.SetActive(true);
        Segment4.SetActive(true);
        Segment5.SetActive(true);
    }

}
