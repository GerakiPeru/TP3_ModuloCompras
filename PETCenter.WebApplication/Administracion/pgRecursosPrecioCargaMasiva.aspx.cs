using Microsoft.Office.Interop.Excel;
using PETCenter.Entities.Common;
using PETCenter.Entities.Compras;
using PETCenter.Logic.Compras;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PETCenter.WebApplication.Administracion
{
    public partial class pgRecursosPrecioCargaMasiva : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public string[] GetRange(string range, Worksheet excelWorksheet)
        {
            Microsoft.Office.Interop.Excel.Range workingRangeCells =
              excelWorksheet.get_Range(range, Type.Missing);
            //workingRangeCells.Select();

            System.Array array = (System.Array)workingRangeCells.Cells.Value2;
            string[] arrayS = this.ConvertToStringArray(array);

            return arrayS;
        }

        string[] ConvertToStringArray(System.Array values)
        {

            // create a new string array
            string[] theArray = new string[values.Length];

            // loop through the 2-D System.Array and populate the 1-D String Array
            for (int i = 1; i <= values.Length; i++)
            {
                if (values.GetValue(1, i) == null)
                    theArray[i - 1] = "";
                else
                    theArray[i - 1] = (string)values.GetValue(1, i).ToString();
            }

            return theArray;
        }

        protected void btnCargar_Click(object sender, EventArgs e)
        {
            Boolean fileOK = false;
            String path = "F:\\Data\\"; //Server.MapPath(@"~/File/");
            if (FileUploadPlantilla.HasFile) 
            {
                String fileExtension = System.IO.Path.GetExtension(FileUploadPlantilla.FileName).ToLower();
                String[] allowedExtensions = {".xls"};
                for (int i = 0; i < allowedExtensions.Length; i++)
                {
                    if (fileExtension == allowedExtensions[i])
                    {
                        fileOK = true;
                    }
                }
            }
            if (fileOK)
            {
                try
                {
                    System.Web.HttpContext.Current.Session[Constant.resursoproveedor] = null;
                    FileUploadPlantilla.PostedFile.SaveAs(path + FileUploadPlantilla.FileName);
                    try 
                    {

                        string sArchivo = path + FileUploadPlantilla.FileName;

                        Microsoft.Office.Interop.Excel.Application app = new Microsoft.Office.Interop.Excel.Application();

                        Microsoft.Office.Interop.Excel.Workbook wb = app.Workbooks.Open(
                            sArchivo, Type.Missing, Type.Missing, Type.Missing, Type.Missing,
                                Type.Missing, Type.Missing, Type.Missing, Type.Missing,
                                Type.Missing, Type.Missing, Type.Missing, Type.Missing,
                                Type.Missing, Type.Missing);

                        Worksheet sheet = (Worksheet)wb.Sheets["Sheet0"];

                        Range excelRange = sheet.UsedRange;
                        List<RecursoProveedor> ocol = new List<RecursoProveedor>();
                        int index = 0;
                        foreach (Microsoft.Office.Interop.Excel.Range row in excelRange.Rows)
                        {
                            int rowNumber = row.Row;
                            string[] A4D4 = GetRange("A" + rowNumber + ":D" + rowNumber + "", sheet);

                            blCompras bl = new blCompras();
                            Transaction transaction = Common.InitTransaction();
                            int result = 0;
                            decimal _valorUnitario;
                            bool isNumeric = decimal.TryParse(A4D4[2], out _valorUnitario);

                            RecursoProveedor recursoproveedor = new RecursoProveedor();
                            recursoproveedor.presentacionrecurso = new PresentacionRecurso();
                            recursoproveedor.presentacionrecurso.codigo = A4D4[0];
                            recursoproveedor.presentacionrecurso.descripcion = A4D4[1];
                            recursoproveedor.proveedor = new Proveedor();
                            recursoproveedor.proveedor.Codigo = A4D4[3];
                            if (!isNumeric)
                            {
                                recursoproveedor.valorUnitario = 0;
                                recursoproveedor.desactivo = "ERROR: El valor unitario no tiene el formato correcto";
                            }
                            else 
                            {
                                recursoproveedor.valorUnitario = _valorUnitario;
                                result = bl.ActualizarRecursoProveedorCargaMasiva(recursoproveedor, out transaction);
                                if (transaction.type == TypeTransaction.OK)
                                {
                                    recursoproveedor.desactivo = "OK: Registro Cargado correctamente";
                                }
                                else
                                {
                                    recursoproveedor.desactivo = string.Format("ERROR: {0}", transaction.message);
                                }
                                
                            }                            
                            if (index != 0)
                                ocol.Add(recursoproveedor);
                            index++;


                        }
                        //app = null;
                        System.Web.HttpContext.Current.Session[Constant.resursoproveedor] = ocol;
                        foreach (Process clsProcess in Process.GetProcesses())
                            if (clsProcess.ProcessName.Equals("EXCEL"))  //Process Excel?
                                clsProcess.Kill();

                        Page.ClientScript.RegisterStartupScript(this.GetType(), "showSuccessChild", "parent.GetRecursoProveedorTempCargaMasiva();parent.showSuccess('Se realizó la carga de lista de Precios');", true);
                    }
                    catch (Exception childex) 
                    {
                        foreach (Process clsProcess in Process.GetProcesses())
                            if (clsProcess.ProcessName.Equals("EXCEL"))  //Process Excel?
                                clsProcess.Kill();
                        Page.ClientScript.RegisterStartupScript(this.GetType(), "showErrorChild",
                        string.Format("parent.showError('{0}');", childex.Message), true);
                    }
                    
                }
                catch (Exception ex)
                {
                    foreach (Process clsProcess in Process.GetProcesses())
                        if (clsProcess.ProcessName.Equals("EXCEL"))  //Process Excel?
                            clsProcess.Kill();
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "showErrorChild", 
                        string.Format("parent.showError('{0}');",ex.Message), true);
                }
            }
            else
            {
                foreach (Process clsProcess in Process.GetProcesses())
                    if (clsProcess.ProcessName.Equals("EXCEL"))  //Process Excel?
                        clsProcess.Kill();
                Page.ClientScript.RegisterStartupScript(this.GetType(), "showErrorChild",
                        string.Format("parent.showError('{0}');", "No ha sido posible procesar el archivo"), true);
            }
        }
    }
}