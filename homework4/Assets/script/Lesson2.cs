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

    private void OnTriggerEnter(Collider other) //����� �������� ������� ������ � ����������
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



  //  [SerializeField]  ��� ������������� � ���������� ����� (� ���� ���� ����� �������� ������ ������)
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
        print("Hello"); //��������� ��� �������
        Debug.Log("Hello"); //������ �������

        GameObject_Cube = Instantiate(GameObject_Prefab,Vector3.zero,Quaternion.identity);
        Instantiate(GameObject_Prefab, gameObject.transform, true); // ��� �������� �� ������������ �������
        Destroy(GameObject_Cube, 3/*sec*/); //�������� ����� �����

        transform.GetChild(1 /*������*/).gameObject.SetActive(false); //��������� � ��������� �������
        transform.Find("Root").gameObject.SetActive(false);
        //GameObject.Find // ��� ���� ������, ����� ���������, �� ������������ � update ����� ���� ������ �� ����������
        GameObject.Find("Jhon").transform.Find("Root").gameObject.SetActive(false);
        GameObject.FindGameObjectWithTag("Player").SetActive(false); //�� ����
        Enemies = GameObject.FindGameObjectsWithTag("Enemi");
        for(int i = 0; i < Enemies.Length; i++)
        {
            Enemies[i].SetActive(false);
        }
        player_collider = GetComponent<CapsuleCollider>();
        GetComponent<CapsuleCollider>().enabled = false; //���������� �����������
        Destroy(player_collider);
        Destroy(this); //�������� ������� ������� � �������
    }

    private void FixedUpdate()
    {


        //player_speed = Vector3_player_Direction * player_speed * Time.deltaTime;
        transform.Translate(Vector3_player_Direction * player_speed * 10 * Time.deltaTime);









        Debug.Log("Hello" + Time.fixedDeltaTime);//��� ����������� �������� �� �����������
    }

    // Update is called once per frame
    void Update()
    {

        Vector3_player_Direction.x = Input.GetAxis("Horizontal"); //y - �����
        Vector3_player_Direction.z = Input.GetAxis("Vertical");




        if (Input.GetButtonDown("Fire1")) //LKM
        {
            Instantiate(GameObject_Mine, Transform_Mine_Spawn.position, Transform_Mine_Spawn.rotation);
        }









        Debug.Log("Hello" + Time.deltaTime);

        timer += Time.deltaTime; //����� ���������� ���������
        if(timer > 5)
        {
            GameObject_Cube.SetActive(false); //���������� ������� �� �����
        }


        if (Input.GetKey(KeyCode.Q)) //��� ���������� ������ GetKeyUp GetKeyDown
            //GetMouseButtonDown(0)    0-LKM, 1-PKM, 2-koles,
        {
            Debug.Log("Pressed Q");
        } else if (Input.GetKeyUp(KeyCode.Q))
        {
            Debug.Log("Dont pressed Q");
        }

        moveHorizontal = Input.GetAxis("Horizontal");
        moveVertical = Input.GetAxis("Vertical");
        //GetAxisRaw - ���������� �������   
    }
}
