using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Utilities
{
    /// <summary>
    /// Runs through all Components and returns the first IMapElement found
    /// </summary>
    /// <param name="gameObject"></param>
    /// <returns>Returns null if no IMapElement is Found</returns>
	public static IMapElement GetIMapElement(GameObject gameObject)
    {
        Component[] components = gameObject.GetComponents<Component>();
        for (int i = 0; i < components.Length; i++)
        {
            if(components[i] is IMapElement)
            {
                return (IMapElement)components[i];
            }
        }

        return null;
    }
}
