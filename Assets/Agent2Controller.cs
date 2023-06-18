using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Agent2Controller : MonoBehaviour
{
    public float speed = 5.0f;
    public float agent1DistanceThreshold = 3.0f;
    public GameObject player;
    public GameObject target;
    public GameObject agent1;


    // agent states:
    private enum State
    {
    ChasePlayer,
    ChaseTarget,
    Flee
    }

    private State currentState = State.ChasePlayer;
    private void Update()
    {
        float distanceBetweenTarget = Vector3.Distance(transform.position, target.transform.position);
        float distanceBetweenPlayer = Vector3.Distance(transform.position, player.transform.position);
        float distanceBetweenAgent = Vector3.Distance(transform.position, agent1.transform.position);
        Vector3 pDirection = (player.transform.position - transform.position).normalized;
        Vector3 tDirection = (target.transform.position - transform.position).normalized;
        Vector3 aDirection = (agent1.transform.position - transform.position).normalized;

        if (currentState == State.ChasePlayer){
            transform.position += pDirection * speed * Time.deltaTime;
        }
        else if(currentState == State.ChaseTarget){
            transform.position += tDirection * speed * Time.deltaTime;
        }
        else if(currentState == State.Flee){
            transform.position -= aDirection * speed * Time.deltaTime;
        }

        if (distanceBetweenPlayer <= distanceBetweenTarget && distanceBetweenAgent > agent1DistanceThreshold){
            currentState = State.ChasePlayer;
        }
        else if (distanceBetweenPlayer > distanceBetweenTarget && distanceBetweenAgent > agent1DistanceThreshold){
            currentState = State.ChaseTarget;
        }
        else{
            currentState = State.Flee;
        }
    }
}
