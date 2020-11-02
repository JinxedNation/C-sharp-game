/***************************
@Author William Halling
@Date   2 November 2020
@C# script for allowing the AI to roam the map in unity


 **************************/


using UnityEngine;

//-------------------------------------------------------------------------------------------


public class Camera : MonoBehaviour
{
    ///player cube 
    public Transform player_Cube_target;


    /// allows manipulation of the camera follow speed
    public float player_Camera_Speed = 0.50f;


    /// allows the offset distance for the camera from player object
    public Vector3 xyz_Plane_Offset_Distance;





//-------------------------------------------------------------------------------------------


        /**
         * Method FixedUpdate
         * 
         * Purpose: 
         *      makes the camera follow the player at each frame
         *      flowing camera allows the camera to mooth in a fluid motion instead of the view being jumpy
         *      
         * @return void
         */
    void FixedUpdate ()
    {
            /// gets the camera x y z location at each frame
        Vector3 camera_XYZ_Preffered_XYZ_Location = player_Cube_target.position + xyz_Plane_Offset_Distance;

            /// smooth_Camera_Flow follows the camera in a smooth motion from point to destination point
        Vector3 flowing_Camera = Vector3.Lerp(transform.position, camera_XYZ_Preffered_XYZ_Location, player_Camera_Speed * Time.deltaTime);


        transform.position = flowing_Camera;
        transform.LookAt(player_Cube_target);
    }
}