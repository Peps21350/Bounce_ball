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

    public static string[] state_buying = new string[4];
    
    public int count_items;
    public static int counter_Right = 0; //currentItem

    SavePrefs sp = new SavePrefs();

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
        pr[0] = new Price(0, 30, Convert.ToBoolean(state_buying[0]));
        pr[1] = new Price(1, 40, Convert.ToBoolean(state_buying[1]));
        pr[2] = new Price(1, 50, Convert.ToBoolean(state_buying[2]));
        pr[3] = new Price(1, 60, Convert.ToBoolean(state_buying[3]));
    }
 
    private void Start()
    {
        VisibleText(50);
        sp.LoadMoney();
        ChangeStateItems();
        AddPrice();
        ShowLock();
        
        counter_Right = 0;
    }

    public void Right()
    {
        if (counter_Right  <= count_items-2)
        {
            counter_Right++;
            VisibleText(counter_Right);
            ShopItems.transform.position = ItemsPosition.position + new Vector3(shag, 0f, 0f);
            ShowLock();
        }
    }

    public void Left()
    {
        if (counter_Right > 0)
        {
            counter_Right--;
            VisibleText(counter_Right);
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
        Price itemShop = (Price)listPrice[counter_Right];
        if (itemShop.stateBuying)
        {
            variable = counter_Right;
            VisibleText(variable);
            ChangeMaterials.stateMaterials = counter_Right;
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
            Price ob = (Price)listPrice[counter_Right];
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
        Price SomeSkin = (Price)listPrice[counter_Right];
        if (PlayerMecanics.money >= SomeSkin.price && SomeSkin.stateBuying == false)
        {
            SavePrefs.moneyToSave -= SomeSkin.price;
            SomeSkin.stateBuying = true;
            SavePrefs.stateitem[counter_Right] = Convert.ToString(SomeSkin.stateBuying);
            ChangeStateWrite();
            sp.Save();
            sp.LoadMoney();

            ShowLock();
        }
        else { Debug.Log("No money or u buy this skin"); }
    }

    
    

    
  



}


