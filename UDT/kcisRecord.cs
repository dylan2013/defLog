using FISCA.UDT;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace defLog
{
    /// <summary>
    /// 學生其他資料
    /// </summary>
    [TableName("student.phone")]
    class kcisRecord : ActiveRecord
    {
        /// <summary>
        /// 學生系統編號
        /// </summary>
        [Field(Field = "ref_student_id")]
        public string StudentID { get; set; }

        /// <summary>
        /// 學生手機號碼
        /// </summary>
        [Field(Field = "student_phone")]
        public string StudentPhone { get; set; }
    }
}
