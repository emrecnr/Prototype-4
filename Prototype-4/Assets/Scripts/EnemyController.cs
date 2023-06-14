using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private float speed = .75f;
    private GameObject player;
    private Rigidbody rb2;
    void Start()
    {
        player = GameObject.Find("Player");
        rb2 = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 followPlayer = (player.transform.position-transform.position).normalized;
        rb2.AddForce(followPlayer*speed);

        if (transform.position.y<-10)
        {
            Destroy(gameObject);
        }
    }
}
