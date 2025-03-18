using UnityEngine;
using System.Collections;

public class TrainingTarget : MonoBehaviour
{
    public Vector3 startPosition;

    public Vector3 endPosition;

    public float riseTime = 1f;
    public float riseAmount = 2f;

    public Renderer myRenderer;

    public Color canSeeColor;
    public Color noCanSeeColor;
    public Color hitColor;
    bool hit = false;

    void Start(){

        Relocate();
    }

    IEnumerator RiseRoutine(){
        float t = 0;
        startPosition = transform.position;
        endPosition = transform.position + new Vector3(0, riseAmount, 0);
        while (t < riseTime){
            t += Time.deltaTime;
            transform.position = Vector3.Lerp(startPosition,endPosition,t/riseTime);
            yield return null;
        }
        transform.position = endPosition;
        yield return null;
    }

    IEnumerator FallRoutine(){
        float t = 0;
        startPosition = transform.position;
        endPosition = transform.position + new Vector3(0, -riseAmount, 0);
        while (t < riseTime)
        {
            t += Time.deltaTime;
            transform.position = Vector3.Lerp(startPosition, endPosition, t / riseTime);
            yield return null;
        }
        transform.position = endPosition;
        yield return null;
    }

    public void CanSee(){
        if(hit){
            return;
        }
        myRenderer.material.color = canSeeColor;
    }

    public void NoCanSee(){
        if(hit){
            return;
        }
        myRenderer.material.color = noCanSeeColor;
    }


    public void SetAsHit(){
        hit = true;
        myRenderer.material.color = hitColor;
    }

    public void Relocate(){
        hit = false;

        StartCoroutine(RelocateRoutine());
    }



    IEnumerator RelocateRoutine(){
        Vector3 newPosition = new Vector3(Random.Range(-14,14),-2,Random.Range(-14,14));

        StartCoroutine(FallRoutine());
        yield return new WaitForSeconds(riseTime);
        transform.position = newPosition;
        StartCoroutine(RiseRoutine());
        yield return null;
    }
}
