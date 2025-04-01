
using Palmmedia.ReportGenerator.Core.Common;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Windows;

  
public static class Msg_Context
{
   public static List<Text_msg> ctx  = new();
   public static Dictionary<string ,Func<Task>> dic = new();
    public static void  ClearCtx()
    {
        ctx=new(); //直接new一个
    }
}
interface Handle
{

    Task Handle_msg();
     

}



 public class Text_msg
{
     public string content { get; set; }
    public string source { get; set; }

}


 

// 其他代码保持不变

public static class RequestHelper
{
    public static readonly HttpClient client = new HttpClient();
    const string apiKey = "sk-e42e5d81a01a4fc7a61fb64aaefcdfc1";
    const string appId = "18330ae3b774477bbc42aa0d93767131"; // 替换为实际的应用ID
    const string url = "https://dashscope.aliyuncs.com/api/v1/apps/" + appId + "/completion";

    public static async Task<string> Send(string Sys_Message, string prompt)
    {
        client.DefaultRequestHeaders.Add("Authorization", $"Bearer {apiKey}");

         
        string jsonContent = $"{{ \"input\": {{ \"prompt\": \"{Sys_Message+prompt}\" }}, \"parameters\": {{}}, \"debug\": {{}} }}";

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
