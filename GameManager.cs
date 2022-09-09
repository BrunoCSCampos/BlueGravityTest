using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Player player;
    public UIManager uiManager;
    public Cursor cursor;
    public Walk_0_Animation walkScript;
    public Animator walkAnimator;

    public bool hasOutfit1 = false;
    public bool hasOutfit2 = false;
    public bool hasOutfit3 = false;

    public bool usingOutfit0 = true;
    public bool usingOutfit1 = false;
    public bool usingOutfit2 = false;
    public bool usingOutfit3 = false;

    public bool shopUIEnabled = false;
    public bool shopOpen = false;
    public bool inventoryUIEnabled = false;
    public bool inventoryOpen = false;
    public bool innUIEnabled = false;
    public bool innOpen = false;
    public bool onBuyMode = false;
    public bool onSellMode = false;

    public bool onInnMode = false;

    public float money = 10;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player").transform.GetComponent<Player>();
        cursor = GameObject.Find("Cursor").transform.GetComponent<Cursor>();
        uiManager = GameObject.Find("Canvas").transform.GetComponent<UIManager>();
        walkScript = GameObject.Find("Player").transform.GetComponent<Walk_0_Animation>();
        walkAnimator = walkScript.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        CursorShopControl();
        CursorShopSelect();
        CursorInventoryControl();
        CursorInventorySelect();
        CursorOnInnControl();
        CursorInnSelect();
    }

    public void OpenShop()
    {
        if (shopOpen == false && inventoryOpen == false)
        {
            player.canMove = false;
            walkAnimator.SetBool("canMove", false);
            walkScript.ResetPosition();
            uiManager.ShopDialogue();
            shopUIEnabled = true;
            CursorEnabled();
            shopOpen = true;
        }

    }

    public void OpenInventory()
    {
        if(shopOpen == false && shopUIEnabled == false && inventoryOpen == false && innOpen == false)
        {
            player.canMove = false;
            walkAnimator.SetBool("canMove", false);
            walkScript.ResetPosition();
            uiManager.InventoryOpen();
            inventoryUIEnabled = true;
            CursorEnabled();
            inventoryOpen = true;
            

        }
    }

    public void OpenInn()
    {
        if(innOpen == false && inventoryOpen == false)
        {
            
            player.canMove = false;
            walkAnimator.SetBool("canMove", false);
            walkScript.ResetPosition();
            uiManager.InnDialogue();
            innUIEnabled = true;
            CursorEnabled();
            innOpen = true;
            StartCoroutine("OnInnRoutine");
        }
    }

    public void CursorEnabled()
    {
        if (shopUIEnabled == true)
        {
            cursor.onShopBuy = true;
        }
        if(inventoryUIEnabled == true)
        {
            cursor.onInventoryOutfit0 = true;
        }
        if(innUIEnabled == true)
        {
            cursor.onInnRest = true;
        }
    }

       public void CursorInventoryControl()
    {
        if(inventoryUIEnabled == true)
        {
            if(cursor.onInventoryOutfit0 && Input.GetKeyDown(KeyCode.DownArrow))
            {
                cursor.onInventoryOutfit0 = false;
                cursor.onInventoryOutfit1 = true;
            }
            else if(Input.GetKeyDown(KeyCode.DownArrow) && cursor.onInventoryOutfit1 == true)
            {
                cursor.onInventoryOutfit1 = false;
                cursor.onInventoryOutfit2 = true;
            }
            else if(Input.GetKeyDown(KeyCode.DownArrow) && cursor.onInventoryOutfit2 == true)
            {
                cursor.onInventoryOutfit2 = false;
                cursor.onInventoryOutfit3 = true;
            }
            else if(Input.GetKeyDown(KeyCode.DownArrow) && cursor.onInventoryOutfit3 == true)
            {
                cursor.onInventoryOutfit3 = false;
                cursor.onInventoryBack = true;
            }
            else if(Input.GetKeyDown(KeyCode.UpArrow) && cursor.onInventoryOutfit1 == true)
            {
                cursor.onInventoryOutfit1 = false;
                cursor.onInventoryOutfit0 = true;
            }
            else if (Input.GetKeyDown(KeyCode.UpArrow) && cursor.onInventoryOutfit2 == true)
            {
                cursor.onInventoryOutfit2 = false;
                cursor.onInventoryOutfit1 = true;
            }
            else if (Input.GetKeyDown(KeyCode.UpArrow) && cursor.onInventoryOutfit3 == true)
            {
                cursor.onInventoryOutfit3 = false;
                cursor.onInventoryOutfit2 = true;
            }
            else if (Input.GetKeyDown(KeyCode.UpArrow) && cursor.onInventoryBack == true)
            {
                cursor.onInventoryBack = false;
                cursor.onInventoryOutfit3 = true;
            }
        }
    }
    public void CursorShopControl()
    {
        if (shopUIEnabled == true)
        {

            if (cursor.onShopBuy == true && Input.GetKeyDown(KeyCode.DownArrow))
            {
                cursor.onShopBuy = false;
                cursor.onShopSell = true;
            }
            else if (Input.GetKeyDown(KeyCode.DownArrow) && cursor.onShopSell == true)
            {
                cursor.onShopSell = false;
                cursor.onShopBack1 = true;
            }
            else if (Input.GetKeyDown(KeyCode.UpArrow) && cursor.onShopSell == true)
            {
                cursor.onShopSell = false;
                cursor.onShopBuy = true;
            }
            else if (Input.GetKeyDown(KeyCode.UpArrow) && cursor.onShopBack1 == true)
            {
                cursor.onShopBack1 = false;
                cursor.onShopSell = true;
            }
            if (onBuyMode == true)
            {

                if (Input.GetKeyDown(KeyCode.DownArrow) && cursor.onShopOutfit1 == true)
                {
                    cursor.onShopOutfit1 = false;
                    cursor.onShopOutfit2 = true;
                }
                else if (Input.GetKeyDown(KeyCode.UpArrow) && cursor.onShopOutfit2 == true)
                {
                    cursor.onShopOutfit2 = false;
                    cursor.onShopOutfit1 = true;
                }
                else if (Input.GetKeyDown(KeyCode.DownArrow) && cursor.onShopOutfit2 == true)
                {
                    cursor.onShopOutfit2 = false;
                    cursor.onShopOutfit3 = true;
                }
                else if (Input.GetKeyDown(KeyCode.UpArrow) && cursor.onShopOutfit3 == true)
                {
                    cursor.onShopOutfit3 = false;
                    cursor.onShopOutfit2 = true;
                }
                else if (Input.GetKeyDown(KeyCode.DownArrow) && cursor.onShopOutfit3 == true)
                {
                    cursor.onShopOutfit3 = false;
                    cursor.onShopBack2 = true;
                }
                else if (Input.GetKeyDown(KeyCode.UpArrow) && cursor.onShopBack2 == true)
                {
                    cursor.onShopBack2 = false;
                    cursor.onShopOutfit3 = true;
                }
            }
            if (onSellMode == true)
            {
                if (Input.GetKeyDown(KeyCode.DownArrow) && cursor.onSellOutfit1 == true)
                {
                    cursor.onSellOutfit1 = false;
                    cursor.onSellOutfit2 = true;
                }
                else if (Input.GetKeyDown(KeyCode.UpArrow) && cursor.onSellOutfit2 == true)
                {
                    cursor.onSellOutfit2 = false;
                    cursor.onSellOutfit1 = true;
                }
                else if (Input.GetKeyDown(KeyCode.DownArrow) && cursor.onSellOutfit2 == true)
                {
                    cursor.onSellOutfit2 = false;
                    cursor.onSellOutfit3 = true;
                }
                else if (Input.GetKeyDown(KeyCode.UpArrow) && cursor.onSellOutfit3 == true)
                {
                    cursor.onSellOutfit3 = false;
                    cursor.onSellOutfit2 = true;
                }
                else if (Input.GetKeyDown(KeyCode.DownArrow) && cursor.onSellOutfit3 == true)
                {
                    cursor.onSellOutfit3 = false;
                    cursor.onSellBack = true;
                }
                else if (Input.GetKeyDown(KeyCode.UpArrow) && cursor.onSellBack == true)
                {
                    cursor.onSellBack = false;
                    cursor.onSellOutfit3 = true;
                }
            }


        }
    }

    public void CursorOnInnControl()
    {
        if(Input.GetKeyDown(KeyCode.DownArrow) && cursor.onInnRest == true)
        {
            cursor.onInnRest = false;
            cursor.onInnBack = true;
        }
        else if(Input.GetKeyDown(KeyCode.UpArrow) && cursor.onInnBack == true)
        {
            cursor.onInnBack = false;
            cursor.onInnRest = true;
        }
    }


    public void CursorInventorySelect()
    {
        if (Input.GetKeyDown(KeyCode.Space) && cursor.onInventoryOutfit0 == true)
        {
            Debug.Log("You've equipped Outfit0");
            usingOutfit0 = true;
            usingOutfit1 = false;
            usingOutfit2 = false;
            usingOutfit3 = false;
        }

        else if (Input.GetKeyDown(KeyCode.Space) && cursor.onInventoryOutfit1 == true && hasOutfit1 == true)
        {
            Debug.Log("You've equipped Outfit1");
            usingOutfit1 = true;
            usingOutfit0 = false;
            usingOutfit2 = false;
            usingOutfit3 = false;
        }
        else if (Input.GetKeyDown(KeyCode.Space) && cursor.onInventoryOutfit2 == true && hasOutfit2 == true)
        {
            Debug.Log("You've equipped Outfit2");
            usingOutfit2 = true;
            usingOutfit0 = false;
            usingOutfit1 = false;
            usingOutfit3 = false;
        }
        else if (Input.GetKeyDown(KeyCode.Space) && cursor.onInventoryOutfit3 == true && hasOutfit3 == true)
        {
            Debug.Log("You've equipped Outfit3");
            usingOutfit3 = true;
            usingOutfit1 = false;
            usingOutfit2 = false;
            usingOutfit0 = false;
        }
        else if (Input.GetKeyDown(KeyCode.Space) && cursor.onInventoryBack == true)
        {
            cursor.onInventoryBack = false;
            uiManager.InventoryClose();
            player.canMove = true;
            walkAnimator.SetBool("canMove", true);
            StartCoroutine("InventoryRoutine");
        }



    }

    public void CursorInnSelect()
    {
        if (onInnMode == true)
        {
            if (Input.GetKeyDown(KeyCode.Space) && cursor.onInnRest == true)
            {
                Debug.Log("You've rested at the inn.");
                player.transform.position = new Vector3(-14.1f, -0.8f, 0);
                uiManager.InnClose();
                cursor.onInnRest = false;
                player.canMove = true;
                player.currentStamina = player.totalStamina;
                walkAnimator.SetBool("canMove", true);
                StartCoroutine("InnRoutine");

            }
            else if (Input.GetKeyDown(KeyCode.Space) && cursor.onInnBack == true)
            {
                uiManager.InnClose();
                cursor.onInnBack = false;
                player.canMove = true;
                onInnMode = false;
                walkAnimator.SetBool("canMove", true);
                StartCoroutine("InnRoutine");
            }
        }
    }
    public void CursorShopSelect()
    {
        if (Input.GetKeyDown(KeyCode.Space) && cursor.onShopBuy == true)
        {
            Debug.Log("Tried to buy something");
            uiManager.ShopOptions();
            cursor.onShopBuy = false;
            cursor.onShopOutfit1 = true;
            StartCoroutine("OnBuyRoutine");

        }
        else if (Input.GetKeyDown(KeyCode.Space) && cursor.onShopSell == true)
        {
            Debug.Log("Tried to sell something");
            uiManager.ShopOptions();
            cursor.onShopSell = false;
            cursor.onSellOutfit1 = true;
            StartCoroutine("OnSellRoutine");
        }
        else if (Input.GetKeyDown(KeyCode.Space) && cursor.onShopBack1 == true)
        {

            cursor.onShopBack1 = false;
            uiManager.ShopFullClose();
            player.canMove = true;
            walkAnimator.SetBool("canMove", true);
            StartCoroutine("ShopRoutine");
        }

        if (onBuyMode == true)
        {
            if (Input.GetKeyDown(KeyCode.Space) && cursor.onShopOutfit1 == true && hasOutfit1 == false)
            {
                if (money >= 50)
                {
                    Debug.Log("Bought Outfit1");
                    hasOutfit1 = true;
                    money = money - 50;
                }
                else
                {
                    Debug.Log("Not enough money");
                }
            }
            else if (Input.GetKeyDown(KeyCode.Space) && cursor.onShopOutfit2 == true && hasOutfit2 == false)
            {
                if (money >= 50)
                {
                    Debug.Log("Bought Outfit2");
                    hasOutfit2 = true;
                    money = money - 50;
                }
                else
                {
                    Debug.Log("Not enough money");
                }
            }
            else if (Input.GetKeyDown(KeyCode.Space) && cursor.onShopOutfit3 == true && hasOutfit3 == false)
            {
                if (money >= 50)
                {
                    Debug.Log("Bought Outfit3");
                    hasOutfit3 = true;
                    money = money - 50;
                }
                else
                {
                    Debug.Log("Not enough money");
                }
            }
            else if (Input.GetKeyDown(KeyCode.Space) && cursor.onShopBack2 == true)
            {
                cursor.onShopBack2 = false;
                uiManager.ShopCloseOptions();
                cursor.onShopBuy = true;
                onBuyMode = false;
                onSellMode = false;
            }
        }
        else if (onSellMode == true)
        {
            if (Input.GetKeyDown(KeyCode.Space) && cursor.onSellOutfit1 == true && hasOutfit1 == true && usingOutfit1 == false)
            {
                Debug.Log("Sold Outfit1");
                hasOutfit1 = false;
                money = money + 25;


            }
            else if (Input.GetKeyDown(KeyCode.Space) && cursor.onSellOutfit2 == true && hasOutfit2 == true && usingOutfit2 == false)
            {
                Debug.Log("Sold Outfit2");
                hasOutfit2 = false;
                money = money + 25;
            }


            else if (Input.GetKeyDown(KeyCode.Space) && cursor.onSellOutfit3 == true && hasOutfit3 == true && usingOutfit3 == false)
            {
                Debug.Log("Sold Outfit3");
                hasOutfit3 = false;
                money = money + 25;

            }
            else if (Input.GetKeyDown(KeyCode.Space) && cursor.onSellBack == true)
            {
                cursor.onSellBack = false;
                uiManager.ShopCloseOptions();
                cursor.onShopBuy = true;
                onBuyMode = false;
                onSellMode = false;
            }
        }
    }
    
       


    

    public IEnumerator ShopRoutine()
    {
        yield return new WaitForSeconds(0.2f);
        shopUIEnabled = false;
        shopOpen = false;
        StopCoroutine("ShopRoutine");
    }

    public IEnumerator InventoryRoutine()
    {
        yield return new WaitForSeconds(0.2f);
        inventoryUIEnabled = false;
        inventoryOpen = false;
        StopCoroutine("InventoryRoutine");
    }

    public IEnumerator OnBuyRoutine()
    {
        yield return new WaitForSeconds(0.2f);
        onBuyMode = true;
        StopCoroutine("OnBuyRoutine");
    }

    public IEnumerator OnSellRoutine()
    {
        yield return new WaitForSeconds(0.2f);
        onSellMode = true;
        StopCoroutine("OnSellRoutine");
    }

    public IEnumerator OnInnRoutine()
    {
        yield return new WaitForSeconds(0.2f);
        onInnMode = true;
        StopCoroutine("OnnInnRoutine");
    }
    public IEnumerator InnRoutine()
    {
        yield return new WaitForSeconds(0.2f);
        innUIEnabled = false;
        innOpen = false;
        StopCoroutine("InnRoutine");
    }

    
    
}
