using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mine : MonoBehaviour
{
    //[SerializeField] private float damage = 1000;
    public LayerMask layer;
    [SerializeField]public ParticleSystem particle;
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            //GetComponent<UnitHP>().Adjust(damage);
            Debug.Log(particle.gameObject.name);
            particle.Play();
            //Destroy(gameObject);
            


        }
        
    }
}
    
