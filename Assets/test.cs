
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
         Msg_Context.ctx.Add(new Text_msg { source = "老板", content = "帮我分析近期股市，和相关投资" });

          Selector.flag = 2;
      
    }

    // Update is called once per frame
    void  Update()
    {
      

    }

}

 