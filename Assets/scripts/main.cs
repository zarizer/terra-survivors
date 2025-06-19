using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class main : MonoBehaviour
{

    public string character = "executor";
    public Transform attack_perks;
    public Transform stat_perks;


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
        }
    }
}
