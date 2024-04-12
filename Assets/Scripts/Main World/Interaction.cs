using UnityEngine;
using UnityEngine.SceneManagement;

//This script is used to load the minigames when the player interacts with the minigame loader objects

//Implements the IInteractable interface to allow the player to interact with the object (Interface is in the Interactor.cs)
public class Interaction : MonoBehaviour, IInteractable 
{
    public void Interact() //Called when the player interacts with the object
    {
        switch (gameObject.name) //Switch statement to check which object the player has interacted with
        {
            case "QuizLoader1":
                SceneManager.LoadScene("Quiz Minigame 1");
                break;
            case "QuizLoader2":
                SceneManager.LoadScene("Quiz Minigame 2");
                break;
            case "FoodLoader":
                SceneManager.LoadScene("Food Minigame");
                break;
            case "SocializeLoader":
                SceneManager.LoadScene("Socialize Minigame");
                break;
            case "SocializeLoader2":
                SceneManager.LoadScene("Basketball Minigame");
                break;
        }
    }
}
