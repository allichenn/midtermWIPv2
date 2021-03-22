using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class levelOneRiddle : MonoBehaviour
{
    
    public Text keyText;
    public Text endText;

    bool redRiddle = true;
    bool orangeRiddle = false;
    bool yellowRiddle = false;
    bool greenRiddle = false;
    bool homeRiddle = false;

    bool eggActive = false;
    bool carrotActive = false;
    bool watermelonActive = false;
    bool donutActive = false;

    public AudioSource interactSound, pickUpSound;

    bool hitRed, hitOrange, hitYellow, hitGreen;

    public GameObject exclamationPoint, exclamationPoint2;
    public Transform pointOne, pointTwo;

    // Start is called before the first frame update
    void Start()
    {
        exclamationPoint2.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionStay2D(Collision2D other){
        
        if(other.gameObject.name == "red_0" && redRiddle == true){
            if (Input.GetKey(KeyCode.Space)){
                interactSound.Play();
                keyText.text = "A BOX WITHOUT HINGES, LOCK OR KEY, \nYET A GOLDEN TREASURE LIES INSIDE ME. \nGO FIND IT FOR ME!";
                exclamationPoint.SetActive(false); //upon interaction, hide !
                exclamationPoint.transform.position = pointOne.position; //move ! to next position
                Debug.Log("touched red, bools redRiddle:" + redRiddle + " orangeRiddle: " + orangeRiddle);
                eggActive = true;
            }
        } else if(other.gameObject.name == "egg1" && eggActive == true){
            if (Input.GetKey(KeyCode.Space)){
                pickUpSound.Play();
                keyText.text = "CORRECT, AN EGG! THANK YOU!\n\nSEEMS LIKE ORANGE (BOTTOM LEFT) NEEDS SOME HELP TOO.";
                Debug.Log("found egg");
                Destroy(other.gameObject);
                exclamationPoint.SetActive(true); //upon touching egg, show next !
                redRiddle = false;
                eggActive = false;
                orangeRiddle = true;
            }
        } else if(other.gameObject.name == "orange_0" && orangeRiddle == true){
            if (Input.GetKey(KeyCode.Space)){
                interactSound.Play();
                keyText.text = "HELP ME FIND SOMETHING THAT IS \nORANGE AND SOUNDS LIKE PARROT!";
                exclamationPoint.SetActive(false); //upon orange interaction, hide the !
                Debug.Log("touched orange");
                carrotActive = true;
            }
        } else if(other.gameObject.name == "carrot1" && carrotActive == true){
            if (Input.GetKey(KeyCode.Space)){
                pickUpSound.Play();
                keyText.text = "YES, A CARROT! JUST WHAT I NEEDED!\n\nTALK TO YELLOW (BOTTOM RIGHT) NEXT?";
                Debug.Log("found carrot");
                Destroy(other.gameObject);
                exclamationPoint2.SetActive(true); //upon touching carrot, show new !
                orangeRiddle = false;
                carrotActive = false;
                yellowRiddle = true;
            }
        } else if(other.gameObject.name == "yellow_0" && yellowRiddle == true){
            if (Input.GetKey(KeyCode.Space)){
                interactSound.Play();
                keyText.text = "IT LOOKS GREEN, IT OPENS RED. \nWHAT YOU EAT IS RED BUT \nWHAT YOU SPIT OUT IS BLACK. \nWHAT AM I LOOKING FOR?";
                exclamationPoint2.SetActive(false); //upon talking, hide again
                exclamationPoint2.transform.position = pointTwo.position; //move to green position
                Debug.Log("touched yellow");
                watermelonActive = true;
            }
        } else if(other.gameObject.name == "watermelon1" && watermelonActive == true){
            if (Input.GetKey(KeyCode.Space)){
                pickUpSound.Play();
                keyText.text = "YES, A SLICE OF WATERMLON! YUM!\n\nPLEASE HELP GREEN (TOP RIGHT) AND CALL IT A DAY!";
                Debug.Log("found watermelon");
                Destroy(other.gameObject);
                exclamationPoint2.SetActive(true); //show !
                yellowRiddle = false;
                watermelonActive = false;
                greenRiddle = true;
            }
        } else if(other.gameObject.name == "green_0" && greenRiddle == true){
            if (Input.GetKey(KeyCode.Space)){
                interactSound.Play();
                keyText.text = "WHAT I AM LOOKING FOR HAS NO\nBEGINNING, MIDDLE, OR END.";
                exclamationPoint2.SetActive(false);
                Debug.Log("touched green");
                donutActive = true;
            }
        } else if(other.gameObject.name == "donut1" && donutActive == true){
            if (Input.GetKey(KeyCode.Space)){
                pickUpSound.Play();
                keyText.text = "INDEED, IT IS A DONUT!\n\nTHANK YOU SO MUCH FOR YOUR HELP! \nIT'S GETTING LATE... YOU SHOULD HEAD HOME NOW.";
                Debug.Log("found donut");
                Destroy(other.gameObject);
                greenRiddle = false;
                donutActive = false;
                homeRiddle = true;
            }
        } else if(other.gameObject.name == "homeDoor" && homeRiddle == true){
                endText.text = "IT HAS BEEN A GOOD DAY.\nTHE END.";
                Debug.Log("returned home");
                gameObject.SetActive(false);
                homeRiddle = true;
                SceneManager.LoadScene("levelTwo");
        } 
    } 
}
