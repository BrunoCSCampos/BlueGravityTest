using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Walk_0_Animation : MonoBehaviour
{
    public Animator animator;
    public Player player;
    public GameManager gameManager;

    public bool isWalkingUp = false;
    public bool isWalkingDown = false;
    public bool isWalkingLeft = false;
    public bool isWalkingRight = false;

    public void Start()
    {
        animator = GetComponent<Animator>();
        gameManager = GameObject.Find("Game_Manager").GetComponent<GameManager>();
    }

    public void Update()
    {
        WalkingAnimation();
        ChangeOutfit();

    }

    public void WalkingAnimation()
    {
        if (Input.GetKey(KeyCode.DownArrow))
        {
            isWalkingDown = true;
            SetDirection();
            animator.SetBool("DWalk_On", true);
            animator.SetBool("DWalk_Idle", false);
        }
        else if (Input.GetKeyUp(KeyCode.DownArrow))
        {
            animator.SetBool("DWalk_Idle", true);
            animator.SetBool("DWalk_On", false);
            WalkingReset();

        }
        else if (Input.GetKey(KeyCode.UpArrow))
        {
            isWalkingUp = true;
            SetDirection();
            animator.SetBool("UWalk_On", true);
            animator.SetBool("UWalk_Idle", false);
        }
        else if (Input.GetKeyUp(KeyCode.UpArrow))
        {
            animator.SetBool("UWalk_Idle", true);
            animator.SetBool("UWalk_On", false);
            WalkingReset();
        }

        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            isWalkingLeft = true;
            SetDirection();
            animator.SetBool("LWalk_On", true);
            animator.SetBool("LWalk_Idle", false);
        }
        else if (Input.GetKeyUp(KeyCode.LeftArrow))
        {
            animator.SetBool("LWalk_Idle", true);
            animator.SetBool("LWalk_On", false);
            WalkingReset();
        }

        else if (Input.GetKey(KeyCode.RightArrow))
        {
            isWalkingRight = true;
            SetDirection();
            animator.SetBool("RWalk_On", true);
            animator.SetBool("RWalk_Idle", false);
        }
        else if (Input.GetKeyUp(KeyCode.RightArrow))
        {
            animator.SetBool("RWalk_Idle", true);
            animator.SetBool("RWalk_On", false);
            WalkingReset();
        }
    }

    public void WalkingReset()
    {
        isWalkingDown = false;
        isWalkingUp = false;
        isWalkingLeft = false;
        isWalkingRight = false;
    }
    public void SetDirection()
    {
        if (isWalkingUp == true)
        {
            animator.SetBool("DWalk_Idle", false);
            animator.SetBool("DWalk_On", false);
            animator.SetBool("LWalk_Idle", false);
            animator.SetBool("LWalk_On", false);
            animator.SetBool("RWalk_On", false);
            animator.SetBool("RWalk_Idle", false);
        }
        if (isWalkingDown == true)
        {
            animator.SetBool("UWalk_Idle", false);
            animator.SetBool("UWalk_On", false);
            animator.SetBool("LWalk_Idle", false);
            animator.SetBool("LWalk_On", false);
            animator.SetBool("RWalk_On", false);
            animator.SetBool("RWalk_Idle", false);
        }
        if(isWalkingLeft == true)
        {
            animator.SetBool("DWalk_Idle", false);
            animator.SetBool("DWalk_On", false);
            animator.SetBool("UWalk_Idle", false);
            animator.SetBool("UWalk_On", false);
            animator.SetBool("RWalk_On", false);
            animator.SetBool("RWalk_Idle", false);
        }
        if(isWalkingRight == true)
        {
            animator.SetBool("DWalk_Idle", false);
            animator.SetBool("DWalk_On", false);
            animator.SetBool("UWalk_Idle", false);
            animator.SetBool("UWalk_On", false);
            animator.SetBool("LWalk_On", false);
            animator.SetBool("LWalk_Idle", false);
        }
    }

    public void ResetPosition()
    {
        animator.SetBool("DWalk_Idle", true);
        animator.SetBool("DWalk_On", false);
        animator.SetBool("UWalk_Idle", false);
        animator.SetBool("UWalk_On", false);
        animator.SetBool("LWalk_Idle", false);
        animator.SetBool("LWalk_On", false);
        animator.SetBool("RWalk_On", false);
        animator.SetBool("RWalk_Idle", false);
    }

    public void ChangeOutfit()
    {
        if(gameManager.usingOutfit0 == true)
        {
            animator.SetBool("usingOutfit0", true);
            animator.SetBool("usingOutfit1", false);
            animator.SetBool("usingOutfit2", false);
            animator.SetBool("usingOutfit3", false);
        }
        else if(gameManager.usingOutfit1 == true)
        {
            animator.SetBool("usingOutfit1", true);
            animator.SetBool("usingOutfit0", false);
            animator.SetBool("usingOutfit2", false);
            animator.SetBool("usingOutfit3", false);
        }
        else if(gameManager.usingOutfit2 == true)
        {
            animator.SetBool("usingOutfit2", true);
            animator.SetBool("usingOutfit0", false);
            animator.SetBool("usingOutfit1", false);
            animator.SetBool("usingOutfit3", false);
        }
        else if(gameManager.usingOutfit3 == true)
        {
            animator.SetBool("usingOutfit3", true);
            animator.SetBool("usingOutfit0", false);
            animator.SetBool("usingOutfit1", false);
            animator.SetBool("usingOutfit2", false);
        }
    }


}
