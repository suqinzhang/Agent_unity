
using Newtonsoft.Json;
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
   public static Dictionary<string ,Handle> dic = new();
    public static void  ClearCtx()
    {
        ctx=new(); 
    }
}
public interface Handle
{

    Task Handle_msg();
     

}



 public class Text_msg
{
     public string content { get; set; }
    public string source { get; set; }

}


 



public static class RequestHelper  
{
    public static readonly HttpClient client = new HttpClient();
    const string apiKey = "sk-e42e5d81a01a4fc7a61fb64aaefcdfc1";
    const string appId = "18330ae3b774477bbc42aa0d93767131"; 
    const string url = "https://dashscope.aliyuncs.com/api/v1/apps/" + appId + "/completion";

    public static async Task<string> Send( string prompt)
    {
        if (!client.DefaultRequestHeaders.Contains("Authorization"))
        {
            client.DefaultRequestHeaders.Add("Authorization", $"Bearer {apiKey}");
        }

       
        string jsonContent = $"{{ \"input\": {{ \"prompt\": {prompt} }}, \"parameters\": {{}}, \"debug\": {{}} }}";
       
        HttpContent content = new StringContent(jsonContent, Encoding.UTF8, "application/json");

        try
        {
            HttpResponseMessage response = await client.PostAsync(url, content);
            
            string responseBody = await response.Content.ReadAsStringAsync();
            Root rootObject = JsonConvert.DeserializeObject<Root>(responseBody);

            return rootObject.output.text;

        }
        catch (Exception ex)
        {
            return ex.Message;
        }
    }
}



public class Output
{
    public string finish_reason { get; set; }
    public string session_id { get; set; }
    public string text { get; set; }

    
 
}

public class Model
{
    public int output_tokens { get; set; }
    public string model_id { get; set; }
    public int input_tokens { get; set; }
}

public class Usage
{
    public List<Model> models { get; set; }
}

public class Root
{
    public Output output { get; set; }
    public Usage usage { get; set; }
    public string request_id { get; set; }
}