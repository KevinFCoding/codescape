using UnityEngine;
using System.Collections;

public class ItemPickUp : Interactable {

    public Item item;

    public override void Interact() {
        base.Interact();
        PickUpKey();
        }

    public void PickUpKey() {

        Debug.Log(IsInCollision);

        if (IsInCollision) {
            if (Input.GetAxis("Fire1") > 0) {
                Destroy(gameObject);

                Inventory.instance.AddItem(item);
                Debug.Log("Object PickUp : " + item.name);
                }

            }
        }

    }
