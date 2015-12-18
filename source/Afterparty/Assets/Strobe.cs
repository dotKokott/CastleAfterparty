using UnityEngine;
using System.Collections;

public class Strobe : MonoBehaviour {

    public Light Light;
    public float StrobeSpeed = 0.2f;
	void Start () {
        Light = GetComponent<Light>();
	}

    float timer = 0;
	void FixedUpdate () {
        timer += Time.deltaTime;

        //if (timer > StrobeSpeed) {
        //    timer = 0;
        //    if (Light.intensity == 6) {
        //        Light.intensity = 0;
        //    } else if (Light.intensity == 0) {
        //        Light.intensity = 6;
        //    }
        //}

        Light.intensity = AudioAnal.currentValues[3] * 100;
	}
}
