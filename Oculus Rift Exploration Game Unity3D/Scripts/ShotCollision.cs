using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotCollision : MonoBehaviour
{
    public GameObject explosionPrefab;
    public GameObject heartPrefab;

    void Start()
    {
        // After arrow is instantiated(trigger pressed), destroy it after 5 seconds
		Destroy(gameObject, 5.0f); 
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("shootable"))
        {
            //Instantiate explosion where arrow is
			//Parent arrow's transform to target's transform (making arrow a child of target)
			//Destroy ridgidbody & collider so arrow can stick to object
            Instantiate(explosionPrefab, gameObject.transform.position, gameObject.transform.rotation);           
            gameObject.transform.parent = collision.gameObject.transform;
            Destroy(gameObject.GetComponent<Rigidbody>());
            Destroy(gameObject.GetComponent<Collider>());
            Destroy(collision.gameObject, 0.8f);
        } 
		else if (collision.gameObject.CompareTag("arrowTarget"))
        {
            //Parent arrow's transform to target's transform (making arrow a child of target)
			//Destroy ridgidbody & collider so arrow can stick to object
            gameObject.transform.parent = collision.gameObject.transform;
            Destroy(gameObject.GetComponent<Rigidbody>());
            Destroy(gameObject.GetComponent<Collider>());
        } 
        else if (collision.gameObject.CompareTag("animal"))
        {
            //Instantiate explosion where arrow is
            Instantiate(heartPrefab, gameObject.transform.position, gameObject.transform.rotation);
            Destroy(gameObject);
        }
    }
}

