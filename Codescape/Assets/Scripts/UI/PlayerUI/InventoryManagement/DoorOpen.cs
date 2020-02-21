using UnityEngine;
using System.Collections;

public class DoorOpen : Interactable {

    [SerializeField] private bool IsDoorOpen = false;
    private bool HasKey = false;

    public override void Interact() {
        base.Interact();
        CheckIfKey();
        }

    public void CheckIfKey() {
        SearchKey();
        if (IsInCollision) {
            if (Input.GetAxis("Fire1") > 0 && HasKey) {

                IsDoorOpen = true;

                transform.Rotate(0, 90, 0);

                }

            }

            }

    public void SearchKey() {
        Debug.Log(Inventory.instance.items.Count);
        for (var i = 0; i < Inventory.instance.items.Count; i++) {

            if(Inventory.instance.items[i].name == "Key") {
                HasKey = true;
                break;
                }
            }
        }


        }
    
