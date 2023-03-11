using UnityEngine;

public class SmoothCamera : MonoBehaviour
{
    public Transform Camera1;
    public Transform Camera2;
    public Transform Camera3;
    public float CameraSpeed;
    public bool isActivated;

    private float t = 0f;
    void Start()
    {
        isActivated = false;
    }
    void Update()
    {

        // 두 카메라 사이의 거리 계산
        if (isActivated)
        {
            float distance = Vector3.Distance(Camera1.position, Camera2.position);

            // 현재 위치에서 목표 위치까지 보간된 값을 구함
            t = Mathf.Clamp01(t + Time.deltaTime / CameraSpeed);
            transform.position = Vector3.Lerp(Camera1.position, Camera2.position, t);
            transform.rotation = Quaternion.Lerp(Camera1.rotation, Camera2.rotation, t);

            // 카메라 크기도 보간
            Camera.main.orthographicSize = Mathf.Lerp(Camera1.GetComponent<Camera>().orthographicSize,
                                                      Camera2.GetComponent<Camera>().orthographicSize, t);
        }
       
    }

    //음료씬으로 넘어가기
    public void MoveCupScene()
    {
        // 이동할 위치를 확인하고 준비가 되면 카메라 이동
        this.transform.position = Camera3.transform.position;
    }
}
