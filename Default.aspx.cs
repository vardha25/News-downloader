using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.IO;
using System.Web.UI.WebControls;
using HtmlAgilityPack;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Threading.Tasks;
using System.Drawing.Imaging;
using System.Drawing.Drawing2D;


namespace scraping3
{
    public partial class WebForm2 : System.Web.UI.Page
    {

        H2PTesting.h2ptrans h2p;
        public static int z,w,h;
        public static String str;
        protected void Page_Load(object sender, EventArgs e)
        {
            h2p = new H2PTesting.h2ptrans();
             HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
            HtmlWeb hw = new HtmlWeb();
            String url = "https://www.jagran.com";
            try
            {
                doc = hw.Load(url);
                HtmlNodeCollection node = doc.DocumentNode.SelectNodes("//*[contains(@class,'container')]//h3/a[@href]");
                if (ListBox1.Items.Count<=0)
                {
                    foreach (HtmlNode nodes in node)
                    {
                        HtmlAttribute att = nodes.Attributes["href"];
                        ListItem dataItem = new ListItem();
                        dataItem.Text = nodes.InnerText;
                        dataItem.Value = att.Value;
                        ListBox1.Items.Add(dataItem);
                    }
                }
            }
            catch(Exception a)
            {
               
                Response.Write(@"<script language='javascript'>alert('Check your Internet Connection and Try Again');</script>");
            }
        }

        public void link3(String url,String hreftag)
        {
            HtmlAgilityPack.HtmlDocument doc2 = new HtmlAgilityPack.HtmlDocument();
            HtmlWeb hw2 = new HtmlWeb();
            String newurl1 = "https://" + url + hreftag;
            
            try
            {
                doc2 = hw2.Load(newurl1);
               
                if ("//*[contains(@class,'bodysummery')]//figcaption" != null && "//*[contains(@class,'bodysummery')]//img" != null && doc2.DocumentNode.SelectSingleNode("//*[@id=\"jagran_image_id\"]").GetAttributeValue("src", string.Empty)!="//www.jagranimages.com/images/jagran_logo.jpg")
                {
                   
                        z++;

                        HtmlNodeCollection nodes = doc2.DocumentNode.SelectNodes("//*[contains(@class,'articleBody')]//p");
                        String s = null;
                        if (nodes != null)
                        {
                            foreach (HtmlNode node in nodes)
                            {
                                s += node.InnerText;

                            }
                            String abc = h2p.translate(s);
                            System.IO.File.WriteAllText(TextBox3.Text + "Top-Level Folder\\news\\" + z, abc);
                        }

                        var pre = doc2.DocumentNode.Descendants("figure").FirstOrDefault();
                        var links = pre.Descendants("img");
                        var links1 = pre.Descendants("figcaption");
                        foreach (var node in links1)
                        {
                            String abc1 = h2p.translate(node.InnerText);
                            System.IO.File.WriteAllText(TextBox3.Text + "Top-Level Folder\\captions\\" + z, abc1);

                        }


                        foreach (var node in links)
                        {


                            string a = "http:" + node.GetAttributeValue("src", string.Empty);
                            string n = node.GetAttributeValue("alt", string.Empty);
                            String abc2 = h2p.translate(n);
                            System.IO.File.WriteAllText(TextBox3.Text + "Top-Level Folder\\headings\\" + z, abc2);
                            string saveLocation = TextBox3.Text + "Top-Level Folder\\images\\" + z + ".jpg";

                            byte[] imageBytes;
                            HttpWebRequest imageRequest = (HttpWebRequest)WebRequest.Create(a);
                            WebResponse imageResponse = imageRequest.GetResponse();

                            Stream responseStream = imageResponse.GetResponseStream();

                            using (BinaryReader br = new BinaryReader(responseStream))
                            {
                                imageBytes = br.ReadBytes(500000);
                                br.Close();
                            }
                            responseStream.Close();
                            imageResponse.Close();

                            FileStream fs = new FileStream(saveLocation, FileMode.Create);
                            BinaryWriter bw = new BinaryWriter(fs);
                            if (RadioButtonList1.SelectedIndex == 0)
                            {
                                h = Convert.ToInt16(TextBox1.Text);
                                w = Convert.ToInt16(TextBox2.Text);
                                System.Drawing.Image i = byteArrayToImage(imageBytes);
                                System.Drawing.Image i2 = ReSize(i, h, w);
                                byte[] i3 = imageToByteArray(i2);
                                try
                                {
                                    bw.Write(i3);
                                }
                                finally
                                {
                                    fs.Close();
                                    bw.Close();
                                }
                            }
                            else
                            {
                                try
                                {
                                    bw.Write(imageBytes);
                                }
                                finally
                                {
                                    fs.Close();
                                    bw.Close();
                                }
                            }
                        }
                }
            }
            catch
            {
                 Response.Write(@"<script language='javascript'>alert('Check your Internet Connection and Try Again');</script>");
            
            }
            
        }
        public byte[] imageToByteArray(System.Drawing.Image imageIn)
        {
            MemoryStream ms = new MemoryStream();
            imageIn.Save(ms, System.Drawing.Imaging.ImageFormat.Gif);
            return ms.ToArray();
        }
        public System.Drawing.Image byteArrayToImage(byte[] byteArrayIn)
        {
            MemoryStream ms = new MemoryStream(byteArrayIn);
            System.Drawing.Image returnImage = System.Drawing.Image.FromStream(ms);
            return returnImage;
        }

        static System.Drawing.Image ReSize(System.Drawing.Image imgPhoto, int Width, int Height)
        {
           int sourceWidth = imgPhoto.Width;
           int sourceHeight = imgPhoto.Height;
           

            float nPercent = 0;
            float nPercentW = 0;
            float nPercentH = 0;

            nPercentW = ((float)Width / (float)sourceWidth);
            nPercentH = ((float)Height / (float)sourceHeight);

            if (nPercentH < nPercentW)
                nPercent = nPercentH;
        
            else
            {
                nPercent = nPercentW;
           
            }
            int destWidth = (int)(sourceWidth * nPercent);
            int destHeight = (int)(sourceHeight * nPercent);

            Bitmap b = new Bitmap(destWidth, destHeight);
            Graphics g =Graphics.FromImage((System.Drawing.Image)b);
            g.InterpolationMode = InterpolationMode.HighQualityBicubic;

            g.DrawImage(imgPhoto, 0, 0, destWidth, destHeight);
            g.Dispose();

            return (System.Drawing.Image)b;
            
        }
    
        public void link4(String url,String hreftag)
        {
            HtmlAgilityPack.HtmlDocument doc1 = new HtmlAgilityPack.HtmlDocument();
            HtmlWeb hw1 = new HtmlWeb();
           
            String newurl = "https://" + url + hreftag;
            try
            {
                if (hreftag.Contains("https"))
                {
                    doc1 = hw1.Load(hreftag);
                }

                else
                {
                    doc1 = hw1.Load(newurl);
                }
                if (doc1.DocumentNode.SelectNodes("*//*[contains(@class,'pagination border0')]") == null)
                {
                    str = "";
                    foreach (HtmlNode node in doc1.DocumentNode.SelectNodes("*//*[contains(@class,'MainHd')]//a[@href]"))
                    {
                        if (str != node.Attributes["href"].Value)
                        {
                             HtmlAttribute att1 = node.Attributes["href"];
                             link4(url, att1.Value);
                        }
                        str = node.Attributes["href"].Value;
                        
                    }
                }
                else
                {
                    while (true)
                    {
                        if (doc1.DocumentNode.SelectNodes("*//*[contains(@class,'last')]") == null)
                        {
                            break;
                        }
                        else
                        {
                            foreach (HtmlNode node in doc1.DocumentNode.SelectNodes("*//*[contains(@class,'last')]//a[@href]"))
                            {

                                HtmlAttribute att1 = node.Attributes["href"];
                                String str = "https://www.jagran.com" + att1.Value;
                                // doc1 = hw1.Load(str);
                                foreach (HtmlNode link in doc1.DocumentNode.SelectNodes("//*[contains(@class,'topicList')]//a[@href]"))
                                {
                                    HtmlAttribute att = link.Attributes["href"];
                                    
                                    link3("www.jagran.com", att.Value);
                                }
                                doc1 = hw1.Load("https://www.jagran.com" + att1.Value);
                            }
                        }
                    }
                }
            }
            catch(Exception c)
            {
                 Response.Write(@"<script language='javascript'>alert('Check your Internet Connection and Try Again');</script>");
            
            }
         
        }

       


        public void link2(String url, String hreftag)
        {
            
            HtmlAgilityPack.HtmlDocument doc1 = new HtmlAgilityPack.HtmlDocument();
            HtmlWeb hw1 = new HtmlWeb();
           
            String newurl = "https://" + url + hreftag;
            try
            {
                doc1 = hw1.Load(newurl);
                foreach (HtmlNode node in doc1.DocumentNode.SelectNodes("*//*[contains(@class,'morebt')]/a[@href]"))
                {
                    HtmlAttribute att1 = node.Attributes["href"];
                    String str = "https://www.jagran.com" + att1.Value;
                    link1(url, att1.Value);

                }
            }
            catch(Exception b)
            {
             Response.Write(@"<script language='javascript'>alert('Check your Internet Connection and Try Again');</script>");
            }

          
        
        }
        public void link1(String url,String hreftag)
        {
            z++;
           
            HtmlAgilityPack.HtmlDocument doc1 = new HtmlAgilityPack.HtmlDocument();
            HtmlWeb hw1 = new HtmlWeb();
            String str = "https://www.jagran.com" + hreftag;
            try
            {
                doc1 = hw1.Load(str);
                HtmlNodeCollection nodes = doc1.DocumentNode.SelectNodes("//*[contains(@class,'textbx')]//p");
                String s = null;
                if (nodes != null)
                {
                    foreach (HtmlNode node in nodes)
                    {
                        s += node.InnerText;

                    }
                    System.IO.File.WriteAllText(@"o:\Top-Level Folder\news\" + z, s);
                }
                foreach (var node in doc1.DocumentNode.SelectNodes("*//*[contains(@class,'imgbx')]//img"))
                {

                    System.IO.File.WriteAllText(@"o:\Top-Level Folder\headings\" + z, node.GetAttributeValue("alt", string.Empty));

                    string a = "http:" + node.GetAttributeValue("src", string.Empty);
                    string saveLocation = @"o:\Top-Level Folder\images\" + z + ".jpg";

                    byte[] imageBytes;
                    HttpWebRequest imageRequest = (HttpWebRequest)WebRequest.Create(a);
                    WebResponse imageResponse = imageRequest.GetResponse();

                    Stream responseStream = imageResponse.GetResponseStream();

                    using (BinaryReader br = new BinaryReader(responseStream))
                    {
                        imageBytes = br.ReadBytes(500000);
                        br.Close();
                    }
                    responseStream.Close();
                    imageResponse.Close();

                    FileStream fs = new FileStream(saveLocation, FileMode.Create);
                    BinaryWriter bw = new BinaryWriter(fs);
                    try
                    {
                        bw.Write(imageBytes);
                    }
                    finally
                    {
                        fs.Close();
                        bw.Close();
                    }
                }
            }
            catch(Exception a)
            {
                 Response.Write(@"<script language='javascript'>alert('Check your Internet Connection and Try Again');</script>");
            }
            
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            string rootpath = TextBox3.Text;
            string folderName =  TextBox3.Text+"Top-Level Folder";
            string pathString = System.IO.Path.Combine(folderName, "images");
            string pathString2 = TextBox3.Text+"Top-Level Folder\\headings";
            string pathString3 = TextBox3.Text + "Top-Level Folder\\news";
            string pathString4 = TextBox3.Text + "Top-Level Folder\\captions";
            System.IO.Directory.CreateDirectory(pathString);
            string fileName = System.IO.Path.GetRandomFileName();
            if (!System.IO.Directory.Exists(pathString))
            {
                System.IO.Directory.CreateDirectory(pathString);
            }
            if (!System.IO.Directory.Exists(pathString2))
            {
                System.IO.Directory.CreateDirectory(pathString2);
            }
            if (!System.IO.Directory.Exists(pathString3))
            {
                System.IO.Directory.CreateDirectory(pathString3);
            }
            if (!System.IO.Directory.Exists(pathString4))
            {
                System.IO.Directory.CreateDirectory(pathString4);
            }

             String url = "www.jagran.com";
             String str = ListBox1.SelectedItem.Value;
             if (ListBox1.SelectedItem.Value == "/spiritual/rashifal-hindi.html")
             {
                 link2(url, str);
             }
             else
             {
                 link4(url, str);
             }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        protected void Button3_Click(object sender, EventArgs e)
        {

        }

        protected void RadioButtonList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(RadioButtonList1.SelectedIndex==0)
            {
                TextBox1.Visible = true;
                TextBox2.Visible = true;
                Label4.Visible = true;
                Label5.Visible = true;
                Label6.Visible = true;
            }
        }
   

    }
}