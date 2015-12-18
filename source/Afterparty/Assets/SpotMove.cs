using UnityEngine;
using System.Collections;

public class SpotMove : MonoBehaviour {
    
    public Vector3 To;

    public float Time;

	// Use this for initialization
	void Start () {
        iTween.RotateTo( gameObject, iTween.Hash( "rotation", To, "time", Time, "looptype", iTween.LoopType.pingPong, "easetype", iTween.EaseType.easeInCubic ) );
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
