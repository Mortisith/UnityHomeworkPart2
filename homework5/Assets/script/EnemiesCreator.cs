using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemiesCreator : MonoBehaviour
{
    [SerializeField] GameObject GameObject_Slug;
    [SerializeField] Transform Transform_Slug_Spawn;

    NavMeshAgent NPS;
    int random;

    public Transform[] Path_Point = new Transform[3];

    private void Awake()
    {
        Instantiate(GameObject_Slug, Transform_Slug_Spawn.position, Transform_Slug_Spawn.rotation);
    }


    void Start()
    {
        
        NPS = GameObject_Slug.GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {

        if (NPS.remainingDistance < 0.05f)
        {
            SetDistanation();
        }

    }

    private void SetDistanation()
    {
        random = Random.Range(0, 3);
        NPS.SetDestination(Path_Point[random].position);
    }
}
