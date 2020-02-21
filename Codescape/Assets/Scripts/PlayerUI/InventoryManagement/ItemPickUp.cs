using UnityEngine;
using System.Collections;

public class ItemPickUp : Interactable {

    public Item item;

    public override void Interact() {
        base.Interact();
        PickUpKey();
        }

    public void PickUpKey() {


        if (IsInCollision) {
            if (Input.GetAxis("Fire1") > 0) {
                Inventory.instance.AddItem(item);
                Debug.Log("Object PickUp : " + item.name);
                Destroy(gameObject);
                this.ChangeOverlayState(false);

                }

            }
        }
    }
