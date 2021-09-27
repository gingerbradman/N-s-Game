using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class Enemy : MonoBehaviour
{

    private Transform target;

    public float speed;

    public Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();

    }

    // Update is called once per frame
    void Update()
    {
        //if (Vector2.Distance(transform.position, target.position) > 3)
        {
            transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        }
    }

    void OnCollisionEnter2D(Collision2D collider)
    {

        if (collider.gameObject.name == "Player")
        {
            collider.gameObject.GetComponent<Player>().DamagePlayer(1);
            Destroy(this.gameObject);
        }


    }
}

