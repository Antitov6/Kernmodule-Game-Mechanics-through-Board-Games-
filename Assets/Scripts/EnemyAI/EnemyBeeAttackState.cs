using UnityEngine;

public class EnemyBeeAttackState : EnemyBeeBaseState
{
    private float speed;

    private GameObject playerTarget;

    private int randomNumber;

    public override void EnterState(EnemyBeeStateManager enemyBee)
    {
        Debug.Log("AttackState");
        speed = enemyBee.movementSpeed;
        playerTarget = GameObject.FindObjectOfType<PlayerMovement>().gameObject;

        randomNumber = Random.Range(0, 2);
    }

    public override void UpdateState(EnemyBeeStateManager enemyBee)
    {
        enemyBee.ChangeCurrentTarget(playerTarget.transform);  

        if(Vector3.Distance(enemyBee.transform.position, playerTarget.transform.position) <= 2.5f)
        {
            enemyBee.SchootSting();
            ChangeCurrentState(enemyBee);
        }
        else
        {
            var step = speed * Time.deltaTime;
            enemyBee.transform.position = Vector3.MoveTowards(enemyBee.transform.position, new Vector3(playerTarget.transform.position.x, 1.75f, playerTarget.transform.position.z), step);
        }

    }

    public override void OnTriggerEnter(EnemyBeeStateManager enemyBee, Collider other)
    {
        if (other.GetComponent<Sting>())
        {
            enemyBee.Death(other);
        }
    }

    private void ChangeCurrentState(EnemyBeeStateManager enemyBee)
    {
        if (randomNumber == 0)
        {
            enemyBee.SwitchState(enemyBee.FlowerState);
        }
        else
        {
            enemyBee.SwitchState(enemyBee.WildBeeState);
        }
    }
}
