using UnityEngine;
using System.Collections;

public enum State {
    Dancing,
    Walking
}

public class Person : MonoBehaviour {


    public State CurrentState;

    public float DanceSpeed;
    public float DanceIntensity;
    public float WalkSpeed = 3;


    public Transform[] Waypoints;
    public int CurrentWaypoint = 0;
    public int WayDirection = 1;

    public string Name;
    
    public Vector3 LookDirection;
	void Start () {
	    
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        var rot = transform.localRotation;
        transform.localRotation = Quaternion.Euler(rot.x, Mathf.Rad2Deg * Mathf.Atan2(LookDirection.x, LookDirection.z), rot.z);

        if (Random.Range(0, 100) == 0) {
            WayDirection *= -1;
        }

        switch (CurrentState) {
            case State.Dancing:
                var pos = transform.position;
                pos.y += Mathf.Sin(Time.time * DanceSpeed) * DanceIntensity;

                transform.position = pos;

                if (Random.Range(0, 300) == 0) {
                    CurrentState = State.Walking;
                }
                break;
            case State.Walking:
                if(Waypoints.Length == 0) {
                    return;
                }
                var targetVec = Waypoints[CurrentWaypoint].position - transform.position;
                targetVec.y = 0;

                if (targetVec.magnitude < 0.5f) {
                    CurrentWaypoint += WayDirection;
                    if (CurrentWaypoint < 0) CurrentWaypoint = Waypoints.Length - 1;
                    if (CurrentWaypoint > Waypoints.Length - 1) CurrentWaypoint = 0;
                }
                
                targetVec.Normalize();
                LookDirection = targetVec;

                transform.position += targetVec * WalkSpeed * Time.deltaTime;

                if (Random.Range(0, 200) == 0) {
                    CurrentState = State.Dancing;
                }
                

                break;
            default:
                break;
        }
	}
}
