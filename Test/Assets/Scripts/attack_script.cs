using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class attack_script : MonoBehaviour
{
    public Manager manager;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            Destroy(collision.gameObject);
            manager.birdCount++;
        }
    }
}
