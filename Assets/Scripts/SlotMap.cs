using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SlotMap : MonoBehaviour
{

    Button button;
    public int index;
    public string Name;

    // Start is called before the first frame update
    void Start()
    {
        button = GetComponent<Button>();
        button.onClick.RemoveAllListeners();
        button.onClick.AddListener(OnMapButton);
        button.GetComponentInChildren<Text>().text = Name;

    }

    void OnMapButton() 
    {
        Debug.Log("  "+Name+"   "+index);
    }

}
