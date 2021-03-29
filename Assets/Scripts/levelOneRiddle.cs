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

    bool carrotActive = false;
    bool eggActive = false;
    bool watermelonActive = false;
    bool donutActive = false;
    bool fiveCheck = false;

    public AudioSource interactSound, pickUpSound;

    bool hitRed, hitOrange, hitYellow, hitGreen;

    public GameObject exclamationPoint, exclamationPoint2;
    public Transform pointOne, pointTwo, pointThree, pointFour, pointFive; //three and four are first
    private Transform currentPoint;

    //black screen stuff//
    public bool fading = false;
    public SpriteRenderer blackScreen;
    private Color fadeColor;
    public float alpha = 1;

    float cameraLeft, cameraRight, cameraBottom, cameraTop;

    float cameraDist = 0.5f;

    // Start is called before the first frame update
    void Start()
    {
        exclamationPoint2.SetActive(false);
        currentPoint = pointThree;
    }

    // Update is called once per frame
    void Update()
    {

        Vector2 lowerLeft = Camera.main.ScreenToWorldPoint(new Vector3(0, 0, 0)); //finding screen location
        Vector2 upperRight = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0));
        cameraLeft = lowerLeft.x + cameraDist;
        cameraBottom = lowerLeft.y + cameraDist;
        cameraRight = upperRight.x - cameraDist;
        cameraTop = upperRight.y - cameraDist;

        if (fading == true){
            Debug.Log("fading");
            
            if (alpha < 1){
                alpha += .002f;
            } else {
                SceneManager.LoadScene("levelTwo");
            }
        } else {
            if (alpha > 0){
                alpha -= .02f;
            }
        }

        fadeColor = new Color(0, 0, 0, alpha);
        blackScreen.color = fadeColor;

        if (exclamationPoint.activeInHierarchy){
            exclamationPoint.transform.position = Vector3.Lerp(exclamationPoint.transform.position, currentPoint.position, 0.03f);

            if (exclamationPoint.transform.position.x > cameraRight)
            {
                exclamationPoint.transform.position = new Vector3(cameraRight, exclamationPoint.transform.position.y, exclamationPoint.transform.position.z);
            }

            if (exclamationPoint.transform.position.x < cameraLeft)
            {
                exclamationPoint.transform.position = new Vector3(cameraLeft, exclamationPoint.transform.position.y, exclamationPoint.transform.position.z);
            }

            if (exclamationPoint.transform.position.y > cameraTop)
            {
                exclamationPoint.transform.position = new Vector3(exclamationPoint.transform.position.x, cameraTop, exclamationPoint.transform.position.z);
            }

            if (exclamationPoint.transform.position.y < cameraBottom)
            {
                exclamationPoint.transform.position = new Vector3(exclamationPoint.transform.position.x, cameraBottom, exclamationPoint.transform.position.z);
            }
        }

        if (exclamationPoint2.activeInHierarchy){
            exclamationPoint2.transform.position = Vector3.Lerp(exclamationPoint2.transform.position, currentPoint.position, 0.03f);

            if (exclamationPoint2.transform.position.x > cameraRight)
            {
                exclamationPoint2.transform.position = new Vector3(cameraRight, exclamationPoint2.transform.position.y, exclamationPoint2.transform.position.z);
            }

            if (exclamationPoint2.transform.position.x < cameraLeft)
            {
                exclamationPoint2.transform.position = new Vector3(cameraLeft, exclamationPoint2.transform.position.y, exclamationPoint2.transform.position.z);
            }

            if (exclamationPoint2.transform.position.y > cameraTop)
            {
                exclamationPoint2.transform.position = new Vector3(exclamationPoint2.transform.position.x, cameraTop, exclamationPoint2.transform.position.z);
            }

            if (exclamationPoint2.transform.position.y < cameraBottom)
            {
                exclamationPoint2.transform.position = new Vector3(exclamationPoint2.transform.position.x, cameraBottom, exclamationPoint2.transform.position.z);
            }
        }
    }

    private void OnCollisionStay2D(Collision2D other){
        
        if(other.gameObject.name == "red_0" && redRiddle == true){
            if (Input.GetKey(KeyCode.Space)){
                interactSound.Play();
                keyText.text = "HELP ME FIND SOMETHING THAT IS \nORANGE AND SOUNDS LIKE PARROT!";

                exclamationPoint.SetActive(false); //upon interaction, hide !
                //exclamationPoint.transform.position = pointOne.position; //move ! to next position

                Debug.Log("touched red, bools redRiddle:" + redRiddle + " orangeRiddle: " + orangeRiddle);
                carrotActive = true;
            }
        } else if(other.gameObject.name == "carrot1" && carrotActive == true){
            if (Input.GetKey(KeyCode.Space)){
                pickUpSound.Play();
                keyText.text = "YES, A CARROT! JUST WHAT I NEEDED!\n\nSEEMS LIKE ORANGE (BOTTOM LEFT) NEEDS SOME HELP TOO.";
                Debug.Log("found carrot");
                Destroy(other.gameObject);

                exclamationPoint.SetActive(true); //upon touching egg, show next !
                exclamationPoint.transform.position = gameObject.transform.position; //move ! to next position
                currentPoint = pointOne;

                redRiddle = false;
                carrotActive = false;
                orangeRiddle = true;
            }
        } else if(other.gameObject.name == "orange_0" && orangeRiddle == true){
            if (Input.GetKey(KeyCode.Space)){
                interactSound.Play();
                keyText.text = "A BOX WITHOUT HINGES, LOCK OR KEY, \nYET A GOLDEN TREASURE LIES INSIDE IT.. \nCAN YOU HELP ME FIND THIS?";

                exclamationPoint.SetActive(false); //upon orange interaction, hide the !

                Debug.Log("touched orange");
                eggActive = true;
            }
        } else if(other.gameObject.name == "egg1" && eggActive == true){
            if (Input.GetKey(KeyCode.Space)){
                pickUpSound.Play();
                keyText.text = "CORRECT, AN EGG! THANK YOU!\n\nTALK TO YELLOW (BOTTOM RIGHT) NEXT?";
                Debug.Log("found egg");
                Destroy(other.gameObject);

                exclamationPoint2.SetActive(true); //upon touching carrot, show new !
                exclamationPoint2.transform.position = gameObject.transform.position; //move ! to next position
                currentPoint = pointFour;

                orangeRiddle = false;
                eggActive = false;
                yellowRiddle = true;
            }
        } else if(other.gameObject.name == "yellow_0" && yellowRiddle == true){
            if (Input.GetKey(KeyCode.Space)){
                interactSound.Play();
                keyText.text = "IT LOOKS GREEN, IT OPENS RED. \nWHAT YOU EAT IS RED BUT \nWHAT YOU SPIT OUT IS BLACK. \nWHAT AM I LOOKING FOR?";

                exclamationPoint2.SetActive(false); //upon talking, hide again
                //exclamationPoint2.transform.position = pointTwo.position; //move to green position

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
                exclamationPoint2.transform.position = gameObject.transform.position; //move ! to next position
                currentPoint = pointTwo;
                
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

                exclamationPoint2.SetActive(true); //show !
                exclamationPoint2.transform.position = gameObject.transform.position; //move ! to next position
                currentPoint = pointFive;
                fiveCheck = true;

                greenRiddle = false;
                donutActive = false;
                homeRiddle = true;
            }
        } else if(other.gameObject.name == "homeDoor" && homeRiddle == true){
                fading = true;
                endText.text = "IT HAS BEEN A GOOD DAY.\nYOU REST WELL...";
                Debug.Log("returned home");
                //gameObject.SetActive(false);
                gameObject.GetComponent<SpriteRenderer>().enabled = false;
                homeRiddle = true;
                //SceneManager.LoadScene("levelTwo"); //go to level two
        } 
    } 

     void OnTriggerEnter2D(Collider2D other){ //COLLIDER not COLLISION bc no physics
        if(other.gameObject.name == "pointFiveCheck" && fiveCheck == true){
                
            exclamationPoint2.SetActive(false);
            Debug.Log("touched point five");
        }
    }
}
