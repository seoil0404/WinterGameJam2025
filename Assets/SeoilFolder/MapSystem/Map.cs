using UnityEngine;

[RequireComponent(typeof(Renderer))]
public class Map : MonoBehaviour
{
    private Renderer mapRenderer;

    public float Length
    {
        get
        {
            if(mapRenderer == null)
                mapRenderer = GetComponent<Renderer>();

            return mapRenderer.bounds.size.z;
        }
    }
}
