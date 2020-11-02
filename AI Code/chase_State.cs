/***************************
@Author William Halling
@Date   2 November 2020
@C# script for allowing the AI to roam the map in unity

 **************************/

using System;
using System.Collections;
using UnityEngine;
using UnityEngine.AI;
public class chase_State : MonoBehaviour
{

    public float sparkles_Radar_Range = 15.0f;
    public float sparkles_Speed = 5.0f;

    run_Away_State temporary_Run_Away;

    Transform sparkles_Friend_The_Player_Cube;
    NavMeshAgent sparkles_Walkable_Map;

//-------------------------------------------------------------------------------------------------------

    void Start()
    {
        sparkles_Friend_The_Player_Cube = our_Cube.current.Player_Cube.transform;
        sparkles_Walkable_Map = GetComponent<NavMeshAgent>();
    }





//-------------------------------------------------------------------------------------------------------

    void Update()
    {
        chase_Friendly_Player_State();
    }





//-------------------------------------------------------------------------------------------------------

    void chase_Friendly_Player_State()
    {
        float sparkles_Distance_From_Player = Vector3.Distance(sparkles_Friend_The_Player_Cube.position, transform.position);

        if (sparkles_Distance_From_Player <= sparkles_Radar_Range)
        {
            sparkles_Walkable_Map.SetDestination(sparkles_Friend_The_Player_Cube.position);
        }
        look_At_Player_Friend();
    }





//-------------------------------------------------------------------------------------------------------

    void look_At_Player_Friend()
    {
        Vector3 sparkles_Distance_To_Friend = (sparkles_Friend_The_Player_Cube.position - transform.position).normalized;
        Quaternion sparkles_Rotation = Quaternion.LookRotation(new Vector3(sparkles_Distance_To_Friend.x, 0.0f, sparkles_Distance_To_Friend.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, sparkles_Rotation, Time.deltaTime * sparkles_Speed);
    }





//-------------------------------------------------------------------------------------------------------

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, sparkles_Radar_Range);
    }
} 