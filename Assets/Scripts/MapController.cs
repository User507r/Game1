using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapController : MonoBehaviour
{

    List<Coin> coinList = new List<Coin>();
    List<Nagget> naggetList = new List<Nagget>();
    List<Price> ObjectList= new List<Price>();



    void Start()
    {
        coinList.Add(new Coin() { gold = 3});
        coinList.Add(new Coin());
        coinList.Add(new Coin());

        Coin coin = new Coin();
        coin.SetGold(7);
        coinList.Add(coin);
        Debug.Log(coin.GetGold());

        for (int i = 0; i < 10; i++)
        {
            naggetList.Add(new Nagget() { type = 1, gold = i });
            

        }

        foreach (var obj in coinList) 
        {
            ObjectList.Add(obj);


        }
        foreach (var obj in naggetList)
        {
            ObjectList.Add(obj);


        }

        ObjectList.ForEach(obj => 
        {
            Debug.Log("obj = "+ obj.GetType()+"  "+ obj.GetGold());
        
        });




    }


    void Update()
    {
        
    }
}
