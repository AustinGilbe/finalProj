using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class follow2objects : MonoBehaviour
{
    [SerializeField] private Transform o1;
    [SerializeField] private Transform o2;

    public float speed;

    private Vector2 pos;
    private Vector2 vel;

    // Update is called once per frame
    void Update()
    {
        pos = (o1.position + o2.position) * 0.5f;
        transform.position = Vector2.SmoothDamp(transform.position, pos, ref vel, speed);
        transform.position = new Vector3(transform.position.x, transform.position.y, -10);
    }
}
