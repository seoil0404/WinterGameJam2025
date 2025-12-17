using UnityEngine;
using UnityEngine.InputSystem;

public class CamObj : MonoBehaviour
{
    public static CamObj instance;
    private Player player;
    private float mouseX = 0;
    private float mouseY = 0;

    private void Start()
    {
        player = Player.Instance;
    }
    private void Update()
    {
        transform.position = player.gameObject.transform.position + new Vector3 (0, 1.05f, 0);
        Rotate();
    }
    private void Rotate()
    {
        //마우스 감도
        float mousesensitivity = 400f;
        mouseX += Input.GetAxisRaw("Mouse X") * mousesensitivity * Time.deltaTime;
        mouseY -= Input.GetAxisRaw("Mouse Y") * mousesensitivity * Time.deltaTime;
        mouseY = Mathf.Clamp(mouseY, -90f, 90f);
        player.transform.localRotation = Quaternion.Euler(0, mouseX, 0f);
        transform.localRotation = Quaternion.Euler(mouseY, mouseX, 0f);

    }
}
