using System.Collections;
using UnityEngine;
using Random = System.Random;

namespace Minigame_Related.Food_Minigame
{
    public class FoodThrower : MonoBehaviour
    {
        [SerializeField] private bool reverseDirection = false; //For the other fruit thrower, if there is two fruit throwers it should be true
        [SerializeField] private float minForceX = 1.5f; //Minimum force in x axis
        [SerializeField] private float maxForceX = 3.5f; //Maximum force in x axis
        [SerializeField] private float minForceY = 5f; //Minimum force in y axis
        [SerializeField] private float maxForceY = 8f; //Maximum force in y axis
        [SerializeField] private GameObject[] fruits; //Fruits that will be thrown

        private Random _random = new Random(); //Random object for randomizing the force 
        
        [HideInInspector]
        public bool stop = false; //If true, the fruit thrower will stop throwing fruits
    
        void Start()
        {
            if (reverseDirection) //If the fruit thrower is the other one
            {
                minForceX *= -1; //Reverse the force in x axis
                maxForceX *= -1; //Reverse the force in x axis
            }
            StartCoroutine(ThrowFruit()); //Start throwing fruits
        }
    
        IEnumerator ThrowFruit() //Coroutine for throwing fruits
        { 
            if (!stop) //If the fruit thrower is not stopped
            {
                int randomFruitIndex = _random.Next(0, fruits.Length); //Randomize the fruit
                
                GameObject currentFruit = Instantiate(fruits[randomFruitIndex], transform.position, Quaternion.identity); //Instantiate the fruit and get the instance
                float randomForceX = (float) _random.NextDouble() * (maxForceX - minForceX) + minForceX; //Randomize the force in x axis
                float randomForceY = (float) _random.NextDouble() * (maxForceY - minForceY) + minForceY; //Randomize the force in y axis
                Vector3 forceAmount = new Vector3(randomForceX, randomForceY, 0); //Create a vector3 for the force
                currentFruit.GetComponent<Rigidbody>().AddTorque(new Vector3(0,5,5), ForceMode.Impulse); //Add torque to the fruit
                currentFruit.GetComponent<Rigidbody>().AddForce(forceAmount, ForceMode.Impulse); //Add force to the fruit
        
                float randomTimeBetweenFruits = _random.Next(1, 2); //Randomize the time between fruits (May not work as intended because of the .Next()?)
                
                yield return new WaitForSeconds(randomTimeBetweenFruits); //Wait for the time
        
                StartCoroutine(ThrowFruit()); //Start throwing fruits again
            }
        }
    }
}