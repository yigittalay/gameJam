using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Thorn : MonoBehaviour
{
    [SerializeField] float thornSpeed;
    Rigidbody thornRb;
    Vector3 moveDirection;

    void Start()
    {
        thornRb = GetComponent<Rigidbody>();
        SpawnThorn();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnThorn()
    {
        moveDirection = (Player.currentPos - transform.position).normalized * thornSpeed;
        thornRb.velocity = moveDirection;
        Destroy(gameObject, 4f);
    }

    private void OnTriggerEnter(Collider other)
    {
        int bulletDamage = Random.Range(20, 26);
        if (other.CompareTag("Player"))
        {
            Player.currentHealth -= bulletDamage;

            Destroy(gameObject);
        }
    }

}