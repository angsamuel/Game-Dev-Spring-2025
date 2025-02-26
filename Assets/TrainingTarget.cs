using UnityEngine;
using System.Collections;

public class TrainingTarget : MonoBehaviour
{
    public Vector3 startPosition;

    public Vector3 endPosition;

    public float riseTime = 1f;

    public Renderer myRenderer;

    public Color canSeeColor;
    public Color noCanSeeColor;

    void Start(){

        StartCoroutine(RiseRoutine());
    }

    IEnumerator RiseRoutine(){
        float t = 0;
        while(t < riseTime){
            t += Time.deltaTime;
            transform.position = Vector3.Lerp(startPosition,endPosition,t/riseTime);
            yield return null;
        }
        transform.position = endPosition;
        yield return null;
    }

    public void CanSee(){

        myRenderer.material.color = canSeeColor;
    }

    public void NoCanSee(){

        myRenderer.material.color = noCanSeeColor;
    }
}
