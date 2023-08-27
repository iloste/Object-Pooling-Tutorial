using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetManager : MonoBehaviour
{
    public static TargetManager instance = null;

    [SerializeField] Transform[] m_spawnPoints;

    List<int> m_indexes;
    float m_timer;
    float m_timerLimit = 3;

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

        m_indexes = new List<int>();
        for (int i = 0; i < m_spawnPoints.Length; i++)
        {
            m_indexes.Add(i);
        }

        m_timer = m_timerLimit; 
    }

   

    // Update is called once per frame
    void Update()
    {
        m_timer -= Time.deltaTime;
        if (m_timer <= 0)
        {
            m_timer = m_timerLimit;
            CreateTarget();
        }
    }

    private void CreateTarget()
    {
        if (m_indexes.Count > 0)
        {
            GameObject target = ObjectPoolManager.instance.GetObject("Target");
            int index = Random.Range(0, m_indexes.Count);
            target.transform.position = m_spawnPoints[m_indexes[index]].position;
            target.GetComponent<Target>().index = m_indexes[index];
            Debug.Log(m_indexes[index]);
            m_indexes.RemoveAt(index);
        }
    }

    public void Died(int index)
    {
        m_indexes.Add(index);
    }
}
