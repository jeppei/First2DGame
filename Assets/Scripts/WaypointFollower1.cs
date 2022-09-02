using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointFollower1 : MonoBehaviour
{
    [SerializeField] private GameObject[] waypoints;
    private int currentWaypointIndex = 0;

    [SerializeField] private float speed = 2f;

    // Update is called once per frame
    void Update()
    {
        Vector2 nextWaypointPosition = waypoints[currentWaypointIndex].transform.position;
        if (Vector2.Distance(nextWaypointPosition, transform.position) < .1f) 
        {
            currentWaypointIndex++;
            currentWaypointIndex %= waypoints.Length;
            //if (currentWaypointIndex >= waypoints.Length)
            //{
            //    currentWaypointIndex = 0;
            //}
        }
        transform.position = Vector2.MoveTowards(transform.position, nextWaypointPosition, Time.deltaTime * speed);
    }
}
