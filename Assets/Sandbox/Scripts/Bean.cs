using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bean : Item
{
    [SerializeField] private GameObject baked;
    public override void ShowItem()
    {
        baked.SetActive(true);
    }
}
