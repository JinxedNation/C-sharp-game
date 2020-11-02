/***************************
@Author William Halling
@Date   2 November 2020
@C# script for allowing the AI to roam the map in unity


 **************************/

using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using UnityEngine;

public class a_Player : MonoBehaviour
{
    public Rigidbody player_Cube_Body;
    public Vector3   player_XYZ_Plane_Movement;

    // Start is called before the first frame update
//-------------------------------------------------------------------------------------------


    void Start()
    {
        player_Cube_Body = this.GetComponent<Rigidbody>();
    }

//-------------------------------------------------------------------------------------------


    // Update is called once per frame
    void Update()
    {
        ///controlls movement along the x plane
        float player_X_Plane_Location = Input.GetAxis("Horizontal");

        ///controlls movement along z plane
        float player_Z_Plane_Location = Input.GetAxis("Vertical");


        player_XYZ_Plane_Movement = new Vector3(player_Z_Plane_Location, 0.0f, player_X_Plane_Location);

        ///apply rotation to the player
        Vector3 move_Camera_View     = new Vector3(player_Z_Plane_Location, 0, player_X_Plane_Location);

    }

//-------------------------------------------------------------------------------------------


    void FixedUpdate()
    {
        cube_Location(player_XYZ_Plane_Movement);
    }

    void cube_Location(Vector3 players_current_XYZ_Movement_Direction)
    {
        float players_Movement_Speed = 10.0f;
        player_Cube_Body.MovePosition(transform.position + (players_current_XYZ_Movement_Direction * players_Movement_Speed * Time.deltaTime));
    }

}