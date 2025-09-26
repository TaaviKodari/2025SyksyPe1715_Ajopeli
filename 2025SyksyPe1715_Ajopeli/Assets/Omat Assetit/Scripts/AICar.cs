using UnityEngine;

public class AICar : MonoBehaviour
{
    public Transform[] waypoints;
    public float speed = 10f;

    // Update is called once per frame
    void Update()
    {
        //Liikutaan eteenpäin
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }
}
