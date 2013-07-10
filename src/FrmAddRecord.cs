using System;
using System.Windows.Forms;

namespace RegularGlossary
{
    public partial class FrmAddRecord : Form
    {
        public FrmAddRecord()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (txtName.Text == "" || txtExplain.Text == "")
            {
                MessageBox.Show("请输入内容");
            }
            else
            {
                Dbcontrol dbc01 = new Dbcontrol();
                string strEx;
                if (rdoSingle.Checked)
                {
                    strEx = "insert into [sheet1$] (名称,解释) VALUES('" + txtName.Text.Trim() + "','" + txtExplain.Text.Trim() + "')";
                    MessageBox.Show(dbc01.ReExNum(strEx) > 0 ? "添加成功！" : "添加失败！");
                }
                else
                {
                    int succNum = 0;
                    string[] charSplit = { "\r\n" };
                    string[] strContFirst = txtExplain.Text.Split(charSplit, StringSplitOptions.None);
                    for (int i = 0; i < strContFirst.Length - 1; i++)
                    {
                        string[] strContSecond = strContFirst[i].Split(txtName.Text[0]);
                        strEx = "insert into [sheet1$] (名称,解释) VALUES('" + strContSecond[0] + "','" + strContSecond[1] + "')";
                        if (dbc01.ReExNum(strEx) > 0)
                        {
                            succNum += 1;
                        }
                    }
                    MessageBox.Show("成功添加了【" + succNum + "】条记录。", "成功提示");
                }
                ClearForm();
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Dispose();
            Close();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {

            ClearForm();

        }
        protected void ClearForm()
        {
            txtExplain.Text = "";
            txtName.Text = "";
        }

        private void rdoSingle_CheckedChanged(object sender, EventArgs e)
        {
            RdoChange();
        }
        protected void RdoChange()
        {
            if (rdoSingle.Checked)
            {
                lblName.Text = "名称：";
                lblName.Left += 10;
                lblExplain.Text = "解释：";
                ttMain.SetToolTip(txtName, "");
                ttMain.SetToolTip(txtExplain, "");
            }
            else
            {
                lblName.Text = "分割符：";
                lblExplain.Text = "记录：";
                lblName.Left -= 10;
                ttMain.SetToolTip(txtName, "名称与解释之间的分割符，比如\\d 数字，那么分割符是空格[ ]\n分割符仅提取输入的第一个字符。");
                ttMain.SetToolTip(txtExplain, "一行一条记录");
            }
        }

    }
}