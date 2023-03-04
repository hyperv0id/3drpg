using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System;


public class MouseManager : MonoBehaviour
{
    public static MouseManager Instance;


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
