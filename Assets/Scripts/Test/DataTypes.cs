
using UnityEngine;

public class DataTypes : MonoBehaviour
{
    public string otherText = "MyText";
    public float number = 17.36f;
    public int count = 25;
    public bool isHas = false;


    public Transform transformObject;
    private Transform otherTransform; // null references component
    public Quaternion quaternion;
    public Vector3 vectorObject;
    public float x = 3;
    public float y = 3;
    public float z = 3;

    public FunctionTest test;

    private void Awake()
    {
        vectorObject = new Vector3(x, y, z);
        transform.position = vectorObject;
        transform.localScale = vectorObject;
        transform.rotation = Quaternion.Euler(vectorObject.x, vectorObject.y, vectorObject.z);
        vectorObject = transform.up;// это будет означать локальное направление в вверх
        vectorObject = transform.right;  
    }
    private void OnEnable()
    {
        test.AddForceCastom(vectorObject);
    }
    private void Start()
    { 
    }
    private void Update()
    {
        
    }
    private void LateUpdate()
    {
        
    }
}
