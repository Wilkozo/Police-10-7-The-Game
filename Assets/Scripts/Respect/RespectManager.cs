using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class RespectManager
{
    //respect amount
    private static int Respect;

    //adjust the amount of respect
    public static int RespectValue
    {
        //get the amount of respect the player has
        get
        {
            return Respect;
        }
        //set the amount of respect the player has
        set
        {
            Respect = value;
        }
    }
}
