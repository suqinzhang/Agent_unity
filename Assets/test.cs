
using Newtonsoft.Json;
using Palmmedia.ReportGenerator.Core.Common;
using System.Threading.Tasks;
using UnityEngine;

public class test : MonoBehaviour
{
    bool flag = true;
    // Start is called before the first frame update
     void Start()
    {
         Msg_Context.ctx.Add(new Text_msg { source = "�ϰ�", content = "���ҷ������ڹ��У������Ͷ��" });

          Selector.flag = 2;
      
    }

    // Update is called once per frame
    void  Update()
    {
      

    }

}

 