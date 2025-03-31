using System.Threading.Tasks;
using UnityEditor.Compilation;
using UnityEngine;

public class NewsAgent : MonoBehaviour, Msg_Context
{
    string Prompt = "";
    string source = "NewsAgent";

    public async Task Handle_msg(Text_msg msg)
    {
        
        var response= await RequestHelper.Send(msg.content, Prompt);
        Msg_Context.ctx.Add(new Text_msg {source=source,content=response });


    }

 
}