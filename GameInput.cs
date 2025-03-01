using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameInput : MonoBehaviour
{
    

    public Vector2 getmovement()
    {
        
        Vector2 inputvector = new Vector2(0f, 0f);
        if (Input.GetKey(KeyCode.W))
        {
            inputvector.y += 1f;
        }
        else if (Input.GetKey(KeyCode.S))
        {
            inputvector.y -= 1f;
        }
        else if (Input.GetKey(KeyCode.A))
        {
            inputvector.x -= 1f;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            inputvector.x += 1f;
        }

        inputvector = inputvector.normalized;
        return inputvector;
    }
}
