using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Rendering;
using UnityEditor.Toolbars;
using UnityEditor.SceneManagement;
using UnityEngine;

public class Generate_enemies : MonoBehaviour
{
    public float timer = 0;
    public List<GameObject> enemies;
    public PlayerController player;
    public GameObject enemy_spawner;

    public void Rotate()
        {
        enemy_spawner.transform.RotateAround(player.gameObject.transform.position, Vector3.forward, Random.Range(-1000, 1000));
        }
 
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer > 3)
        {
            timer = 0;
            GameObject enemy = Instantiate(enemies[Random.Range(0,3)],transform);
            enemy.transform.localPosition = new Vector3(enemy_spawner.transform.position.x, enemy_spawner.transform.position.y, 0);
            enemy.GetComponent<enemy_script>().can_move = true;
        }
        Rotate();
    }
}
