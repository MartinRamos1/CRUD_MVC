﻿using CRUD_MVC.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CRUD_MVC.Controllers
{
    public class ContactoController : Controller
    {
        private static string conexion = ConfigurationManager.ConnectionStrings["cadena"].ToString();

        private static List<Contacto> olista = new List<Contacto>();

        // GET: Contacto
        public ActionResult Inicio()
        {

            olista = new List<Contacto>();

            using (SqlConnection oconexion = new SqlConnection(conexion))
            {
                SqlCommand cmd = new SqlCommand("SELECT * FROM CONTACTOS", oconexion);
                cmd.CommandType = CommandType.Text;
                oconexion.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {

                        Contacto aux = new Contacto();

                        aux.IdContacto = Convert.ToInt32(dr["IdContacto"]);
                        aux.Nombre = dr["Nombre"].ToString();
                        aux.Apellido = dr["Apellido"].ToString();
                        aux.Numero = dr["Numero"].ToString();
                        aux.Correo = dr["Correo"].ToString();

                        olista.Add(aux);

                    }
                }
            }
            return View(olista);
        }

        public ActionResult Registrar()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Registrar(Contacto contacto)
        {

            using (SqlConnection oconexion = new SqlConnection(conexion))
            {
                SqlCommand cmd = new SqlCommand("sp_Registrar", oconexion);
                cmd.Parameters.AddWithValue("Nombre", contacto.Nombre);
                cmd.Parameters.AddWithValue("Apellido", contacto.Apellido);
                cmd.Parameters.AddWithValue("Numero", contacto.Numero);
                cmd.Parameters.AddWithValue("Correo", contacto.Correo);

                cmd.CommandType = CommandType.StoredProcedure;
                oconexion.Open();
                cmd.ExecuteNonQuery();

            }

            return RedirectToAction("Inicio", "Contacto");
        }
    }

}