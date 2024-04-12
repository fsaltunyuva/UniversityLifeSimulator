using UnityEngine;

//Singleton Pattern for the player's stats and the connection between the university and the minigames
public class Singleton : MonoBehaviour
{
    public static Singleton Instance { get; private set; } //Singleton Pattern
    
    public static float currentAcademy; //Current academy points of the player
    public static float currentBasicNeed; //Current basic need points of the player
    public static float currentSocial; //Current social points of the player
    public static float universityTimerSeconds; //Current time for university 
    public static bool isPlayerPlayedUniversityAtLeastOnce = false; //Boolean to check if the player played the university scene at least once
    private static bool isInstatiatedBefore = false; // To prevent duplication of Singleton game object (Singleton Pattern)
    
    void Start()
    {
        if(!isInstatiatedBefore) //Singleton Pattern
        {
            DontDestroyOnLoad(this);
            isInstatiatedBefore = true;
        }
    }
    
    public static void increaseCurrentAcademy(float academy) //Increase or decrease the current academy points
    {
        currentAcademy += academy;
        if(currentAcademy >= 100) //To prevent exceeding 100
            currentAcademy = 100;
        if(currentAcademy <= 0) //To prevent going below 0
            currentAcademy = 0;
    }
    
    public static void increaseCurrentBasicNeed(float basicNeed) //Increase or decrease the current basic need points
    {
        currentBasicNeed += basicNeed;
        if(currentBasicNeed >= 100) //To prevent exceeding 100
            currentBasicNeed = 100;
        if(currentBasicNeed <= 0) //To prevent going below 0
            currentBasicNeed = 0;
    }
    
    public static void increaseCurrentSocial(float social) //Increase or decrease the current social points
    {
        currentSocial += social;
        if(currentSocial >= 100) //To prevent exceeding 100
            currentSocial = 100;
        if(currentSocial <= 0) //To prevent going below 0
            currentSocial = 0;
    }
}
