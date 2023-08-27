using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    [SerializeField] bool useBlueBullets;

    private void Update()
    {
        //#9

        //if (Input.GetKeyDown(KeyCode.Space))
        //{
        //    GameObject bullet = ObjectPooler.instance.GetObject();
        //    bullet.transform.position = this.transform.position;
        //    bullet.transform.rotation = this.transform.rotation;
        //}


        if (Input.GetKeyDown(KeyCode.R))
        {
            useBlueBullets = !useBlueBullets;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            GameObject bullet;

            if (useBlueBullets)
            {
                bullet = ObjectPooler.instance.GetObject();
            }
            else
            {
                bullet = ObjectPoolManager.instance.GetObject("Bullet");
            }

            bullet.transform.position = this.transform.position;
            bullet.transform.rotation = this.transform.rotation;
        }
    }
}
