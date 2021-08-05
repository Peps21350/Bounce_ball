using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Price
{
    public int Id;
    public int price;
    public bool stateBuying;

    public Price()
    {
    }

    public Price(int id, int price, bool state)
    {
        Id = id;
        this.price = price;
        stateBuying = state;
    }

}
