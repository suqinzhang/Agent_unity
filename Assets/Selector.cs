
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class Selector : MonoBehaviour, Msg_Context
{
    string Prompt = "����ѡ������Ⱥ����, �����ƾ����ŵ�NewsAgent,��������ժҪ����Ǳ���ɵ�SearchAgent,����k��ͼ��KAgent,�������յ�FxAgent�������߹�Ʊ���׵�ManegerAgent ������ѡ����һ��agent,���ظ�ʽ {   \"content\": \" \",   \"next\": \" \"},����������ǣ�";
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
        string send_msg= Msg_Context.ctx.ToString();    //�������ַ���
        var response = await RequestHelper.Send(send_msg, Prompt); //��ȡ��ģ�ͻظ�
        
        Msg_Context.ctx.Add(new Text_msg { source = source, content = response });//���������ģ�����Դ��������Ϣ��Ϊ��һ���������Ĳ���
    }
}


class Select_Msg
{
    public string content { get; set; }
    public string next { get; set; }
}