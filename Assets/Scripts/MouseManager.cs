using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class EventVector3 : UnityEvent<Vector3> { }  //继承了vector3类型
//这个class不是集成monobehaviour，需要被系统序列化才能在inspector现实出来

public class MouseManager : MonoBehaviour
{
    public EventVector3 OnMouseClicked;

    RaycastHit hitInfo;

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
