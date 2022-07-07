using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewShootBomb : MonoBehaviour
{
    [SerializeField] GameObject bomb;
    [SerializeField] Transform Spawn;
    

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            GameObject NewBomb = Instantiate(bomb, Spawn.position, Spawn.rotation);
            NewBomb.GetComponent<BombShoot>().SetDirection(Spawn.forward);
            Destroy(NewBomb.transform.gameObject, 3f);
        }
               
    }
}
