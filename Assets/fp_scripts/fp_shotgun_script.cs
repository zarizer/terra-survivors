using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fp_shotgun_script : FightObject_template
{
    public PlayerController player;
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
    }

    public override void Shot()
    {
        player.PlaySound(player.GetSound("shotgun_shot"));
        transform.RotateAround(player.gameObject.transform.position, Vector3.forward, Random.Range(-1000, 1000));
        gameObject.LeanAlpha(1, 0f);
        damage_on = true;
        gameObject.LeanAlpha(0, 0.5f);
        Collider2D[] hits = Physics2D.OverlapCircleAll(transform.position, 0.5f);
        foreach (var hit in hits)
        {
            if (hit.CompareTag("enemy"))
            {
                EnemyMakeImpact();
                Debug.Log("IMPACT (вращение)");
            }
        }
        LeanTween.delayedCall(0.2f, () => { damage_on = false; });
    }
}
