using UnityEngine;

public class BoundarySetup : MonoBehaviour
{
    public GameObject background;
    public float boundaryThickness = 1f;

    void Start()
    {
        CreateBoundary("TopBoundary", new Vector2(0, background.transform.localScale.y / 2), new Vector2(background.transform.localScale.x, boundaryThickness));
        CreateBoundary("BottomBoundary", new Vector2(0, -background.transform.localScale.y / 2), new Vector2(background.transform.localScale.x, boundaryThickness));
        CreateBoundary("LeftBoundary", new Vector2(-background.transform.localScale.x / 2, 0), new Vector2(boundaryThickness, background.transform.localScale.y));
        CreateBoundary("RightBoundary", new Vector2(background.transform.localScale.x / 2, 0), new Vector2(boundaryThickness, background.transform.localScale.y));
    }

    void CreateBoundary(string name, Vector2 position, Vector2 size)
    {
        GameObject boundary = new GameObject(name);
        boundary.transform.parent = background.transform;
        boundary.transform.localPosition = position;

        BoxCollider2D collider = boundary.AddComponent<BoxCollider2D>();
        collider.size = size;
    }
}
