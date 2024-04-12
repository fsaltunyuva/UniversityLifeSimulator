using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    private Vector2 rawInput; //Raw input from the player
    [SerializeField] private float moveSpeed = 5f; //Move speed of the player

    void Update()
    {
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, -3.3f, 3.3f), transform.position.y, transform.position.z); //Clamp the player's position
        transform.position += new Vector3(rawInput.x * moveSpeed * Time.deltaTime,0,0); //Move the player
    }
    
    void OnMove(InputValue value)
    {
        rawInput = value.Get<Vector2>(); //Get the raw input
    }
}
