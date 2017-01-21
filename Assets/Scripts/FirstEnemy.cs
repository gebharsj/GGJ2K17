using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class FirstEnemy : MonoBehaviour
{
    public float speed;
    public GameObject ring;
    public GameObject ringSpawn;

    GameObject player;
    GameManager gameManager;
    bool attacking;
    NavMeshAgent nav;

    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        nav = GetComponent<NavMeshAgent>();
        int random = Random.Range(0, gameManager.players.Count);
        player = gameManager.players[random];
    }

    void Update()
    {
        if(Vector3.Distance(transform.position, player.transform.position) > 10)
        {
            transform.LookAt(player.transform);
            nav.SetDestination(player.transform.position);
         //   transform.LookAt(player.transform);
         //   transform.Translate(player.transform.position);
        }
        else
        {
            if(!attacking)
            Attack();
        }
    }

    IEnumerator Attack()
    {
        attacking = true;
        GameObject clone = Instantiate(ring, ringSpawn.transform.position, ringSpawn.transform.rotation) as GameObject;
        clone.transform.SetParent(null);
        yield return new WaitForSeconds(3);
        attacking = false;
    }
	//private NavMeshAgent nav;
	//[SerializeField]
	//private List<GameObject> targets; // list of targets
 //   [SerializeField]
 //   private float speed; // checking distance is for when a player enters the enemy's trigger. If the current target is too far away then theTarget will become the player that the enemy collided with.

	//private GameObject theTarget;// the actual target
	//private int _target; // the target selector 
 //   public GameObject ring;
 //   public GameObject ringSpawn;
 //                        // Use this for initialization
 //   GameManager gameManager;
 //   Animator anim;
 //   float lastTime;
 //   float cooldown = 1f;
 //   bool attacking;
 //   bool firstGround = false;
 //   void OnEnable()
 //   {
 //       gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
 //       anim = GetComponent<Animator>();
 //       foreach (GameObject go in gameManager.players)
 //       {
 //           targets.Add(go);
 //       }
 //       nav = GetComponent<NavMeshAgent>();
 //       _target = Random.Range(0, targets.Count);
 //       theTarget = targets[_target];
      
 //   }
	//void Start ()
 //   {
 // //      anim = GetComponent<Animator>();
 // //      foreach(GameObject go in gameManager.players)
 // //      {
 // //          targets.Add(go);
 // //      }
	//	//nav = GetComponent<NavMeshAgent> ();
	//	//_target = Random.Range (0, targets.Count);
	//	//theTarget = targets[_target];
	//	//Chase ();
	//}
	
	//void Update ()
 //   {
 //       if (!theTarget.activeInHierarchy)
 //       {
 //           for (int i = 0; i < targets.Count; i++)
 //           {
 //               if (targets[i].activeInHierarchy)
 //                   theTarget = targets[i].gameObject;
 //           }
 //       }
 //   }
	
 //   void LateUpdate()
 //   {
 //       if (firstGround)
 //       {
 //           anim.SetFloat("Distance", Vector3.Distance(transform.position, theTarget.transform.position));
 //           if (attacking == false && Vector3.Distance(transform.position, theTarget.transform.position) > this.GetComponent<SphereCollider>().radius)
 //           {
 //               Chase();
 //           }
 //           else if (!attacking && Vector3.Distance(transform.position, theTarget.transform.position) < this.GetComponent<SphereCollider>().radius)
 //           {
 //               anim.SetBool("Attack", false);
 //               anim.SetBool("IsRunning", false);

 //               if (Time.time + cooldown > lastTime && !attacking)
 //               {
 //                   attacking = true;
 //                   lastTime = Time.time;
 //                   StartCoroutine(Attack());
 //               }
 //           }
 //       }
 //   }
	//IEnumerator Attack()
 //   {
 //       anim.SetBool("IsRunning", false);
 //       anim.SetBool("Attack", true);
 //       yield return new WaitForSeconds(.5f);
 //       anim.SetBool("Attack", false);
 //       yield return new WaitForSeconds(2f);
 //       GameObject clone = Instantiate(ring, ringSpawn.transform.position, ringSpawn.transform.rotation) as GameObject;
 //       clone.transform.SetParent(null);
 //       attacking = false;     
 //   }
	//void Chase()
	//{
 //       anim.SetBool("Attack", false);
 //       anim.SetBool("IsRunning", true);
 //       nav.speed = speed;
 //       nav.destination = theTarget.transform.position;       
	//}
 //   void OnTriggerEnter(Collider other)
 //   {
 //       if(firstGround == false && other.tag == "Ground")
 //       {
 //           firstGround = true;
 //           Chase();
 //       }
 //   }
}
