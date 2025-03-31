
using Palmmedia.ReportGenerator.Core.Common;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Unity.VisualScripting;
using UnityEngine;


interface Msg_Context
{
   public static List<Text_msg> ctx  = new();
    public static Dictionary<string ,Func<Text_msg,Task>> dic = new();
    public static void  ClearCtx()
    {
        ctx=new(); //ֱ��newһ��
    }
    Task Handle_msg(Text_msg msg);
     

}



 public class Text_msg
{
     public string content { get; set; }
    public string source { get; set; }

}


public class Input
{
    public string Prompt { get; set; }
}

public class RequestModel
{
    public Input Input { get; set; }
    public List<string> Parameters { get; set; }  
    public List<string> Debug { get; set; }  
}

// �������뱣�ֲ���

public static class RequestHelper
{
    public static readonly HttpClient client = new HttpClient();
    const string apiKey = "sk-e42e5d81a4fc7a61fb64aaefcdfc1";
    const string appId = "18330ae3b774477bbc42aa0d93767131"; // �滻Ϊʵ�ʵ�Ӧ��ID
    const string url = "https://dashscope.aliyuncs.com/api/v1/apps/" + appId + "/completion";

    public static async Task<string> Send(string Sys_Message, string prompt)
    {
        client.DefaultRequestHeaders.Add("Authorization", $"Bearer {apiKey}");

        var requestModel = new RequestModel
        {
            Input = new Input { Prompt = Sys_Message + prompt },
            Parameters = new List<string>(), // �������������͵�����
            Debug = new List<string>() // �������������͵�����
        };

        string jsonContent = JsonUtility.ToJson(requestModel);// ʹ����ȷ��JsonSerializer����
        HttpContent content = new StringContent(jsonContent, Encoding.UTF8, "application/json");

        try
        {
            HttpResponseMessage response = await client.PostAsync(url, content);
            
                string responseBody = await response.Content.ReadAsStringAsync();

            return responseBody;
            
            
        }
        catch (Exception ex)
        {
            return ex.Message;
        }
    }
}
