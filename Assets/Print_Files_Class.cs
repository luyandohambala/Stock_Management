using Spire.Pdf;
using Stock_Management.Assets.Pages;
using Stock_Management.Assets.ViewModel;
using System.Collections.ObjectModel;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Printing;
using System.Reflection;
using System.Windows;
using System.Windows.Controls;
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

        public static bool print_quote_invoice(ObservableCollection<Quotation_Lists> list, string type)
        {
            var to_print = string.Empty;

            if (type == "quote")
            {
                var variable = new Print_Files_Class();
                to_print = variable.prepare_quotation_invoice(list, Settings_Page_ViewModel.quotation_template, type);

                if (Settings_Page_ViewModel.printer_name != "Not set" && Settings_Page_ViewModel.quotation_template != "Not set" && !string.IsNullOrEmpty(to_print))
                {
                    PdfDocument pdf = new(to_print);
                    pdf.PrintSettings.PrinterName = Settings_Page_ViewModel.printer_name;
                    pdf.Print();

                    return true;
                }
                else
                {
                    MessageBox.Show("Invoice/Quotation printer name or template not configured. Aborting print.");
                    return false;
                }
            }
            else if (type == "invoice")
            {
                to_print = new Print_Files_Class().prepare_quotation_invoice(list, Settings_Page_ViewModel.invoice_template, type);

                if (Settings_Page_ViewModel.printer_name != "Not set" && Settings_Page_ViewModel.invoice_template != "Not set" && !string.IsNullOrEmpty(to_print))
                {
                    PdfDocument pdf = new(to_print);
                    pdf.PrintSettings.PrinterName = Settings_Page_ViewModel.printer_name;
                    pdf.Print();

                    return true;
                }
                else
                {
                    MessageBox.Show("Invoice/Quotation printer name or template not configured. Aborting print.");
                    return false;
                }
            }
            return false;


        }

        private string prepare_quotation_invoice(ObservableCollection<Quotation_Lists> list, string filelocation, string type)
        {
            try
            {
                Word_App.Visible = false;
                Word_Document =
                Word_App.Documents.Open(filelocation, Missing.Value, Missing.Value, Missing.Value, Missing.Value,
                Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value,
                Missing.Value, Missing.Value, Missing.Value);

                Word.Table table = Word_Document.Tables[1];

                for (int i = 2; i <= list.Count + 1; i++)
                {
                    table.Rows.Add(Missing.Value);
                    table.Cell(i, 1).Range.Text = list[i - 2].Quantity2.ToString();
                    table.Cell(i, 2).Range.Text = list[i - 2].Description;
                    table.Cell(i, 3).Range.Text = list[i - 2].Unit_price;
                    table.Cell(i, 4).Range.Text = list[i - 2].Row_total_price;

                }

                string save_location = string.Empty;

                FindAndReplace("[Q\\INo.]", Quotation_Page_ViewModel.quotation_number);
                FindAndReplace("[Date]", DateTime.Now.ToString("d/MM/yyyy"));

                if (type == "quote")
                {
                    FindAndReplace("[Inq_Number]", "        ");
                    save_location = System.IO.Path.GetFullPath($@".\Assets\History\Quotation\Quotation_{Quotation_Page_ViewModel.quotation_number}.pdf");
                }
                else if (type == "invoice")
                {
                    FindAndReplace("[Inq_Number]", Quotation_Page_ViewModel.invoice_reference_number);
                    save_location = System.IO.Path.GetFullPath($@".\Assets\History\Invoice\Invoice_{Quotation_Page_ViewModel.quotation_number}.pdf");
                }

                FindAndReplace("[Subtotal]", $"{Quotation_Page_ViewModel.quot_total_price:N2}");
                
                if (!string.IsNullOrEmpty(Quotation_Page_ViewModel.tax_value))
                {
                    FindAndReplace("[Taxed_amount]", Convert.ToDouble(Quotation_Page_ViewModel.tax_value.Replace("VAT: ", "")).ToString("N2"));
                    FindAndReplace("[total_amount]", $"{Quotation_Page_ViewModel.quot_total_price + Convert.ToDouble(Quotation_Page_ViewModel.tax_value.Replace("VAT: ", "")):N2}");
                }
                else
                {
                    FindAndReplace("[Taxed_amount]", "");
                    FindAndReplace("[total_amount]", $"{Quotation_Page_ViewModel.quot_total_price + 0:N2}");
                }

                FindAndReplace("[Tax]", Settings_Page_ViewModel.value_added_tax);
                FindAndReplace("[Currency]", Settings_Page_ViewModel.currency_);
                

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

        /// <summary>
        /// receipt printing section
        /// </summary>
        /// <param name="file_location"></param>
        /// <returns></returns>

        public static bool print_receipt(ObservableCollection<checkout_list> list, string total_amount)
        {
            var to_print = new Print_Files_Class().prepare_document(list, Settings_Page_ViewModel.receipt_template, total_amount);

            if (Settings_Page_ViewModel.receipt_printer != "Not set" && Settings_Page_ViewModel.receipt_template != "Not set" && !string.IsNullOrEmpty(to_print))
            {
                PdfDocument pdf = new(to_print);
                pdf.PrintSettings.PrinterName = Settings_Page_ViewModel.receipt_printer;
                pdf.Print();

                return true;
            }
            else
            {
                MessageBox.Show("Receipt printer name or template not configured. Aborting print.");
                return false;
            }
            
        }

        private string prepare_document(ObservableCollection<checkout_list> list, string filelocation, string total_amount)
        {

            try
            {
                Word_App.Visible = false;
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

                FindAndReplace("[Currency]", Settings_Page_ViewModel.currency_);
                FindAndReplace("[total_amount]", total_amount);
                FindAndReplace("[Cashier]", MainWindow.Current_user);
                FindAndReplace("[Date]", DateTime.Now);

                string save_location = System.IO.Path.GetFullPath($@".\Assets\History\Receipt\Receipt_{DateTime.Now:d-MM-yyyy}.pdf");


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

        /// <summary>
        /// sale report function below
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        public bool prepare_report(ObservableCollection<Sales_list_Class> list)
        {
            try
            {
                string filelocation = System.IO.Path.GetFullPath(@"./Assets/Templates/Report/Sale Report Template.docx");

                Word_App.Visible = false;
                Word_Document =
                Word_App.Documents.Open(filelocation, Missing.Value, Missing.Value, Missing.Value, Missing.Value,
                Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value,
                Missing.Value, Missing.Value, Missing.Value);

                Word.Table table = Word_Document.Tables[1];

                var date = DateTime.Now.ToString("d/MM/yyyy");

                FindAndReplace("[Date]", date);

                for (int i = 2; i <= list.Count + 1; i++)
                {
                    table.Rows.Add(Missing.Value);
                    table.Cell(i, 1).Range.Text = list[i - 2].Date;
                    table.Cell(i, 2).Range.Text = list[i - 2].Item_name;
                    table.Cell(i, 3).Range.Text = list[i - 2].Item_quantity;
                    table.Cell(i, 4).Range.Text = list[i - 2].Amount;
                    table.Cell(i, 5).Range.Text = list[i - 2].Change;
                    table.Cell(i, 6).Range.Text = list[i - 2].Profit;
                    table.Cell(i, 7).Range.Text = list[i - 2].Cashier;

                }

                FindAndReplace("[Currency]", Settings_Page_ViewModel.currency_);

                double total_cost = 0;
                double total_profit = 0;
                
                foreach (var item in list)
                {
                    total_cost += Convert.ToDouble(item.Amount.Replace(Settings_Page_ViewModel.currency_, ""));
                    total_profit += Convert.ToDouble(item.Profit.Replace(Settings_Page_ViewModel.currency_, ""));
                }

                FindAndReplace("[Total_Sales]", list.Where(x => DateTime.Parse(x.Date).ToString("d/MM/yyyy") == date).Count());
                FindAndReplace("[Total_Cost]", $"{Settings_Page_ViewModel.currency_}{total_cost:N2}");
                FindAndReplace("[Total_Profit]", $"{Settings_Page_ViewModel.currency_}{total_profit:N2}");
                FindAndReplace("[Cashier]", MainWindow.Current_user);
                

                string save_location = System.IO.Path.GetFullPath($@".\Assets\Sale Reports\Report_{DateTime.Parse(date):d-MM-yyyy}.pdf");


                Word_Document.ExportAsFixedFormat(save_location, Word.WdExportFormat.wdExportFormatPDF);

                Word_Document.Close(Word.WdSaveOptions.wdDoNotSaveChanges, Word.WdOriginalFormat.wdOriginalDocumentFormat, false);
                Word_App.Quit(Word.WdSaveOptions.wdDoNotSaveChanges);

                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error code: {ex.Message}. Please try again later.");
                return false;
            }
        }
    }

}
