using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class BasketballTimer : MonoBehaviour
{
    [SerializeField] float targetTime = 60.0f; //Time limit
    [SerializeField] TextMeshProUGUI timerText; //Text to show the time limit
    [SerializeField] private TextMeshProUGUI scoredBasketsTMPUGUI; //Text to show the number of baskets scored
    [SerializeField] private TextMeshProUGUI socializeGainInfoTMPUGUI; //Text to show the number of socialize points gained
    [SerializeField] private TextMeshProUGUI basicNeedLossInfoTMPUGUI; //Text to show the number of basic need points lost
    [SerializeField] private BasketballMinigameManager basketballMinigameManagerInstance; //Instance of the BasketballMinigameManager script
    [SerializeField] private GameObject resultPanel; //Panel to show the result of the minigame
    public bool stopTimer; //false = ongoing
    
    private void Start()
    {
        //To show the cursor and unlock it
        Cursor.visible = true; 
        Cursor.lockState = CursorLockMode.None;
        
        timerText.text = targetTime.ToString("0"); //Sets the text to show the time limit
    }

    private void Update()
    {
        if (!stopTimer) //If the timer is not stopped
        {
            targetTime -= Time.deltaTime; //Decreases the time limit
            timerText.text = targetTime.ToString("0"); //Sets the text to show the time limit

            if (targetTime <= 0.0f) //If the time limit is over
            {
                timerEnded();
            }
        }
    }
    
    void timerEnded()
    {
        basketballMinigameManagerInstance.gameOver = true; //Sets the game over variable to true
        timerText.text = "0"; //Sets the text to show the time limit
        stopTimer = true; //Stops the timer
        scoredBasketsTMPUGUI.text = basketballMinigameManagerInstance.score.ToString(); //Sets the text to show the number of baskets scored
        socializeGainInfoTMPUGUI.text = "You have gained " + (basketballMinigameManagerInstance.score * 2) + " socialize point."; //Sets the text to show the number of socialize points gained
        basicNeedLossInfoTMPUGUI.text = "You have lost " + (basketballMinigameManagerInstance.threwBalls * 2) + " basic need points. Because you have thrown " + basketballMinigameManagerInstance.threwBalls + " balls.";
        resultPanel.SetActive(true); //Enables the result panel
        Singleton.increaseCurrentSocial(basketballMinigameManagerInstance.score * 1); //Increases the current socialize points
        Singleton.increaseCurrentBasicNeed(-basketballMinigameManagerInstance.threwBalls * 2); //Decreases the current basic need points
    }
    
    public void loadUniversityScene()
    {
        //Set the cursor to be invisible and lock it
        Cursor.visible = false; 
        Cursor.lockState = CursorLockMode.Locked; 
        SceneManager.LoadScene("University"); //Loads the university scene
    }
}
