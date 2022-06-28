using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Lesson4 : MonoBehaviour
{

    [SerializeField] Transform[] Path_Point = new Transform[3];
    NavMeshAgent NPS;
    int random;
    Camera camera;
    RaycastHit hit; //хранит инфо о позиции 

    private void Awake()
    {
        NPS = GetComponent<NavMeshAgent>(); 
    }

    // Start is called before the first frame update
    void Start()
    {
        //camera = Camera.main;
    }


    private void SetDistanation()
    {
        random = Random.Range(0, 3);
        NPS.SetDestination(Path_Point[random].position);// установка рандомных точек пути
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(2))
        {
            //Physics.Raycast(camera.ScreenPointToRay(Input.mousePosition), out hit);
            NPS.SetDestination(hit.point);
        }


        if (NPS.remainingDistance < 0.05f)
        {
            SetDistanation();
        }
    }


  

    
}
