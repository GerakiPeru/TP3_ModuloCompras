<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="pgRecursosPrecioCargaMasiva.aspx.cs" Inherits="PETCenter.WebApplication.Administracion.pgRecursosPrecioCargaMasiva" %>
<form id="form1" runat="server">
<link href="/Content/css/home.css" rel="stylesheet" type="text/css" />

<link href="/Content/css/font-talma.min.css" rel="stylesheet" type="text/css" />
<style> 
    table, th, td { border: 0px ; padding: 0px; } 
    table { border-spacing: 0px; } 
</style>
<script type="text/javascript" language="javascript">
    function checkfile(sender) {
        var validExts = new Array(".xls");
        var fileExt = sender.value;
        fileExt = fileExt.substring(fileExt.lastIndexOf('.'));
        if (validExts.indexOf(fileExt) < 0) {
            parent.showError("No ha sido posible procesar el archivo");
            sender.value = "";
            return false;
        }
        else return true;
    }
</script>
<div style="margin:0px;">    
    <table style="width:100%">
        <tr>
            <td>
                <asp:FileUpload ID="FileUploadPlantilla" onchange="checkfile(this);" runat="server" CssClass="upload-buttom" accept=".xls" />   
            </td>
            <td>
                <div class="home-buttom" style="width:90px; height:20px;" 
                    onclick="document.getElementById('<%=btnCargar.ClientID%>').click();">
                    <center><i class="fa fa-cloud-upload">&nbsp;&nbsp;</i> Cargar</center>
                </div>
            </td>
        </tr>

    </table>
    <div style="display:none">
        <asp:Button runat="server" text="" id="btnCargar" OnClick="btnCargar_Click" />
    </div>
    
</div>
</form>
