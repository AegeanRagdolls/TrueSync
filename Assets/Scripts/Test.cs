using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using TrueSync;
using UnityEngine;

public class Test : MonoBehaviour
{

    public TSTransform[] tSTransforms;

    int I = 0;

    public void Awake()
    {

    }

    // Start is called before the first frame update
    void Start()
    {

    }

    private void FixedUpdate()
    {
        I++;
        if (I == 500)
        {
            TrueSyncManager.PauseSimulation();

            foreach (var item in tSTransforms)
            {
                Debug.Log(item.position.x + ">>>" + item.position.y + ">>>" + item.position.z);
            }
        }
    }


    public string EncryptWithMD5(string source)
    {
        byte[] sor = Encoding.UTF8.GetBytes(source);
        MD5 md5 = MD5.Create();
        byte[] result = md5.ComputeHash(sor);
        StringBuilder strbul = new StringBuilder(40);
        for (int i = 0; i < result.Length; i++)
        {
            strbul.Append(result[i].ToString("x2"));//加密结果"x2"结果为32位,"x3"结果为48位,"x4"结果为64位

        }
        return strbul.ToString();
    }
}
