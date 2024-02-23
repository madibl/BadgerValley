using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour, IInventory
{
    public int Trash { get => trash; set => trash = value;}

    public int trash = 0;
}