using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
    [SerializeField]
    private Slider Hpbar;

    private float maxHp = 100;
    private float CurHp = 100;

    void Start()
    {
        Hpbar.value=(float)CurHp/(float)maxHp;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            CurHp -= 10;
        }
            HandleHP();
    }

    private void HandleHP()
    {
        Hpbar.value = (float)CurHp / (float)maxHp;
    }
    }
    