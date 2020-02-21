using UnityEngine;
using System.Collections;

public class DoorOpen : Interactable {

    private Inventory inventory;

    private bool IsDoorOpen = false;

    public override void Interact() {
        base.Interact();
        CheckIfKey();
        }

    public void CheckIfKey() {

        if (IsInCollision) {
            if (Input.GetAxis("Fire1") > 0) {


                IsDoorOpen = true;

                Debug.Log(IsDoorOpen);
                }

            }
        }
    }
