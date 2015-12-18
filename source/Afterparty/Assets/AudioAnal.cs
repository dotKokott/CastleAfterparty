using UnityEngine;
using System.Collections;

public class AudioAnal : MonoBehaviour {

    public AudioListener Listener;

    float[] samples;

    public static float[] currentValues;
	// Use this for initialization
	IEnumerator Start () {
        Listener = GetComponent<AudioListener>();

        samples = new float[512];

        currentValues = new float[8];

        while( true ) {
            yield return new WaitForSeconds( 1 / 15.0f );

            AudioListener.GetSpectrumData( samples, 0, FFTWindow.BlackmanHarris );
            var count = 0;
            float diff = 0;
            for ( int i = 0; i < 8; ++i ) {
                float average = 0;

                int sampleCount = (int)Mathf.Pow( 2, i ) * 2;
                for ( int j = 0; j < sampleCount; ++j ) {
                    average += samples[count] * ( count + 1 );
                    ++count;
                }
                average /= samples.Length;
                diff = Mathf.Clamp( average * 10.0f - currentValues[i], 0, 4 );
                currentValues[i] = average * 10;
            }
        }
        
    }
	
	// Update is called once per frame
	void Update () {
	    
	}
}
