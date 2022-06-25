using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBeeStateManager : MonoBehaviour
{
    public float movementSpeed;
    [SerializeField] float rotationSpeed;
    private BabyBee[] amountOffBabyBees;
    [SerializeField] GameObject stingPrefab;
    [SerializeField] Transform stingSpawnPoint;
    public Transform currentTaget;
    public bool collectedNectar;
    private ParticleSystem honeyPartical;
    private Animator animator;
    [SerializeField] GameObject babyBeePrefab;
    [SerializeField] float babyBeePositionOffsetMin;
    [SerializeField] float babyBeePositionOffsetMax;

    EnemyBeeBaseState currentState;
    public EnemyBeeFlowerState FlowerState = new EnemyBeeFlowerState();
    public EnemyBeeHiveState HiveState = new EnemyBeeHiveState();
    public EnemyBeeWildBeeState WildBeeState = new EnemyBeeWildBeeState();
    public EnemyBeeAttackState AttackState = new EnemyBeeAttackState();

    void Start()
    {
        currentState = FlowerState;
        currentState.EnterState(this);
        collectedNectar = false;
        honeyPartical = GetComponentInChildren<ParticleSystem>();
        honeyPartical.Pause();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        currentState.UpdateState(this);

        EnemyRotation();
    }

    void OnTriggerEnter(Collider collider)
    {
        currentState.OnTriggerEnter(this, collider);
    }

    public void SwitchState(EnemyBeeBaseState state)
    {
        currentState = state;
        state.EnterState(this);
    }

    public void CollectNectar(Collider other)
    {
        other.GetComponent<Flower>().DissableNectar();
        collectedNectar = true;
        honeyPartical.Play();
    }

    public void CollectHoney()
    {
        // Plus Honing scoren

        for (int i = 0; i < 1; i++)
        {
            AddBabyBee();
        }

        collectedNectar = false;
        honeyPartical.Pause();
        honeyPartical.Clear();
    }

    public void AddBabyBee()
    {
        float spawnPositionXmin = transform.position.x - Random.Range(babyBeePositionOffsetMin, babyBeePositionOffsetMax);
        float spawnPositionXPlus = transform.position.x + Random.Range(babyBeePositionOffsetMin, babyBeePositionOffsetMax);
        float spawnPositionXRandom;
        float spawnPositionZmin = transform.position.z - Random.Range(babyBeePositionOffsetMin, babyBeePositionOffsetMax);
        float spawnPositionZPlus = transform.position.z + Random.Range(babyBeePositionOffsetMin, babyBeePositionOffsetMax);
        float spawnPositionZRandom;
        int randNumberX = Random.Range(0, 2);
        int randNumberZ = Random.Range(0, 2);

        if (randNumberX == 0)
        {
            spawnPositionXRandom = spawnPositionXmin;
        }
        else
        {
            spawnPositionXRandom = spawnPositionXPlus;
        }

        if (randNumberZ == 0)
        {
            spawnPositionZRandom = spawnPositionZmin;
        }
        else
        {
            spawnPositionZRandom = spawnPositionZPlus;
        }

        Vector3 spawnPosition = new Vector3(spawnPositionXRandom, transform.position.y, spawnPositionZRandom);
        GameObject babyBee = Instantiate(babyBeePrefab, spawnPosition, transform.rotation);
        babyBee.transform.SetParent(transform);
    }

    public void ChangeCurrentTarget(Transform target)
    {
        currentTaget = target;
    }

    void EnemyRotation()
    {
        // Determine which direction to rotate towards
        Vector3 targetDirection = currentTaget.position - transform.position;

        // The step size is equal to speed times frame time.
        float singleStep = rotationSpeed * Time.deltaTime;

        // Rotate the forward vector towards the target direction by one step
        Vector3 newDirection = Vector3.RotateTowards(transform.forward, new Vector3(targetDirection.x, 0f, targetDirection.z), singleStep, 0.0f);

        // Calculate a rotation a step closer to the target and applies rotation to this object
        transform.rotation = Quaternion.LookRotation(newDirection);
    }

    public void Death(Collider other)
    {
        animator.SetTrigger("Death");
        Destroy(this.gameObject, 1f);
        Destroy(other.gameObject);
        // Update Score
    }

    public void SchootSting()
    {
        amountOffBabyBees = GetComponentsInChildren<BabyBee>();

        if (amountOffBabyBees.Length >= 1)
        {
            var sting = Instantiate(stingPrefab, stingSpawnPoint.position, stingSpawnPoint.rotation);
            //sting.GetComponent<Rigidbody>().velocity = stingSpawnPoint.up * stingspeed * Time.deltaTime;

            GameObject babyBee = GetComponentInChildren<BabyBee>().gameObject;
            //Destroy(babyBee);
            //Animator babyBeeAnimation = GetComponentInChildren<Animator>();
            //babyBeeAnimation.SetTrigger("Death");
            //Destroy(babyBeeAnimation.gameObject, 1f);
        }
    }

    public void DestroyGameobject(GameObject gameObject)
    {
        Destroy(gameObject);
    }
}
