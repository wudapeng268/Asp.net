using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net.Mail;
using System.Net;
using System.Text.RegularExpressions;
using System.Data;


public partial class forgetPwd : System.Web.UI.Page
{
    Cookie cookie = new Cookie();
    MySql sql = new MySql();
    protected void Page_Load(object sender, EventArgs e)
    {
        String user = cookie.cookieisequal();
        if (user != "")
        {
            login.Style["display"] = "none";
            logined.Style["display"] = "block";
            loguser.InnerHtml = user;
        }
    }

    public void SendMail(String mail)
    {
        String message = Regex.Replace(HttpContext.Current.Request.Url.ToString(), "forgetPwd.aspx", "") + "change.aspx?" + MD5Password.Encrypt(mail);
        MailMessage mailmessage = new MailMessage("wenbaadmin@163.com", mail, "问吧", "<h1>问吧</h1><h2><a href='" + message + "'>密码重置链接</a>点击进入修改<br>" + message + "</h2><p style = 'display: none'> 时光是一座城，城里住着千姿百态的人。通透的人懂得在城墙上开一扇窗，给自己一米阳光，给风雨几分慈悲。素雅的人在城里种花种草种光阴，与时光对饮，捻心事入诗。凉薄的人用岁月的灰烬一点一点修补过往，阻挡了温暖，升华了孤单。而我，只愿带着我的三寸烟火，守一方锦城，祈求岁月静好，现世安稳。——题记素来多愁善感，会为春燕衔泥而归欢喜，会为花落残红零落为泥哀伤。想来千年前，我定是宋词里哪位婉约的女子，一不小心入了书生的眼，一眼万年，回首已翩然落于一纸墨香。究竟是否结了尘缘，春燕未带回杳音，时光也未曾给我讯息。或许，千年前那座城，已然随着历史的洪荒，散落在布满尘埃的角落，只待我哪日午夜梦回，提着花灯到曲径通幽处找寻，又或许，它就是今夜的月色里，那朵含着心事的白莲，只待我靠近，便要向我吐露千年的恋。也曾在偶然间，误入过一处桃花源。那时的灯火正阑珊，我似武陵人行舟而往，晓风残月，星疏水寒，两岸杨柳依依，摇曳着时光的浅。我撑一把油纸伞，踏岸穿行于朦胧的青石小巷，亭台水榭，烟雨楼阁，有舞低杨柳楼心月，有歌尽桃花扇底风，有墨香之荡漾，有茶香之委婉，盈盈绕绕，交织成一幅精美画卷。此时的光阴，就像一首悠扬的宋词，淅淅沥沥的落在我的油纸伞上，平仄有声，又像一幅写意的泼墨图，刻画进最最明净的时光里，浓淡相宜。以为，这便是青葱岁月，以为，这就是锦绣华年，然而，所有的以为都不过是以为罢了。或许，分离是时光固有的酷刑，饶是清幽如你，还是激烈如我，都逃不过既定的宿命。当岁月将梦境蹂躏得支离破碎，企图将所有的故事缴获，也许只有安静守候才是最能经历风霜的诗歌，而那些疼痛的伤，将搁浅在流光的刻痕里，经年不忘。故事还未结束，故事却已然结束。再次在最深的红尘中相逢，不过彼此感慨一句，从别后，忆相逢，几回魂梦与君同。然后，各自背着相同的过往，看各自的云卷云舒，赏各自的花开盛世。其实这也是一种缘，只是这段缘，背负着太多的伤感，如浅夏的雨，来时轰轰烈烈，走时悄无声息。总觉得文字，是从丽江的小巷迤逦而来，时而带着一米阳光的明媚，时而带着婉约温柔的缱绻，时而又带着朦胧湿润的哀伤，与文字的邂逅便是一段美艳动人的相逢。许多时候，或许我们愿意守候的，并不是那座锦绣斑斓的城，而是因为城中，那些如烟花般绚烂的相逢，即使稍纵即逝，即使注定灰飞烟灭，却还是执意不肯放过那一刻的炙热。从来都知道，文字是美好而伤感的。写了那样多的字，已分不清是文字在记录我，还是我在记录文字。就如一个有故事的人，分不清是故事在为他铭记，还是他在演绎故事。而事实上，世间之人都叫尘埃迷了眼，左不过是你在风景之中看风景，无意中又成为了别人的风景，一切，不过是个缘字。红尘陌上，总有一些相逢惊艳着时光，总有一次回眸隐藏着离殇。多想，在乍暖还寒的晓春里，与一段尘缘擦肩，不祈求地老天荒的诺言，只在淡水流年里，走一程细水长流。若是如此，就在那时卸掉这一身浮华吧，用清欢建一座城，也学清心寡欲的僧人，在心田里修篱种菊，看流水无痕，赏花落无声，在清浅的时光里，将岁月烹成一壶且浓且淡的茶。写几贴小字，让墨浸染在光阴里，馨香就那样无拘无束的萦绕着经年，不诉忧伤，不诉别离。夕阳西下的余晖中，我独倚轩窗，捧着那盏喝到无味的茶，此时，推门而入的，正是我痴痴等候的良人。落笔之时，写一首小诗，不为纪念，只为多年以后，落花时节又逢君，能浅笑而安。请帮我记得，如果我曾来过。旧时的秋千架，是否已然斑驳？墙角的幽兰，是否也开了又落？都说时光凉薄，如一支笔，行过阡陌，却终是在你的一纸素笺，留一笔云淡风轻，再留一笔浅彩淡墨。许多故事，禁锢在光阴里，无法挣脱，或许有一个你，或许有一个我。人生，是一场修行。命运这道禅意，论谁也悟不破。十月的秋意里，是谁在捡拾时光的残片？又是谁将离愁叙说？诉说如秋叶般滑落，细细簌簌，嘶哑婆娑。他说，请帮我记得，如果我曾来过。</p>");
        //from email，to email，主题，邮件内容
        mailmessage.IsBodyHtml = true;
        mailmessage.Priority = MailPriority.Normal; //邮件优先级
        SmtpClient smtpClient = new SmtpClient("smtp.163.com", 25); //smtp地址以及端口号
        smtpClient.Credentials = new NetworkCredential("wenbaadmin@163.com", "wenbawenba");//smtp用户名密码
        smtpClient.EnableSsl = true; //启用ssl
        smtpClient.Send(mailmessage); //发送邮件
    }


    protected void submit_Click(object sender, EventArgs e)
    {
        String searchsql = "select * from TUser where email = '" + email.Text + "'";
        DataSet ds = sql.sqlsearch(searchsql);
        if (ds.Tables["t"].Rows.Count == 0)
        {
            Response.Write("<script type='text/javascript'>alert('没有这个用户!!')</script>");
            return;
        }
        SendMail(email.Text);
        Response.Write("<script type='text/javascript'>alert('已经发送邮件;请登录邮箱查看!');lwindow.window.location.href= 'cancel.aspx'</script>");
    }
    
}