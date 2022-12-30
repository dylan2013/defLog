using FISCA;
using FISCA.Presentation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace defLog
{
    public class Program
    {
        [MainMethod()]
        static public void Main()
        {

            RibbonBarItem Print = FISCA.Presentation.MotherForm.RibbonBarItems["學生", "康橋"];
            Print["輸入學生手機號碼"].Click += delegate
            {
                TextIntputForm tiForm = new TextIntputForm();
                tiForm.ShowDialog();
            };
        }
    }
}
