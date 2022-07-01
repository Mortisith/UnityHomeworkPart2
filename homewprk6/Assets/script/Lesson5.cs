using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Lesson5 : MonoBehaviour
{
    private float degrees = 30.0f;
    public Color color;

    public Material material;
    private WaitForSeconds waitTime = new WaitForSeconds(0.1f);

    RaycastHit hit;
    Ray RayOrigin;


    public LayerMask mask;
    public Transform player;


    public UnityEvent OnStart;

    void Start()
    {
        float rad = degrees + Mathf.Deg2Rad; //вычисление радиан
        print(Mathf.Abs(-10)); //модуль числа
        print(Mathf.Cos(Mathf.Deg2Rad * 60)); //косинус 60 в радианах

        var value = Mathf.Repeat(Time.deltaTime, 3.0f); //повторение до числа(от 0до 3)
        print(Mathf.Approximately(1.0f, 25.0f / 25.0f)); //сравнение чисел с плавающей точкой, примерное значение

        var value2 = Mathf.PingPong(Time.deltaTime, 3.0f); //от наименьшего к большему и обратно

        color = Mathf.CorrelatedColorTemperatureToRGB(Time.deltaTime * 100.0f); //постепенное изменение цвета


        transform.position = new Vector3(Mathf.Clamp(Time.deltaTime, 1.0f, 5.0f),0,0);  //ограничение переменной значениями от и до

        print(Mathf.Pow(5, 2)); //возведение в степень (5 в степени 2)
        print(Mathf.Lerp(10.0f, 30.0f, 0.5f));  //первое число стремиться ко второму за время 0.5. принт именно времени, которое понадобилось
        print(Mathf.Max(1, 2, 3)); //печатает максимальное из ряда

        print(Random.Range(4.6f, 12.3f)); //случайное число от 4 до 11
        print(Random.value); //возвращает случайное число от 0 до 1
        print(Random.insideUnitSphere); //возвращает число в пределах единичной сферы, вектор 3 - координаты


        Invoke("MyFunction", 5.0f); //вызов функции через 5 секунд
        InvokeRepeating("MyFunction", 3.0f, 5.0f); //вызов функции через 3 сек и повторение вызова каждые 5сек
        CancelInvoke("MyFunction"); //остановка функции



        material = GetComponent<MeshRenderer>().material;
        StartCoroutine(ChangeColor(color));
        StopAllCoroutines();
        StopCoroutine(ChangeColor(color));



        if(OnStart == null)
        {
            OnStart = new UnityEvent();

            OnStart.Invoke();
        }

    }



    IEnumerator ChangeColor(Color newColor)
    {
        while(material.color != newColor)
        {
            material.color = Color.Lerp(material.color, newColor, Time.deltaTime);
            yield return null;

            yield return new WaitForFixedUpdate(); //дождаться следующего фиксапд
            yield return new WaitForEndOfFrame(); //после след латеапд и рендер
            yield return new WaitForSeconds(2.0f); //через каждые 2 сек

            yield return waitTime;


            yield break; // закончить выполнение


        }
    }


    private void MyFunction()
    {
        print("Function"); 
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            StopCoroutine(ChangeColor(color));
        }



        Physics.Raycast(transform.position, transform.forward); //начало луча, направление. В этом случае длина луча = 1
        Physics.Raycast(transform.position, transform.forward, out hit, 5.0f); //с заданием длины луча
        //Physics.Raycast(transform.position, transform.forward, out hit, 5.0f, QueryTriggerInteraction.UseGlobal + LayerMask); //для реакции на провер объекты


        RayOrigin = new Ray(transform.position, transform.forward);
        if(Physics.Raycast(RayOrigin, out hit, 5.0f))
        {
            print(hit.transform.name);
        }

    
    }



    private void FixedUpdate()
    {
        RaycastHit hit2;

        var startPos = transform.position + new Vector3(0f,1.0f,0f);//поднять позицию луча
        var dir = (player.position - startPos) + new Vector3(0f, 1.0f, 0f);

        var rayCast = Physics.Raycast(startPos, dir, out hit, Mathf.Infinity, mask); //mathf - бесконечна длина

        if (rayCast)
        {
            if (hit.collider.gameObject.CompareTag("Player"))
            {
                color = Color.green;
            }
        }
        Debug.DrawRay(startPos, dir, color); //видимый луч
    }
}
