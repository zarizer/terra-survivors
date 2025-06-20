using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class main : MonoBehaviour
{

    public string character = "executor";
    public Transform attack_perks;
    public Transform stat_perks;
    public Object_data objects;
    public PlayerController player1;


    void Start()
    {
        StartGame();
    }
    void Update()
    {
        
    }

    void StartGame()
    {
        if (character == "executor")
        {
            for (int i = 0; i<stat_perks.childCount; i++)
            {
                stat_perks.GetChild(i).GetComponent<perk_script>().ChangeImage("empty_perk");
            }
            attack_perks.GetChild(0).GetComponent<perk_script>().ChangeImage("shotgun_perk");
            attack_perks.GetChild(0).GetComponent<perk_script>().perk_name = "shotgun";
            GameObject shotgun_shot = Instantiate(objects.GetDictionary()["shotgun_shot"], attack_perks.GetChild(0));
            shotgun_shot.transform.position = player1.transform.position + Vector3.up*0.75f;
            shotgun_shot.transform.localScale = Vector3.one * 150;
            attack_perks.GetChild(0).GetChild(0).name = "attack";

        }
    }
}
