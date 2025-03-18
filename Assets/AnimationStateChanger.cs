using UnityEngine;

public class AnimationStateChanger : MonoBehaviour
{

    public Animator animator;
    public string currentAnimation = "";
    public void ChangeAnimationState(string newAnimationState, float crossFade = 0.2f){
        //animator.Play(newAnimationState);
        if(currentAnimation == newAnimationState){
            return;
        }
        currentAnimation = newAnimationState;
        animator.CrossFade(newAnimationState, crossFade);
    }

}
