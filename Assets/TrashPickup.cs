using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashPickup : MonoBehaviour
{
    public int trashAmount = 1;
        private void OnTriggerEnter2D(Collider2D other) {
            if(other.tag == "Player") {
                IInventory inventory = other.GetComponent<IInventory>();

                if(inventory != null) {
                    inventory.Trash = inventory.Trash + trashAmount;
                    print("Player Inventory has" + inventory.Trash + " trash in it.");
                    gameObject.SetActive(false);
                }
            }
        }
}

