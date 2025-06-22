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
    public Object_data object_data;
    public texture_data texture_data;
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

    public void AddAttackPerk(string perk_name)
    {
        GameObject perk = Instantiate(object_data.GetDictionary()["attack_perk"], attack_perks);
        perk.name = "attack_perk" + (attack_perks.childCount + 1).ToString();
        perk.transform.localScale = Vector3.one;
        perk.GetComponent<RectTransform>().localPosition = new Vector2(50 * (attack_perks.transform.childCount) - 25, -25) ;
        if (perk_name == "shotgun_perk")
        {
            GameObject real_perk = Instantiate(object_data.GetDictionary()["shotgun_shot"], perk.transform);
            real_perk.GetComponent<FightObject_template>().name = perk_name;
            real_perk.GetComponent<FightObject_template>().GetReady();
        }
        else if (perk_name == "civilight_eterna")
        {
            GameObject real_perk = Instantiate(object_data.GetDictionary()["civilight_eterna"], perk.transform);
            real_perk.GetComponent<FightObject_template>().name = perk_name;
            real_perk.GetComponent<FightObject_template>().GetReady();
        }
    }
}
