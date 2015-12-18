using UnityEngine;
using System.Collections;

public enum Need {
    Falafel,
    Beer,
    MDMA
}

public class Alina : MonoBehaviour {

    public GameObject Falafel;
    public GameObject Bottle;
    public GameObject Bag;

    public Person CurrentTarget;
    public Need CurrentNeed = Need.Falafel;

    public Person[] People;

	// Use this for initialization
	void Start () {
        People = GameObject.FindObjectsOfType<Person>();

        StartCoroutine( NewTarget(5) );
	}

    IEnumerator NewTarget(float wait) {
        yield return new WaitForSeconds( wait );

        var newPerson = People[Random.Range( 0, People.Length - 1 )];

        CurrentTarget = newPerson;
        CurrentNeed = (Need)Random.Range( 0, 2 );

        Debug.Log( "New Target: " + CurrentTarget.Name + " " + CurrentNeed.ToString() );
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
            var hasFalafel = Falafel.activeInHierarchy;
            var hasBottle = Bottle.activeInHierarchy;
            var hasBag = Bag.activeInHierarchy;

            Falafel.SetActive( false );
            Bottle.SetActive( false );
            Bag.SetActive( false );

            if((hasFalafel && CurrentNeed == Need.Falafel) || (hasBottle && CurrentNeed == Need.Beer) || (hasBottle && CurrentNeed == Need.MDMA)) {
                if ( CurrentTarget == person ) {
                    CurrentTarget = null;
                    StartCoroutine( NewTarget( Random.Range( 1, 4 ) ) );
                }
            }

        }
    }
}
