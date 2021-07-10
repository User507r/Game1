using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class NextLevel : MonoBehaviour
{
    bool enter = false;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player" && !enter)
        {
            enter = true;
            SaveLoad.saveLoad.NextLevel();
        }
    }
}
