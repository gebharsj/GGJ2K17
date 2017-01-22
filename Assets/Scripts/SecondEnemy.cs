using UnityEngine;
using System.Collections;

public class SecondEnemy : MonoBehaviour {

    public ParticleSystem[] beamParts;
    NavMeshAgent agent;
    GameManager gm;
    GameObject target;
    Animator anim;
    bool hitGround;
    bool isAttacking;

    void Start()
    {
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();
        target = gm.players[Random.Range(0, gm.players.Count)];
        agent = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        anim.SetFloat("Distance", Vector3.Distance(transform.position, target.transform.position));
        if (hitGround)
        {
            if (Vector3.Distance(transform.position, target.transform.position) > 10)
                agent.SetDestination(target.transform.position);
            else if (agent.remainingDistance <= 10)
            {
                if (GetComponent<Health>().health <= 0)
                {
                    StopAllCoroutines();
                    foreach (ParticleSystem ps in beamParts)
                    {
                        ps.enableEmission = false;
                    }
                }
                agent.velocity = Vector3.zero;
                CallCoroutine("Attack");
            }
        }
    }

    void CallCoroutine(string coroutine)
    {
        StartCoroutine(coroutine);
    }

    IEnumerator Attack()
    {
        if (!isAttacking)
        {
            isAttacking = true;
            agent.velocity = Vector3.zero;
            anim.SetBool("Attack", true);
            yield return new WaitForSeconds(0.5f);
            anim.SetBool("Attack", false);
            yield return new WaitForSeconds(.65f);
            foreach(ParticleSystem ps in beamParts)
            {
                ps.enableEmission = true;
            }
            yield return new WaitForSeconds(1f);
            foreach (ParticleSystem ps in beamParts)
            {
                ps.enableEmission = false;
            }
            yield return new WaitForSeconds(3f);
            isAttacking = false;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Ground")
            hitGround = true;
    }
}