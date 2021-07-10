using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapList : MonoBehaviour
{

    public static MapList mapList;

    public GameObject Slot;
    public GameObject Content;
    private void Awake()
    {
        mapList = this;
    }





}
