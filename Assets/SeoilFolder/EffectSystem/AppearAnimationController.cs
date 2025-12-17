using DG.Tweening;
using UnityEngine;

public class AppearAnimationController : MonoBehaviour
{
    [SerializeField] private float duration = .5f;
    private Vector3 startScale;

    private void Start()
    {
        startScale = transform.localScale;
        transform.localScale = Vector3.zero;
        transform.DOScale(startScale, duration);
    }
}
