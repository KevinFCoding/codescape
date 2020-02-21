using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerMovement : MonoBehaviour {
    float m_InitialSpeed;
    [SerializeField] float m_TranslationSpeed;
    Rigidbody m_Rigidbody;

    bool isFalling = false;

    float maxSlope = 90f;


    private void Awake() {
        m_Rigidbody = GetComponent<Rigidbody>();
        }

    // Start is called before the first frame update
    void Start() {
        m_InitialSpeed = m_TranslationSpeed;

        }

    private void FixedUpdate() {

        if (!InventoryUI.IsInventoryActivated()) {

            Movement();
            Jump();
            Run();
            }
        
    }

    private void Jump() {
        float jInput = Input.GetAxis("Jump");

        if (jInput > 0 && !isFalling) {
            GetComponent<Rigidbody>().velocity = new Vector3(0, 4, 0);
            }
        isFalling = true;
        }

    private void Run() {
        float rInput = Input.GetAxis("Run");

        if (rInput > 0) {
            m_TranslationSpeed = m_InitialSpeed * 2;
            }
        else {
            m_TranslationSpeed = m_InitialSpeed;
            }
        }

    private void Movement() {
        float vInput = Input.GetAxis("Vertical");
        float hInput = Input.GetAxis("Horizontal");

        Vector3 vect_forward = transform.forward * m_TranslationSpeed * Time.fixedDeltaTime * vInput;
        Vector3 vect_side = transform.right * m_TranslationSpeed * Time.fixedDeltaTime * hInput;

        m_Rigidbody.MovePosition(transform.position + vect_forward + vect_side);
        }

    private void OnCollisionStay(Collision collision) {
        foreach (ContactPoint contact in collision.contacts) {
            if (Vector3.Angle(contact.normal, Vector3.up) < maxSlope) {
                isFalling = false;
                }

            }

        }

    private void OnCollisionExit(Collision collision) {
        isFalling = true;
        }

    }
