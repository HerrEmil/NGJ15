using UnityEngine;
using System.Collections;

public class BossBehaviour : MonoBehaviour
{

    private Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.transform.tag.Equals("Ball"))
        {
            bool hit = animator.GetBool("OnHit");
            if (hit != true)
            {
                animator.SetBool("OnHit", true);
                //Wait();
            }
        }
    }

    //IEnumerator Wait()
    //{
    //    yield return new WaitForSeconds(1);
    //    animator.SetBool("OnHit", false);
    //}
}
