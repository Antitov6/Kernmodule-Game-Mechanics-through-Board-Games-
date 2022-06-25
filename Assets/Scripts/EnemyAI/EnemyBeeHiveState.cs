using UnityEngine;

public class EnemyBeeHiveState : EnemyBeeBaseState
{

    private float speed;
    private BeeHive beeHivePosition;

    private int randomNumber;

    public override void EnterState(EnemyBeeStateManager enemyBee)
    {
        Debug.Log("HiveSate");
        speed = enemyBee.movementSpeed;
        beeHivePosition = GameObject.FindObjectOfType<BeeHive>();
        enemyBee.ChangeCurrentTarget(beeHivePosition.transform);
        randomNumber = Random.Range(0, 3);
    }

    public override void UpdateState(EnemyBeeStateManager enemyBee)
    {
        var step = speed * Time.deltaTime;
        enemyBee.transform.position = Vector3.MoveTowards(enemyBee.transform.position, new Vector3(beeHivePosition.transform.position.x, 1.75f, beeHivePosition.transform.position.z), step);
    }

    public override void OnTriggerEnter(EnemyBeeStateManager enemyBee, Collider other)
    {
        BeeHive(enemyBee, other);

        if (other.GetComponent<Sting>())
        {
            enemyBee.Death(other);
        }
    }

    private void BeeHive(EnemyBeeStateManager enemyBee, Collider other)
    {
        if (other.GetComponent<BeeHive>())
        {
            if (enemyBee.collectedNectar)
            {
                enemyBee.CollectHoney();

                if (enemyBee.gameObject.CompareTag("EnemyRed"))
                {
                    GameObject.FindObjectOfType<ScoreBoard>().AddScoreEnemy1();
                }
                else
                {
                    GameObject.FindObjectOfType<ScoreBoard>().AddScoreEnemy2();
                }

                ChangeCurrentState(enemyBee);
            }
        }
    }

    private void ChangeCurrentState(EnemyBeeStateManager enemyBee)
    {
        if(randomNumber == 0)
        {
            enemyBee.SwitchState(enemyBee.FlowerState);
        }
        else if(randomNumber == 1)
        {
            enemyBee.SwitchState(enemyBee.WildBeeState);
        }
        else
        {
            enemyBee.SwitchState(enemyBee.AttackState);
        }
    }
}
