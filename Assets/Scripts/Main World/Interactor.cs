using UnityEngine;

//This script inspired from the tutorial https://www.youtube.com/watch?v=K06lVKiY-sY

interface IInteractable //Interface to allow the player to interact with the object
{
    public void Interact(); //Method to be called when the player interacts with the object
}

public class Interactor : MonoBehaviour
{
    private Transform cameraTransform; //The camera's transform
    public float interactRange; //The range the player can interact with objects
    
    [SerializeField] private GameObject crosshair; //The crosshair to show when the player cannot interact with an object
    [SerializeField] private GameObject interactionCrosshair; //The crosshair to show when the player can interact with an object

    private void Start()
    {
        if (Camera.main != null)  //Checks if the main camera is not null to prevent NullReferenceException
            cameraTransform = Camera.main.transform; //Sets the cameraTransform to the main camera's transform
    }

    void Update()
    {
        Ray r = new Ray(cameraTransform.position, cameraTransform.forward); //Creates a ray from the camera's position to the direction the camera is facing
        Debug.DrawRay(cameraTransform.position, cameraTransform.forward, Color.green); //Draws the ray in the scene view for debugging purposes

        if (Physics.Raycast(r, out RaycastHit hitInfo, interactRange)) //Checks if the raycast has hit an object within the interactRange
        {
            
            if (hitInfo.collider.gameObject.TryGetComponent(out IInteractable interactObj) && 
                (Input.GetKeyDown(KeyCode.E) || Input.GetMouseButtonDown(0))) //Checks if the object has the IInteractable interface and if the player has pressed E or left click
            {
                interactObj.Interact(); //Calls the Interact method on the object that has the IInteractable interface
            }
            
            if (hitInfo.collider.gameObject.CompareTag("Interactable")) //Checks if the object has the Interactable tag
            {
                crosshair.SetActive(false); //Disables the crosshair
                interactionCrosshair.SetActive(true); //Enables the interaction crosshair
            }
            else
            {
                crosshair.SetActive(true); //Enables the crosshair
                interactionCrosshair.SetActive(false); //Disables the interaction crosshair
            }
        }
    }
}