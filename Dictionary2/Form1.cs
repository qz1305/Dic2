using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Dictionary2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btn_Search_Click(object sender, EventArgs e)
        {
            Dictionary<string, string> myDict = new Dictionary<string, string>();
            StreamReader sr = new StreamReader(@"C: \Users\Admin\Documents\New folder\dic2.txt");
            string line = null; //biến line là biến lưu từng dòng trong file
            string[] words = null;
            do
            {
                line = sr.ReadLine();
                if (line != null)
                {
                    words = line.Split(':');
                    myDict.Add(words[0], words[1]); // Add words[0] là từ đầu tiên trong chuỗi khi tách ra, đó là từ
                                                    // Add words[1] là từ thứ 2 trong chuỗi khi tách ra, đó là nghĩa của từ
                }
                else rtb_Meaning.Text = "Không có từ cần tìm";
                foreach (KeyValuePair<string, string> kvp in myDict)
                {
                    if (kvp.Key == txt_Search.Text)
                        rtb_Meaning.Text = kvp.Value;
                }

            }
            while (line != null && words[0] != txt_Search.Text);
        }
    }
}
