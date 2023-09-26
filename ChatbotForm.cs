using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FootballBot
{
    public partial class ChatbotForm : Form
    {
        Chatbot chatbot = new Chatbot();
        public ChatbotForm()
        {
            InitializeComponent();
            this.richTextBoxChat.Text = chatbot.GetResponse() + "\n\n";
        }
        private void buttonSend_Click(object sender, EventArgs e)
        {
            String userInput = this.textBoxChat.Text.ToString();
            this.richTextBoxChat.Text += $"You: {userInput}\n";

            this.richTextBoxChat.Text += chatbot.GetResponse(userInput) + "\n";
        }
    }
}
