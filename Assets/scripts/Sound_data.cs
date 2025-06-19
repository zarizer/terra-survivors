using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Sound_data : MonoBehaviour
{

    [SerializeField]
    private List<string> keys = new List<string>();

    [SerializeField]
    private List<AudioClip> values = new List<AudioClip>();

    public Dictionary<string, AudioClip> GetDictionary()
    {
        var dict = new Dictionary<string, AudioClip>();
        for (int i = 0; i < keys.Count; i++)
        {
            dict[keys[i]] = values[i];
        }
        return dict;
    }

  

}
