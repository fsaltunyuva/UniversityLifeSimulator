using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;

public class Timer : MonoBehaviour
{
    [SerializeField] float targetTime = 60.0f; //Time limit
    [SerializeField] TextMeshProUGUI timerText; //Timer text
    [SerializeField] TMP_InputField inputField; //Input field
    [SerializeField] QuizMinigameManager quizMinigameManagerScript; //Quiz minigame manager script
    [SerializeField] GameObject resultPanel; //Result panel
    [SerializeField] TextMeshProUGUI infoText; //Info text
    [SerializeField] TextMeshProUGUI resultText; //Result text
    [SerializeField] TextMeshProUGUI gainInfoText; //Gain info text

    public bool stopTimer; //If the timer should stop

    private void Start()
    {
        // Set the cursor to be visible and unlock it
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        timerText.text = targetTime.ToString("0"); //Set the timer text to the target time
    }

    private void Update()
    {
        if (!stopTimer) //If the timer is not stopped
        {
            targetTime -= Time.deltaTime; //Decreases the time limit
            timerText.text = targetTime.ToString("0"); //Sets the text to show the time limit

            if (targetTime <= 0.0f) //If the time limit is 0
            {
                timerEnded(); 
            }
        }
    }

    void timerEnded() //When the timer ends
    {
        timerText.text = "0"; //Set the timer text to 0
        inputField.interactable = false; //Disable the input field
        quizMinigameManagerScript.playerWin = false; //Player loses
        resultText.text = "You Lost!"; //Set the result text to "You Lost!"
        resultText.color = Color.red; //Set the result text color to red
        infoText.text = "You could not pass the quiz."; //Set the info text to "You could not pass the quiz."
        gainInfoText.text = "You could not gain any academy point."; //Set the gain info text to "You could not gain any academy point."
        resultPanel.SetActive(true); //Display the result panel
        //No need for switch-case since the result of losing is the same in the both quiz mini-games
        stopTimer = true; //Stop the timer
    }
    
    public void loadUniversityScene()
    {
        // Set the cursor to be invisible and lock it
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.None;
        SceneManager.LoadScene("University"); //Load the university scene
    }
}