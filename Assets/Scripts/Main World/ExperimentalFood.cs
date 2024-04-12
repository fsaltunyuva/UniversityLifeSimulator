using UnityEngine;

//Created by following the tutorial at https://www.youtube.com/watch?v=hsJs7dvzgMM
//Created for collectible foods in the area, not in use in the final game but kept for future additions.

[RequireComponent(typeof(SphereCollider))]

public class ExperimentalFood : MonoBehaviour
{
    //Amounts to replenish the player's needs by
    [SerializeField] private float _basicNeedAmountToReplenish = 10f, _academyAmountToReplenish = 10f, _socialAmountToReplenish = 10f;
    
    private void Awake()
    {
        GetComponent<SphereCollider>().isTrigger = true; //Sets the collider to be a trigger to allow the player to trigger the food
    }

    private void Update()
    {
        transform.Rotate(transform.up, 20f * Time.deltaTime); //Rotates the food 
    }

    private void OnTriggerEnter(Collider other)
    {
        if(!other.gameObject.CompareTag("Player")) return; //Checks if the player has triggered the food and if not, returns
        
        SurvivalManager survivalManager = other.gameObject.GetComponent<SurvivalManager>(); //Gets the SurvivalManager instance from the player
        
        if (survivalManager == null) return; //Checks if the SurvivalManager instance is null and if so, returns
        
        survivalManager.ReplenishAcademyBasicNeedSocial(_academyAmountToReplenish, _basicNeedAmountToReplenish, _socialAmountToReplenish); //Replenishes the player's needs
        Destroy(gameObject); //Destroys the food
    }
}
