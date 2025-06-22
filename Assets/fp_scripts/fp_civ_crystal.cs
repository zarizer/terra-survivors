using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class fp_civ_crystal : FightObject_template
{
    public PlayerController player;

    public float damage;
    public float push_strengh;
    public string damage_type;
    void Start()
    {

    }

    void Update()
    {
        if (damage_on) 
        {
            Collider2D[] hits = Physics2D.OverlapCircleAll(transform.position, 0.3f);
            foreach (var hit in hits)
            {
                if (hit.CompareTag("enemy"))
                {
                    EnemyMakeImpact(hit.GetComponent<enemy_script>());
                    hit.GetComponent<enemy_script>().GetDamage(damage, damage_type);
                    damage_on = false;
                    LeanTween.delayedCall(0.1f, () => { damage_on = true; });
                }
            }
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
        Vector2 vector_towards_player = new Vector2(transform.position.x - player.transform.position.x, transform.position.y - player.transform.position.y);
        vector_towards_player.Normalize();
        enemy.gameObject.GetComponent<Rigidbody2D>().AddForce(vector_towards_player * push_strengh, ForceMode2D.Impulse);
        enemy.can_move = false;
        LeanTween.delayedCall(0.1f, () => { enemy.can_move = true; });
        enemy.gameObject.LeanColor(Color.red, 0.01f);
        enemy.gameObject.LeanColor(Color.white, 0.4f);
    }

    public override void GetReady()
    {

    }
}