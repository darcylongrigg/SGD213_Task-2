using UnityEngine;

public static class Casting
{
    private static LayerMask layerMask = LayerMask.GetMask("Default");


    public static bool Raycast(this Rigidbody2D rigidbody, Vector2 direction)
    {
        if (rigidbody.bodyType == RigidbodyType2D.Kinematic)
        {
            return false;
        }

        Vector2 size = new Vector2(0.25f, 0.25f);
        float distance = 0.4f;
        float angle = 0f;

        RaycastHit2D hit = Physics2D.BoxCast(rigidbody.position, size, angle, direction, distance, layerMask);
        return hit.collider != null && hit.rigidbody != rigidbody;
    }


    public static bool DotTest(this Transform transform, Transform other, Vector2 testDirection)
    {
        Vector2 direction = other.position - transform.position;
        return Vector2.Dot(direction, testDirection) > 0.25f;
    }

}
