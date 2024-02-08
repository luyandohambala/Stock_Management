using Stock_Management.Assets.Pages;
using Stock_Management.Assets.ViewModel;
using System.Collections.ObjectModel;
using System.Drawing.Printing;
using System.Reflection;
using System.Windows;
using Word = Microsoft.Office.Interop.Word;

namespace Stock_Management.Assets
{
    internal class Print_Files_Class
    {

        /// <summary>
        /// print quotation/invoice method
        /// </summary>
        

        Word.Application Word_App = new();
        Word.Document Word_Document;
        object objectMiss = Missing.Value;
        object FileLocation;


        public static bool print_quote_invoice(string file_location)
        {
            if (Settings_Page_ViewModel.printer_name != "Not set")
            {
                PrintDocument printDocument = new();
                printDocument.PrinterSettings.PrinterName = Settings_Page_ViewModel.printer_name;
                printDocument.DocumentName = file_location;
                printDocument.Print();
                return true;
            }
            return false;
        }

        public static bool print_receipt(ObservableCollection<checkout_list> list, string total_amount)
        {
            var to_print = new Print_Files_Class().prepare_document(list, @"I:\j\c#\Stock_Management\bin\Debug\net7.0-windows\Assets\Templates\Receipt\template.docx", total_amount);

            if (Settings_Page_ViewModel.receipt_printer != "Not set" && Settings_Page_ViewModel.receipt_template != "Not set" && !string.IsNullOrEmpty(to_print))
            {
                PrintDocument printDocument = new();
                printDocument.PrinterSettings.PrinterName = Settings_Page_ViewModel.receipt_printer;
                printDocument.DocumentName = to_print;
                printDocument.Print();
                return true;
            }
            else
            {
                MessageBox.Show("Receipt printer name or template not configured. Aborting print.");
                return false;
            }
            
        }

        public string prepare_document(ObservableCollection<checkout_list> list, string filelocation, string total_amount)
        {

            try
            {
                Word_Document =
                Word_App.Documents.Open(filelocation, Missing.Value, Missing.Value, Missing.Value, Missing.Value,
                Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value,
                Missing.Value, Missing.Value, Missing.Value);
                
                Word.Table table = Word_Document.Tables[1];

                for (int i = 2; i <= list.Count + 1; i++)
                {
                    table.Rows.Add(Missing.Value);
                    table.Cell(i, 1).Range.Text = list[i - 2].Quantity.ToString();
                    table.Cell(i, 2).Range.Text = list[i - 2].Item_name;
                    table.Cell(i, 3).Range.Text = list[i - 2].Item_price;

                }

                FindAndReplace("[total_amount]", total_amount);
                FindAndReplace("[Cashier]", MainWindow.Current_user);
                FindAndReplace("[Date]", DateTime.Now);

                string save_location = $@"/History/Receipt/Receipt.pdf";

                Word_Document.ExportAsFixedFormat(save_location, Word.WdExportFormat.wdExportFormatPDF);

                Word_Document.Close(Word.WdSaveOptions.wdDoNotSaveChanges, Word.WdOriginalFormat.wdOriginalDocumentFormat, false);
                Word_App.Quit(Word.WdSaveOptions.wdDoNotSaveChanges);

                return save_location;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error code: {ex.Message}. Please try again later.");
                return string.Empty;
            }
            
        }

        private void FindAndReplace(object FindText, object ReplaceText)
        {
            Word_App.Selection.Find.Execute(FindText, false, true, false, false, false, true, false, 1, ReplaceText, 2, false, false, false, false);
        }
    }

}
