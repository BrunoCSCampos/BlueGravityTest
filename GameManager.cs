using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Player player;
    public UIManager uiManager;
    public Cursor cursor;

    public bool hasOutfit1 = false;
    public bool hasOutfit2 = false;
    public bool hasOutfit3 = false;

    public bool shopUIEnabled = false;
    public bool shopOpen = false;

    public float money = 10;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player").transform.GetComponent<Player>();
        cursor = GameObject.Find("Cursor").transform.GetComponent<Cursor>();
        uiManager = GameObject.Find("Canvas").transform.GetComponent<UIManager>();
    }

    // Update is called once per frame
    void Update()
    {
        CursorControl();
        CursorSelect();
    }

    public void OpenShop()
    {
        if (shopOpen == false)
        {
            player.canMove = false;
            uiManager.ShopDialogue();
            shopUIEnabled = true;
            CursorEnabled();
            shopOpen = true;
        }

    }

    public void CursorEnabled()
    {
        if (shopUIEnabled == true)
        {
            GameObject.Find("Cursor").transform.GetComponent<Image>().enabled = true;
            cursor.onShopBuy = true;
        }
    }

    public void CursorDisabled()
    {
        GameObject.Find("Cursor").transform.GetComponent<Image>().enabled = false;
    }

    public void CursorControl()
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
            else if (Input.GetKeyDown(KeyCode.DownArrow) && cursor.onShopOutfit1 == true)
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
    }

    public void CursorSelect()
    {
        if (Input.GetKeyDown(KeyCode.Space) && cursor.onShopBuy == true)
        {
            Debug.Log("Tried to buy something");
            uiManager.ShopOptions();
            cursor.onShopBuy = false;
            cursor.onShopOutfit1 = true;

        }
        else if (Input.GetKeyDown(KeyCode.Space) && cursor.onShopSell == true)
        {
            Debug.Log("Tried to sell something");
        }
        else if (Input.GetKeyDown(KeyCode.Space) && cursor.onShopBack1 == true)
        {

            cursor.onShopBack1 = false;
            uiManager.ShopFullClose();
            player.canMove = true;
            CursorDisabled();
            StartCoroutine("ShopRoutine");
        }
        else if (Input.GetKeyDown(KeyCode.Space) && cursor.onShopOutfit1 == true && hasOutfit1 == false)
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
            //Close shop options
            //Move cursor back
            cursor.onShopBuy = true;
        }


    }

    public IEnumerator ShopRoutine()
    {
        yield return new WaitForSeconds(0.2f);
        shopUIEnabled = false;
        shopOpen = false;
        StopCoroutine("ShopRoutine");
    }

    
    
}
