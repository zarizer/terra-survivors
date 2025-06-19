using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class texture_data : MonoBehaviour
{

    [SerializeField]
    private List<string> keys = new List<string>();

    [SerializeField]
    private List<Sprite> values = new List<Sprite>();

    public Dictionary<string, Sprite> GetDictionary()
    {
        var dict = new Dictionary<string, Sprite>();
        for (int i = 0; i < keys.Count; i++)
        {
            dict[keys[i]] = values[i];
        }
        return dict;
    }

  

}
