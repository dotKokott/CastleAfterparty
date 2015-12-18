using UnityEngine;
using System.Collections;

public class Alina : MonoBehaviour {

    public GameObject Falafel;
    public GameObject Bottle;
    public GameObject Bag;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnControllerColliderHit( ControllerColliderHit hit ) {
        if(hit.collider.tag == "Falafel") {
            Falafel.SetActive( true );
            Bottle.SetActive( false );
            Bag.SetActive( false );
        }

        if ( hit.collider.tag == "Drug" ) {
            Falafel.SetActive( false );
            Bottle.SetActive( false );
            Bag.SetActive( true );
        }

        if ( hit.collider.tag == "Beer" ) {
            Falafel.SetActive( false );
            Bottle.SetActive( true );
            Bag.SetActive( false );
        }

        var person = hit.gameObject.GetComponent<Person>();
        if( person ) {
            Falafel.SetActive( false );
            Bottle.SetActive( false );
            Bag.SetActive( false );
        }
    }
}
