using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class perk_script : MonoBehaviour
{
    public Sprite perk_sprite;
    public texture_data textures;
    public Object_data object_data;
    public Sound_data sound_data;
    public string perk_name;
    public PlayerController player_script;

    public float cur_cooldawn;
    public float cooldawn_time;

    public int level;
    public float speed;


    void Start()
    {
        //ChangeImage("empty_perk");
    }

    void Update()
    {
        
    }

    public void ChangeImage(string perk_name)
    {
        perk_sprite = GetTexture(perk_name);
        Debug.Log("here");
        GetComponent<UnityEngine.UI.Image>().sprite = perk_sprite;
    }

    Sprite GetTexture(string texture_name)
    {
        return textures.GetDictionary()[texture_name];
    }

    GameObject GetObject(string object_name)
    {
        return object_data.GetDictionary()[object_name];
    }

    AudioClip GetSound(string sound_name)
    {
        return sound_data.GetDictionary()[sound_name];
    }

    public void UsePerk()
    {
        if (cur_cooldawn<=0)
        {
            Shot();
            cur_cooldawn = cooldawn_time;
        }
        else
        {
            cur_cooldawn -= Time.deltaTime*speed;
        }
    }
    
    void Shot()
    {
        transform.GetChild(0).GetComponent<FightObject_template>().Shot();

    }
}

