using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] private Slider academySlider, basicNeedSlider, socialSlider; //Slider to show the player's basic need and social

    private void FixedUpdate() //FixedUpdate is used to prevent the sliders from lagging behind
    {
        academySlider.value = Singleton.currentAcademy; //Sets the academy slider value to the current academy
        basicNeedSlider.value = Singleton.currentBasicNeed; //Sets the basic need slider value to the current basic need
        socialSlider.value = Singleton.currentSocial; //Sets the social slider value to the current social
    }
}
