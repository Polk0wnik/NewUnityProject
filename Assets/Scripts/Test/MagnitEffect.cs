 
using UnityEngine;

public class MagnitEffect : MonoBehaviour
{
    [SerializeField] private Transform targetMagnit;
    [SerializeField] private float maxDistance = 10f;
    [SerializeField] private float veclocity = 15f;

    public void FixedUpdate()
    {
        float distance = Vector3.Distance(transform.position, targetMagnit.position);
        if(distance < maxDistance)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetMagnit.position, veclocity * Time.deltaTime);
        }
    }
}
