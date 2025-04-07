using Newtonsoft.Json;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;
using UnityEngine.UI;



public class NewsAgent : MonoBehaviour, Handle
{
    string Prompt = "你是NewsAgent，帮我分析最近的财经新闻,联网查询，不要返回选择器结果";
    string source = "NewsAgent";
    public Text text;
    float r = 158f / 255f;
    float g = 122f / 255f;
    float b = 192f / 255f;
    void Start()
    {
        Msg_Context.dic.Add(source, this);


    }
    public async Task Handle_msg()
    {
        Image color = GetComponent<Image>();
        color.color = new Color(r, g, b);
        Msg_Context.ctx.Add(new Text_msg { source = "user", content = Prompt });
        string _send_msg = JsonConvert.SerializeObject(Msg_Context.ctx);
        var response = await RequestHelper.Send(_send_msg);
        text.text = response;
        Msg_Context.ctx.Add(new Text_msg {source=source,content=response });
        color.color = new Color(1, 1, 1);
        await Task.Delay(5000);
        Selector.flag = 2;
        
    }

 
}