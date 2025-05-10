using UnityEngine;

public static class CameraUtility
{
    public static Rect GetRect(Camera cam)
    {
        float h = cam.orthographicSize;
        Vector2 center = cam.transform.position;
        Vector2 extent = new(h * cam.aspect, h);
        Rect cameraRect = new Rect(center - extent, extent * 2);
        return cameraRect;
    }
    public static Vector2 GetRandomPointInCamera(Camera cam)
    {
        Rect rect = GetRect(cam);
        return GetRandomPoint(rect);
    }
    public static Vector2 GetRandomPointInCamera(Camera cam, System.Random random)
    {
        Rect rect = GetRect(cam);
        return GetRandomPoint(rect, random);
    }

    static Vector2 GetRandomPoint(Rect rect)
    {
        float x = Random.Range(rect.xMin, rect.xMax);
        float y = Random.Range(rect.yMin, rect.yMax);
        return new(x, y);
    }
    static Vector2 GetRandomPoint(Rect rect,System.Random random)
    {
        float x = (float) random.NextDouble();
        float y = (float) random.NextDouble();

        x = Mathf.Lerp(rect.xMin, rect.xMax, x);
        y = Mathf.Lerp(rect.yMin, rect.yMax, y);

        return new(x, y);
    }
}
