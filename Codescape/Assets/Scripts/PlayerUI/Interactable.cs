using UnityEngine;

public class Interactable : MonoBehaviour {

    [SerializeField] float radius = 2f; // range of interaction
    public bool IsInCollision = false;
    [SerializeField] private GameObject textOverlay;

    public void OnCollisionEnter(Collision collision) {

        Debug.Log("Player in collision");
        IsInCollision = true;
        textOverlay.SetActive(true);
        Interact();
        }


    public void OnCollisionExit(Collision collision) {
        Debug.Log("Player leaving collision");
        IsInCollision = false;
        textOverlay.SetActive(false);
        }


    private void OnDrawGizmosSelected() {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, radius);
        }


    public virtual void Interact() {
        Debug.Log("Base of the interact method"); // WIll be use to add to inventory and manage doors
        }
    }
