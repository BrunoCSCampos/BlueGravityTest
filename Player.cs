using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float moveSpeed = 1;
    public bool canMove = true;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Movement();
    }

    public void Movement()
    {
        if (canMove == true)
        {
            if (Input.GetKey(KeyCode.UpArrow))
            {
                Debug.Log("Walking up");
                transform.Translate(Vector3.up * Time.deltaTime * moveSpeed);
                //Move object up
                //Play Up animation loop
            }
            if (Input.GetKey(KeyCode.DownArrow))
            {
                Debug.Log("Walking down");
                transform.Translate(Vector3.down * Time.deltaTime * moveSpeed);
                //Move object down
                //Play down animation loop
            }
            if (Input.GetKey(KeyCode.RightArrow))
            {
                Debug.Log("Walking right");
                transform.Translate(Vector3.right * Time.deltaTime * moveSpeed);
                //Play right animation loop
            }
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                Debug.Log("Walking left");
                transform.Translate(Vector3.left * Time.deltaTime * moveSpeed);
                //Play left animation loop
            }
        }
    }
}
