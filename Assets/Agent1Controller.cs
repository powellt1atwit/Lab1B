using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Agent1Controller : MonoBehaviour
{
    public GameObject player;
    public GameObject target;

    public float speed = 5.0f;
    public float playerDistanceThreshold = 5.0f;
    public float targetDistanceThreshold = 3.0f;
    public bool activated = false;

    private void Update()
    {
        float distanceBetweenTarget = Vector3.Distance(transform.position, target.transform.position);
        float distanceBetweenPlayer = Vector3.Distance(transform.position, player.transform.position);
        Vector3 direction = (player.transform.position - transform.position).normalized;

        // Implement agent behavior code for Agent 1 using Decision Tree
        if(distanceBetweenTarget < targetDistanceThreshold){
            if(distanceBetweenPlayer < playerDistanceThreshold){
                //flee
                transform.position -= direction * speed * Time.deltaTime;
            }
            else{
                //chase
                transform.position += direction * speed * Time.deltaTime;
            }
        }
        else{
            //chase
            transform.position += direction * speed * Time.deltaTime;
        }
        
    }
    
}
