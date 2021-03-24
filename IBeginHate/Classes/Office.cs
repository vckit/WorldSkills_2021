using IBeginHate.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Word = Microsoft.Office.Interop.Word;

namespace IBeginHate.Classes
{
    class Office
    {
        void ToWord()
        {
            var word = new Word.Application();
            var document = word.Documents.Open(Environment.CurrentDirectory + @"\" + "Template.docx");
            try
            {
                var table = document.Tables[1];

                var service = AppData.db.Service.ToList();
                int i = 2;
                foreach (var item in service)
                {
                    table.Rows.Add();
                    table.Cell(i, 1).Range.Text = item.Title;
                    table.Cell(i, 2).Range.Text = item.DurationInDays.ToString();
                    i++;

                }

                document.SaveAs2(@"C:\Users\Domovski\Desktop\template.pdf", Word.WdSaveFormat.wdFormatPDF);
                document.Close(Word.WdSaveOptions.wdDoNotSaveChanges);
                word.Quit(Word.WdSaveOptions.wdDoNotSaveChanges);
                
           }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error!");
                document.Close(Word.WdSaveOptions.wdDoNotSaveChanges);
            }

        }
    }
}
