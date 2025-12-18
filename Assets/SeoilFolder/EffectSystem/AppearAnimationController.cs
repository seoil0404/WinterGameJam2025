using DG.Tweening;
using UnityEngine;

public class AppearAnimationController : MonoBehaviour
{
    [SerializeField] private float duration = .5f;
    private Vector3 startScale = Vector3.zero;

    private bool isStopped = false;

    private void Start()
    {
        if(isStopped) return;

        startScale = transform.localScale;
        transform.localScale = Vector3.zero;
        transform.DOScale(startScale, duration);
    }

    public void StopAnimation()
    {
        isStopped = true;
        transform.DOKill();
        
        if(startScale != Vector3.zero)
            transform.localScale = startScale;
    }
}
