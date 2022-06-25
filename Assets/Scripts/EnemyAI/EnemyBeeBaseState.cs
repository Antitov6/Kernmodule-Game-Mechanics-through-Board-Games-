using UnityEngine;

public abstract class EnemyBeeBaseState
{
    public abstract void EnterState(EnemyBeeStateManager enemyBee);

    public abstract void UpdateState(EnemyBeeStateManager enemyBee);

    public abstract void OnTriggerEnter(EnemyBeeStateManager enemyBee, Collider collider);
}
