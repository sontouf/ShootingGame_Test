using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFSM : MonoBehaviour
{
	public enum EnemyState { GoToBase, AttackBase, ChasePlayer, AttackPlayer}
	public EnemyState currentState;

	private void Update()
	{
		if (currentState == EnemyState.GoToBase) { GoToBase(); }
		else if (currentState == EnemyState.AttackBase) { AttackBase(); }
		else if (currentState == EnemyState.ChasePlayer) { ChasePlayer(); }
		else { AttackPlayer(); }
	}

	public Sight sightSensor;
	public Transform baseTransform;
	public float baseAttackDistance;

	void GoToBase() { 
		if (sightSensor.detectedObject != null)
		{
			currentState = EnemyState.ChasePlayer;
		}
		float distanceToBase = Vector3.Distance(
			transform.position, baseTransform.position );
		if (distanceToBase < baseAttackDistance) 
		{
			currentState = EnemyState.AttackBase;
		}
	}
	void AttackBase() 
	{ 
		
	}

	public float playerAttackDistance;
	void ChasePlayer() 
	{
        if (sightSensor.detectedObject == null)
        {
            currentState = EnemyState.GoToBase;
			return;
        }
        float distanceToBase = Vector3.Distance(
            transform.position, sightSensor.detectedObject.transform.position);
        if (distanceToBase < playerAttackDistance)
        {
            currentState = EnemyState.AttackPlayer;
        }
    }
	void AttackPlayer() { 
		if (sightSensor.detectedObject == null)
		{
			currentState = EnemyState.GoToBase;
			return;
		}

		float distanceToPlayer = Vector3.Distance(transform.position, sightSensor.detectedObject.transform.position);
		if (distanceToPlayer > playerAttackDistance * 1.1f)
		{
			currentState = EnemyState.ChasePlayer;
		}
	}


}
