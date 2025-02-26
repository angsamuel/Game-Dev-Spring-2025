using UnityEngine;

public class Kunai : MonoBehaviour
{


    public TrainingTarget target;
    public Transform playerTransform;

    void Update(){
        transform.position = playerTransform.position;
        transform.LookAt(target.transform);

        //check for line of sight
        RaycastHit hit;
        if(Physics.Linecast(transform.position, target.transform.position, out hit, LayerMask.GetMask("Terrain"))){
            target.NoCanSee();
        }else{
            target.CanSee();
        }

    }
}
