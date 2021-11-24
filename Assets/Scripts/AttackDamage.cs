using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackDamage : MonoBehaviour
{
    public LayerMask layer;
    public float radius = 1f;
    public float damage = 1f;

    // Start is called before the first frame update
    

    // Update is called once per frame
    void Update()
    {

        Collider[] hits = Physics.OverlapSphere(transform.position, radius, layer);
        if (hits.Length > 0)
        {
           // print("Touch the game object");
            hits[0].GetComponent<HealthScript>().ApplyDamage(damage);
            gameObject.SetActive(false);
        }
    }
}
