using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lesson2 : MonoBehaviour
{

    [SerializeField] float player_speed;
    private Vector3 Vector3_player_Direction = Vector3.zero;

    [SerializeField] GameObject GameObject_Mine;
    [SerializeField] Transform Transform_Mine_Spawn;

    [SerializeField] int Damage = 10;

    private void OnTriggerEnter(Collider other) //нужно поствить галочку тригер в инспекторе
    {
        //var enemy = other.GetComponent<MyEnemy>();
        //enemy.Hurt(Damage);
        Destroy(gameObject);
    }

    int heals;
    public void Hurt(int count)
    {
        heals -= count;
        if(heals <= 0)
        {
            Die();
        }
    }
    private void Die()
    {
        Destroy(gameObject);
    }



  //  [SerializeField]  для подсвечивания в инспекторе юнити (в появ поле можно добавить нужный объект)
    [SerializeField] GameObject GameObject_Prefab;
    GameObject GameObject_Cube;

    float timer = 0;

    GameObject[] Enemies;

    CapsuleCollider player_collider;

    float moveHorizontal;
    float moveVertical;

    // Start is called before the first frame update
    void Start()
    {
        print("Hello"); //сообщение для консоли
        Debug.Log("Hello"); //второй вариант

        GameObject_Cube = Instantiate(GameObject_Prefab,Vector3.zero,Quaternion.identity);
        Instantiate(GameObject_Prefab, gameObject.transform, true); // для создания на родительском объекте
        Destroy(GameObject_Cube, 3/*sec*/); //удаление через время

        transform.GetChild(1 /*индекс*/).gameObject.SetActive(false); //обращение к дочернему объекту
        transform.Find("Root").gameObject.SetActive(false);
        //GameObject.Find // еще одни способ, очень затратный, не использовать в update поиск идет только по оглавлению
        GameObject.Find("Jhon").transform.Find("Root").gameObject.SetActive(false);
        GameObject.FindGameObjectWithTag("Player").SetActive(false); //по тегу
        Enemies = GameObject.FindGameObjectsWithTag("Enemi");
        for(int i = 0; i < Enemies.Length; i++)
        {
            Enemies[i].SetActive(false);
        }
        player_collider = GetComponent<CapsuleCollider>();
        GetComponent<CapsuleCollider>().enabled = false; //отключение компонентов
        Destroy(player_collider);
        Destroy(this); //удаление данного скрипта с объекта
    }

    private void FixedUpdate()
    {


        //player_speed = Vector3_player_Direction * player_speed * Time.deltaTime;
        transform.Translate(Vector3_player_Direction * player_speed * 10 * Time.deltaTime);









        Debug.Log("Hello" + Time.fixedDeltaTime);//для оптимизации умножают на перемещение
    }

    // Update is called once per frame
    void Update()
    {

        Vector3_player_Direction.x = Input.GetAxis("Horizontal"); //y - вверх
        Vector3_player_Direction.z = Input.GetAxis("Vertical");




        if (Input.GetButtonDown("Fire1")) //LKM
        {
            Instantiate(GameObject_Mine, Transform_Mine_Spawn.position, Transform_Mine_Spawn.rotation);
        }









        Debug.Log("Hello" + Time.deltaTime);

        timer += Time.deltaTime; //время выполнение программы
        if(timer > 5)
        {
            GameObject_Cube.SetActive(false); //выключение объекта на сцене
        }


        if (Input.GetKey(KeyCode.Q)) //для считывания клавиш GetKeyUp GetKeyDown
            //GetMouseButtonDown(0)    0-LKM, 1-PKM, 2-koles,
        {
            Debug.Log("Pressed Q");
        } else if (Input.GetKeyUp(KeyCode.Q))
        {
            Debug.Log("Dont pressed Q");
        }

        moveHorizontal = Input.GetAxis("Horizontal");
        moveVertical = Input.GetAxis("Vertical");
        //GetAxisRaw - мгновенная реакция   
    }
}
