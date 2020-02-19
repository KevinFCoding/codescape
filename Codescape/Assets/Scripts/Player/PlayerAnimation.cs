using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{

    private Animator animator;

    private const string IDLE_ANIMATION_BOOL = "idle";
    private const string WALK_ANIMATION_BOOL = "walk";
    private const string RUN_ANIMATION_BOOL = "run";
    private const string RUNBACKWARDS_ANIMATION_BOOL = "runBackwards";
    private const string JUMP_ANIMATION_BOOL = "jump";

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponentInChildren<Animator>();
    }

    public void AnimateJump()
    {
        if(animator.GetCurrentAnimatorStateInfo(0).normalizedTime < 1.0f)
        {
            Animate(JUMP_ANIMATION_BOOL);
        }
        
    }

    public void AnimateRun()
    {
        Animate(RUN_ANIMATION_BOOL);
    }

    public void AnimateRunBackwards()
    {
        Animate(RUNBACKWARDS_ANIMATION_BOOL);
    }

    public void AnimateWalk()
    {
        Animate(WALK_ANIMATION_BOOL);
    }

    public void AnimateIdle()
    {
        Animate(IDLE_ANIMATION_BOOL);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetAxis("Jump") > 0)
        {
            Animate(JUMP_ANIMATION_BOOL);
        }
        else if (Input.GetAxis("Run") > 0 && Input.GetAxis("Vertical") > 0)
        {
            Animate(RUN_ANIMATION_BOOL);
        }
        else if (Input.GetAxis("Vertical") < 0)
        {
            Animate(RUNBACKWARDS_ANIMATION_BOOL);
        }
        else if (Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") > 0)
        {
            Animate(WALK_ANIMATION_BOOL);
        }
        else
        {
            Animate(IDLE_ANIMATION_BOOL);
        }
        
    }

    private void Animate(string boolName)
    {
        DisableOtherAnimations(animator, boolName);

        animator.SetBool(boolName, true);
    }

    private void DisableOtherAnimations(Animator animator, string animation)
    {
        foreach(AnimatorControllerParameter parameter in animator.parameters)
        {
            if(parameter.name != animation)
            {
                animator.SetBool(parameter.name, false);
            }
        }
    }
}
