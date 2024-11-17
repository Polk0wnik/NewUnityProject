
using UnityEngine;

public class GunRotation : MonoBehaviour
{
    private Transform transformGun;
    private Camera myCamera;
    public float speedRotate = 6f;
    private float inputX;

    private void Start()
    {
        transformGun = GetComponent<Transform>();
        myCamera = FindObjectOfType<Camera>();
    }

    // Update is called once per frame
    private void Update()
    {
        GunRotat();
    }
    public void UpdateDirectionGun(float x)
    {
        inputX = x; 
    }
    private void GunRotat()
    { 
        // �������� ������� ������� ����� �� ������ � ������� ������
        // � ���������� � ����� ���������� c ����� Vector3
        Vector3 mousePos = myCamera.ScreenToWorldPoint(Input.mousePosition);

         // ��������� ������� ������ � ����� ���������� � ����� Vector3 ��� ���������� ������
        Vector3 gunPos = transformGun.position;

        // ������� ���� �� ����� � � ����� � � ��������� �� � �������
        float angle = Mathf.Atan2((mousePos.y - gunPos.y), (mousePos.x - gunPos.x)) * Mathf.Rad2Deg;

        angle += inputX > 0 ? angle : (inputX < 0 ? -angle : angle);
         
        // ������������� ������� �� ��� Z 
        Quaternion rotateGun = Quaternion.Euler(new Vector3(0,0,angle));

        //������ ������� ������� �� ������������� ������ �� ����� ���� A � ����� ���� B � �������� �� �������� ��������
        transformGun.rotation = Quaternion.Slerp(transformGun.rotation, rotateGun,speedRotate * Time.deltaTime);
    }
 }
