
using UnityEngine;

public class ZombieAnim : MonoBehaviour
{
    [SerializeField] private Animator zombie_anim;

    public void DeadAnim(bool dead)
    {
        zombie_anim.SetBool("isDead", dead);
    }
    public void AttackAnim(bool Attack)
    {
        zombie_anim.SetBool("isAttack", Attack);
    }
    public void MoveAnim(float x)
    {
        zombie_anim.SetFloat("VelocityX", x);
    }
}
