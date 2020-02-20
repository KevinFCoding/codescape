using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapsMovement : MonoBehaviour
{
    [SerializeField] float m_TranslationSpeed;
    bool isMoving = false;
    bool isDescending = true;
    float m_StartPosition;

    // Start is called before the first frame update
    void Start()
    {
        m_StartPosition = transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {

        if (transform.position.y > m_StartPosition - 10 && isDescending)
        {
            transform.position = new Vector3(transform.position.x, (float)transform.position.y - m_TranslationSpeed, transform.position.z);
        }
        else
        {
            isDescending = false;
        }
        if (transform.position.y < m_StartPosition && !isDescending)
        {
            transform.position = new Vector3(transform.position.x, (float)transform.position.y + m_TranslationSpeed, transform.position.z);
        }
        else
        {
            isDescending = true;
        }
    }
}
