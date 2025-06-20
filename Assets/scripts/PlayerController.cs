using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D body;

    public float BaseVelocity = 1;
    public float ModificationVelocity = 1;
    public float max_hp;
    public float cur_hp;
    public float def;

    public Transform attack_perks;
    public AudioSource audio_source;
    public GameObject hp_bar;

    public Sound_data sound_data;
    void Start()
    {
        body = this.GetComponent<Rigidbody2D>();
        cur_hp = max_hp;
    }

    void Update()
    {
        body.velocity.Set(0, 0);

        float h_move = Input.GetAxis("Horizontal");
        float v_move = Input.GetAxis("Vertical");

        //Debug.Log(h_move + " "+ v_move);

        body.velocity = new Vector2(h_move * BaseVelocity * ModificationVelocity, v_move * BaseVelocity * ModificationVelocity);

        CheckPerks();
    }

    public void CheckPerks()
    {
        for (int i = 0; i < attack_perks.childCount; i++)
        {
            attack_perks.GetChild(i).GetComponent<perk_script>().UsePerk();
        }
    }

    public void PlaySound(AudioClip sound)
    {
        audio_source.GetComponent<AudioSource>().clip = sound;
        audio_source.GetComponent<AudioSource>().pitch = ((float)Random.Range(90, 120)) / 100;
        audio_source.GetComponent<AudioSource>().Play();
    }

    public void GetDamage(float damage)
    {
        if (damage - def <= 0) damage = 1;
        else damage -= def;

        cur_hp -= damage;
        hp_bar.GetComponent<UnityEngine.UI.Image>().fillAmount = cur_hp/max_hp;
    }


    public AudioClip GetSound(string sound_name)
    {
        return sound_data.GetDictionary()[sound_name];
    }
}
