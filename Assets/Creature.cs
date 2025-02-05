using UnityEngine;

public class Creature : MonoBehaviour
{
    public float speed = 5f;

    public GameObject smokeBombPrefab;


    void Update(){
        // if(Input.GetKey(KeyCode.W)){
        //     Move(new Vector3(0, 0, 1));
        // }
        // if(Input.GetKey(KeyCode.S)){
        //     Move(new Vector3(0, 0, -1));
        // }
        // if(Input.GetKey(KeyCode.A)){
        //     Move(new Vector3(-1, 0, 0));
        // }
        // if(Input.GetKey(KeyCode.D)){
        //     Move(new Vector3(1, 0, 0));
        // }

        // if(Input.GetKeyDown(KeyCode.Space)){
        //     Instantiate(smokeBombPrefab, transform.position, Quaternion.identity);
        // }
    }

    public void Move(Vector3 direction){
        transform.position += direction * speed * Time.deltaTime;
        if(direction == Vector3.zero){
            return;
        }
        transform.LookAt(transform.position + direction);
    }

    public void PoofSmokeBomb(){
        Instantiate(smokeBombPrefab, transform.position, Quaternion.identity);
    }


}
