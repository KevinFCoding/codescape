using UnityEngine;

public class Interactable : MonoBehaviour {

    public float radius = 3f; // range of interaction

    bool IsInRange = false;
    public bool IsDoorOpen = false;
    Transform player;

    public void Update() {
            if (IsInRange) {
            float Distance = Vector3.Distance(player.position, transform.position);

            if (Distance <= radius) {
                Debug.Log("INTERACT MOTHERFUCKER");
                }
            }
          }

    private void OnCollisionEnter(Collision collision) {
        if (collision.gameObject.CompareTag("player")) {
            GameObject.FindGameObjectsWithTag("Door1");
            }
        }
        
    public void OpenDoor() {
        IsDoorOpen = !IsDoorOpen;
        }
    //public void IsFocused(Transform playerTransform) {
    //    IsInRange = true;
    //    player = playerTransform;
    //    }

    //public void IsUnFocused() {
    //    IsInRange = false;
    //    player = null;
    //    }

    private void OnDrawGizmosSelected() {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, radius);
        }
    }
