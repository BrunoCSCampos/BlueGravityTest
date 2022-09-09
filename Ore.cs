using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ore : MonoBehaviour
{
    public GameManager gameManager;
    public Player player;
    public float oreHp = 3;
    public bool interactRange = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        InteractOre();
        DestroyOre();
    }

    public void DestroyOre()
    {
        if(oreHp <= 0)
        {
            gameManager = GameObject.Find("Game_Manager").GetComponent<GameManager>();
            gameManager.money = gameManager.money + 10;
            Destroy(this.gameObject);
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Debug.Log("Player is within range.");
            interactRange = true;
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            Debug.Log("Player has left range.");
            interactRange = false;
        }
    }

    public void InteractOre()
    {
        player = GameObject.Find("Player").GetComponent<Player>();
        if (interactRange == true && Input.GetKeyDown(KeyCode.Space) && player.currentStamina >= 1)
        {
            Debug.Log("You have interacted with an Ore");
            player.AttackOre();

        }
    }


}
