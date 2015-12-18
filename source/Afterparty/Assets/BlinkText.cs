using UnityEngine;
using System.Collections;

public class BlinkText : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (Alina.CurrentTarget != null) {
            var text = Alina.CurrentTarget.Name;
            switch (Alina.CurrentNeed) {
                case Need.Falafel:
                    text += " NEEDS A FALAFEL";
                    break;
                case Need.Beer:
                    text += " NEEDS A BEER";
                    break;
                case Need.MDMA:
                    text += " NEEDS SOME DRUGS";
                    break;
                default:
                    break;
            }

            GetComponent<UnityEngine.UI.Text>().text = text;
        } else {
            GetComponent<UnityEngine.UI.Text>().text = "";
        }
        
        var col = GetComponent<UnityEngine.UI.Text>().material.color;
        GetComponent<UnityEngine.UI.Text>().material.color = new Color(col.r, col.g, col.b, Mathf.Abs(Mathf.Cos(Time.time * 2)));
	}
}
