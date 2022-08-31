using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.IO;
using Excel = Microsoft.Office.Interop.Excel;
using System.Reflection;

namespace XMLcheckApp
{
    public partial class Form1 : Form
    {
        struct device
        {
            public string name;
            public string index;
        }
        List<device> deviceList = new List<device>();

        XmlDocument xmlDoc = new XmlDocument();
        string xmlPath = "";
        string excelPath = "";
        string excelPath2 = "";
        object misValue = Missing.Value;
        Excel.Application excelApp;
        Excel.Workbook excelWb;
        Excel.Worksheet excelWs;
        int row = 1;
        int col = 1;

        public Form1()
        {
            InitializeComponent();
            buttonGetDataCSExcel.Enabled = false;
            toolStripSL.Text = "Select or type zenon exported XML path";
        }

        private void buttonSearch_Click(object sender, EventArgs e)
        {
            xmlPath = OpenFile(1);
            textBoxXmlPath.Text = xmlPath;
            toolStripSL.Text = "Selected file: " + xmlPath + " Select operation on XML.";
        }
        private string OpenFile(int type) // 1- xml, 2 - xlsx
        {
            string filePath = "";
            if (type == 1)
            {
                OpenFileDialog openFileDialog1 = new OpenFileDialog
                {
                    InitialDirectory = @"c:\Users\localadm\Desktop",
                    Title = "Select XML file",
                    CheckFileExists = true,
                    CheckPathExists = true,
                    DefaultExt = "xml",
                    Filter = "Xml file (*.xml)|*.xml",
                    RestoreDirectory = true,
                    ReadOnlyChecked = true,
                    ShowReadOnly = true,
                };

                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    filePath = openFileDialog1.FileName;
                }
            }
            if (type == 2)
            {
                OpenFileDialog openFileDialog1 = new OpenFileDialog
                {
                    InitialDirectory = @"c:\Users\localadm\Desktop",
                    Title = "Select XLS file",
                    CheckFileExists = true,
                    CheckPathExists = true,
                    DefaultExt = "xlsm",
                    Filter = "Excel file with macro (*.xlsm)|*.xlsm",
                    RestoreDirectory = true,
                    ReadOnlyChecked = true,
                    ShowReadOnly = true,
                };

                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    filePath = openFileDialog1.FileName;
                }
            }
            return filePath;
        }

        private void buttonCheckXml_Click(object sender, EventArgs e)
        {
            toolStripSL.Text = "Processing...";
            if (xmlPath.Length > 0)
            {
                excelApp = new Excel.Application();
                excelWb = excelApp.Workbooks.Add(misValue);
                excelWs = excelApp.Worksheets[1];
                row = 3;
                col = 1;
                xmlDoc.Load(xmlPath);
                SearchXml(xmlDoc.DocumentElement, excelWs, 1);
                (excelWs.Cells[1, 1] as Excel.Range).Select();
                SortExcelByCol(excelWs, 2);
                (excelWs.Cells[1, 1] as Excel.Range).Value = "ZENON EXPORT:";
                (excelWs.Cells[2, 1] as Excel.Range).Value = "DEVICE:";
                (excelWs.Cells[2, 2] as Excel.Range).Value = "INDEX:";
                excelPath = xmlPath.Substring(0, xmlPath.Length - 4) + "_CS_NO.xlsx";

                excelWb.SaveAs(excelPath);
                excelWb.Close();
                excelApp.Quit();
                buttonCheckXml.Text = "DONE";
                toolStripSL.Text = "Done. Results saved in Excel File: " + excelPath;
                buttonGetDataCSExcel.Enabled = true;
            }
            else
            {
                MessageBox.Show("Select XML File or type path of it");
            }
        }
        private void SearchXml(XmlNode sourceNode, Excel.Worksheet ws, int functionType)
        {
            //Description:
            //type 1 - get CS indexes
            //type 2 - get Dynamic Textes

            foreach (XmlNode myNode in sourceNode.ChildNodes)
            {
                //type 1 - get CS indexes
                if (functionType == 1)
                {
                    if (myNode.Name.Contains("Elements_"))
                    {
                        string elementName = "";
                        string elementCSIndex = "";

                        foreach (XmlNode childNode in myNode.ChildNodes)
                        {
                            if (String.Equals(childNode.Name, "Name"))
                            {
                                elementName = childNode.InnerText;
                            }
                            if (String.Equals(childNode.Name, "SubstituteDestination"))
                            {
                                elementCSIndex = childNode.InnerText;
                            }
                        }
                        if (elementCSIndex.Contains("[") && elementCSIndex.Contains("]"))
                        {
                            string tempText1, tempText2 = "";
                            tempText1 = elementCSIndex.Substring(0, elementCSIndex.Length - 1);
                            tempText2 = tempText1.Substring(1, tempText1.Length - 1);
                            (ws.Cells[row, col] as Excel.Range).Value = elementName;
                            (ws.Cells[row, col + 1] as Excel.Range).Value = tempText2;
                            row++;
                        }
                    }
                }

                //type 2 - get Dynamic Textes
                if (functionType == 2)
                {
                    if (myNode.Name.Contains("Text"))
                    {
                        string dynText = myNode.InnerText;
                        if (dynText.Contains("@"))
                        {
                            (ws.Cells[row, col] as Excel.Range).Value = dynText;
                            (ws.Cells[row, col + 1] as Excel.Range).Value = dynText.Substring(1, dynText.Length - 1);
                            row++;
                        }

                    }
                }
            }
            foreach (XmlNode childNode in sourceNode.ChildNodes)
            {
                SearchXml(childNode, ws, functionType);
            }


        }
        private void buttonGetDynText_Click(object sender, EventArgs e)
        {
            toolStripSL.Text = "Processing...";
            if (xmlPath.Length > 0)
            {
                excelApp = new Excel.Application();
                excelWb = excelApp.Workbooks.Add(misValue);
                excelWs = excelApp.Worksheets[1];
                (excelWs.Cells[1, 1] as Excel.Range).Value = "DYNAMIC TEXTS:";
                (excelWs.Cells[1, 2] as Excel.Range).Value = "ENG TEXTS:";
                row = 2;
                col = 1;
                xmlDoc.Load(xmlPath);
                SearchXml(xmlDoc.DocumentElement, excelWs, 2);
                excelPath = xmlPath.Substring(0, xmlPath.Length - 4) + "_TEXT.xlsx";
                excelWb.SaveAs(excelPath);
                excelWb.Close();
                excelApp.Quit();
                buttonGetDynText.Text = "DONE";
                toolStripSL.Text = "Done. Results saved in Excel File: " + excelPath;
            }
            else
            {
                MessageBox.Show("Select XML File or type path of it");
            }
        }
        private void SortExcelByCol(Excel.Worksheet ws, int col)
        {
            ws.UsedRange.Select();
            ws.Sort.SortFields.Clear();
            ws.Sort.SortFields.Add(ws.UsedRange.Columns[col], Excel.XlSortOn.xlSortOnValues, Excel.XlSortOrder.xlAscending, Type.Missing, Excel.XlSortDataOption.xlSortNormal);
            var sort = ws.Sort;
            sort.SetRange(ws.UsedRange);
            //sort.Header = Excel.XlYesNoGuess.xlYes; - no header
            sort.MatchCase = false;
            sort.Orientation = Excel.XlSortOrientation.xlSortColumns;
            sort.SortMethod = Excel.XlSortMethod.xlPinYin;
            sort.Apply();
        }
        private string doubleToStringName(double devNo)
        {
            string devNoString = "";
            devNoString = devNo.ToString();
            return devNoString;
        }
        private string convertToString(Excel.Range cell)
        {
            string result = "";
            if (cell.Value is double)
            {
                result = doubleToStringName(cell.Value);
            }
            else result = (string)cell.Value;
            return result;
        }

        private void buttonGetDataCSExcel_Click(object sender, EventArgs e)
        {
            if (excelPath.Length > 1)
            {
                row = 4;
                col = 6;
                int index = 0;
                string cell = "";
                string cell2 = "";

                excelPath2 = OpenFile(2);
                toolStripSL.Text = "Processing...";
                excelApp = new Excel.Application();
                excelWb = excelApp.Workbooks.Open(excelPath2, false, true);
                excelWs = excelApp.Worksheets["ResultX"];
                excelApp.Visible = false;
                cell = convertToString(excelWs.Cells[row, col] as Excel.Range);
                do
                {
                    if (cell != null)
                    {
                        if (cell.Length > 0)
                        {
                            deviceList.Add(new device());
                            var dev = deviceList[index];
                            dev.name = cell;
                            cell2 = convertToString(excelWs.Cells[row, col + 4] as Excel.Range);
                            dev.index = cell2;
                            deviceList[index] = dev;
                            index++;
                        }
                    }
                    row++;
                    cell = convertToString(excelWs.Cells[row, col] as Excel.Range);
                }
                while (row <= 800);
                excelWb.Close();
                excelWb = excelApp.Workbooks.Open(excelPath);
                excelWs = excelApp.Worksheets[1];
                row = 3;
                col = 4;

                for (int i = 0; i <= deviceList.Count - 1; i++)
                {
                    var tempDev = deviceList[i];
                    (excelWs.Cells[row, col] as Excel.Range).Value = tempDev.name;
                    (excelWs.Cells[row, col + 1] as Excel.Range).Value = tempDev.index;
                    row++;
                }
                (excelWs.Cells[1, 4] as Excel.Range).Value = "CS EXCEL:";
                (excelWs.Cells[2, 4] as Excel.Range).Value = "DEVICE";
                (excelWs.Cells[2, 5] as Excel.Range).Value = "INDEX";
                excelWb.SaveAs(excelPath);
                excelWb.Close();
                excelApp.Quit(); 
                buttonGetDataCSExcel.Text = "DONE";
                toolStripSL.Text = "Done. Results saved in Excel File: " + excelPath;
            }
            else
            {
                MessageBox.Show("Operation 1 must be done to select this Operation!");
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
