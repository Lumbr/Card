using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace VladsUsefulScripts
{
    public static class Finders
    {
        public static bool TryFindObjectOfType<T>(out T val) where T : Object
        {
            if (Object.FindObjectOfType<T>() != null)
            {
                val = Object.FindObjectOfType<T>();
                return true;
            }
            else
            {
                val = null;
                return false;
            }

        }
        public static bool TryFindObjectsOfType<T>(out T[] val) where T : Object
        {
            if (Object.FindObjectsOfType<T>() != null)
            {
                val = Object.FindObjectsOfType<T>();
                return true;
            }
            else
            {
                val = null;
                return false;
            }

        }
    } 
    public static class Clampers
    {
        public static void MoveClamp(ref float velocity, float axis, float speed, float maxSpeedMult)
        {
            velocity =  Mathf.Clamp(velocity + (axis * speed), -speed * maxSpeedMult, speed * maxSpeedMult);
        }
        public static void JustClampItAll(ref Vector2 velocity, float axis, float speed, float maxSpeedMult)
        {
            velocity = new Vector2(Mathf.Clamp(velocity.x + (Input.GetAxisRaw("Horizontal") * speed), -speed * maxSpeedMult, speed * maxSpeedMult), velocity.y);
        }
        public static void JustClampItAll(ref Vector3 velocity, float xAxis, float yAxis, float speed, float maxSpeedMult)
        {
            velocity = new Vector3(Mathf.Clamp(velocity.x + (xAxis * speed), -speed * maxSpeedMult, speed * maxSpeedMult), velocity.y, Mathf.Clamp(velocity.x + (yAxis * speed), -speed * maxSpeedMult, speed * maxSpeedMult));
        }
    }
}