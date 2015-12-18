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

    public static Person CurrentTarget;
    public static Need CurrentNeed = Need.Falafel;

    public Person[] People;

    public AudioSource Source;

    public AudioClip Drink;
    public AudioClip Cents;
    public AudioClip Drugs;
    public AudioClip Snack;

	// Use this for initialization
	void Start () {
        People = GameObject.FindObjectsOfType<Person>();

        //Source = GetComponent<AudioSource>();

        StartCoroutine( NewTarget(5) );
	}

    IEnumerator NewTarget(float wait) {
        yield return new WaitForSeconds( wait );

        var newPerson = People[Random.Range( 0, People.Length)];

        CurrentTarget = newPerson;
        CurrentNeed = (Need)Random.Range( 0, 3 );

        Debug.Log( "New Target: " + CurrentTarget.Name + " " + CurrentNeed.ToString() );
    }
	
	// Update is called once per frame
	void Update () {

	}

    void OnControllerColliderHit( ControllerColliderHit hit ) {
        if(hit.collider.tag == "Falafel") {
            if (!Falafel.activeInHierarchy) {
                Source.PlayOneShot(Cents);
                Debug.Log("Play");
            }
            

            Falafel.SetActive( true );
            Bottle.SetActive( false );
            Bag.SetActive( false );

            
        }

        if ( hit.collider.tag == "Drug" ) {
            if (!Bag.activeInHierarchy) {
                Source.PlayOneShot(Cents);
            }
            
            Falafel.SetActive( false );
            Bottle.SetActive( false );
            Bag.SetActive( true );

        }

        if ( hit.collider.tag == "Beer" ) {
            if (!Bottle.activeInHierarchy) {
                Source.PlayOneShot(Cents);
            }            
            
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

            if (hasFalafel) {
                Source.PlayOneShot(Snack);
            }

            if (hasBottle) {
                Source.PlayOneShot(Drink);
            }

            if (hasBag) {
                Source.PlayOneShot(Drugs);
            }


            if((hasFalafel && CurrentNeed == Need.Falafel) || (hasBottle && CurrentNeed == Need.Beer) || (hasBag && CurrentNeed == Need.MDMA)) {
                if ( CurrentTarget == person ) {
                    CurrentTarget = null;
                    StartCoroutine( NewTarget( Random.Range( 1, 4 ) ) );
                }
            }

        }
    }
}
