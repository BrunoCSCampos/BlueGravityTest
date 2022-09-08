using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shopkeeper : MonoBehaviour
{
    public bool interactRange = false;
    public Player player;
    public GameManager gameManager;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("Game_Manager").transform.GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        InteractShop(); 
    }

    public void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            Debug.Log("Player is within range.");
            interactRange = true;
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if(other.tag == "Player")
        {
            Debug.Log("Player has left range.");
            interactRange = false;
        }
    }

    public void InteractShop()
    {
        if(interactRange == true && Input.GetKeyDown(KeyCode.Space) && gameManager.shopOpen == false)
        {
            Debug.Log("You have interacted with the NPC");
            gameManager.OpenShop();
            

        }
    }
}
