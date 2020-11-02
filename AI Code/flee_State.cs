/***************************
@Author William Halling
@Date   2 November 2020
@C# script for allowing the AI to roam the map in unity


 **************************/


using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.AI;


public class flee_State : MonoBehaviour
{
    public float minimum_Safe_Distance = 2.0f;
    public float sparkles_Movement_Speed = 3.0f;


    Transform sparkles_Friend_The_Player;
    /// NavMeshAgent  obj call allows AI to know the terrain it can move on
    NavMeshAgent sparkles_Walkable_Map;





//-------------------------------------------------------------------------------------------

    /**
     * @Function Start
     * @Purpose loads at intial frame so the variables are only set once during the whole play 
     * @return void
     */
    void Start()
    {
        sparkles_Friend_The_Player = our_Cube.current.Player_Cube.transform;
        sparkles_Walkable_Map = GetComponent<NavMeshAgent>();
    }




//-------------------------------------------------------------------------------------------

    /**
     * @Function Update
     * @Purpose calls the variables and statements once per frame
     * @return void
     */
    public void Update()
    {
        sparkles_Flee_From_Player_State();

    }




//-------------------------------------------------------------------------------------------


    void sparkles_Flee_From_Player_State()
    {
        float player_To_Close_To_Sparkles = Vector3.Distance(transform.position, sparkles_Friend_The_Player.transform.position);

        if (player_To_Close_To_Sparkles <= minimum_Safe_Distance)
        {
            Vector3 player_Movement_Plane_Movement = transform.position - sparkles_Friend_The_Player.position;
            Vector3 move_To_Safe_Observing_Coordinates = transform.position + player_Movement_Plane_Movement;
            sparkles_Walkable_Map.SetDestination(move_To_Safe_Observing_Coordinates);
        }
        look_At_Player_Friend();
    }





//-------------------------------------------------------------------------------------------


    void look_At_Player_Friend()
    {
        Vector3 watch_Player = (sparkles_Friend_The_Player.position - transform.position).normalized;
        Quaternion sparkles_Rotation = Quaternion.LookRotation(new Vector3(watch_Player.x, 0.0f, watch_Player.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, sparkles_Rotation, Time.deltaTime * sparkles_Movement_Speed);
    }






//-------------------------------------------------------------------------------------------


    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, minimum_Safe_Distance);
    }
}
