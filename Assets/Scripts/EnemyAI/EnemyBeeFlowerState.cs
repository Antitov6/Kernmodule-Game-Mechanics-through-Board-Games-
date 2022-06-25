using UnityEngine;

public class EnemyBeeFlowerState : EnemyBeeBaseState
{

    private float speed;

    private GameObject[] multipleFlowers;
    public Transform closestFlower;
    public bool flowerContact;

    public override void EnterState(EnemyBeeStateManager enemyBee)
    {
        Debug.Log("FlowerState");
        speed = enemyBee.movementSpeed;

        closestFlower = null;
        flowerContact = false;
    }

    public override void UpdateState(EnemyBeeStateManager enemyBee)
    {
        closestFlower = GetClosestFlower(enemyBee);
        enemyBee.ChangeCurrentTarget(GetClosestFlower(enemyBee));

        var step = speed * Time.deltaTime;
        enemyBee.transform.position = Vector3.MoveTowards(enemyBee.transform.position, new Vector3(closestFlower.transform.position.x, 1.75f, closestFlower.transform.position.z), step);
    }


    public override void OnTriggerEnter(EnemyBeeStateManager enemyBee, Collider other)
    {
        Flower(enemyBee, other);

        if (other.GetComponent<Sting>())
        {
            enemyBee.Death(other);
        }
    }

    private static void Flower(EnemyBeeStateManager enemyBee, Collider other)
    {
        if (other.GetComponent<Flower>())
        {
            if (other.GetComponent<Flower>().hasNectar)
            {
                enemyBee.CollectNectar(other);
                enemyBee.SwitchState(enemyBee.HiveState);
            }
        }
    }

    public Transform GetClosestFlower(EnemyBeeStateManager enemyBee)
    {
        multipleFlowers = GameObject.FindGameObjectsWithTag("Flower");
        float closestDistance = Mathf.Infinity;
        Transform trans = null;

        foreach (GameObject flower in multipleFlowers)
        {
            if (flower.GetComponent<Flower>().hasNectar == true)
            {
                float currentDistance;
                currentDistance = Vector3.Distance(enemyBee.transform.position, flower.transform.position);
                if (currentDistance < closestDistance)
                {
                    closestDistance = currentDistance;
                    trans = flower.transform;
                }
            }
        }
        return trans;
    }
}
