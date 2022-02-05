using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextureRotater : MonoBehaviour
{
    /// <summary>
    /// Id ��������� �� ��������, ���������� ��� ����������� ����, ����� �� ��� �������.
    /// </summary>
    public int id = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //������� ��������.
        if (id == ArrowGameOnClickHandler.currentId) transform.rotation = Quaternion.Euler(0f, 0f, transform.rotation.eulerAngles.z - 90f * Time.deltaTime);
    }
}
