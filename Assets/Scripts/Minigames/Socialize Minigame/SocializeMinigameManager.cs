using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Random = System.Random;

public class SocializeMinigameManager : MonoBehaviour
{
    [SerializeField] private string[] questions; //Questions for the quiz
    [SerializeField] private string[] answers; //Answers for the quiz
    [SerializeField] private TextMeshProUGUI questionText; //Question text
    [SerializeField] private GameObject yesButton; //Yes button
    [SerializeField] private GameObject noButton; //No button
    [SerializeField] private GameObject resultPanel; //Result panel
    [SerializeField] private TextMeshProUGUI scorePercentageTMPUGUI; //Text that shows the score percentage
    [SerializeField] private TextMeshProUGUI socializeGainInfoTMPUGUI; //Text that shows how many socialize points are gained
    
    private int correctAnswers; //Correct answers
    private int wrongAnswers; //Wrong answers
    
    private string answer; //Answer of the player
    private int currentQuestionIndex; //Current question index
    
    void Start()
    {
        // Set the cursor to be visible and unlock it
        Cursor.visible = true; 
        Cursor.lockState = CursorLockMode.None;
        
        ShuffleArray(questions); //Shuffle the questions
        ShuffleArray(answers); //Shuffle the answers
        
        currentQuestionIndex = 0; //Set the current question index to 0
        questionText.text = questions[0]; //Set the question text to the first question
    }
    
    public void YesButton() //When the player clicks the yes button
    {
        answer ="yes";
        CheckAnswer();
    }
    
    public void NoButton() //When the player clicks the no button
    {
        answer = "no";
        CheckAnswer();
    }

    private void CheckAnswer() //Check the answer
    {
        if (answer == answers[currentQuestionIndex]) //If the answer is correct
        {
            correctAnswers++; //Increase the correct answers
            Debug.Log("Correct!");
        }
        else //If the answer is wrong
        { 
            wrongAnswers++; //Increase the wrong answers
            Debug.Log("Wrong!");
        }

        if (!(currentQuestionIndex + 1 >= questions.Length)) //If the current question index is not the last question
        {
            currentQuestionIndex++; //Increase the current question index
            questionText.text = questions[currentQuestionIndex]; //Set the question text to the current question
        }
        else
        {
            Debug.Log("End of questions!"); //Log the end of questions
            int percentage = (int) ((double)correctAnswers / (correctAnswers+wrongAnswers) * 100); //Calculate the percentage
            scorePercentageTMPUGUI.text = percentage + "%"; //Set the text to the percentage
            socializeGainInfoTMPUGUI.text = "You have gained " +  (percentage * 40) / 100 + " basic need point."; //Set the text to the basic need points gained
            Singleton.increaseCurrentSocial(percentage * 40); //Increase the basic need points
            resultPanel.SetActive(true); //Display the result panel
            yesButton.GetComponent<Button>().interactable = false; //Disable the yes button for further use
            noButton.GetComponent<Button>().interactable = false; //Disable the no button for further use
        }
    }
    
    public void loadUniversityScene() 
    {
        // Set the cursor to be invisible and lock it
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.None;
        SceneManager.LoadScene("University"); //Load the university scene
    }
    
    //Gotten from StackOverflow to shuffle array
    static void ShuffleArray<T>(T[] array)
    {
        Random random = new Random();

        // Iterate through the array from the end to the beginning
        for (int i = array.Length - 1; i > 0; i--)
        {
            // Generate a random index within the array
            int randomIndex = random.Next(0, i + 1);

            // Swap the elements at the current and random indices
            (array[i], array[randomIndex]) = (array[randomIndex], array[i]);
        }
    }
    
}
