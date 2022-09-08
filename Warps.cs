using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Warps : MonoBehaviour
{
    public int warpId;
    public Player player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player").GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
     if(warpId == 0 && other.tag == "Player")   
        {
            
            Debug.Log("You have entered the store.");
            player.transform.position = new Vector3(-12.6f, 2.8f, 0);
        }

     else if(warpId == 1 && other.tag == "Player")
        {
            Debug.Log("You have exited the store.");
            player.transform.position = new Vector3(-1.51f, -0.9f, 0);
        }
    }

}
