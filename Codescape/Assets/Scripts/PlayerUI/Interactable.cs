using UnityEngine;

public class Interactable : MonoBehaviour {

    public float radius = 3f; // range of interaction

    private void OnDrawGizmosSelected() {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, radius);
        }
    }
