/*
    Declaring the required namespaces for the script. The System.Collections Namespace contains interfaces and classes that define various collections of objects, such as lists, queues, hash-tables, dictionaries, etc.
    The System.Collection.Generic Namespace contains interfaces and classes that define generic collections that allow users to create strongly typed collections that provide better type safety and performance than 
    non-generic strongly typed collections. UnityEngine is a namespace in the Unity game engine that provides a set of classes and functions for creating and managing game objects, scenes, physics, audio, user interfaces, 
    and more. The UnityEngine namespace contains many commonly used classes, such as GameObject, Transform, Vector3, Collider2D, and AudioSource. These classes provide functionality for creating and manipulating 
    objects in a 2D game world.
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
    The CameraController script is attached to a game object in the scene that represents the camera. The CameraController script is responsible for controlling the position of the camera based on the position of another game 
    object (in this case, the player game object). When the Update() method is called every frame, the position of the camera (transform.position) is set to the position of the player game object, with the z-coordinate of the 
    camera's position unchanged. This effectively makes the camera follow the player horizontally and vertically, but not in-depth (which would cause the camera to zoom in and out).

    The [SerializeField] attribute is used to expose a private field's value in the Inspector window, so that we can edit it like a public field, but without making it actually public. 

    In Unity, the Update() method is a built-in method that is called every frame, by default. This means that any code we put inside the Update() method will be executed once per frame, as long as the script component is enabled 
    and attached to an active game object in the scene. The Update() method is part of Unity's MonoBehaviour class, which is the base class for all Unity scripts that can be attached to game objects in the scene. 
*/
public class CameraController2 : MonoBehaviour
{
    [SerializeField] private Transform player;


    // Update is called once per frame
    private void Update()
    {
        transform.position = new Vector3(player.position.x, player.position.y, transform.position.z);
    }
}
