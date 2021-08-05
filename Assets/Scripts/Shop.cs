using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using System;

public class Shop : MonoBehaviour
{
    public GameObject ShopItems;
    public GameObject TakenText;
    //public GameObject RawImage;
   // public GameObject Buy;

    public RawImage RawImage;
    public Button Buy;
    public Transform ItemsPosition;

    public static string[] stateBuying = new string[4];


    public int CountItems;
    public static int counterRight = 0; //currentItem

    SavePrefs sp = new SavePrefs();

    //public static ChangeMaterials instance;
    private float shag = -252;
    private static int variable = 100;

    Price[] pr = new Price[4];



    public ArrayList listPrice = new ArrayList();


    public void ChangeStateWrite()
    {
        SavePrefs.stateitem[0] = Convert.ToString(pr[0].stateBuying);
        SavePrefs.stateitem[1] = Convert.ToString(pr[1].stateBuying);
        SavePrefs.stateitem[2] = Convert.ToString(pr[2].stateBuying);
        SavePrefs.stateitem[3] = Convert.ToString(pr[3].stateBuying);
    }
    public void ChangeStateItems()
    {


        pr[0] = new Price(0, 30, Convert.ToBoolean(stateBuying[0]));
        pr[1] = new Price(1, 40, Convert.ToBoolean(stateBuying[1]));
        pr[2] = new Price(1, 50, Convert.ToBoolean(stateBuying[2]));
        pr[3] = new Price(1, 60, Convert.ToBoolean(stateBuying[3]));

    }
 
    private void Start()
    {
        VisibleText(50);
        sp.LoadMoney();
        ChangeStateItems();
        AddPrice();
        ShowLock();
        

        counterRight = 0;
    }

    public void Right()
    {
        if (counterRight  <= CountItems-2)
        {
            counterRight++;
            VisibleText(counterRight);
            ShopItems.transform.position = ItemsPosition.position + new Vector3(shag, 0f, 0f);
            ShowLock();
        }
    }

    public void Left()
    {
        if (counterRight > 0)
        {
            counterRight--;
            VisibleText(counterRight);
            ShopItems.transform.position = ItemsPosition.position + new Vector3(-shag, 0f, 0f);
            ShowLock();
        }
    }

    private void VisibleText(int somenumber)
    {
        if (somenumber == variable)
        {
            ActiveTextTakenSkin(true);
        }
        else { ActiveTextTakenSkin(false); }
    }

    public void OK()//applySkin
    {
        Price itemShop = (Price)listPrice[counterRight];
        if (itemShop.stateBuying)
        {
            variable = counterRight;
            VisibleText(variable);
            ChangeMaterials.stateMaterials = counterRight;
            ActiveTextTakenSkin(true);
        }

        else
        {
            ActiveTextTakenSkin(false);
            Debug.Log("First u must buy this skin");
        }
        
    }


    private void VisibleElementsAfterBought(bool state)
    {
        RawImage.gameObject.SetActive(state);
        Buy.gameObject.SetActive(state);
    }


    private void ActiveTextTakenSkin(bool state)
    {
        TakenText.SetActive(state);
    }

    public void ShowLock()//UpdateStateLock
    {
            Price ob = (Price)listPrice[counterRight];
            VisibleElementsAfterBought(!ob.stateBuying);
    }

    public void AddPrice()
    {
        listPrice.Add(pr[0]);
        listPrice.Add(pr[1]);
        listPrice.Add(pr[2]);
        listPrice.Add(pr[3]);
    }

    public void UnlockSkin()//tryToBuySkin
    {
        Price SomeSkin = (Price)listPrice[counterRight];
        if (PlayerMecanics.money >= SomeSkin.price && SomeSkin.stateBuying == false)
        {
            SavePrefs.moneyToSave -= SomeSkin.price;
            SomeSkin.stateBuying = true;
            SavePrefs.stateitem[counterRight] = Convert.ToString(SomeSkin.stateBuying);
            ChangeStateWrite();
            sp.Save();
            sp.LoadMoney();

            ShowLock();
        }
        else { Debug.Log("No money"); }

    }

    
    

    
  



}


