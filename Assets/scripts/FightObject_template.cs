using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FightObject_template : MonoBehaviour
{
    public bool damage_on = false;
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    virtual public void Shot() { }

    virtual public void EnemyMakeImpact(enemy_script enemy) { }

    virtual public void GetReady() { }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(collision.GetComponent<Collider2D>().tag);
        if (damage_on)
        {
            if (collision.GetComponent<Collider2D>().tag == "enemy")
            {
                EnemyMakeImpact(collision.GetComponent<Collider2D>().GetComponent<enemy_script>());
                Debug.Log("IMPACT");
            }
        }
    }
}
