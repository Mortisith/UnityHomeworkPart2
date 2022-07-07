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
        float rad = degrees + Mathf.Deg2Rad; //���������� ������
        print(Mathf.Abs(-10)); //������ �����
        print(Mathf.Cos(Mathf.Deg2Rad * 60)); //������� 60 � ��������

        var value = Mathf.Repeat(Time.deltaTime, 3.0f); //���������� �� �����(�� 0�� 3)
        print(Mathf.Approximately(1.0f, 25.0f / 25.0f)); //��������� ����� � ��������� ������, ��������� ��������

        var value2 = Mathf.PingPong(Time.deltaTime, 3.0f); //�� ����������� � �������� � �������

        color = Mathf.CorrelatedColorTemperatureToRGB(Time.deltaTime * 100.0f); //����������� ��������� �����


        transform.position = new Vector3(Mathf.Clamp(Time.deltaTime, 1.0f, 5.0f),0,0);  //����������� ���������� ���������� �� � ��

        print(Mathf.Pow(5, 2)); //���������� � ������� (5 � ������� 2)
        print(Mathf.Lerp(10.0f, 30.0f, 0.5f));  //������ ����� ���������� �� ������� �� ����� 0.5. ����� ������ �������, ������� ������������
        print(Mathf.Max(1, 2, 3)); //�������� ������������ �� ����

        print(Random.Range(4.6f, 12.3f)); //��������� ����� �� 4 �� 11
        print(Random.value); //���������� ��������� ����� �� 0 �� 1
        print(Random.insideUnitSphere); //���������� ����� � �������� ��������� �����, ������ 3 - ����������


        Invoke("MyFunction", 5.0f); //����� ������� ����� 5 ������
        InvokeRepeating("MyFunction", 3.0f, 5.0f); //����� ������� ����� 3 ��� � ���������� ������ ������ 5���
        CancelInvoke("MyFunction"); //��������� �������



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

            yield return new WaitForFixedUpdate(); //��������� ���������� �������
            yield return new WaitForEndOfFrame(); //����� ���� ������� � ������
            yield return new WaitForSeconds(2.0f); //����� ������ 2 ���

            yield return waitTime;


            yield break; // ��������� ����������


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



        Physics.Raycast(transform.position, transform.forward); //������ ����, �����������. � ���� ������ ����� ���� = 1
        Physics.Raycast(transform.position, transform.forward, out hit, 5.0f); //� �������� ����� ����
        //Physics.Raycast(transform.position, transform.forward, out hit, 5.0f, QueryTriggerInteraction.UseGlobal + LayerMask); //��� ������� �� ������ �������


        RayOrigin = new Ray(transform.position, transform.forward);
        if(Physics.Raycast(RayOrigin, out hit, 5.0f))
        {
            print(hit.transform.name);
        }

    
    }



    private void FixedUpdate()
    {
        RaycastHit hit2;

        var startPos = transform.position + new Vector3(0f,1.0f,0f);//������� ������� ����
        var dir = (player.position - startPos) + new Vector3(0f, 1.0f, 0f);

        var rayCast = Physics.Raycast(startPos, dir, out hit, Mathf.Infinity, mask); //mathf - ���������� �����

        if (rayCast)
        {
            if (hit.collider.gameObject.CompareTag("Player"))
            {
                color = Color.green;
            }
        }
        Debug.DrawRay(startPos, dir, color); //������� ���
    }
}
