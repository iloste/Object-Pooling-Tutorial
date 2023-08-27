using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedBullet : PooledObject
{
    [SerializeField] float m_speed = 5;

    Rigidbody m_rb;

    private void Awake()
    {
        m_rb = this.GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        m_rb.position += transform.forward * Time.deltaTime * m_speed;
    }

    private void OnCollisionEnter(Collision collision)
    {
        this.gameObject.SetActive(false);
        ObjectPoolManager.instance.ReturnObject(Key, this.gameObject);
    }
}
