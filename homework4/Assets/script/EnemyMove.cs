using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMove : MonoBehaviour
{
    [SerializeField] Transform[] Path_Point = new Transform[3];
    NavMeshAgent NPS;
    int random;
    private void Awake()
    {
        NPS = GetComponent<NavMeshAgent>();
    }
    private void SetDistanation()
    {
        random = Random.Range(0, 3);
        NPS.SetDestination(Path_Point[random].position);
    }
    void Update()
    {
        if (NPS.remainingDistance < 0.05f)
        {
            SetDistanation();
        }
    }
}
