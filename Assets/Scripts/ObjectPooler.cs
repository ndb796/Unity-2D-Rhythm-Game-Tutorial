using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPooler : MonoBehaviour {
    
    public List<GameObject> Notes;
    private List<List<GameObject>> notePools;

    public int poolCount = 10;
    private bool more = true;
    
    void Start()
    {
        notePools = new List<List<GameObject>>();
        for(int i = 0; i < Notes.Count; i++)
        {
            notePools.Add(new List<GameObject>());
            for (int j = 0; j < poolCount; j++)
            {
                GameObject obj = Instantiate(Notes[i]);
                obj.SetActive(false);
                notePools[i].Add(obj);
            }
        }
    }

    public GameObject getObject(int noteType)
    {
        foreach (GameObject obj in notePools[noteType - 1])
        {
            if (!obj.activeInHierarchy)
            {
                return obj;
            }
        }
        if (more)
        {
            GameObject obj = Instantiate(Notes[noteType - 1]);
            notePools[noteType - 1].Add(obj);
            return obj;
        }
        return null;
    }

}
