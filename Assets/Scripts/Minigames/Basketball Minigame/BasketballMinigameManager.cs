using System.Collections;
using TMPro;
using UnityEngine;

//Close up camera logic gotten from https://stackoverflow.com/questions/43234909/how-can-i-make-the-second-camera-to-display-in-the-bottom-right-corner-in-a-smal

public class BasketballMinigameManager : MonoBehaviour
{
    [SerializeField] private Rigidbody basketballRigidbody; //Rigidbody of the basketball
    [SerializeField] private GameObject basketballPrefab; //Prefab of the basketball
    [SerializeField] private GameObject stick; //Stick on timing bar
    [SerializeField] private GameObject closeUpCamera; //Camera to show the basketball going into the hoop
    [SerializeField] public TextMeshProUGUI scoredBasketsTMPUGUI; //Text to show the number of baskets scored
    public bool gameOver = false; //false = ongoing
    public int score = 0; //Number of baskets scored
    public int threwBalls = 0; //Number of balls thrown
     
    IEnumerator InstantiateNewBall() //Instantiates a new basketball after 2.5 seconds
    {
        yield return new WaitForSeconds(2.5f); //Waits for 2.5 seconds
        GameObject instantiatedBasketball = Instantiate(basketballPrefab); //Instantiates a new basketball and stores it in a variable
        basketballRigidbody = instantiatedBasketball.GetComponent<Rigidbody>(); //Gets the Rigidbody of the new basketball
        stick.GetComponent<Stick>().enabled = true; //Enables the stick
        stick.GetComponent<Floater>().enabled = true; //Enables the floater
        closeUpCamera.SetActive(false); //Disables the close up camera
    }
    
    public void throwBall(float x, float y, float z) //Throws the basketball
    {
        basketballRigidbody.AddForce(new Vector3(x, y, z), ForceMode.Impulse); //Adds a force to the basketball with ForceMode.Impulse
        closeUpCamera.SetActive(true); //Enables the close up camera
        StartCoroutine(InstantiateNewBall()); //Starts the coroutine to instantiate a new basketball
    }
}
