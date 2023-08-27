using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPoolManager : MonoBehaviour
{
    public static ObjectPoolManager instance = null;
    [SerializeField] PooledObject[] m_prefabs;

    Dictionary<string, ObjectPool> m_objectPoolers;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }

        m_objectPoolers = new Dictionary<string, ObjectPool>();
    }

    private void Start()
    {
        for (int i = 0; i < m_prefabs.Length; i++)
        {
            RegisterPrefab(m_prefabs[i].Key, m_prefabs[i].gameObject);
        }
    }

    public GameObject GetObject(string key)
    {
        if (m_objectPoolers.ContainsKey(key))
        {
            return m_objectPoolers[key].GetObject();
        }
        else
        {
            Debug.LogError("Key: '" + key + "' does not exist in the object pooler");
            return null;
        }
    }

    public void ReturnObject(string key, GameObject GO)
    {
        if (m_objectPoolers.ContainsKey(key))
        {
            m_objectPoolers[key].ReturnObject(GO);
        }
        else
        {
            Debug.LogError("Key: '" + key + "' does not exist in the object pooler");
        }
    }

    public void RegisterPrefab(string key, GameObject prefab)
    {
        if (!m_objectPoolers.ContainsKey(key))
        {
            GameObject parent = Instantiate(new GameObject(), this.transform);
            parent.name = key;
            ObjectPool pool = new ObjectPool(parent, prefab);
            m_objectPoolers.Add(key, pool);
        }
    }

}
