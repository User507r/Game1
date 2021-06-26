
using UnityEngine;

public class Camera : MonoBehaviour
{
    public GameObject player;
    Vector3 pos;
    void FixedUpdate()
    {
        pos = new Vector3(player.transform.position.x, player.transform.position.y, -10f);


        transform.position = Vector3.Lerp(transform.position, pos, Time.deltaTime * 1);



    }
}
