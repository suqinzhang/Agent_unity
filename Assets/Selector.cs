
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class Selector : MonoBehaviour, Msg_Context
{
    string Prompt = "你是选择器，群中有, 分析财经新闻的NewsAgent,根据新闻摘要锁定潜力股的SearchAgent,计算k线图的KAgent,分析风险的FxAgent，最后决策股票交易的ManegerAgent ，帮我选择下一个agent,返回格式 {   \"content\": \" \",   \"next\": \" \"},处理的任务是：";
    string source = "Selector";
    

    void Start()
    {
        Msg_Context.dic.Add(source, Handle_msg);

    }

 


    void Update()
    {
         
    }

    public async Task Handle_msg(Text_msg msg)
    {
        string send_msg= Msg_Context.ctx.ToString();    //上下文字符串
        var response = await RequestHelper.Send(send_msg, Prompt); //获取大模型回复
        
        Msg_Context.ctx.Add(new Text_msg { source = source, content = response });//放入上下文，生成源加生成消息作为下一个处理器的参数
    }
}


class Select_Msg
{
    public string content { get; set; }
    public string next { get; set; }
}