
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
        // Получаем позицию курсора мышки на экране с помошью камеры
        // и сохранаяем в новую переменную c типом Vector3
        Vector3 mousePos = myCamera.ScreenToWorldPoint(Input.mousePosition);

         // сохраняем позицию ствола в новую переменную с типом Vector3 для сокращения текста
        Vector3 gunPos = transformGun.position;

        // считаем угол от точки А к точке Б и переводим их в радианы
        float angle = Mathf.Atan2((mousePos.y - gunPos.y), (mousePos.x - gunPos.x)) * Mathf.Rad2Deg;

        angle += inputX > 0 ? angle : (inputX < 0 ? -angle : angle);
         
        // устанавливаем поворот по оси Z 
        Quaternion rotateGun = Quaternion.Euler(new Vector3(0,0,angle));

        //делаем плавный поворот по установленным данным от точки угла A к точке угла B и умножаем на скорость поворота
        transformGun.rotation = Quaternion.Slerp(transformGun.rotation, rotateGun,speedRotate * Time.deltaTime);
    }
 }
