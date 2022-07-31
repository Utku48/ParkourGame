using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WayPointFallower : MonoBehaviour
{
    //Yapılacak olan sağa,sola,ileri,geri hareketlerde hareketin hangi iki nokta arasında yapılacağını belirler. 
    [SerializeField] GameObject[] waypoints;
    int currentWaypointIndex = 0;

    [SerializeField] float speed = 1f;
    void Update()
    {
        if (Vector3.Distance(transform.position, waypoints[currentWaypointIndex].transform.position) < .1f)
        {
            currentWaypointIndex++;
            if (currentWaypointIndex >= waypoints.Length)
            {
                currentWaypointIndex = 0;
            }
        }

        transform.position = Vector3.MoveTowards(transform.position, waypoints[currentWaypointIndex].transform.position, speed * Time.deltaTime);
    }
}
