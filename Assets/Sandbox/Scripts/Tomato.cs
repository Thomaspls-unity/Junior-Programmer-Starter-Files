using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tomato : Item
{
    [SerializeField] private Transform tomatoStem;
    public override void ShowItem()
    {
        tomatoStem.position = new Vector3(0, 1, 0);
    }
}
