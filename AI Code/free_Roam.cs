/***************************
@Author William Halling
@Date   2 November 2020
@C# script for allowing the AI to roam the map in unity


 **************************/


using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class free_Roam : MonoBehaviour
{
    /// sparkles Navigation Variables 
    public float sparkles_Movement_Speed;

        /// sparkles_Recovery_Period = waiting time between movement
    private float sparkles_Recovery_Period;

        /// sparkles_Rest_And_Recovery_Time_Remaining - countdown before next move
    public float sparkles_Rest_And_Recovery_Time_Remaing;

        /// stores the range of travel locations 
    private int travel_To_A_Random_Location;
    
        /// contains maximum number of random travel locations
    private int maximum_Random_Travel_Locations;


    /// array stores the random free roam locations for Sparkles
    public Transform[] sparkles_Travel_Locations;
   


//-------------------------------------------------------------------------------------------


    // Start is called before the first frame update
    void Start()
    {
        sparkles_Recovery_Period        = sparkles_Rest_And_Recovery_Time_Remaing;
        maximum_Random_Travel_Locations = sparkles_Travel_Locations.Length;
        travel_To_A_Random_Location     = Random.Range(0, maximum_Random_Travel_Locations);
    }



//------------------------------------------------------------------------------------------

    // Update is called once per frame
    void Update()
    {
        free_Roam_State();
    }

    void free_Roam_State()
    {
        transform.position = Vector3.MoveTowards(transform.position, sparkles_Travel_Locations[travel_To_A_Random_Location].position, sparkles_Movement_Speed * Time.deltaTime);


        if ((Vector3.Distance(transform.position, sparkles_Travel_Locations[travel_To_A_Random_Location].position) < 0.5f) && (sparkles_Recovery_Period <= 0))
        {
            travel_To_A_Random_Location = Random.Range(0, maximum_Random_Travel_Locations);
            sparkles_Recovery_Period = sparkles_Rest_And_Recovery_Time_Remaing;
        }

        else
        {
            sparkles_Recovery_Period -= Time.deltaTime;
        }
    }
}