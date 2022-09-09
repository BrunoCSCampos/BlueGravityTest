using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float moveSpeed = 1;

    public bool canMove = true;
    public bool isDown = true;
    public bool isUp = false;
    public bool isLeft = false;
    public bool isRight = false;

    public bool canAttack = true;

    public float totalStamina = 5;
    public float currentStamina = 5;
    public float attackArea = 0.25f;

    public LayerMask oreLayer;
    

    public GameManager gameManager;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("Game_Manager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
        Inventory();
    }

    public void Movement()
    {
        if (canMove == true)
        {
            if (Input.GetKey(KeyCode.UpArrow))
            {
                Debug.Log("Walking up");
                isDown = false;
                isLeft = false;
                isRight = false;
                isUp = true;
                transform.Translate(Vector3.up * Time.deltaTime * moveSpeed);
                //Move object up
                //Play Up animation loop
            }
            if (Input.GetKey(KeyCode.DownArrow))
            {
                Debug.Log("Walking down");
                isUp = false;
                isLeft = false;
                isRight = false;
                isDown = true;
                transform.Translate(Vector3.down * Time.deltaTime * moveSpeed);
                //Move object down
                //Play down animation loop
            }
            if (Input.GetKey(KeyCode.RightArrow))
            {
                isUp = false;
                isDown = false;
                isLeft = false;
                isRight = true;
                Debug.Log("Walking right");
                transform.Translate(Vector3.right * Time.deltaTime * moveSpeed);
                //Play right animation loop
            }
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                isUp = false;
                isDown = false;
                isRight = false;
                isLeft = true;
                Debug.Log("Walking left");
                transform.Translate(Vector3.left * Time.deltaTime * moveSpeed);
                //Play left animation loop
            }
        }
    }

    public void Inventory()
    {
      if(gameManager.inventoryOpen == false && Input.GetKeyDown(KeyCode.KeypadEnter))
        {
            gameManager.OpenInventory();
        }
    }

    public void AttackOre()
    {
        if(currentStamina >= 1 && canAttack == true)
        {
            Collider[] attack = Physics.OverlapSphere(transform.position, attackArea, oreLayer);

            foreach (Collider attackedOre in attack)
            {
                Debug.Log("You have attacked an ore.");
                Ore oreScript = attackedOre.GetComponent<Ore>();
                Ore_Animation oreAnimation = attackedOre.GetComponent<Ore_Animation>();
                if (oreScript != null && oreAnimation != null)
                {
                    oreScript.oreHp = oreScript.oreHp -1;
                    oreAnimation.AnimateHit();
                    StartCoroutine("AttackRoutine");

                }
                

            }
        }
    }

    public IEnumerator AttackRoutine()
    {
        canAttack = false;
        yield return new WaitForSeconds(0.1f);
        currentStamina = currentStamina - 1;
        canAttack = true;
        StopCoroutine("AttackRoutine");
    }

    //public void OnDrawGizmos()
    //{
    //    Gizmos.color = Color.red;
    //    Gizmos.DrawWireSphere(transform.position, attackArea);
    //}
}
