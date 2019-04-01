using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Web;
using System.Net;
using System.Windows.Forms;
using Newtonsoft.Json;
using System.IO;
using Newtonsoft.Json.Linq;
using System.Threading;

namespace WoloSummonerIDApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public String none = "N/A";

        void Form1_Load(object sender, EventArgs e)
        {
            btnRun.Enabled = false;
            lblNick.Text = none;
            API_Key.UseSystemPasswordChar = true;
        }

        void cbMultinick_CheckedChanged(object sender, EventArgs e)
        {
            int iChecked = cbMultinick.Checked ? 1 : 0;
            if (iChecked == 1)
            {
                this.Height = 615;
                txtNicks.Multiline = true;
                txtNicks.Height = 500;
                txtNicks.Width = 250;
                txtNicks.ScrollBars = ScrollBars.Vertical;
                lblNick.Text = "";
            }
            else
            {
                this.Height = 135;
                txtNicks.ScrollBars = ScrollBars.None;
                txtNicks.Multiline = false;
                lblNick.Text = none;
            }
        }

        private void btnAPI_Click(object sender, EventArgs e)
        {
            String URL = "https://eun1.api.riotgames.com/lol/summoner/v4/summoners/by-name/Kaylesse?api_key="+API_Key.Text;
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(URL);
            var code = HttpStatusCode.Unauthorized;
            try
            {
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                code = response.StatusCode;
            }
            catch (Exception ex)
            {
                code = HttpStatusCode.Unauthorized;
                lblVerify.Text = "Wrong";
                lblVerify.ForeColor = Color.FromArgb(255, 0, 0);
                MessageBox.Show(ex.Message, "API Key Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            if(code == HttpStatusCode.OK)
            {
                lblVerify.Text = "Correct";
                lblVerify.ForeColor = Color.FromArgb(0, 255, 0);
                btnRun.Enabled = true;
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        public static string Reverse(string s)
        {
            char[] charArray = s.ToCharArray();
            Array.Reverse(charArray);
            return new string(charArray);
        }

        String getaccID(String s)
        {
            String URL1 = "https://eun1.api.riotgames.com/lol/summoner/v4/summoners/by-name/" + s + "?api_key=" + API_Key.Text;
            HttpWebRequest request1 = (HttpWebRequest)WebRequest.Create(URL1);
            try
            {
                HttpWebResponse response1 = (HttpWebResponse)request1.GetResponse();
                Stream receiveStream1 = response1.GetResponseStream();
                StreamReader readStream1 = new StreamReader(receiveStream1, Encoding.Default);
                String data1 = readStream1.ReadToEnd();
                var enID = JObject.Parse(data1)["accountId"].ToString();
                String URL2 = "https://eun1.api.riotgames.com/lol/match/v4/matchlists/by-account/" + enID + "?api_key=" + API_Key.Text;
                HttpWebRequest request2 = (HttpWebRequest)WebRequest.Create(URL2);
                HttpWebResponse response2 = (HttpWebResponse)request2.GetResponse();
                Stream receiveStream2 = response2.GetResponseStream();
                StreamReader readStream2 = new StreamReader(receiveStream2, Encoding.Default);
                String data2 = readStream2.ReadToEnd();
                var gameID = JObject.Parse(data2)["matches"][0]["gameId"].ToString();
                String URL3 = "https://eun1.api.riotgames.com/lol/match/v4/matches/" + gameID + "?api_key=" + API_Key.Text;
                HttpWebRequest request3 = (HttpWebRequest)WebRequest.Create(URL3);
                HttpWebResponse response3 = (HttpWebResponse)request3.GetResponse();
                Stream receiveStream3 = response3.GetResponseStream();
                StreamReader readStream3 = new StreamReader(receiveStream3, Encoding.Default);
                String data3 = readStream3.ReadToEnd();
                var temp = (JObject)JsonConvert.DeserializeObject(data3);
                var ilegraczy = temp["participantIdentities"].Count();
                String accHistoryLink = "";
                for (int i = 0; i < ilegraczy; i++)
                {
                    if (temp["participantIdentities"][i]["player"]["summonerName"].ToString() == s)
                    {
                        accHistoryLink = temp["participantIdentities"][i]["player"]["matchHistoryUri"].ToString();
                    }
                }
                String reversedaccHistoryLink = Reverse(accHistoryLink);
                String reversedaccID = "";
                foreach (char c in reversedaccHistoryLink)
                {
                    if (c == '/')
                    {
                        break;
                    }
                    reversedaccID += c;
                }
                none = Reverse(reversedaccID);
                reversedaccID = "";
                return none;
            }
            catch (Exception exc)
            {
                if (s == "")
                {
                    return "Empty line :>";
                }
                else
                {
                    return "Summoner doesn't exist";
                }
            }
            
        }

        private void btnRun_Click(object sender, EventArgs e)
        {
            List<String> nicki = new List<string>();
            Dictionary<String, String> lista = new Dictionary<string, string>();
            lblNick.Text = "";
            if(!cbMultinick.Checked)
            {
                String str = txtNicks.Text;
                String temp = getaccID(str);
                lblNick.Text = temp;
            }
            else
            {
                int ileLinii = txtNicks.Lines.Count();
                for(int i=0;i<ileLinii;i++)
                {
                    nicki.Add(txtNicks.Lines[i]);
                }
                foreach(String item in nicki)
                {
                    String temp = getaccID(item);
                    Thread.Sleep(3700);
                    if(lista.ContainsKey(item))
                    {
                        continue;
                    }
                    lista.Add(item, temp);
                }
                using (StreamWriter writetext = new StreamWriter("lista.txt"))
                {
                    foreach(var item in lista)
                    {
                        writetext.WriteLine(item.Key + "\t" + item.Value + "\n");
                    }
                }
                lblNick.Text = "Done";
            }
            nicki = null;
            lista = null;
        }

        private void cbpassword_CheckedChanged(object sender, EventArgs e)
        {
            int iCheckedP = cbpassword.Checked ? 1 : 0;
            if (iCheckedP == 0)
            {
                API_Key.UseSystemPasswordChar = true;
            }
            else
            {
                API_Key.UseSystemPasswordChar = false;
            }
        }

        void API_Key_TextChanged(object sender, EventArgs e)
        {
            
        }
    }
}
