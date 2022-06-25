using UnityEngine;

public class EnemyBeeWildBeeState : EnemyBeeBaseState
{
    private float speed;

    private GameObject[] multipleWildBees;
    public Transform closestWildBee;

    private int randomNumber;

    public override void EnterState(EnemyBeeStateManager enemyBee)
    {
        Debug.Log("WildBeeState");

        speed = enemyBee.movementSpeed;

        closestWildBee = null;

        randomNumber = Random.Range(0, 2);
    }

    public override void UpdateState(EnemyBeeStateManager enemyBee)
    {
        closestWildBee = GetClosestWildBee(enemyBee);
        enemyBee.ChangeCurrentTarget(GetClosestWildBee(enemyBee));

        var step = speed * Time.deltaTime;
        enemyBee.transform.position = Vector3.MoveTowards(enemyBee.transform.position, new Vector3(closestWildBee.transform.position.x, 1.75f, closestWildBee.transform.position.z), step);
    }

    public override void OnTriggerEnter(EnemyBeeStateManager enemyBee, Collider other)
    {
        WildBabyBee(enemyBee, other);

        if (other.GetComponent<Sting>())
        {
            enemyBee.Death(other);
        }
    }

    private void WildBabyBee(EnemyBeeStateManager enemyBee, Collider other)
    {
        if (other.GetComponent<WildBabyBee>())
        {
            enemyBee.AddBabyBee();
            ChangeCurrentState(enemyBee);
            enemyBee.DestroyGameobject(other.gameObject);
        }
    }

    public Transform GetClosestWildBee(EnemyBeeStateManager enemyBee)
    {
        multipleWildBees = GameObject.FindGameObjectsWithTag("WildBabyBee");
        float closestDistance = Mathf.Infinity;
        Transform trans = null;

        foreach (GameObject wildBee in multipleWildBees)
        {
                float currentDistance;
                currentDistance = Vector3.Distance(enemyBee.transform.position, wildBee.transform.position);
                if (currentDistance < closestDistance)
                {
                    closestDistance = currentDistance;
                    trans = wildBee.transform;
                }
        }
        return trans;
    }

    private void ChangeCurrentState(EnemyBeeStateManager enemyBee)
    {
        if (randomNumber == 0)
        {
            enemyBee.SwitchState(enemyBee.FlowerState);
        }
        else
        {
            enemyBee.SwitchState(enemyBee.AttackState);
        }
    }
}
