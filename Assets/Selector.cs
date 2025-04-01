
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Unity.VisualScripting;
using UnityEngine;

public class Selector : MonoBehaviour, Handle
{
    string Prompt = "你是选择器，群中有, 分析财经新闻的NewsAgent,根据新闻摘要锁定潜力股的SearchAgent,计算k线图的KAgent,分析风险的FxAgent，最后决策股票交易的ManegerAgent ，帮我选择下一个agent,返回格式 {   \\\"stop\\\": \\\" \\\",   \\\"next\\\": \\\" \\\"},next是对应的agent，stop bool 是否停止整个群聊,如果停止，next设置0";
    string source = "Selector";
    public static int flag = 0;     //0这个群聊停止，1启动选择，2，agent工作
    string next = "";

    void Start()
    {
        Msg_Context.dic.Add(source, Handle_msg);
        Debug.Log(Prompt);
       
    }

    void Update()
    {
        
        if (flag == 2)
        {
            _ = Handle_msg();
            
        }
        if (flag == 1)
        {
            Debug.Log(next);
            if (Msg_Context.dic.ContainsKey(next))
            {
                _ = Msg_Context.dic[next]();
            }
            else
            {
                Debug.Log("没有这个agent");
            }
            
        }
    }

    public async Task Handle_msg()
    {
        string send_msg = JsonUtility.ToJson(Msg_Context.ctx);
        Debug.Log(send_msg);
        var response = await RequestHelper.Send(Prompt, send_msg);
        var select = JsonUtility.FromJson<Select_Msg>(response);
        Debug.Log(response);
        next = select.next;
        next= "NewsAgent";
        Msg_Context.ctx.Add(new Text_msg { source = source, content = response });
        Debug.Log(Msg_Context.ctx.ToString());
        flag = select.stop ?  0 : 1;
        
    }
}


class Select_Msg
{
    public string next { get; set; }
    public bool stop { get; set; }
}