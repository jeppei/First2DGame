using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointFollower : MonoBehaviour
{
    [SerializeField] private GameObject[] waypoints;
    private int currentWaypointIndex = 0;

    [SerializeField] private float speed = 2f;

    void Update()
    {
        if (waypoints.Length == 0) return;

        Vector2 nextWaypointPosition = waypoints[currentWaypointIndex].transform.position;
        if (Vector2.Distance(nextWaypointPosition, transform.position) < .1f) 
        {
            currentWaypointIndex++;
            currentWaypointIndex %= waypoints.Length;
        }
        transform.position = Vector2.MoveTowards(transform.position, nextWaypointPosition, Time.deltaTime * speed);
    }
}
