using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPooler : MonoBehaviour
{
    //#1
    public static ObjectPooler instance = null;

    //#2
    [SerializeField] GameObject m_prefab;
    List<GameObject> m_inactiveObjects;
    List<GameObject> m_activeObjects;


    private void Awake()
    {
        // #1
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }

        //#2
        m_inactiveObjects = new List<GameObject>();
        m_activeObjects = new List<GameObject>();
    }

    public GameObject GetObject()
    {
        //#3
        GameObject GO;

        // take an existing object
        //#3
        if (m_inactiveObjects.Count > 0)
        {
            //#3
            GO = m_inactiveObjects[0];
            m_inactiveObjects.RemoveAt(0);
            m_activeObjects.Add(GO);

            GO.SetActive(true);
        }
        // create a new object
        //#4
        else
        {
            //#4
            GO = Instantiate(m_prefab, this.transform);
            m_activeObjects.Add(GO);
        }

        //#3
        return GO;
    }

    //#5
    public void ReturnObject(GameObject GO)
    {
        //#5
        if (m_activeObjects.Contains(GO))
        {
            //#5
            m_activeObjects.Remove(GO);
            m_inactiveObjects.Add(GO);
        }
    }
}
