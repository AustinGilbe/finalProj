/*
    This code creates a script named "Rotate" that can be attached to a GameObject in a Unity scene. When attached to a GameObject, this script will rotate the GameObject around its z-axis 
    at a constant speed.   
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    // The "SerializeField" attribute on the "speed" variable means that the variable can be modified in the Unity Inspector, but is still private and cannot be accessed from other scripts.
    [SerializeField] private float speed = 2f;

    /*
        In the Update() method, the "transform" variable refers to the Transform component of the GameObject to which this script is attached. The Rotate() method is called on this transform, 
        which rotates the GameObject around its z-axis by a specified amount.
        By default, Update() is called once per frame in Unity, which means that this script will continuously rotate the GameObject at a constant speed around its z-axis.
     */
    void Update()
    {
        /*
            The "Rotate()" method takes three arguments: the amount to rotate around the x-axis, the amount to rotate around the y-axis, and the amount to rotate around the z-axis. In this case, 
            the x and y rotation values are 0, which means that the rotation only occurs around the z-axis. The third argument of the Rotate() method is calculated by multiplying 360 (which represents 
            a full rotation in degrees) by the "speed" variable and by the "Time.deltaTime" value. Time.deltaTime is a Unity variable that represents the time since the last frame was rendered,
            which ensures that the rotation speed is consistent across different framerates.
        */
        transform.Rotate(0, 0, 360 * speed * Time.deltaTime);
    }
}
