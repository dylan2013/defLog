using FISCA.LogAgent;
using FISCA.Presentation.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace defLog
{
    public partial class TextIntputForm : BaseForm
    {
        kcisRecord kcisRecord { get; set; }
        string StudentID { get; set; }

        FISCA.UDT.AccessHelper access = new FISCA.UDT.AccessHelper();

        public TextIntputForm()
        {
            InitializeComponent();

            List<string> StudentIDList = K12.Presentation.NLDPanels.Student.SelectedSource;

            if (StudentIDList.Count == 1)
            {
                StudentID = StudentIDList[0];
                List<kcisRecord> kcisList = access.Select<kcisRecord>(string.Format("ref_student_id='{0}'", StudentID));

                if (kcisList.Count > 0)
                {
                    tbStudentPhone.Text = kcisList[0].StudentPhone;
                    kcisRecord = kcisList[0];
                }
            }
            else
            {
                MsgBox.Show("請選擇一個學生!");
                this.Close();
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            StringBuilder sb_log = new StringBuilder();

            if (kcisRecord == null)
            {
                //新增
                kcisRecord kcis = new kcisRecord();
                kcis.StudentPhone = tbStudentPhone.Text;
                kcis.StudentID = StudentID;

                List<kcisRecord> SaveList = new List<kcisRecord>();
                SaveList.Add(kcis);

                access.InsertValues(SaveList);

                //沒有電話的時候,新增資料
                sb_log.AppendLine("新增學生電話資料:");
                sb_log.AppendLine(kcis.StudentPhone);
            }
            else
            {
                //更新或刪除
                if (string.IsNullOrEmpty(tbStudentPhone.Text))
                {
                    sb_log.AppendLine("刪除學生電話資料:");

                }
                else
                {
                    //有電話資料,則更新資料
                    sb_log.AppendLine("更新學生電話資料:");
                    sb_log.AppendLine(string.Format("由 {0} 變更為 {1}", kcisRecord.StudentPhone, tbStudentPhone.Text));

                    kcisRecord.StudentPhone = tbStudentPhone.Text;
                    kcisRecord.Save();

                }

            }

            //student , class , teacher , course
            ApplicationLog.Log("學生電話資料", "修改", "student", StudentID, sb_log.ToString());

            MsgBox.Show("儲存成功!");
        }
    }
}
