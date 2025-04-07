
using Newtonsoft.Json;
using Palmmedia.ReportGenerator.Core.Common;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

public class test : MonoBehaviour
{
    public static int flag = 1; 
   public InputField inputField;
    // Start is called before the first frame update
    void Start()
    {
        Msg_Context.ctx.Add(new Text_msg { source = "系统设置", content = "如果你是选择器，请根据当前对话的上下文，选择下一个要响应的 agent，并仅返回以下格式：\r\n{ \"stop\": true, \"next\": \"AgentName\" }\r\n- 如果整个群聊流程应终止，设置 stop=true，并将 next 设为 0。 \r\n- 群聊包含以下 agents 及其职责：\r\n  - NewsAgent: 分析财经新闻，提取关键信息。\r\n  - SearchAgent: 根据新闻摘要锁定潜力股。\r\n  - KAgent: 计算并分析 K 线图。\r\n  - FxAgent: 评估潜在风险。\r\n  - ManagerAgent: 做出最终交易决策。\r\n请根据当前上下文选择最合适的 agent，并确保流程合理衔接。\r\n" });
       
        
      
    }

 

    public void send()
    {
        if (flag == 1)
        {
            Msg_Context.ctx.Add(new Text_msg { source = "user", content = $"{inputField.text}" });
            Selector.flag = 2;
            flag = 0;
        }
    }

    // Update is called once per frame


    /* async  Task  t()
     {
          await Task.Delay(1000);
         await Msg_Context.dic["NewsAgent"].Handle_msg();
         await Msg_Context.dic["NewsAgent"].Handle_msg();
        await Msg_Context.dic["KAgent"].Handle_msg();

        await Msg_Context.dic["FxAgent"].Handle_msg();

        await Msg_Context.dic["ManegerAgent"].Handle_msg();




     }*/



}

 