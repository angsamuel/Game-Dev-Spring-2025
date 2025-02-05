using UnityEngine;
using System.Collections;

public class SmokeBomb : MonoBehaviour
{

    public float maxScale = 3f;
    float currentScale = 0f;
    public float scaleSpeed = 1f;

    bool growing = true;

    void Start()
    {
        transform.localScale = Vector3.zero;
        StartCoroutine(SmokePoofRoutine());
    }

    void Update()
    {
        // if(growing){
        //     if(currentScale <= maxScale){
        //         currentScale += scaleSpeed * Time.deltaTime;
        //         transform.localScale = Vector3.one * currentScale;
        //     }else{
        //         growing = false;
        //     }
        // }


        // if(!growing){
        //     if(currentScale >= 0f){
        //         currentScale -= scaleSpeed * Time.deltaTime;
        //         transform.localScale = Vector3.one * currentScale;
        //     }else{
        //         Destroy(gameObject);
        //     }
        // }
    }


    IEnumerator SmokePoofRoutine(){
        while(currentScale <= maxScale){
            currentScale += scaleSpeed * Time.deltaTime;
            transform.localScale = Vector3.one * currentScale;
            yield return null;
        }

        yield return new WaitForSeconds(1f);

        while(currentScale >= 0f){
            currentScale -= scaleSpeed * Time.deltaTime;
            transform.localScale = Vector3.one * currentScale;
            yield return null;
        }

        Destroy(gameObject);
    }




}