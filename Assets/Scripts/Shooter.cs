using System.Collections;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    private new Camera camera;


    void Start()
    {
        camera = GetComponent<Camera>();

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            var screenPosition = new Vector2(camera.pixelWidth / 2, camera.pixelHeight / 2);

            Ray ray = camera.ScreenPointToRay(screenPosition);

            if (Physics.Raycast(ray, out RaycastHit hitInfo, 1000))
            {
                StartCoroutine(ProcessShot(hitInfo.point));
            }
        }
    }

    private IEnumerator ProcessShot(Vector3 position)
    {
        var sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        sphere.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
        sphere.transform.position = position;

        yield return new WaitForSeconds(1.0f);

        Destroy(sphere);
    }

    void OnGUI()
    {
        float size = 16;
        float positionX = camera.pixelWidth / 2 - size / 4;
        float positionY = camera.pixelHeight / 2 - size / 2;

        GUI.Label(new Rect(positionX, positionY, size, size), "•");
    }
}
