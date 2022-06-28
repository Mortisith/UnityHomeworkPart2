using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lesson3 : MonoBehaviour
{

    [SerializeField] private int jumpForce = 2;


    Rigidbody rg;
    CharacterController controller;

    Vector3 GravityVelocity;
    [SerializeField] float gravityForce = 9.81f;


    [SerializeField] Vector2 Vector2D;
    [SerializeField] Vector3 Vector3D;
    [SerializeField] Transform v1;
    [SerializeField] Transform v2;
    [SerializeField] Vector3 v11;
    [SerializeField] Vector3 v22;
    [SerializeField] float distance;

    [SerializeField] int speeed = 2;

    [SerializeField] Transform enemy_cube;


    [SerializeField] Transform Target;


    [SerializeField] Vector3 angle1;


    private float angle;


    private bool isGrounded = true;

    /// <summary>
    /// Проверка пола, коллизии
    /// </summary>
    /// <param name="collision"></param>
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "Floor") isGrounded = true;
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.transform.tag == "Floor") isGrounded = false;
    }



    // Start is called before the first frame update
    void Start()
    {
        print(Vector2D.magnitude); //длина вектора
        print(Vector3D.magnitude);
        print(transform.position.magnitude);





        print(Vector3.Dot(v11, v22)); //скалярное произведдение
        print(Vector3.Cross(v11, v22)); //векторное произведение



        transform.rotation = Quaternion.identity; //сброс поворота




        rg = GetComponent<Rigidbody>(); // кэширование
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetButtonDown("Jump") && isGrounded) //для контроллера не нужна проверка и в условие controller.IsGrounded == true
        {
            GravityVelocity.y += Mathf.Sqrt(jumpForce * 3.0f * gravityForce);
        }







       // controller.Move(moveDerection + GravityVelocity * speeed * Time.deltaTime);  реализация движения через карактер контроллер

        


        if(GravityVelocity.y < 0)
        {
            GravityVelocity.y = 0;
        }
        GravityVelocity.y -= gravityForce*10 * Time.deltaTime; //гравитация


        distance = Vector3.Distance(v1.position, v2.position); // расстояние между 2 векторами
        distance = (v1.position - v2.position).magnitude;
        distance = Mathf.Sqrt((v1.position - v2.position).sqrMagnitude);
        distance = (v1.position - v2.position).sqrMagnitude; //отношение векторов




        transform.position += new Vector3(0, 0, Time.deltaTime * speeed); //движение по z вектору. без остановки
        transform.Translate(Vector3.forward * speeed * Time.deltaTime, Space.World); //на условный север, глобальный /Space.Self
        transform.Translate(0, 0, speeed * Time.deltaTime);




       // transform.Translate(Vector3.forward * speeed * Time.deltaTime, Camera.main.transform); // движение относительно камеры, ее вектора направления(куда смотрит)




        transform.position = Vector3.MoveTowards(transform.position, enemy_cube.position, Time.deltaTime * speeed); //движение к заданному оъекту: от какого к какому
        transform.position = Vector3.Lerp(transform.position, enemy_cube.position, Time.deltaTime * speeed); //передвижение за указанный промежуток времени, 3 аргумент, зависит от расстояния между объектами





    }

    private void FixedUpdate()
    {
        //rb.MovePosition(transform.position + Vector3_player_Direction * GravityVelocity* БЕЗ СКОРОСТИ- ее * на DIRECTION player_speed * 10 * Time.deltaTime);
    }

    private void LateUpdate()
    {
        Vector3 relativePos = Target.position - transform.position;
        transform.rotation = Quaternion.LookRotation(relativePos); //смотреть на объект
        angle = Quaternion.Angle(transform.rotation, Target.rotation); //вычисление угла
        transform.rotation = Quaternion.Euler(angle1); // поворот по вектору, перевод кватерниона в угол элера

        transform.rotation = Quaternion.Slerp(transform.rotation, enemy_cube.rotation, speeed * Time.deltaTime); //поворот взгляда за врагом
        transform.rotation = Quaternion.FromToRotation(Vector3.up, Vector3.right); //поворот от 1 позиции до 2

        transform.Rotate(Vector3.up * speeed * Time.deltaTime); //вращение относительно вектора

        transform.RotateAround(enemy_cube.position, Vector3.right, 10 * Time.deltaTime); //вращение вокруг объекта


        transform.LookAt(enemy_cube); //смотреть нна объект, передача трансформ в аргумент
    }




    private void OnTriggerEnter(Collider other)
    {
        if (other.tag != "Player")
        Destroy(other.gameObject); //удаление при входе в коллизию объекта, для взаимод нужно риджитбоди или карактер
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.tag != "Player")
        {
            print("Healing");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        
    }

}
