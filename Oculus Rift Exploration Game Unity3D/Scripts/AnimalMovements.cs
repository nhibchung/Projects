using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AnimalMovements : MonoBehaviour {

    public Animator Rabbit_Red;
    private int randomNumber;

    //For navmesh agent
    public float roamRadius;
    public float roamTime;

    private Transform target;
    private NavMeshAgent agent;
    private float timer;
    
    void Start()
    {
        randomNumber = randomNumGenerator();
        //For navmesh agent
        agent = GetComponent<NavMeshAgent>();
        timer = roamTime;
    }

    // Update is called once per frame
    void Update () {
        timer += Time.deltaTime;
        if (timer >= roamTime)
        {
			//30% of the time will be idle
            if (randomNumber < 4)       
            {
                Rabbit_Red.SetBool("idleTrigger", true);
                Rabbit_Red.SetBool("moveTrigger", false);        
                agent.SetDestination(transform.position);               
                timer = 0;
                randomNumber = randomNumGenerator();
            } 
			else
			// randomNumber >= 4      
			//70% of the time will be moving
            { 
                Rabbit_Red.SetBool("moveTrigger", true);
                Rabbit_Red.SetBool("idleTrigger", false);
                Vector3 newPosition = RandomNavPos(transform.position, roamRadius, -1);
                agent.SetDestination(newPosition);
                timer = 0;
                randomNumber = randomNumGenerator();             
            }
        }
    }

    // Navmesh's random position generator 
    public Vector3 RandomNavPos(Vector3 origin, float distance, int layermask)
    {
        Vector3 randomPoint = Random.insideUnitSphere * distance;
        randomPoint += origin;
        NavMeshHit hit;
        NavMesh.SamplePosition(randomPoint, out hit, distance, layermask);
        return hit.position;
    }

    public int randomNumGenerator()
    {
        //Range is 1->10 because min (inclusive), max (exclusive)
        randomNumber = Random.Range(1, 11);     
        return randomNumber;
    }
}
