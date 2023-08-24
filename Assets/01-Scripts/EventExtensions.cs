using UnityEngine;

namespace _01_Scripts
{
    public static class EventExtensions 
    {
        public static bool IsLeftMouseButtonDown(this Event evt)
        {
            return evt.type == EventType.MouseDown && evt.button == 0;
        }
    }
}
