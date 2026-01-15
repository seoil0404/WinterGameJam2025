using UnityEngine;
using UnityEngine.EventSystems;

public class ChartScrollController : MonoBehaviour
{
    [SerializeField] private RectTransform content;
    [SerializeField] private float scrollSpeed;

    private float minY = 0;
    public float MaxY;

    private void Awake()
    {
        minY = content.anchoredPosition.y;
    }

    private void Update()
    {
        float wheel = Input.mouseScrollDelta.y;
        if (wheel == 0f) return;

        Vector2 pos = content.anchoredPosition;
        pos.y -= wheel * scrollSpeed * Time.deltaTime;
        pos.y = Mathf.Clamp(pos.y, minY, MaxY + minY);
        content.anchoredPosition = pos;
    }
}
