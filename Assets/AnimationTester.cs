using UnityEngine;

public class AnimationTester : MonoBehaviour
{

    public Animator animator;
    public string currentAnimation = "";
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        ChangeAnimation("Wiggle");
    }

    // Update is called once per frame
    float t = 0;

    void Update()
    {
        t+=Time.deltaTime;
        if(t>5){
            t = 0;
            ChangeAnimation("SpinAndBounce");
        }
    }

    public void ChangeAnimation(string newAnimation, float crossFade = 0.2f){
        if(currentAnimation != newAnimation){
            currentAnimation = newAnimation;
            //animator.CrossFade(newAnimation, crossFade);
            animator.Play(newAnimation);
        }
    }
}
