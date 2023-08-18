using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class EventExtensions 
{
    public static bool IsLeftMouseButtonDown(this Event evt)
    {
        return evt.type == EventType.MouseDown && evt.button == 0;
    }
}
