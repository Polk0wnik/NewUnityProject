 
using UnityEngine;

public class PersonAnimator : MonoBehaviour
{
     private Animator person_anim;

    private void Awake()
    {
        person_anim = transform.GetChild(0).GetComponent<Animator>();
    }
    public void MoveAnim(float x)
    {
        person_anim.SetFloat("VelocityX", Mathf.Abs(x));
    }
    public void JumpAnim(bool IsJumping)
    {
        person_anim.SetBool("isJump" , IsJumping);
    }
}
