using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Cursor : MonoBehaviour
{
    public GameManager gameManager;
    public bool onShopBuy;
    public bool onShopSell;
    public bool onShopBack1;
    public bool onShopOutfit1;
    public bool onShopOutfit2;
    public bool onShopOutfit3;
    public bool onShopBack2;
    public bool onInventoryOutfit0;
    public bool onInventoryOutfit1;
    public bool onInventoryOutfit2;
    public bool onInventoryOutfit3;
    public bool onInventoryBack;
    public bool onSellOutfit1;
    public bool onSellOutfit2;
    public bool onSellOutfit3;
    public bool onSellBack;
    public bool onInnRest;
    public bool onInnBack;


    public GameObject shopUI;
    public Text shopBuyText;
    public Text shopSellText;
    public Text shopBackText;
    public Text shopOutfit1Text;
    public Text shopOutfit2Text;
    public Text shopOutfit3Text;
    public Text shopBack2Text;

    public GameObject inventoryUI;
    public Text invOutfit0Text;
    public Text invOutfit1Text;
    public Text invOutfit2Text;
    public Text invOutfit3Text;
    public Text invBackText;

    public GameObject innUI;
    public Text onInnRestText;
    public Text onInnBackText;






    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("Game_Manager").GetComponent<GameManager>();
        shopUI = GameObject.Find("Canvas").GetComponent<UIManager>().transform.GetChild(0).gameObject;
        shopBuyText = shopUI.transform.GetChild(2).transform.GetChild(0).GetComponent<Text>();
        shopSellText = shopUI.transform.GetChild(2).transform.GetChild(1).GetComponent<Text>();
        shopBackText = shopUI.transform.GetChild(2).transform.GetChild(2).GetComponent<Text>();
        shopOutfit1Text = shopUI.transform.GetChild(3).transform.GetChild(0).GetComponent<Text>();
        shopOutfit2Text = shopUI.transform.GetChild(3).transform.GetChild(1).GetComponent<Text>();
        shopOutfit3Text = shopUI.transform.GetChild(3).transform.GetChild(2).GetComponent<Text>();
        shopBack2Text = shopUI.transform.GetChild(3).transform.GetChild(3).GetComponent<Text>();


        inventoryUI = GameObject.Find("Canvas").GetComponent<UIManager>().transform.GetChild(2).gameObject;
        invOutfit0Text = inventoryUI.transform.GetChild(0).transform.GetChild(0).GetComponent<Text>();
        invOutfit1Text = inventoryUI.transform.GetChild(0).transform.GetChild(1).GetComponent<Text>();
        invOutfit2Text = inventoryUI.transform.GetChild(0).transform.GetChild(2).GetComponent<Text>();
        invOutfit3Text = inventoryUI.transform.GetChild(0).transform.GetChild(3).GetComponent<Text>();
        invBackText = inventoryUI.transform.GetChild(0).transform.GetChild(4).GetComponent<Text>();

        innUI = GameObject.Find("Canvas").GetComponent<UIManager>().transform.GetChild(1).gameObject;
        onInnRestText = innUI.transform.GetChild(2).transform.GetChild(0).GetComponent<Text>();
        onInnBackText = innUI.transform.GetChild(2).transform.GetChild(1).GetComponent<Text>();

    }

    // Update is called once per frame
    void Update()
    {
        ShopCursorPosition();
        InventoryCursorPosition();
        InnCursorPosition();
    }

    public void ShopCursorPosition()
    {
        if (onShopBuy == true)
        {
            shopBuyText.text = ">>BUY";
            shopSellText.text = "SELL";
            shopBackText.text = "BACK";

        }
        else if (onShopSell == true)
        {
            shopSellText.text = ">>SELL";
            shopBuyText.text = "BUY";
            shopBackText.text = "BACK";
        }
        else if (onShopBack1 == true)
        {
            shopBackText.text = ">>BACK";
            shopBuyText.text = "BUY";
            shopSellText.text = "SELL";
        }
        if (gameManager.onBuyMode == true)
        {
            if (onShopOutfit1 == true)
            {
                shopBuyText.text = ">>BUY";
                shopOutfit1Text.text = ">>OUTFIT 1 50";
                shopOutfit2Text.text = "OUTFIT 2 50";
                shopOutfit3Text.text = "OUTFIT 3 50";
                shopBack2Text.text = "BACK";
            }
            else if (onShopOutfit2 == true)
            {
                shopBuyText.text = ">>BUY";
                shopOutfit2Text.text = ">>OUTFIT 2 50";
                shopOutfit1Text.text = "OUTFIT 1 50";
                shopOutfit3Text.text = "OUTFIT 3 50";
                shopBack2Text.text = "BACK";

            }
            else if (onShopOutfit3 == true)
            {
                shopBuyText.text = ">>BUY";
                shopOutfit3Text.text = ">>OUTFIT 3 50";
                shopOutfit1Text.text = "OUTFIT 1 50";
                shopOutfit2Text.text = "OUTFIT 2 50";
                shopBack2Text.text = "BACK";
            }
            else if (onShopBack2 == true)
            {
                shopBuyText.text = ">>BUY";
                shopBack2Text.text = ">>BACK";
                shopOutfit1Text.text = "OUTFIT 1 50";
                shopOutfit2Text.text = "OUTFIT 2 50";
                shopOutfit3Text.text = "OUTFIT 3 50";

            }
        }
        if (gameManager.onSellMode == true)
        {
            if (onSellOutfit1 == true)
            {
                shopSellText.text = ">>SELL";
                shopOutfit1Text.text = ">>OUTFIT 1 25";
                shopOutfit2Text.text = "OUTFIT 2 25";
                shopOutfit3Text.text = "OUTFIT 3 25";
                shopBack2Text.text = "BACK";
            }
            else if (onSellOutfit2 == true)
            {
                shopSellText.text = ">>SELL";
                shopOutfit2Text.text = ">>OUTFIT 2 25";
                shopOutfit1Text.text = "OUTFIT 1 25";
                shopOutfit3Text.text = "OUTFIT 3 25";
                shopBack2Text.text = "BACK";

            }
            else if (onSellOutfit3 == true)
            {
                shopSellText.text = ">>SELL";
                shopOutfit3Text.text = ">>OUTFIT 3 25";
                shopOutfit1Text.text = "OUTFIT 1 25";
                shopOutfit2Text.text = "OUTFIT 2 25";
                shopBack2Text.text = "BACK";
            }
            else if (onSellBack == true)
            {
                shopSellText.text = ">>SELL";
                shopBack2Text.text = ">>BACK";
                shopOutfit1Text.text = "OUTFIT 1 25";
                shopOutfit2Text.text = "OUTFIT 2 25";
                shopOutfit3Text.text = "OUTFIT 3 25";

            }
        }

    }

    public void InventoryCursorPosition()
    {
        if(onInventoryOutfit0 == true)
        {
            invOutfit0Text.text = ">>OUTFIT 0";
            invOutfit1Text.text = "OUTFIT 1";
            invOutfit2Text.text = "OUTFIT 2";
            invOutfit3Text.text = "OUTFIT 3";
            invBackText.text = "BACK";

        }
        else if(onInventoryOutfit1 == true)
        {
            invOutfit1Text.text = ">>OUTFIT 1";
            invOutfit0Text.text = "OUTFIT 0";
            invOutfit2Text.text = "OUTFIT 2";
            invOutfit3Text.text = "OUTFIT 3";
            invBackText.text = "BACK";
        }
        else if (onInventoryOutfit2 == true)
        {
            invOutfit2Text.text = ">>OUTFIT 2";
            invOutfit0Text.text = "OUTFIT 0";
            invOutfit1Text.text = "OUTFIT 1";
            invOutfit3Text.text = "OUTFIT 3";
            invBackText.text = "BACK";
        }
        else if (onInventoryOutfit3 == true)
        {
            invOutfit3Text.text = ">>OUTFIT 3";
            invOutfit0Text.text = "OUTFIT 0";
            invOutfit2Text.text = "OUTFIT 2";
            invOutfit1Text.text = "OUTFIT 1";
            invBackText.text = "BACK";
        }
        else if (onInventoryBack == true)
        {
            invBackText.text = ">>BACK";
            invOutfit1Text.text = "OUTFIT 1";
            invOutfit0Text.text = "OUTFIT 0";
            invOutfit2Text.text = "OUTFIT 2";
            invOutfit3Text.text = "OUTFIT 3";
           
        }
    }

    public void InnCursorPosition()
    {
        if(onInnRest == true)
        {
            onInnRestText.text = ">>REST";
            onInnBackText.text = "BACK";
        }
        else if(onInnBack == true)
        {
            onInnBackText.text = ">>BACK";
            onInnRestText.text = "REST";
        }
    }


}
