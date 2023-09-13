using UnityEngine;

namespace _01_Scripts
{
    public static class EventExtensions 
    {
        public static bool IsLeftMouseButtonDown(this Event evt)
        {
            return evt.type == EventType.MouseDown && evt.button == 0;
        }
        
        /// <summary>
        /// Returns the current vector with a new X
        /// </summary>
        public static Vector3 WithNewY(this Vector3 vector, float newY) => new Vector3(vector.x, newY, vector.z);

        /// <summary>
        /// Returns the current vector with a new X
        /// </summary>
        public static Vector2 WithNewX(this Vector2 vector, float newX) => new Vector2(newX, vector.y);
    }
}
