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

    public void SetList()
    {
        SaveLoad.saveLoad.MapDoneList.ForEach( map => 
        {
            if (map > 0)
            {
                SlotMap slotMap = Instantiate(Slot).GetComponent<SlotMap>();
                slotMap.index = map;
                slotMap.Name = "mapName " + map;
                slotMap.transform.parent = Content.transform;
                slotMap.gameObject.SetActive(true);
            }

        });
    }




}
