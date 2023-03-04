using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System;
using System.Drawing;


public class MouseManager : MonoBehaviour
{
    public static MouseManager Instance;

    [SerializeField]
    Texture2D point, doorway, attack, target, arrow;

    public Action<Vector3> OnMouseClicked;

    RaycastHit hitInfo;

    private void Awake()
    {
        if(Instance != null)
        {
            Destroy(Instance);
        }
        Instance = this;
    }

    void Update()
    {
        SetCursorTexture();
        MouseControl();
    }

    void SetCursorTexture()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);//从屏幕点击位置创建射线

        if (Physics.Raycast(ray, out hitInfo))//创建raycast，获取hitInfo
        {
            // 切换鼠标贴图
            switch (hitInfo.collider.gameObject.tag)
            {
                case "Ground":
                    Cursor.SetCursor(target, new Vector2(16, 16), CursorMode.Auto);
                    break;
                
            }
        }
    }

    void MouseControl()
    {
        if (Input.GetMouseButtonDown(0) && hitInfo.collider != null)   //点击鼠标左键是0并且点击的东西碰撞体不为空
        {
            if (hitInfo.collider.gameObject.CompareTag("Ground"))
                OnMouseClicked?.Invoke(hitInfo.point);//?.代表判断当前的事件是否为空，如果不为空，执行invoke启动传入事件这个坐标点
        }
    }
}
