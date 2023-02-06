using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAIMovement : MonoBehaviour
{
    private Transform target;
    private NavMeshAgent agent;

    private void Start()
    {
        target = PlayerManager.instance.Player.transform;
        agent = GetComponent<NavMeshAgent>();
		agent.updateRotation = false;
		agent.updateUpAxis = false;
    }

    private void Update()
    {
        float distance = Vector2.Distance(target.position, transform.position);

        agent.SetDestination(target.position);

        if (distance <= agent.stoppingDistance){
            FaceTarget();
        }else{
            FaceMovementDirection();
        }
    }

    private void FaceMovementDirection(){
        Vector2 moveDirection = agent.velocity;
            if(moveDirection != Vector2.zero){
                float angle = Mathf.Atan2(moveDirection.y, moveDirection.x) * Mathf.Rad2Deg - 90;
                transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
            }
    }

    private void FaceTarget(){
        Vector2 direction = transform.InverseTransformPoint(target.transform.position);
        if(direction != Vector2.zero){
            float Angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90;
            transform.Rotate(0, 0, Angle);
        }
    }

}
