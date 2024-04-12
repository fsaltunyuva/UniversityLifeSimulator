using UnityEngine;
using UnityEngine.Serialization;

namespace Minigame_Related.Food_Minigame 
{
    public class FoodCollector : MonoBehaviour
    {
        [SerializeField] private FoodMinigameManager foodMinigameManagerInstance; //Instance of the FoodMinigameManager script
        [SerializeField] private AudioSource audioSource; //AudioSource of the player
        [SerializeField] private AudioClip eatSFX; //SFX of eating
    
        private void OnTriggerEnter(Collider other) //If the player hits the food
        {
            if (other.CompareTag("HealthyFruit") ) //If the food is healthy
            {
                Destroy(other.transform.gameObject); //Destroy the food
                audioSource.PlayOneShot(eatSFX); //Play the eating SFX
                foodMinigameManagerInstance.eatenHealthyFoods++; //Increase the number of eaten healthy fruits    
                foodMinigameManagerInstance.eatenHealthyFruitsTMPUGUI.text = foodMinigameManagerInstance.eatenHealthyFoods.ToString(); //Set the text to show the number of eaten healthy fruits
            }
            else if (other.CompareTag("UnhealthyFruit")) //If the food is unhealthy
            {
                Destroy(other.transform.gameObject); //Destroy the food
                audioSource.PlayOneShot(eatSFX); //Play the eating SFX
                if (foodMinigameManagerInstance.eatenUnhealthyFoods !< 3) //If the number of eaten unhealthy fruits is not less than 3
                {
                    foodMinigameManagerInstance.eatenUnhealthyFoods++; //Increase the number of eaten unhealthy fruits
                    foodMinigameManagerInstance.eatenUnhealthyFruitsTMPUGUI.text = foodMinigameManagerInstance.eatenUnhealthyFoods.ToString(); //Set the text to show the number of eaten unhealthy fruits
                }
            }
        }
    }
}
