using UnityEngine;
using System.Collections;

public static class MousePick {


    /// <summary>
    /// Obtains a game object that is under the mouse pointer, or null if none found.
    /// </summary>
    /// <returns>null if no object under mouse position or the game object under the mouse</returns>
    public static GameObject GetObject()
    {
        GameObject returnObject = null;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if(Physics.Raycast(ray, out hit, 1000.0f))
        {
            returnObject = hit.transform.gameObject;
        }
        return returnObject;
    }

    /// <summary>
    /// Obtains a game object that is under the mouse pointer, or null if none found.
    /// </summary>
    /// <param name="hit">Ray cast info</param>
    /// <returns>null if no object under mouse position or the game object under the mouse</returns>
    public static GameObject GetObject(out RaycastHit hit)
    {
        GameObject returnObject = null;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit, 1000.0f))
        {
            returnObject = hit.transform.gameObject;
        }
        return returnObject;
    }

    /// <summary>
    /// Obtains a game object that is under a touched screen position, or null if none found.
    /// </summary>
    /// <returns>null if no object under the touch point, otherwise a game object</returns>
    public static GameObject GetObjectTouch()
    {
        GameObject returnObject = null;
        Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, 1000.0f))
        {
            returnObject = hit.transform.gameObject;
        }
        return returnObject;
    }

}
