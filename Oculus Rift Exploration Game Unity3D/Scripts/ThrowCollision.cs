using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowCollision : MonoBehaviour {

    public GameObject heartPrefab;

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("animal"))
        {
            Instantiate(heartPrefab, gameObject.transform.position, gameObject.transform.rotation);
            Destroy(gameObject);
        }
    }
}
