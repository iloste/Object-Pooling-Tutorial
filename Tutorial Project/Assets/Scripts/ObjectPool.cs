using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool
{
    GameObject m_parent;
    GameObject m_prefab;
    List<GameObject> m_inactiveObjects;
    List<GameObject> m_activeObjects;


    public ObjectPool(GameObject parent, GameObject prefab)
    {
        m_parent = parent;
        m_prefab = prefab;
        m_inactiveObjects = new List<GameObject>();
        m_activeObjects = new List<GameObject>();
    }

    public GameObject GetObject()
    {
        GameObject GO;

        // take an existing object
        if (m_inactiveObjects.Count > 0)
        {
            GO = m_inactiveObjects[0];
            m_inactiveObjects.RemoveAt(0);
            m_activeObjects.Add(GO);

            GO.SetActive(true);
            return GO;
        }
        // create a new object
        else
        {
            GO = Object.Instantiate(m_prefab, m_parent.transform);
            m_activeObjects.Add(GO);
            return GO;
        }
    }

    public void ReturnObject(GameObject GO)
    {
        m_inactiveObjects.Add(GO);
        m_activeObjects.Remove(GO);
    }
}
