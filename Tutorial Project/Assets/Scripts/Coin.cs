using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : PooledObject
{
    [SerializeField] float m_rotationSpeed;


    // Update is called once per frame
    void Update()
    {
        transform.eulerAngles += new Vector3(0, 1, 0) * Time.deltaTime * m_rotationSpeed;
    }
}
