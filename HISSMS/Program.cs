using System;
using System.Collections.Generic;
using System.Windows.Forms;
using DevExpress.LookAndFeel;

namespace HISSMS
{
    
    static class Program
    {
        public static String PQ;
        //Create a variabel to store result
        public static DialogResult Rslt;
        
        //create a property to assign values to the rslt variable
        public static DialogResult Rsltt
        {
            get
            {
                return Rslt;
            }
            set
            {
                Rslt = value;
            }
        }

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();

            Application.SetCompatibleTextRenderingDefault(false);
            
            Start();
        }
        //DevExpress.Skins.SkinManager.EnableFormSkins();
        //DevExpress.UserSkins.BonusSkins.Register();
        //UserLookAndFeel.Default.SetSkinStyle("DevExpress Style");
        
        public static void Start()
        {
            FormHISSMS f = new FormHISSMS();
            //MessageBox.Show(PQ);
            
            
            Application.Run(new Form_DangNhap());
            if (DialogResult.OK == Rslt)
            {
                if (PQ == "bhyt")
                {

                    f.ribbonPage1.Visible = true;
                }
                if (PQ == "admin")
                {

                    f.ribbonPage1.Visible = true;
                    f.ribbonPage4.Visible = true;
                    f.ribbonPage3.Visible = true;
                    


                }
                Application.Run(f);
                
                //FormHISSMS Form2 = new FormHISSMS();
                //Form2.Show();
                //Form2.ribbonPage1.Visible = true;
            }
            else
            {
                Application.Exit();
            }
        }
        
        }
    }
