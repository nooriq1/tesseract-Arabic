using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace myproject
{
    public partial class ConfirmIdentity : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            bool find = false;
            string path1 = @"C:\Users\asus\Desktop\my project\main\myproject\myproject\img\output_text_file.txt.txt";
            

            if (FileUpload1.HasFile )
            {
                string fileName = Path.GetFileName(FileUpload1.FileName);
                string uploadDirectory = Server.MapPath("~/img"); // Define the upload directory

                FileUpload1.SaveAs(Path.Combine(uploadDirectory, fileName));

                // Updated Tesseract path for Arabic language
                string tesseractPath = @"C:\Program Files\Tesseract-OCR\tesseract.exe";
                string inputFile = Path.Combine(uploadDirectory, fileName);
                string outputFile = Path.Combine(uploadDirectory, "output_text_file.txt");
                string arguments = "\"" + inputFile + "\" \"" + outputFile + "\" -l ara";

                var processInfo = new System.Diagnostics.ProcessStartInfo(tesseractPath, arguments)
                {
                    RedirectStandardOutput = true,
                    UseShellExecute = false,
                    CreateNoWindow = true
                };

                var process = new System.Diagnostics.Process { StartInfo = processInfo };
                process.Start();
                process.WaitForExit();

                // Read the text from the output file
                string extractedText = File.ReadAllText(@"C:\Users\asus\Desktop\my project\main\myproject\myproject\img\output_text_file.txt.txt");

                // Print or use the extracted text
                //Response.Write("Extracted Text: " + extractedText);

                string path = @"C:\Users\asus\Desktop\my project\main\myproject\myproject\img\output_text_file.txt.txt";

                if (File.Exists(path))
                {
                    string[] lines= File.ReadAllLines(path);
                    int count = 0;
                    

                    foreach (string line in lines)
                    {


                        if (line.Contains(TextBox1.Text))
                        {
                            ViewState["name"] = line;    
                            find = true;

                        }

                        count++;
                    }
                    


                }
                else
                {

                    Response.Write("File not found or incorrect path");
                }





            }
            else
            {
                Response.Write("fill all data");
            }


            if (find)
            {

                Response.Write(" done");

            }
            else
            {
                Response.Write("not done");
            }


        }
    }
}