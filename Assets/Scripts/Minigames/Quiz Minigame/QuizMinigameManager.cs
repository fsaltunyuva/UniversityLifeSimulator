using UnityEngine;
using TMPro;
using System.Linq;
using UnityEngine.SceneManagement;

public class QuizMinigameManager : MonoBehaviour
{
    [SerializeField] private TMP_InputField inputField; //Input field for the quiz
    [SerializeField] Timer timerScript; //Timer script
    private string winningCode; //Winning code for the quiz
    public bool playerWin; //If the player wins
    public bool submitButtonClicked; //If the submit button is clicked
    [SerializeField] GameObject resultPanel; //Result panel
    [SerializeField] TextMeshProUGUI infoText; //Info text
    [SerializeField] TextMeshProUGUI resultText; //Result text
    [SerializeField] TextMeshProUGUI gainInfoText; //Gain info text
    [SerializeField] private TextMeshProUGUI quizTypeInfoText; //Quiz type info text (invisible text) that shows the quiz type

    private void Start()
    {
        if (inputField != null) //If the input field is not null
        {
            // Attach the OnValueChanged event handler to validate and filter input
            inputField.onValueChanged.AddListener(ValidateAndFilterInput);
            //Make sure the input field is selected when the scene starts
            inputField.Select();
            inputField.ActivateInputField();
        }
        
        //Set winning code based on scene name
        setWinCode();
    }

    void Update()
    {
        //Check if the player has entered the winning code
        if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.KeypadEnter) || submitButtonClicked) //If the player presses enter or the submit button is clicked
        {
            if (inputField.text == winningCode) //If the player enters the winning code
            {
                timerScript.stopTimer = true; //Stop the timer
                playerWin = true; //Player wins
                resultText.text = "You Win!"; //Set the result text to "You Win!"
                resultText.color = Color.green; //Set the result text color to green
                infoText.text = "You have passed the quiz."; //Set the info text to "You have passed the quiz."
                resultPanel.SetActive(true); //Display the result panel
                switch (quizTypeInfoText.text) //Switch the quiz type info text
                {
                    case "1": //If the quiz type is 1
                        gainInfoText.text = "You have gained 20 academy point."; //Set the gain info text to "You have gained 40 academy point."
                        Singleton.increaseCurrentAcademy(20); //Increase the academy points by 40
                        Debug.Log("Added 20 to academy point."); //Log the academy points
                        break;
                    case "2": //If the quiz type is 2
                        gainInfoText.text = "You have gained 30 academy point."; //Set the gain info text to "You have gained 50 academy point."
                        Singleton.increaseCurrentAcademy(30); //Increase the academy points by 50
                        Debug.Log("Added 30 to academy point."); //Log the academy points
                        break;
                }
            }
            else
            {
                timerScript.stopTimer = true; //Stop the timer
                playerWin = false; //Player loses
                resultText.text = "You Lost!"; //Set the result text to "You Lost!"
                resultText.color = Color.red; //Set the result text color to red
                infoText.text = "You could not pass the quiz."; //Set the info text to "You could not pass the quiz."
                gainInfoText.text = "You could not gain any academy point."; //Set the gain info text to "You could not gain any academy point."
                resultPanel.SetActive(true); //Display the result panel
            }
        }
    }

    private void ValidateAndFilterInput(string text) //Validate and filter the input to prevent the player from entering invalid characters 
    {
        // Only allow the characters 'R', 'G', 'B', '\r', '\n', and '\b' to be entered
        string allowedChars = "rgbRGB\r\n\x08";
        string filteredText = new string(text.Where(c => allowedChars.Contains(c)).ToArray());
        inputField.text = filteredText.ToUpper();
    }

    private void setWinCode() //Set winning code based on the quiz type info text
    {
        if (quizTypeInfoText.text.Contains("1"))
        {
            winningCode = "GBRBGBBRBBRBRGRBBRBRBBGRBG";
        }
        else if (quizTypeInfoText.text.Contains("2"))
        {
            winningCode = "BGRRGRRBRBBGRBGRBRGBGBRG";
        }
    }
    
    //Button click handlers
    public void OnRedButtonClicked()
    {
        inputField.text += "R";
    }

    public void OnGreenButtonClicked()
    {
        inputField.text += "G";
    }

    public void OnBlueButtonClicked()
    {
        inputField.text += "B";
    }

    public void OnSubmitButtonClicked()
    {
        submitButtonClicked = true;
    }
}