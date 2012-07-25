using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using DataContext;
using System.Data.Entity;
using Annon.Zutu;
using Annon.Xuanxing;
using Annon.Module_Detail;
using System.Collections;

namespace Annon
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点;
        /// </summary>
        [STAThread]
        static void Main()
        {

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Database.SetInitializer<AnnonContext>(new AnnonInitializer());
            //Application.Run(new AddNewUnit());

            //Application.Run(new AAonRating());

            //Application.Run(new AAonRating());


            //Application.Run(new Form2());


         //Application.Run(new AddNewUnit());



            Application.Run(new AAonRating());

            // Application.Run(new OperatePhoto());


            //Application.Run(new Form2());

        }
    }
}
