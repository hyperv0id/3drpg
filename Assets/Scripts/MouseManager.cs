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
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);//����Ļ���λ�ô�������

        if (Physics.Raycast(ray, out hitInfo))//����raycast����ȡhitInfo
        {
            // �л������ͼ
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
        if (Input.GetMouseButtonDown(0) && hitInfo.collider != null)   //�����������0���ҵ���Ķ�����ײ�岻Ϊ��
        {
            if (hitInfo.collider.gameObject.CompareTag("Ground"))
                OnMouseClicked?.Invoke(hitInfo.point);//?.�����жϵ�ǰ���¼��Ƿ�Ϊ�գ������Ϊ�գ�ִ��invoke���������¼���������
        }
    }
}
