using UnityEngine;
using Random = System.Random; //To use the Random class

public class Stick : MonoBehaviour
{
    [SerializeField] BasketballMinigameManager basketballMinigameManagerInstance; //Instance of the BasketballMinigameManager script
    private Floater floaterInstance; //Instance of the Floater script
    private bool hitUpperRed, hitLowerRed, hitGreen; //true = hit, false = not hit
    
    void Start()
    {
        floaterInstance = GetComponent<Floater>(); //Gets the Floater component
    }
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !basketballMinigameManagerInstance.gameOver) // If the player presses the space key
        {
            Random random = new Random(); //To generate random numbers
            if (hitGreen) // If the player hits the green part of the timing bar
            {
                floaterInstance.enabled = false; // Disable the floater
                
                float randomX = NextFloat(-1.4f, -0.68f); // Generate a random number between -1.4 and -0.68 for X value of the vector
                int randomY = random.Next(37, 43); // Generate a random number between 37 and 43 for Y value of the vector
                basketballMinigameManagerInstance.throwBall(randomX, randomY, 30f); // Throw the ball with the generated numbers
                Debug.Log("Force : " + randomX + " " + randomY + " " + 30f); // Log the force
                
                this.enabled = false; // Disable this script to prevent the player from adding a force to current ball again
                
                // Increase the score and set the text to show the score
                basketballMinigameManagerInstance.scoredBasketsTMPUGUI.text = (++basketballMinigameManagerInstance.score).ToString(); 
                basketballMinigameManagerInstance.threwBalls++; // Increase the number of balls thrown
                
                GetComponent<Floater>().frequency *= 1.2f; // Speed up the stick when the player scores
            }
            else if (hitUpperRed) // If the player hits the upper red part of the timing bar
            {
                floaterInstance.enabled = false; // Disable the floater 
                
                float randomX = NextFloat(-1.88f, -0.68f); // Generate a random number between -1.88 and -0.68 for X value of the vector
                int randomY = random.Next(45, 55); // Generate a random number between 45 and 55 for Y value of the vector
                basketballMinigameManagerInstance.throwBall(randomX, randomY, 30f); // Throw the ball with the generated numbers
                Debug.Log("Force : " + randomX + " " + randomY + " " + 30f); // Log the force
                
                this.enabled = false; // Disable this script to prevent the player from adding a force to current ball again
                
                basketballMinigameManagerInstance.threwBalls++; // Increase the number of balls thrown
                GetComponent<Floater>().frequency /= 1.1f; // Slow down the stick when the player scores
            }
            else if (hitLowerRed)
            {
                floaterInstance.enabled = false; // Disable the floater
                
                float randomX = NextFloat(-1.88f, -0.68f); // Generate a random number between -1.88 and -0.68 for X value of the vector
                int randomY = random.Next(15, 25); // Generate a random number between 15 and 25 for Y value of the vector
                basketballMinigameManagerInstance.throwBall(randomX, randomY, 30f); // Throw the ball with the generated numbers
                Debug.Log("Force : " + randomX + " " + randomY + " " + 30f); // Log the force
                
                this.enabled = false; // Disable this script
                
                basketballMinigameManagerInstance.threwBalls++; // Increase the number of balls thrown
                GetComponent<Floater>().frequency /= 1.1f; // Slow down the stick when the player scores
            }
        }
    }
    
    private void OnTriggerEnter2D(Collider2D other) // If the stick hits the timing bar
    {
        switch (other.gameObject.name) // Check which part of the timing bar the stick hits
        {
            case "Upper Red":
                hitUpperRed = true;
                break;
            case "Lower Red":
                hitLowerRed = true;
                break;
            case "Green":
                hitGreen = true;
                break;
        }
    }

    private void OnTriggerExit2D(Collider2D other) // If the stick leaves the timing bar
    {
        switch (other.gameObject.name) // Check which part of the timing bar the stick leaves
        {
            case "Upper Red":
                hitUpperRed = false;
                break;
            case "Lower Red":
                hitLowerRed = false;
                break;
            case "Green":
                hitGreen = false;
                break;
        }
    }
    
    //Gotten from https://www.w3schools.blog/c-random-float-between-two-numbers to generate a random float between two numbers
    static float NextFloat(float min, float max){
        Random random = new Random();
        double val = (random.NextDouble() * (max - min) + min);
        return (float)val;
    }
}