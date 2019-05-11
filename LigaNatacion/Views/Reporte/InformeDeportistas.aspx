<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>


<%@ Register assembly="Microsoft.ReportViewer.WebForms, Version=11.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" namespace="Microsoft.Reporting.WebForms" tagprefix="rsweb" %>

<script runat="server">
     void Page_Load(object sender, EventArgs e)
     {
        if (!IsPostBack)
        {
            Negocio.DeportistaNegocio control = new Negocio.DeportistaNegocio();
            var source = new Microsoft.Reporting.WebForms.ReportDataSource("DSDeportistas", control.ObtenerDeportistas());
            rvInformeDeportistas.LocalReport.DataSources.Add(source);
            rvInformeDeportistas.LocalReport.Refresh();
        }
     }
</script>

<html>
<head runat="server">
    <title>Listado de Deportistas</title>
</head>
<body>
    <form runat="server">
    <div>
        <asp:ScriptManager ID="smReporte" runat="server"></asp:ScriptManager>
        <rsweb:ReportViewer ID="rvInformeDeportistas" runat="server" Width="805px" AsyncRendering="false">
            <LocalReport ReportPath="InformeDeportistas.rdlc">
            </LocalReport>
        </rsweb:ReportViewer>

    </div>
    </form>
</body>
</html>
