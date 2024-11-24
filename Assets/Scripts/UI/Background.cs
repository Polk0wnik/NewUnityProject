using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Background : MonoBehaviour
{
    [SerializeField] private Transform transPersone;
    private Renderer renderBG;
    private Transform transBG;
    public float speedRotate = 2f;
    private void Awake()
    {
        renderBG = GetComponent<Renderer>();
        transBG = GetComponent<Transform>();
    }
    private void RotateBG()
    {
        float horizontal = Input.GetAxis("Horizontal");
        Vector3 inputAxis = new Vector3(horizontal,0,0);
        float x = inputAxis.x * speedRotate * Time.deltaTime;
        renderBG.material.mainTextureOffset += new Vector2(x,0);
    }
    private void FollowBG()
    {
        transBG.position = Vector2.Lerp(transBG.position, transPersone.position, Time.deltaTime);
        transBG.position = new Vector3(transBG.position.x, transBG.position.y, 0);
    }
    private void Update()
    {
        RotateBG();
        FollowBG();
    }
}
