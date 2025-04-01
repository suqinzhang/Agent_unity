using System.Threading.Tasks;
 
using UnityEngine;

public class NewsAgent : MonoBehaviour, Handle
{
    string Prompt = "帮我分析最近的财经新闻，输入没有提供消息，自己联网查询";
    string source = "NewsAgent";


    void Start()
    {
        Msg_Context.dic.Add(source, Handle_msg);


    }
    public async Task Handle_msg()
    {
        string send_msg = JsonUtility.ToJson(Msg_Context.ctx);
        var response= await RequestHelper.Send(send_msg, Prompt);
        Msg_Context.ctx.Add(new Text_msg {source=source,content=response });
        Selector.flag = 2;
        
    }

 
}