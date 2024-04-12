using TMPro;
using UnityEngine;

public class UniversityTimer : MonoBehaviour
{
    [SerializeField] float targetTime = 500; //Time limit
    [SerializeField] TextMeshProUGUI timerText; //Text to show the time limit
    public bool stopTimer; //false = ongoing
    
    [SerializeField] private GameObject _gameOverPanel; //Panel to show the game over screen
    [SerializeField] private TextMeshProUGUI resultText; //Text to show the result of the game
    [SerializeField] private TextMeshProUGUI infoText; //Text to show the result of the game
    
    private void Start()
    {
        if(Singleton.isPlayerPlayedUniversityAtLeastOnce)
            targetTime = Singleton.universityTimerSeconds; //Sets the time limit to the saved time limit
        timerText.text = targetTime.ToString("0"); //Sets the text to show the time limit
    }

    private void Update()
    {
        if (!stopTimer) //If the timer is not stopped
        {
            targetTime -= Time.deltaTime; //Decreases the time limit
            Singleton.universityTimerSeconds = targetTime; //Saves the current time limit
            
            //Gotten from https://stackoverflow.com/questions/3665012/how-to-convert-seconds-in-minsec-format
            int seconds =  (int)(targetTime % 60);
            int minutes = (int)(targetTime / 60);
            timerText.text = minutes + ":" + seconds;

            if (targetTime <= 0.0f) //If the time limit is over
            {
                timerEnded();
            }
        }
    }
    
    void timerEnded()
    {
        Cursor.lockState = CursorLockMode.None; //Unlocks the cursor
        Cursor.visible = true; //Shows the cursor
        
        timerText.text = "0"; //Sets the text to show the time limit
        stopTimer = true; //Stops the timer
        resultText.text = "You won!"; //Sets the result text
        infoText.text = "You graduated from the university! Congratulations!"; //Sets the info text
        _gameOverPanel.SetActive(true); //Enables the result panel
    }
}
