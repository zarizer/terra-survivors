using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEditor.Toolbars;
using UnityEngine;

public class enemy_script : MonoBehaviour
{
    public float speed;
    public float base_damage;
    public float damage_multiplier;


    public Transform player;

    private bool can_move = true;
    void Start()
    {
        
    }


    void Update()
    {
        MoveTowardsPlayer();
    }
    [ContextMenu("MakeForce")]
    public void MakeForce()
    {
        GetComponent<Rigidbody2D>().AddForce(Vector2.down);
    }

    private void OnCollisionEnter2D(UnityEngine.Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            player.gameObject.GetComponent<PlayerController>().GetDamage(base_damage * damage_multiplier);
            Vector2 vector_towards_player = new Vector2(transform.position.x - player.position.x, transform.position.y - player.position.y);
            vector_towards_player.Normalize();
            GetComponent<Rigidbody2D>().AddForce(vector_towards_player * 3, ForceMode2D.Impulse);
            can_move = false;
            LeanTween.delayedCall(1.0f, () => { can_move = true; });
            player.gameObject.LeanColor(Color.red, 0.05f);
            player.gameObject.LeanColor(Color.white, 0.4f);


        }
    }

    void MoveTowardsPlayer()
    {
        if (can_move)
        {
            Vector2 vector_towards_player = new Vector2(player.position.x - transform.position.x, player.position.y - transform.position.y);
            vector_towards_player.Normalize();
            GetComponent<Rigidbody2D>().velocity = vector_towards_player * speed * 0.5f;
        }
    }
        
}
