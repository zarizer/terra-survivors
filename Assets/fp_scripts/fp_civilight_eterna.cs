using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fp_civilight_eterna : FightObject_template
{
    public PlayerController player;

    public float damage;
    public float push_strengh;
    public string damage_type;
    public int amount;
    public int crystal_speed;

    public GameObject crystal;
    public List<GameObject> crystals;
    void Start()
    {

    }

    void Update()
    {
        if (amount != transform.childCount)
        {
            for (int i = transform.childCount-1; i >= 0; i--)
            {
                Destroy(transform.GetChild(i).gameObject);
                crystals.Clear();
            }
            for (int i = 0; i < amount; i++)
            {
                crystals.Add(Instantiate(crystal, transform));
                crystals[i].transform.position = player.transform.position + Vector3.up * 2;
                crystals[i].transform.RotateAround(player.transform.position, Vector3.forward, 360 / amount * i);
                crystals[i].transform.localScale = Vector3.one * 150;
            }
        }
        foreach(Transform cr in transform)
        {
            cr.RotateAround(player.transform.position, Vector3.forward, Time.deltaTime * crystal_speed);
            cr.rotation = new Quaternion(0,0,0,0);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

    }

    public override void Shot()
    {
        
    }

    public override void EnemyMakeImpact(enemy_script enemy)
    {

    }
    public override void GetReady()
    {
        transform.parent.GetComponent<perk_script>().ChangeImage("civilight_eterna");
        transform.parent.GetComponent<perk_script>().perk_name = "civilight_eterna";

    }
}
