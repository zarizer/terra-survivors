using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakeAlpha : MonoBehaviour
{
    public float alpha;
    public float time;
    void Start()
    {
        gameObject.LeanAlpha(alpha, time);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
