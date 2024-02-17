using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gamelength : MonoBehaviour
{
    public static int gameLengthSelector;

    public void setGameto5Pts()
    {
        gameLengthSelector = 5;
    }
 
    public void setGameto7Pts()
    {
        gameLengthSelector = 7;
    }
 
    public void setGameto9Pts()
    {
        gameLengthSelector = 9;
    }

}
