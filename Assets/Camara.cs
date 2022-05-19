using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camara : MonoBehaviour
{
    public Transform target;
    public Vector3 offset;
    //vectores para limitar la posicion de la camara en los ejes
    public Vector2 limitX;
    public Vector2 limitY;

    public float interpolationRatio;

    // Update is called once per frame
    void FixedUpdate()
    {
        //posicion deseada de la camara
        Vector3 desiredPosition = target.position + offset;
        //limitamos el movimiento en el eje horizontal
        float limitedXPosition = Mathf.Clamp(desiredPosition.x, limitX.x, limitX.y);
        //limitamos el movimiento en el eje vertical
        float limitedYPosition = Mathf.Clamp(desiredPosition.y, limitY.x, limitY.y);
        //construimos un VECTOR3 con los limites que hemos creado
        Vector3 limitedPosition = new Vector3 (limitedXPosition, limitedYPosition, desiredPosition.z);
        Vector3 lerpedPosition = Vector3.Lerp(transform.position, limitedPosition, interpolationRatio);

        transform.position = lerpedPosition;

    }
}