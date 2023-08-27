using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : PooledObject
{
    public int index;

    void Update()
    {
        transform.LookAt(Player.instance.transform.position);
    }

    private void OnCollisionEnter(Collision collision)
    {
        this.gameObject.SetActive(false);
        TargetManager.instance.Died(index);
        ObjectPoolManager.instance.ReturnObject(Key, this.gameObject);
    }
}
