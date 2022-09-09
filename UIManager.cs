using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public GameObject storeUI;
    public GameObject inventoryUI;
    public GameObject shopOptionsUI;
    public GameObject inventoryOptionsUI;
    public GameObject innUI;

    public GameManager gameManager;
    public Player player;

    public Text goldText;
    public Text energyText;



    // Start is called before the first frame update
    void Start()
    {
        
        gameManager = GameObject.Find("Game_Manager").GetComponent<GameManager>();
        player = GameObject.Find("Player").GetComponent<Player>();
        goldText = transform.GetChild(3).transform.GetChild(0).GetComponent<Text>();
        energyText = transform.GetChild(4).GetComponent<Text>();
        storeUI = transform.GetChild(0).gameObject;
        inventoryUI = transform.GetChild(2).gameObject;
        inventoryOptionsUI = inventoryUI.transform.GetChild(0).gameObject;
        shopOptionsUI = storeUI.transform.GetChild(3).gameObject;
        innUI = transform.GetChild(1).gameObject;

    }

    // Update is called once per frame
    void Update()
    {
        UpdateInventoryOptions();
        UpdateShopOptions();
        GoldCounter();
        EnergyCounter();
    }

    public void ShopDialogue()
    {
        storeUI.gameObject.SetActive(true);
        storeUI.transform.GetChild(0).gameObject.SetActive(true);
        storeUI.transform.GetChild(1).gameObject.SetActive(true);
        ShopBuySell();

    }

    public void InnDialogue()
    {
        innUI.gameObject.SetActive(true);
        innUI.transform.GetChild(0).gameObject.SetActive(true);
        innUI.transform.GetChild(1).gameObject.SetActive(true);
        innUI.transform.GetChild(2).gameObject.SetActive(true);

    }


    public void ShopBuySell()
    {
        storeUI.transform.GetChild(2).gameObject.SetActive(true);


    }
    public void ShopOptions()
    {
        shopOptionsUI.SetActive(true);
    }

    public void ShopCloseOptions()
    {
        shopOptionsUI.SetActive(false);
    }
    public void ShopFullClose()
    {
        storeUI.transform.GetChild(1).gameObject.SetActive(false);
        storeUI.transform.GetChild(0).gameObject.SetActive(false);
        storeUI.gameObject.SetActive(false);
    }

    public void UpdateShopOptions()
    {
        if (gameManager.onBuyMode == true)
        {
            if (gameManager.hasOutfit1 == true)
            {
                shopOptionsUI.transform.GetChild(0).GetComponent<Text>().color = Color.red;
            }
            else if (gameManager.hasOutfit1 == false)
            {
                shopOptionsUI.transform.GetChild(0).GetComponent<Text>().color = Color.white;
            }
            if (gameManager.hasOutfit2 == true)
            {
                shopOptionsUI.transform.GetChild(1).GetComponent<Text>().color = Color.red;
            }
            else if (gameManager.hasOutfit2 == false)
            {
                shopOptionsUI.transform.GetChild(1).GetComponent<Text>().color = Color.white;
            }
            if (gameManager.hasOutfit3 == true)
            {
                shopOptionsUI.transform.GetChild(2).GetComponent<Text>().color = Color.red;
            }
            else if (gameManager.hasOutfit3 == false)
            {
                shopOptionsUI.transform.GetChild(2).GetComponent<Text>().color = Color.white;
            }
        }

        else if (gameManager.onSellMode == true)
        {
            if (gameManager.hasOutfit1 == true)
            {
                shopOptionsUI.transform.GetChild(0).GetComponent<Text>().color = Color.white;
            }
            else if (gameManager.hasOutfit1 == false)
            {
                shopOptionsUI.transform.GetChild(0).GetComponent<Text>().color = Color.red;
            }
            if (gameManager.hasOutfit2 == true)
            {
                shopOptionsUI.transform.GetChild(1).GetComponent<Text>().color = Color.white;
            }
            else if (gameManager.hasOutfit2 == false)
            {
                shopOptionsUI.transform.GetChild(1).GetComponent<Text>().color = Color.red;
            }
            if (gameManager.hasOutfit3 == true)
            {
                shopOptionsUI.transform.GetChild(2).GetComponent<Text>().color = Color.white;
            }
            else if (gameManager.hasOutfit3 == false)
            {
                shopOptionsUI.transform.GetChild(2).GetComponent<Text>().color = Color.red;
            }
        }
    }


    public void InventoryOpen()
    {
        inventoryUI.SetActive(true);
    }
    public void InventoryClose()
    {
        inventoryUI.SetActive(false);
    }

    public void InnClose()
    {
       innUI.SetActive(false);
    }

    public void UpdateInventoryOptions()
    {
        if (gameManager.hasOutfit1 == true)
        {
            inventoryOptionsUI.transform.GetChild(1).GetComponent<Text>().color = Color.white;

        }
        else if (gameManager.hasOutfit1 == false)
        {
            inventoryOptionsUI.transform.GetChild(1).GetComponent<Text>().color = Color.red;

        }
        if (gameManager.hasOutfit2 == true)
        {
            inventoryOptionsUI.transform.GetChild(2).GetComponent<Text>().color = Color.white;

        }
        else if (gameManager.hasOutfit2 == false)
        {
            inventoryOptionsUI.transform.GetChild(2).GetComponent<Text>().color = Color.red;

        }
        if (gameManager.hasOutfit3 == true)
        {
            inventoryOptionsUI.transform.GetChild(3).GetComponent<Text>().color = Color.white;

        }
        else if (gameManager.hasOutfit3 == false)
        {
            inventoryOptionsUI.transform.GetChild(3).GetComponent<Text>().color = Color.red;

        }
    }

    public void GoldCounter()
    {
        goldText.text = gameManager.money.ToString();
    }

    public void EnergyCounter()
    {
        energyText.text = "ENERGY: " + player.currentStamina.ToString();
    }
   
}
