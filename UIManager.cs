using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public GameObject storeUI;
    public GameObject optionsUI;
    public GameManager gameManager;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("Game_Manager").GetComponent<GameManager>();
        storeUI = transform.GetChild(0).gameObject;
        optionsUI = storeUI.transform.GetChild(3).gameObject;

    }

    // Update is called once per frame
    void Update()
    {
        RemoveOptions();
    }

    public void ShopDialogue()
    {
        storeUI.gameObject.SetActive(true);
        storeUI.transform.GetChild(0).gameObject.SetActive(true);
        storeUI.transform.GetChild(1).gameObject.SetActive(true);
        ShopBuySell();
        
    }
    public void ShopBuySell()
    {
        storeUI.transform.GetChild(2).gameObject.SetActive(true);
        

    }
    public void ShopOptions()
    {
        optionsUI.SetActive(true);
    }

    public void ShopCloseOptions()
    {
        optionsUI.SetActive(false);
    }
    public void ShopFullClose()
    {
        storeUI.transform.GetChild(1).gameObject.SetActive(false);
        storeUI.transform.GetChild(0).gameObject.SetActive(false);
        storeUI.gameObject.SetActive(false);
    }

    public void RemoveOptions()
    {
        if (gameManager.hasOutfit1 == true)
        {
            optionsUI.transform.GetChild(0).GetComponent<Text>().color = Color.red;
        }
        if (gameManager.hasOutfit2 == true)
        {
            optionsUI.transform.GetChild(1).GetComponent<Text>().color = Color.red;
        }
        if (gameManager.hasOutfit3 == true)
        {
            optionsUI.transform.GetChild(2).GetComponent<Text>().color = Color.red;
        }
    }

}
