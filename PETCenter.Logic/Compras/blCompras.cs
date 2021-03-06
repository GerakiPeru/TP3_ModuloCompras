﻿using PETCenter.DataAccess.Compras;
using PETCenter.DataAccess.Configuration;
using PETCenter.Entities.Common;
using PETCenter.Entities.Compras;
using PETCenter.Entities.Seguridad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PETCenter.Logic.Compras
{
    public class blCompras
    {
        #region Proveedor
        public CollectionProveedores GetProveedor_Id(int idproveddor)
        {
            try
            {
                PETCenter.DataAccess.Configuration.DAO dao = new DAO();
                Transaction transaction;
                daCompras da = new daCompras();
                List<Proveedor> provl = da.GetProveedor_Id(idproveddor);
                if (provl.Count() == 0)
                {
                    transaction = Common.GetTransaction(TypeTransaction.ERR, "No se pudo recuperar la información del proveedor");
                }
                else
                {
                    transaction = Common.GetTransaction(TypeTransaction.OK, "");
                }
                return new CollectionProveedores(provl, transaction);
            }
            catch (Exception ex)
            {
                return new CollectionProveedores(Common.GetTransaction(TypeTransaction.ERR, ex.Message));
            }
        }

        public CollectionProveedores GetProveedores_Busqueda(string tipodocumento, string nrodocumento, string codigoProveedor, string nombreProveedor)
        {
            try
            {
                PETCenter.DataAccess.Configuration.DAO dao = new DAO();
                Transaction transaction;
                daCompras da = new daCompras();
                List<Proveedor> provl = da.GetProveedores_Busqueda(tipodocumento, nrodocumento, codigoProveedor, nombreProveedor);
                if (provl.Count() == 0)
                {
                    transaction = Common.GetTransaction(TypeTransaction.ERR, "No existen ordenes de compra disponibles");
                }
                else
                {
                    transaction = Common.GetTransaction(TypeTransaction.OK, "");
                }
                return new CollectionProveedores(provl, transaction);
            }
            catch (Exception ex)
            {
                return new CollectionProveedores(Common.GetTransaction(TypeTransaction.ERR, ex.Message));
            }
        }

        public int GeneraProovedor(string razonSocial, string direccion, string tipoDocumento, string numeroDocumento, string telefono, string contacto, string estado, out Transaction transaction)
        {
            try
            {
                PETCenter.DataAccess.Configuration.DAO dao = new DAO();
                daCompras da = new daCompras();
                int result = da.GeneraProveedor(razonSocial,direccion, tipoDocumento,  numeroDocumento,  telefono,  contacto, estado);
                if (result == 0)
                {
                    transaction = Common.GetTransaction(TypeTransaction.ERR, "No se realizó la transacción");
                }
                else
                {
                    transaction = Common.GetTransaction(TypeTransaction.OK, "Operación realizada satisfactoriamente");
                }
                return result;
            }
            catch (Exception ex)
            {
                transaction = Common.GetTransaction(TypeTransaction.ERR, ex.Message);
                return 0;
            }
        }

        public int ActualizarProveedor(string idProveedor, string direccion, string razonSocial, string tipoDocumento, string numeroDocumento, string telefono, string contacto, string estado, out Transaction transaction)
        {
            try
            {
                PETCenter.DataAccess.Configuration.DAO dao = new DAO();
                daCompras da = new daCompras();
                int result = da.ActualizarProveedor(idProveedor, direccion, razonSocial, tipoDocumento, numeroDocumento, telefono, contacto,estado);
                if (result == 0)
                {
                    transaction = Common.GetTransaction(TypeTransaction.ERR, "No se realizó la operación");
                }
                else
                {
                    transaction = Common.GetTransaction(TypeTransaction.OK, "Operación realizada satisfactoriamente");
                }
                return result;
            }
            catch (Exception ex)
            {
                transaction = Common.GetTransaction(TypeTransaction.ERR, ex.Message);
                return 0;
            }
        }

        public int DeleteProovedor(string idProveedor, string estado, out Transaction transaction)
        {
            try
            {
                PETCenter.DataAccess.Configuration.DAO dao = new DAO();
                daCompras da = new daCompras();
                int result = da.DeleteProveedor(idProveedor, estado);
                if (result == 0)
                {
                    transaction = Common.GetTransaction(TypeTransaction.ERR, "No se realizó la transacción");
                }
                else
                {
                    transaction = Common.GetTransaction(TypeTransaction.OK, "");
                }
                return result;
            }
            catch (Exception ex)
            {
                transaction = Common.GetTransaction(TypeTransaction.ERR, ex.Message);
                return 0;
            }
        }

        public int GuardarEvaluacion(string periodo, out Transaction transaction)
        {
            try
            {
                PETCenter.DataAccess.Configuration.DAO dao = new DAO();
                daEvaluacionProveedor da = new daEvaluacionProveedor();
                int result = da.GuardarEvaluacion(periodo);
                if (result == 0)
                {
                    transaction = Common.GetTransaction(TypeTransaction.ERR, "No se realizó la transacción");
                }
                else
                {
                    transaction = Common.GetTransaction(TypeTransaction.OK, "Operación realizada satisfactoriamente");
                }
                return result;
            }
            catch (Exception ex)
            {
                transaction = Common.GetTransaction(TypeTransaction.ERR, ex.Message);
                return 0;
            }
        }

        public Proveedor GetProveedor(int idProveedor, out Transaction transaction)
        {
            try
            {
                PETCenter.DataAccess.Configuration.DAO dao = new DAO();
                transaction = Common.GetTransaction(TypeTransaction.OK, "");
                daCompras da = new daCompras();
                Proveedor provl = da.GetProveedor(idProveedor);
                if (provl != null)
                {
                    transaction = Common.GetTransaction(TypeTransaction.ERR, "No existen proveedores disponibles");
                }
                else
                {

                    transaction = Common.GetTransaction(TypeTransaction.OK, "");

                }
                return provl;
            }
            catch (Exception ex)
            {
                transaction = Common.GetTransaction(TypeTransaction.ERR, ex.Message);
                return new Proveedor();
            }
        }
        
        
        #endregion

        #region Recursos
        public CollectionRecurso GetRecurso(int idrecurso)
        {
            try
            {
                PETCenter.DataAccess.Configuration.DAO dao = new DAO();
                Transaction transaction;
                daRecurso da = new daRecurso();
                List<Recurso> ocol = da.GetRecurso(idrecurso);
                if (ocol.Count() == 0)
                {
                    transaction = Common.GetTransaction(TypeTransaction.ERR, "No se pudo recuperar los recursos");
                }
                else
                {
                    transaction = Common.GetTransaction(TypeTransaction.OK, "");
                }
                return new CollectionRecurso(ocol, transaction);
            }
            catch (Exception ex)
            {
                return new CollectionRecurso(Common.GetTransaction(TypeTransaction.ERR, ex.Message));
            }
        }

        #endregion

        #region PresentacionRecursos
        public CollectionPresentacionRecurso GetPresentacionRecurso(int idrecurso, int idpresentacion)
        {
            try
            {
                PETCenter.DataAccess.Configuration.DAO dao = new DAO();
                Transaction transaction;
                daPresentacionRecurso da = new daPresentacionRecurso();
                List<PresentacionRecurso> ocol = da.GetPresentacionRecurso(idrecurso, idpresentacion);
                if (idrecurso == -1)
                {
                    transaction = Common.GetTransaction(TypeTransaction.OK, "");
                }
                else
                {
                    if (ocol.Count() == 0)
                    {
                        transaction = Common.GetTransaction(TypeTransaction.ERR, "No se pudo recuperar la presentacion de recursos");
                    }
                    else
                    {
                        transaction = Common.GetTransaction(TypeTransaction.OK, "");
                    }
                }
                return new CollectionPresentacionRecurso(ocol, transaction);
            }
            catch (Exception ex)
            {
                return new CollectionPresentacionRecurso(Common.GetTransaction(TypeTransaction.ERR, ex.Message));
            }
        }
        #endregion

        #region Area
        public CollectionArea GetArea(int idarea)
        {
            try
            {
                PETCenter.DataAccess.Configuration.DAO dao = new DAO();
                Transaction transaction;
                daArea da = new daArea();
                List<Area> ocol = da.GetArea(idarea);
                if (idarea == 0)
                {
                    transaction = Common.GetTransaction(TypeTransaction.OK, "");
                }
                else
                {
                    if (ocol.Count() == 0)
                    {
                        transaction = Common.GetTransaction(TypeTransaction.ERR, "No se pudo recuperar las areas");
                    }
                    else
                    {
                        transaction = Common.GetTransaction(TypeTransaction.OK, "");
                    }
                }
                return new CollectionArea(ocol, transaction);
            }
            catch (Exception ex)
            {
                return new CollectionArea(Common.GetTransaction(TypeTransaction.ERR, ex.Message));
            }
        }
        #endregion

        #region Empleado
        public CollectionEmpleado GetEmpleado(int idEmpleado, int idarea)
        {
            try
            {
                PETCenter.DataAccess.Configuration.DAO dao = new DAO();
                Transaction transaction;
                daEmpleado da = new daEmpleado();
                List<Empleado> ocol = da.GetEmpleado(idEmpleado, idarea);
                if (idEmpleado == 0)
                {
                    transaction = Common.GetTransaction(TypeTransaction.OK, "");
                }
                else
                {
                    if (ocol.Count() == 0)
                    {
                        transaction = Common.GetTransaction(TypeTransaction.ERR, "No se pudo recuperar los empleados");
                    }
                    else
                    {
                        transaction = Common.GetTransaction(TypeTransaction.OK, "");
                    }
                }
                return new CollectionEmpleado(ocol, transaction);
            }
            catch (Exception ex)
            {
                return new CollectionEmpleado(Common.GetTransaction(TypeTransaction.ERR, ex.Message));
            }
        }
        #endregion
        #region ItemSolicitudRecurso
        public CollectionItemSolicitudRecurso GetItemSolicitudRecurso(int idsolicitudrecurso, int idpresentacionrecurso, int cantidad, int stock, int cantidadcomprar)
        {
            try
            {
                PETCenter.DataAccess.Configuration.DAO dao = new DAO();
                Transaction transaction;
                daItemSolicitudRecurso da = new daItemSolicitudRecurso();
                List<ItemSolicitudRecurso> ocol = da.GetItemSolicitudRecurso(idsolicitudrecurso, idpresentacionrecurso, cantidad, stock, cantidadcomprar);

                if (ocol.Count() == 0)
                {
                    transaction = Common.GetTransaction(TypeTransaction.ERR, "No se pudo recuperar los items de la solicitud");
                }
                else
                {
                    transaction = Common.GetTransaction(TypeTransaction.OK, "");
                }

                return new CollectionItemSolicitudRecurso(ocol, transaction);
            }
            catch (Exception ex)
            {
                return new CollectionItemSolicitudRecurso(Common.GetTransaction(TypeTransaction.ERR, ex.Message));
            }
        }
        #endregion

        #region SolicitudRecurso
        public int InsertarSolicitudRecursos(SolicitudRecurso solicitudrecurso, List<ItemSolicitudRecurso> itemssolicitudrecursos, out Transaction transaction) 
        {
            try
            {
                PETCenter.DataAccess.Configuration.DAO dao = new DAO();
                transaction = Common.GetTransaction(TypeTransaction.OK, "");
                daSolicitudRecursos da = new daSolicitudRecursos();
                int result = da.InsertarSolicitudRecursos(solicitudrecurso, itemssolicitudrecursos);
                if (result == 0)
                {
                    transaction = Common.GetTransaction(TypeTransaction.ERR, "No se realizó la transacción");
                }
                else
                {
                    transaction = Common.GetTransaction(TypeTransaction.OK, "Operación realizada satisfactoriamente");
                }
                return result;
            }
            catch (Exception ex)
            {
                transaction = Common.GetTransaction(TypeTransaction.ERR, ex.Message);
                return 0;
            }
        }

        public int AnularSolicitudRecursos(int solicitudrecurso, string motivo, out Transaction transaction)
        {
            try
            {
                PETCenter.DataAccess.Configuration.DAO dao = new DAO();
                transaction = Common.GetTransaction(TypeTransaction.OK, "");
                daSolicitudRecursos da = new daSolicitudRecursos();
                int result = da.AnularSolicitudRecursos(solicitudrecurso, motivo);
                if (result == 0)
                {
                    transaction = Common.GetTransaction(TypeTransaction.ERR, "No se realizó la transacción");
                }
                else
                {
                    transaction = Common.GetTransaction(TypeTransaction.OK, "Operación realizada satisfactoriamente");
                }
                return result;
            }
            catch (Exception ex)
            {
                transaction = Common.GetTransaction(TypeTransaction.ERR, ex.Message);
                return 0;
            }
        }

        public int AprobarSolicitudRecursos(int solicitudrecurso, string motivo, string estado,int saldofinal, out Transaction transaction)
        {
            try
            {
                PETCenter.DataAccess.Configuration.DAO dao = new DAO();
                transaction = Common.GetTransaction(TypeTransaction.OK, "");
                daSolicitudRecursos da = new daSolicitudRecursos();
                int result = da.AprobarSolicitudRecursos(solicitudrecurso, motivo, estado, saldofinal);
                if (result == 0)
                {
                    transaction = Common.GetTransaction(TypeTransaction.ERR, "No se realizó la transacción");
                }
                else
                {
                    transaction = Common.GetTransaction(TypeTransaction.OK, "Operación realizada satisfactoriamente");
                }
                return result;
            }
            catch (Exception ex)
            {
                transaction = Common.GetTransaction(TypeTransaction.ERR, ex.Message);
                return 0;
            }
        }

        public int ActualizarSolicitudRecursos(SolicitudRecurso solicitudrecurso, List<ItemSolicitudRecurso> itemssolicitudrecursos, out Transaction transaction)
        {
            try
            {
                PETCenter.DataAccess.Configuration.DAO dao = new DAO();
                transaction = Common.GetTransaction(TypeTransaction.OK, "");
                daSolicitudRecursos da = new daSolicitudRecursos();
                int result = da.ActualizarSolicitudRecursos(solicitudrecurso, itemssolicitudrecursos);
                if (result == 0)
                {
                    transaction = Common.GetTransaction(TypeTransaction.ERR, "No se realizó la transacción");
                }
                else
                {
                    transaction = Common.GetTransaction(TypeTransaction.OK, "Operación realizada satisfactoriamente");
                }
                return result;
            }
            catch (Exception ex)
            {
                transaction = Common.GetTransaction(TypeTransaction.ERR, ex.Message);
                return 0;
            }
        }

        public CollectionSolicitudRecursos GetSolicitudRecursos_Busqueda(
            int idsolicitudrecursos, string numerosolicitud, int area, int responsable, string fechainicio, string fechafin, string estado)
        {
            try
            {
                PETCenter.DataAccess.Configuration.DAO dao = new DAO();
                Transaction transaction;
                daSolicitudRecursos da = new daSolicitudRecursos();
                List<SolicitudRecurso> ocol = da.GetSolicitudRecursos_Busqueda(idsolicitudrecursos, numerosolicitud, area, responsable, fechainicio, fechafin, estado);
                if (ocol.Count() == 0)
                {
                    transaction = Common.GetTransaction(TypeTransaction.ERR, "No existen solicitudes de recursos disponibles");
                }
                else
                {
                    transaction = Common.GetTransaction(TypeTransaction.OK, "");
                }
                return new CollectionSolicitudRecursos(ocol, transaction);
            }
            catch (Exception ex)
            {
                return new CollectionSolicitudRecursos(Common.GetTransaction(TypeTransaction.ERR, ex.Message));
            }
        }
        #endregion

        #region RecursoProveedor

        public CollectionRecursoProveedor GetRecursoProveedor(int idproveedor, int idrecurso, int idpresentacion, int idproveedorecurso)
        {
            try
            {
                PETCenter.DataAccess.Configuration.DAO dao = new DAO();
                Transaction transaction;
                daRecursoProveedor da = new daRecursoProveedor();
                List<RecursoProveedor> ocol = da.GetRecursoProveedor(idproveedor, idrecurso, idpresentacion, idproveedorecurso);
                if (idrecurso == -1)
                {
                    transaction = Common.GetTransaction(TypeTransaction.OK, "");
                }
                else
                {
                    transaction = Common.GetTransaction(TypeTransaction.OK, "");
                    
                }
                return new CollectionRecursoProveedor(ocol, transaction);
            }
            catch (Exception ex)
            {
                return new CollectionRecursoProveedor(Common.GetTransaction(TypeTransaction.ERR, ex.Message));
            }
        }

        public int ActualizarRecursoProveedorCargaMasiva(RecursoProveedor itemsrecursoproveedor, out Transaction transaction)
        {
            try
            {
                PETCenter.DataAccess.Configuration.DAO dao = new DAO();
                if (itemsrecursoproveedor.valorUnitario == 0)
                {
                    transaction = Common.GetTransaction(TypeTransaction.ERR, "Ingrese un Valor Unitario mayor a cero");
                    return 0;
                }
                else if (itemsrecursoproveedor.presentacionrecurso.codigo == "")
                {
                    transaction = Common.GetTransaction(TypeTransaction.ERR, "El Código del Recurso vacío");
                    return 0;
                }
                else if (itemsrecursoproveedor.proveedor.Codigo == "")
                {
                        transaction = Common.GetTransaction(TypeTransaction.ERR, "El Código del Proveedor está vacío");
                        return 0;
                }
                daRecursoProveedor da = new daRecursoProveedor();
                int result = da.ActualizarRecursoProveedorCargaMasiva(itemsrecursoproveedor);
                if (result == 0)
                {
                    transaction = Common.GetTransaction(TypeTransaction.ERR, "No ha sido posible procesar el archivo");
                }
                else
                {
                    transaction = Common.GetTransaction(TypeTransaction.OK, "Operación realizada satisfactoriamente");
                }
                return result;
            }
            catch (Exception ex)
            {
                transaction = Common.GetTransaction(TypeTransaction.ERR, ex.Message);
                return 0;
            }
        }

        public int ActualizarRecursoProveedor(RecursoProveedor itemsrecursoproveedor, out Transaction transaction)
        {
            try
            {
                PETCenter.DataAccess.Configuration.DAO dao = new DAO();
                if (itemsrecursoproveedor.valorUnitario == 0)
                {
                    transaction = Common.GetTransaction(TypeTransaction.ERR, "Ingrese un Valor Unitario mayor a cero");
                    return 0;
                }
                else if (itemsrecursoproveedor.idRecursoProveedor == 0)
                {
                    if (itemsrecursoproveedor.presentacionrecurso.recurso.idrecurso <= 0)
                    {
                        transaction = Common.GetTransaction(TypeTransaction.ERR, "Seleccione un recurso");
                        return 0;
                    }
                    else if (itemsrecursoproveedor.presentacionrecurso.idpresentacionrecurso <= 0)
                    {
                        transaction = Common.GetTransaction(TypeTransaction.ERR, "Seleccione la presentacion del recurso");
                        return 0;
                    }
                }
                daRecursoProveedor da = new daRecursoProveedor();
                int result = da.ActualizarRecursoProveedor(itemsrecursoproveedor);
                if (result == 0)
                {
                    transaction = Common.GetTransaction(TypeTransaction.ERR, "No se realizó la operación");
                }
                else
                {
                    transaction = Common.GetTransaction(TypeTransaction.OK, "Operación realizada satisfactoriamente");
                }
                return result;
            }
            catch (Exception ex)
            {
                transaction = Common.GetTransaction(TypeTransaction.ERR, ex.Message);
                return 0;
            }
        }
        #endregion

    

    #region EvaluacionProveedor

    public CollectionEvaluacionProveedor GetEvaluaciones_Busqueda(int idevaluacionproveedor, string nroevaluacion, string periodo, int proveedor, int calificado)
        {
            try
            {
                PETCenter.DataAccess.Configuration.DAO dao = new DAO();
                Transaction transaction;
                daEvaluacionProveedor da = new daEvaluacionProveedor();
                List<EvaluacionProveedor> eval = da.GetEvaluaciones_Busqueda(idevaluacionproveedor, nroevaluacion, periodo, proveedor, calificado);
                if (eval.Count() == 0)
                {
                    transaction = Common.GetTransaction(TypeTransaction.ERR, "No existen evaluaciones disponibles");
                }
                else
                {
                    transaction = Common.GetTransaction(TypeTransaction.OK, "");
                }
                return new CollectionEvaluacionProveedor(eval, transaction);
            }
            catch (Exception ex)
            {
                return new CollectionEvaluacionProveedor(Common.GetTransaction(TypeTransaction.ERR, ex.Message));
            }
        }

        public CollectionGenerador Genera_Evaluacion(string periodo)
        {
            try
            {
                PETCenter.DataAccess.Configuration.DAO dao = new DAO();
                Transaction transaction;
                daEvaluacionProveedor da = new daEvaluacionProveedor();
                List<Generador> eval = da.Genera_Evaluacion(periodo);
                if (eval.Count() == 0)
                {
                    transaction = Common.GetTransaction(TypeTransaction.ERR, "No existen evaluaciones disponibles");
                }
                else
                {
                    transaction = Common.GetTransaction(TypeTransaction.OK, "");
                }
                return new CollectionGenerador(eval, transaction);
            }
            catch (Exception ex)
            {
                return new CollectionGenerador(Common.GetTransaction(TypeTransaction.ERR, ex.Message));
            }
        }

        public CollectionOrdenCompra GetOrdenCompraxProveedor(string periodo, int idProveedor)
        {
            try
            {
                PETCenter.DataAccess.Configuration.DAO dao = new DAO();
                Transaction transaction;
                daEvaluacionProveedor da = new daEvaluacionProveedor();
                List<OrdenCompra> eval = da.GetOrdenCompraxProveedor(periodo, idProveedor);
                if (eval.Count() == 0)
                {
                    transaction = Common.GetTransaction(TypeTransaction.ERR, "No existen evaluaciones disponibles");
                }
                else
                {
                    transaction = Common.GetTransaction(TypeTransaction.OK, "");
                }
                return new CollectionOrdenCompra(eval, transaction);
            }
            catch (Exception ex)
            {
                return new CollectionOrdenCompra(Common.GetTransaction(TypeTransaction.ERR, ex.Message));
            }
        }

        public CollectionIncidenciaProveedor GetIncidenciaxProveedor(string periodo, int idProveedor)
        {
            try
            {
                PETCenter.DataAccess.Configuration.DAO dao = new DAO();
                Transaction transaction;
                daEvaluacionProveedor da = new daEvaluacionProveedor();
                List<IncidenciaProveedor> eval = da.GetIncidenciaxProveedor(periodo, idProveedor);
                if (eval.Count() == 0)
                {
                    transaction = Common.GetTransaction(TypeTransaction.ERR, "No existen evaluaciones disponibles");
                }
                else
                {
                    transaction = Common.GetTransaction(TypeTransaction.OK, "");
                }
                return new CollectionIncidenciaProveedor(eval, transaction);
            }
            catch (Exception ex)
            {
                return new CollectionIncidenciaProveedor(Common.GetTransaction(TypeTransaction.ERR, ex.Message));
            }
        }

        public CollectionOrdenCompra GetDetalleOrdenesEvaluacion(string periodo, int idProveedor)
        {
            try
            {
                PETCenter.DataAccess.Configuration.DAO dao = new DAO();
                Transaction transaction;
                daEvaluacionProveedor da = new daEvaluacionProveedor();
                List<OrdenCompra> eval = da.GetOrdenCompraxProveedor(periodo, idProveedor);
                if (eval.Count() == 0)
                {
                    transaction = Common.GetTransaction(TypeTransaction.ERR, "No existen ordenes disponibles");
                }
                else
                {
                    transaction = Common.GetTransaction(TypeTransaction.OK, "");
                }
                return new CollectionOrdenCompra(eval, transaction);
            }
            catch (Exception ex)
            {
                return new CollectionOrdenCompra(Common.GetTransaction(TypeTransaction.ERR, ex.Message));
            }
        }

        

        public CollectionOrdenCompraEvaluacion GetDetalleOrdenesEvaluacion(int idevaluacionproveedor)
        {
            try
            {
                PETCenter.DataAccess.Configuration.DAO dao = new DAO();
                Transaction transaction;
                daEvaluacionProveedor da = new daEvaluacionProveedor();
                List<OrdenCompraEvaluacion> eval = da.GetDetalleOrdenesEvaluacion(idevaluacionproveedor);
                if (eval.Count() == 0)
                {
                    transaction = Common.GetTransaction(TypeTransaction.ERR, "No existen evaluaciones disponibles");
                }
                else
                {
                    transaction = Common.GetTransaction(TypeTransaction.OK, "");
                }
                return new CollectionOrdenCompraEvaluacion(eval, transaction);
            }
            catch (Exception ex)
            {
                return new CollectionOrdenCompraEvaluacion(Common.GetTransaction(TypeTransaction.ERR, ex.Message));
            }
        }

        public CollectionIncidenciaEvaluacion GetDetalleIncidenciasEvaluacion(int idevaluacionproveedor)
        {
            try
            {
                PETCenter.DataAccess.Configuration.DAO dao = new DAO();
                Transaction transaction;
                daEvaluacionProveedor da = new daEvaluacionProveedor();
                List<IncidenciaEvaluacion> eval = da.GetDetalleIncidenciasEvaluacion(idevaluacionproveedor);
                if (eval.Count() == 0)
                {
                    transaction = Common.GetTransaction(TypeTransaction.ERR, "No existen evaluaciones disponibles");
                }
                else
                {
                    transaction = Common.GetTransaction(TypeTransaction.OK, "");
                }
                return new CollectionIncidenciaEvaluacion(eval, transaction);
            }
            catch (Exception ex)
            {
                return new CollectionIncidenciaEvaluacion(Common.GetTransaction(TypeTransaction.ERR, ex.Message));
            }
        }

#endregion
}
}
