using UnityEngine;

public class DogusAI : MonoBehaviour
{

    public Creature myCreature;
    public Creature followCreature;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        MoveTowardsFollowCreature();
    }

    void MoveTowardsFollowCreature(){
        if(Vector3.Distance(followCreature.transform.position, myCreature.transform.position) < 5){
            return;
        }


        Vector3 direction = followCreature.transform.position - myCreature.transform.position;
         direction.y = 0;
         direction.Normalize();
         myCreature.MoveWithCC(direction);
    }
}
