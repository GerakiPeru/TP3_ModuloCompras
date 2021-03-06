﻿using PETCenter.Entities.Common;
using PETCenter.Entities.Compras;
using PETCenter.Entities.Seguridad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace PETCenter.WebApplication.Controllers.ajax
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de interfaz "IwsCompras" en el código y en el archivo de configuración a la vez.
    [ServiceContract]
    public interface IwsCompras
    {
        #region Proveedores
        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "GeneraProveedor", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.WrappedRequest)]
        string GeneraProveedor(
            int puntaje,
            string razonSocial,
            string direccion, string tipoDocumento, string numeroDocumento, string telefono, string contacto);

        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "GetProveedores", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.WrappedRequest)]
        CollectionProveedores GetProveedores();

        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "GuardarProveedor", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.WrappedRequest)]
        string GuardarProveedor(string tipoDocumento, string numeroDocumento, string razonSocial, string direccion, string telefono, string contacto, string estado, string idproveedor);

        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "ActualizarProveedor", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.WrappedRequest)]
        string ActualizarProveedor(string idProveedor, string direccion, string razonSocial, int puntaje, string tipoDocumento, string numeroDocumento, string telefono, string contacto, string estado);

        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "GetProveedores_Busqueda", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.WrappedRequest)]
        CollectionProveedores GetProveedores_Busqueda(string tipodocumento, string nrodocumento, string codigoProveedor, string nombreProveedor);     

        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "GetProveedor", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.WrappedRequest)]
        Proveedor GetProveedor(int idProveedor);


        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "GetProveedor_Id", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.WrappedRequest)]
        CollectionProveedores GetProveedor_Id(int idproveddor);

        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "GetHTMLTipoDocumento", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.WrappedRequest)]
        string GetHTMLTipoDocumento(int idTipoDocumento, string control);
        #endregion

        #region SolicitudRecursos
        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "GetCabeceraSolicitud", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.WrappedRequest)]
        string GetCabeceraSolicitud();

        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "InsertarSolicitudRecursos", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.WrappedRequest)]
        string InsertarSolicitudRecursos(int prioridad, string observacion);

        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "AnularSolicitudRecursos", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.WrappedRequest)]
        string AnularSolicitudRecursos(int solicitud, string motivo);

        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "AprobarSolicitudRecursos", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.WrappedRequest)]
        string AprobarSolicitudRecursos(int solicitud, string motivo, string estado, int saldofinal);

        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "ActualizarSolicitudRecursos", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.WrappedRequest)]
        string ActualizarSolicitudRecursos(string codigosolicitud, string observacion);

        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "GetSolicitudRecursos_Busqueda", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.WrappedRequest)]
        CollectionSolicitudRecursos GetSolicitudRecursos_Busqueda(
            int idsolicitudrecursos, string numerosolicitud, int area, int responsable, string fechainicio, string fechafin, string estado);

        #endregion

        #region Recursos
        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "GetRecurso", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.WrappedRequest)]
        CollectionRecurso GetRecurso(int idrecurso);
        #endregion

        #region Area
        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "GetArea", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.WrappedRequest)]
        CollectionArea GetArea(int idarea);
        #endregion        

        #region Empleado
        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "GetEmpleado", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.WrappedRequest)]
        CollectionEmpleado GetEmpleado(int idempleado, int idarea);
        #endregion

        #region PresentacionRecursos

        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "GetPresentacionRecurso", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.WrappedRequest)]
        CollectionPresentacionRecurso GetPresentacionRecurso(int idrecurso, int idpresentacion);
        #endregion

        #region ItemSolicitudRecurso
        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "GetItemSolicitudRecurso_A", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.WrappedRequest)]
        CollectionItemSolicitudRecurso GetItemSolicitudRecurso_A(int idsolicitudrecurso, int idpresentacionrecurso, int cantidad, int stock, int cantidadcomprar);
        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "GetItemSolicitudRecurso_I", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.WrappedRequest)]
        CollectionItemSolicitudRecurso GetItemSolicitudRecurso_I(int idsolicitudrecurso, int idpresentacionrecurso, int cantidad);

        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "GetItemSolicitudRecurso_M", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.WrappedRequest)]
        CollectionItemSolicitudRecurso GetItemSolicitudRecurso_M(int idsolicitudrecurso, int idpresentacionrecurso, int cantidad);        

        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "GetItemSolicitudRecurso_D", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.WrappedRequest)]
        CollectionItemSolicitudRecurso GetItemSolicitudRecurso_D(int idsolicitudrecurso, int idpresentacionrecurso, int cantidad);
        #endregion

        #region RecursoProveedor
        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "GetRecursoProveedor", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.WrappedRequest)]
        CollectionRecursoProveedor GetRecursoProveedor(int idproveedor, int idrecurso, int idpresentacion, int idproveedorecurso);

        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "GetRecursoProveedorTempCargaMasiva", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.WrappedRequest)]
        CollectionRecursoProveedor GetRecursoProveedorTempCargaMasiva();

        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "ActualizarRecursoProveedor", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.WrappedRequest)]
        string ActualizarRecursoProveedor(int idRecursoProveedor, int idrecurso, int idpresentacionrecurso, int idProveedor, decimal valorUnitario, int activo);

        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "GetRecursoProveedorExel", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.WrappedRequest)]
        string GetRecursoProveedorExel(int idproveedor, int idrecurso, int idpresentacion, int idproveedorecurso);
        #endregion

        #region EvaluacionProveedor

        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "GuardarEvaluacion", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.WrappedRequest)]
        string GuardarEvaluacion(string
            periodo);

        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "GetEvaluaciones_Busqueda", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.WrappedRequest)]
        CollectionEvaluacionProveedor GetEvaluaciones_Busqueda(int idevaluacionproveedor, string nroevaluacion, string periodo, int proveedor, int calificado);

        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "Genera_Evaluacion", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.WrappedRequest)]
        CollectionGenerador Genera_Evaluacion(string periodo);

        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "GetOrdenCompraxProveedor", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.WrappedRequest)]
        CollectionOrdenCompra GetOrdenCompraxProveedor(string periodo, int idProveedor);

        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "GetIncidenciaxProveedor", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.WrappedRequest)]
        CollectionIncidenciaProveedor GetIncidenciaxProveedor(string periodo, int idProveedor);

        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "GetProveedorListado", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.WrappedRequest)]
        CollectionProveedores GetProveedorListado(int idProveedor);

        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "GetDetalleOrdenesEvaluacion", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.WrappedRequest)]
        CollectionOrdenCompraEvaluacion GetDetalleOrdenesEvaluacion(int idevaluacionproveedor);

        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "GetDetalleIncidenciasEvaluacion", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.WrappedRequest)]
        CollectionIncidenciaEvaluacion GetDetalleIncidenciasEvaluacion(int idevaluacionproveedor);

        #endregion

    }


}

