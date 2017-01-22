using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class FirstEnemy : MonoBehaviour
{
    public GameObject ring;
    public GameObject ringSpawn;
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
            if (Vector3.Distance(transform.position, target.transform.position) > 5)
                agent.SetDestination(target.transform.position);
            else if (agent.remainingDistance <= 5)
            {
                if (GetComponent<Health>().health <= 0)
                    StopAllCoroutines();
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
        if(!isAttacking)
        {
            isAttacking = true;
            agent.velocity = Vector3.zero;
            anim.SetBool("Attack", true);
            yield return new WaitForSeconds(0.5f);
            anim.SetBool("Attack", false);
            yield return new WaitForSeconds(.65f);
            GameObject clone = Instantiate(ring, ringSpawn.transform.position, ringSpawn.transform.rotation) as GameObject;
            clone.transform.SetParent(null);
            yield return new WaitForSeconds(4);
            isAttacking = false;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Ground")
            hitGround = true;
    }
}