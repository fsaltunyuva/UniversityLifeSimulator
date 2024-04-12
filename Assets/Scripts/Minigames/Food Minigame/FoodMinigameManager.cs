using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;

namespace Minigame_Related.Food_Minigame
{
    public class FoodMinigameManager : MonoBehaviour
    {
        [SerializeField] private FoodThrower[] fruitThrowerInstances; //Instances of fruit throwers
        [SerializeField] public TextMeshProUGUI eatenHealthyFruitsTMPUGUI; //Text that shows how many healthy fruits are eaten
        [SerializeField] public TextMeshProUGUI eatenUnhealthyFruitsTMPUGUI; //Text that shows how many unhealthy fruits are eaten
        [SerializeField] private GameObject resultPanel; //Result panel
        [SerializeField] private TextMeshProUGUI scorePercentageTMPUGUI; //Text that shows the score percentage
        [SerializeField] private TextMeshProUGUI basicNeedGainInfoTMPUGUI; //Text that shows how many basic need points are gained
    
        [HideInInspector] 
        public int eatenHealthyFoods = 0, eatenUnhealthyFoods = 0;
        private bool gameCondition = true; //false = lost, true = won/ongoing

        private void Start()
        {
            eatenHealthyFruitsTMPUGUI.text = eatenHealthyFoods.ToString(); //Set the text to 0
            eatenUnhealthyFruitsTMPUGUI.text = eatenUnhealthyFoods.ToString(); //Set the text to 0
        }

        void Update()
        {
            if (eatenUnhealthyFoods >= 3 && gameCondition) //If the player eats 3 unhealthy fruits and the game is still ongoing
            {
                gameCondition = false; //Lost
                foreach (var fruitThrowerInstance in fruitThrowerInstances) //Stop the fruit throwers
                {
                    fruitThrowerInstance.stop = true; 
                }
                Invoke(nameof(DisplayResults), 2f); //Display the results after 2 seconds
            }
        }

        private void DisplayResults()
        {
            // Set the cursor to be visible and unlock it
            Cursor.visible = true; 
            Cursor.lockState = CursorLockMode.None;
            
            int percentage = (int) ((double)eatenHealthyFoods / (eatenHealthyFoods+eatenUnhealthyFoods) * 100); //Calculate the percentage
            scorePercentageTMPUGUI.text = percentage + "%"; //Set the text to the percentage
            basicNeedGainInfoTMPUGUI.text = "You have gained " +  (percentage * 40) / 100 + " basic need point."; //Set the text to the basic need points gained
            Singleton.increaseCurrentBasicNeed(percentage * 20); //Increase the basic need points
            resultPanel.SetActive(true); //Display the result panel
        }

        public void loadUniversityScene()
        {
            // Set the cursor to be invisible and lock it
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.None;
            SceneManager.LoadScene("University"); //Load the university scene
        }
    }
}