using StarterAssets;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

//Created by following the tutorial at https://www.youtube.com/watch?v=hsJs7dvzgMM

public class SurvivalManager : MonoBehaviour
{
    [Header("Academic")]
    [SerializeField] private float _maxAcademy; //Max amount of academy the player can have
    [SerializeField] private float _academyDepletionRate; //Rate at which the academy depletes
    private float _currentAcademy; //Current amount of academy the player has
    
    [Header("Basic Needs")]
    [SerializeField] private float _maxBasicNeed; //Max amount of basic need the player can have
    [SerializeField] private float _basicNeedDepletionRate; //Rate at which the basic need depletes
    private float _currentBasicNeed; //Current amount of basic need the player has
    
    [Header("Social")]
    [SerializeField] private float _maxSocial; //Max amount of social the player can have
    [SerializeField] private float _socialDepletionRate; //Rate at which the social depletes
    private float _currentSocial; //Current amount of social the player has
    
    [SerializeField] private GameObject _gameOverPanel; //Panel to show the game over screen
    [SerializeField] private TextMeshProUGUI resultText; //Text to show the result of the game
    [SerializeField] private TextMeshProUGUI infoText; //Text to show the result of the game

    private void Start()
    {
        //To lock the cursor after the minigames
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        
        if (!Singleton.isPlayerPlayedUniversityAtLeastOnce) //Checks if the player has played university at least once
        {
            _currentAcademy = _maxAcademy; //Sets the current academy to the max academy
            _currentBasicNeed = _maxBasicNeed; //Sets the current basic need to the max basic need
            _currentSocial = _maxSocial; //Sets the current social to the max social
            Singleton.isPlayerPlayedUniversityAtLeastOnce = true; //Sets the isPlayerPlayedUniversityAtLeastOnce to true
        }
        else
        {
            Debug.Log("Player played university at least once.");
            _currentAcademy = Singleton.currentAcademy; //Sets the current academy to the saved current academy
            _currentBasicNeed = Singleton.currentBasicNeed; //Sets the current basic need to the saved current basic need
            _currentSocial = Singleton.currentSocial; //Sets the current social to the saved current social
        }
    }

    private void Update()
    {
        _currentAcademy -= _academyDepletionRate * Time.deltaTime; //Depletes the academy
        _currentBasicNeed -= _basicNeedDepletionRate * Time.deltaTime; //Depletes the basic need
        _currentSocial -= _socialDepletionRate * Time.deltaTime; //Depletes the social
        
        Singleton.currentAcademy = _currentAcademy; //Saves the current academy
        Singleton.currentBasicNeed = _currentBasicNeed; //Saves the current basic need
        Singleton.currentSocial = _currentSocial; //Saves the current social

        if (_currentAcademy <= 0 || _currentBasicNeed <= 0 || _currentSocial <= 0) //Checks if the player has lost
        {
            Cursor.lockState = CursorLockMode.None; //Unlocks the cursor
            Cursor.visible = true; //Shows the cursor
            resultText.text = "You lost!"; //Sets the result text to show that the player has lost
            resultText.color = Color.red; //Sets the result text color to red
            infoText.text = "You could not graduate from the university. You can try again by pressing the button below."; //Sets the info text to show that the player has lost
            _gameOverPanel.SetActive(true); //Enables the game over panel
            _currentAcademy = 0; //Sets the current academy to 0
            _currentBasicNeed = 0; //Sets the current basic need to 0
            _currentSocial = 0; //Sets the current social to 0
        } 
    }
    
    //Not in use in the final game but kept for future additions. (Method for ExperimentalFood.cs)
    public void ReplenishAcademyBasicNeedSocial(float academyAmount, float basicNeedAmount, float socialAmount) //Method to replenish the player's needs
    {
        _currentAcademy += academyAmount; //Adds the academy amount to the current academy
        _currentBasicNeed += basicNeedAmount; //Adds the basic need amount to the current basic need
        _currentSocial += socialAmount; //Adds the social amount to the current social
        
        if (_currentAcademy > _maxAcademy) //Checks if the current academy is greater than the max academy
        {
            _currentAcademy = _maxAcademy;
        }
        if(_currentSocial > _maxSocial) //Checks if the current social is greater than the max social
        {
            _currentSocial = _maxSocial;
        }
        if (_currentBasicNeed > _maxBasicNeed) //Checks if the current basic need is greater than the max basic need
        {
            _currentBasicNeed = _maxBasicNeed;
        }
    }
    
    public void ReloadGame() //Method to reload the game
    {
        Singleton.isPlayerPlayedUniversityAtLeastOnce = false; //Sets the isPlayerPlayedUniversityAtLeastOnce to false
        Singleton.currentAcademy = _maxAcademy; //Sets the current academy to the max academy
        Singleton.currentBasicNeed = _maxBasicNeed; //Sets the current basic need to the max basic need
        Singleton.currentSocial = _maxSocial; //Sets the current social to the max social
        UnityEngine.SceneManagement.SceneManager.LoadScene("University"); //Reloads the scene
    }
}
