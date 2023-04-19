using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowController : MonoBehaviour
{
    [Tooltip("скорость пули")]
    [SerializeField]
    private float speed = 10.0f;
    
    [Tooltip("урон стрелы")]
    [SerializeField]
    private float damage = 10f; 
    private void Update()
    {
        transform.Translate(Vector3.right * (speed * Time.deltaTime));
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {        
        if (collision.gameObject.CompareTag("Enemy"))
        {
            var health = collision.gameObject.GetComponent<Health>();
            health.TakeDamage(damage);
        }
        Destroy(gameObject);
    }
}
