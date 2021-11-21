using UnityEngine;

public static class MovementUtility
{
    public static Vector2 GetVelocityDirectionVector(Vector2 v)
    {
        var x = v.x > 0 ? +1 : -1;
        var y = v.y > 0 ? +1 : -1;

        return new Vector2(x, y);
    }
}