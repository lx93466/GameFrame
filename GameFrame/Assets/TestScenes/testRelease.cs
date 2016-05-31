using UnityEngine;
using System.Collections;

public class testRelease : MonoBehaviour
{

    public Camera m_mainCamera;
    int speed = 15;
    float angle = 0;
    float distance = 0;
    // Use this for initialization
    void Start()
    {
        distance = Vector3.Distance(m_mainCamera.transform.position, transform.position);
    }

    // Update is called once per frame
    void Update()
    {
        //angle += Time.deltaTime * speed;
        //float x = distance * Mathf.Sin(angle) + transform.position.x;
        //float z = distance * Mathf.Cos(angle) + transform.position.z;
        //float y = m_mainCamera.transform.position.y;
        //Vector3 v3 = new Vector3(x, y, z);
        //m_mainCamera.transform.position = v3;
        //m_mainCamera.transform.LookAt(transform.position);
        m_mainCamera.transform.RotateAround(transform.position, Vector3.up, Time.deltaTime * speed);
    }

    void OnDestroy()
    {
        Debug.Log("OnDestroy");
    }

}