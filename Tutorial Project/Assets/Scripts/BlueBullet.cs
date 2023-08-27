using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueBullet : MonoBehaviour
{
    //#7.4
    [SerializeField] float m_speed = 5;

    //#7.1
    Rigidbody m_rb;

    private void Awake()
    {
        //#7.2
        m_rb = this.GetComponent<Rigidbody>();
    }

    //7#.3
    void FixedUpdate()
    {
        m_rb.position += transform.forward * Time.deltaTime * m_speed;
    }

    //#8
    private void OnCollisionEnter(Collision collision)
    {
        this.gameObject.SetActive(false);
        ObjectPooler.instance.ReturnObject(this.gameObject);
    }
}
