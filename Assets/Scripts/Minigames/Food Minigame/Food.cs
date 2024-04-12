using UnityEngine;

public class Food : MonoBehaviour
{
    private void OnTriggerEnter(Collider other) 
    {
        if (other.CompareTag("Destroyer")) //If the food hits the destroyer
        {
            Destroy(gameObject); //Destroy the food
        }
    }
}
