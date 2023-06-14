using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float moveSpeed = 2f;
    private Rigidbody rb;
    private GameObject focalPoint;

    public GameObject powerupIndicator;
    public bool hasPowerup;
    private float powerupStrength = 12f;
   
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        focalPoint = GameObject.Find("Focal Point");
    }
    private void Update()
    {
        float forwardInput = Input.GetAxis("Vertical");
        rb.AddForce(focalPoint.transform.forward * forwardInput * moveSpeed);
        powerupIndicator.transform.position = transform.position + new Vector3(0,-0.5f,0);
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Powerup"))
        {
            hasPowerup = true;
            Destroy(other.gameObject);
            StartCoroutine((PowerupCountdownRoutine()));
            powerupIndicator.gameObject.SetActive(true);
        }
        
    }

    IEnumerator PowerupCountdownRoutine()
    {
        yield return new WaitForSeconds(7);
        hasPowerup = false;
        powerupIndicator.gameObject.SetActive(false);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy")&&hasPowerup)
        {
            Rigidbody enemyRb2 = collision.gameObject.GetComponent<Rigidbody>();
            Vector3 awayFromPlayer = collision.gameObject.transform.position - transform.position;
            enemyRb2.AddForce(awayFromPlayer*powerupStrength,ForceMode.Impulse);
            Debug.Log("Collided With"+collision.gameObject.name+"with powerup set to"+hasPowerup);
        }
    }
}
