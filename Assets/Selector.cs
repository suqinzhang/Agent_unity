
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Unity.VisualScripting;
using UnityEngine;

public class Selector : MonoBehaviour, Handle
{
    public static Selector instance;
    string Prompt = "你是选择器，群中有, 分析财经新闻的NewsAgent,根据新闻摘要锁定潜力股的SearchAgent,计算k线图的KAgent,分析风险的FxAgent，最后决策股票交易的ManegerAgent ，帮我选择下一个agent,返回格式 {   \\\"stop\\\": \\\" \\\",   \\\"next\\\": \\\" \\\"},next是对应的agent，stop bool 是否停止整个群聊,如果停止，next设置0";
    string source = "Selector";
    public static int flag = 0;     //0这个群聊停止，1启动选择，2，agent工作
    string next = "";

    void Start()
    {
        instance = this;

    }

    void Update()
    {
        
        if (flag == 2)
        {
            flag = 0;
            _ = Handle_msg();
            
        }
        if (flag == 1)
        {
            
            if (Msg_Context.dic.ContainsKey(next))
            {
                _ = Msg_Context.dic[next].Handle_msg();
            }
            else
            {
                Debug.Log("没有这个agent");
            }
            
        }

    }

    public async Task Handle_msg()
    {

        string _send_msg = JsonConvert.SerializeObject( Msg_Context.ctx);
        Debug.Log(_send_msg);
        var send_msg = "杭州今天的天气";
        var response = await RequestHelper.Send(Prompt, send_msg);
        Debug.Log(response);
        var select = JsonUtility.FromJson<Select_Msg>(response);
       
        next = select.next;
  
        Msg_Context.ctx.Add(new Text_msg { source = source, content = response });
        flag = select.stop ?  0 : 1;
        
    }
}


public class Select_Msg
{
    public string next;
    public bool stop;
}