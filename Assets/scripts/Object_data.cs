using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Object_data : MonoBehaviour
{

    [SerializeField]
    private List<string> keys = new List<string>();

    [SerializeField]
    private List<GameObject> values = new List<GameObject>();

    public Dictionary<string, GameObject> GetDictionary()
    {
        var dict = new Dictionary<string, GameObject>();
        for (int i = 0; i < keys.Count; i++)
        {
            dict[keys[i]] = values[i];
        }
        return dict;
    }

  

}
