using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMove : MonoBehaviour
{
    [SerializeField] Transform[] Path_Point = new Transform[3];
    NavMeshAgent NPS;
    int random;
    [SerializeField] Transform player;
    [SerializeField] float seeDistance = 15f;
    [SerializeField] float follow_speed = 3;
    private int time = 3;

    private void Awake()
    {
        NPS = GetComponent<NavMeshAgent>();
    }
    private void Start()
    {
        StartCoroutine(Patrol());
    }
    private void SetDistanation()
    {
        random = Random.Range(0, 3);
        NPS.SetDestination(Path_Point[random].position);
    }
    void Update()
    {
        

        if(Vector3.Distance(transform.position, player.position) < seeDistance)
        {
            StopCoroutine(Patrol());
            transform.LookAt(player.transform);
            transform.Translate(new Vector3(0, 0, follow_speed * Time.deltaTime));
        }
        else
        {
            StartCoroutine(Patrol());
        }
    }

    IEnumerator Patrol()
    {
        if (NPS.remainingDistance < 0.05f)
        {
            SetDistanation();
        }
        yield return null;
        
    }
}
