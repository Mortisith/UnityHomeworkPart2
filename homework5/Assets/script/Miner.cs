using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Miner : MonoBehaviour
{
    [SerializeField] GameObject mine;
    [SerializeField] Transform mine_Spawn;
    

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire2")) 
        {
            Instantiate(mine, mine_Spawn.position, mine_Spawn.rotation);
        }
    }
}
