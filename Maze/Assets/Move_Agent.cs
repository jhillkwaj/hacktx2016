using UnityEngine;
using System.Collections;

public class Move_Agent : MonoBehaviour {

    int state;
    //0 = patrol
    //1 = chase

    public GameObject player;
    Vector3 chacePos = Vector3.zero;
    NavMeshAgent agent;
    public GameObject failObj;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        patrol();
    }

    // Update is called once per frame
    void Update()
    {
        if(state == 0)
        {
            if(Vector3.Distance(this.transform.position, chacePos) < 2f)
            {
                patrol();
            }
            Debug.Log(Mathf.Abs(Vector3.Angle(this.transform.forward, player.transform.position - this.transform.position)));
            //if near the player
            if(Vector3.Distance(this.transform.position, player.transform.position) < 1f || (Vector3.Distance(this.transform.position, player.transform.position) < 7f && Mathf.Abs(Vector3.Angle(this.transform.forward,player.transform.position - this.transform.position)) < 30f ))
            {
                state = 1;
                chasePlayer();
                this.GetComponent<AudioSource>().Play();
            }
        }
        else if(state == 1)
        {
            //if not near the player
            if (Vector3.Distance(this.transform.position, player.transform.position) > 20f)
            {
                state = 0;
                patrol();
                this.GetComponent<AudioSource>().Stop();
            }
            else
            {
                chasePlayer();
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            GameObject instance = Instantiate(Resources.Load("Fail Audio", typeof(GameObject))) as GameObject;
            failObj.SetActive(true);
            Destroy(this.gameObject);
        }
    }

    void chasePlayer()
    {
        chacePos = player.gameObject.transform.position;
        agent.destination = chacePos;
    }

    void patrol()
    {
        chacePos = new Vector3(Random.Range(-50, 50),0, Random.Range(-50, 50));
        agent.destination = chacePos;
    }
}
