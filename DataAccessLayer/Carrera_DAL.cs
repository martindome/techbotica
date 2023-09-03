﻿using BusinessEntity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class Carrera_DAL
    {
        Acceso_DAL ac = new Acceso_DAL();

        public List<Carrera_BE> listar_carreras()
        {
            List<Carrera_BE> carreras = new List<Carrera_BE>();

            DataTable Tabla = ac.ejecutar_stored_procedure("listar_carreras", null);
            foreach (DataRow reg in Tabla.Rows)
            {
                Carrera_BE CarreraBE = new Carrera_BE();
                mappear_carrera(reg, CarreraBE);
                CarreraBE.Cursos = new Curso_DAL().listar_cursos_carrera(CarreraBE.Id);
                carreras.Add(CarreraBE);
            }
            return carreras;
        }

        public void nueva_carrera(Carrera_BE carrera)
        {
            SqlParameter[] parametros = new SqlParameter[2];
            parametros[0] = new SqlParameter();
            parametros[0].ParameterName = "@nombre";
            parametros[0].DbType = DbType.String;
            parametros[0].Value = carrera.Nombre;

            parametros[1] = new SqlParameter();
            parametros[1].ParameterName = "@descripcion";
            parametros[1].DbType = DbType.String;
            parametros[1].Value = carrera.Descripcion;

            DataTable Tabla = ac.ejecutar_stored_procedure("nueva_carrera", parametros);

            foreach (DataRow reg in Tabla.Rows)
            {
                carrera.Id = Convert.ToInt32(reg["id"].ToString());
            }
            foreach(Curso_BE c in carrera.Cursos)
            {
                agregar_curso_carrera(carrera.Id, c.Id );
            }
        }

        public void agregar_curso_carrera(int id_carrera, int id_curso)
        {
            SqlParameter[] parametros = new SqlParameter[2];
            parametros[0] = new SqlParameter();
            parametros[0].ParameterName = "@id_carrera";
            parametros[0].DbType = DbType.Int32;
            parametros[0].Value = id_carrera;

            parametros[1] = new SqlParameter();
            parametros[1].ParameterName = "@id_curso";
            parametros[1].DbType = DbType.Int32;
            parametros[1].Value = id_curso;

            DataTable Tabla = ac.ejecutar_stored_procedure("nuevo_curso_carrera", parametros);
        }

        public void eliminar_curso_carrera(int id_carrera, int id_curso)
        {
            SqlParameter[] parametros = new SqlParameter[2];
            parametros[0] = new SqlParameter();
            parametros[0].ParameterName = "@id_carrera";
            parametros[0].DbType = DbType.Int32;
            parametros[0].Value = id_carrera;

            parametros[1] = new SqlParameter();
            parametros[1].ParameterName = "@id_curso";
            parametros[1].DbType = DbType.Int32;
            parametros[1].Value = id_curso;

            DataTable Tabla = ac.ejecutar_stored_procedure("eliminar_curso_carrera", parametros);
        }

        public void actualizar_carrera(Carrera_BE carrerabe)
        {
            SqlParameter[] parametros = new SqlParameter[3];
            parametros[0] = new SqlParameter();
            parametros[0].ParameterName = "@nombre";
            parametros[0].DbType = DbType.String;
            parametros[0].Value = carrerabe.Nombre;

            parametros[1] = new SqlParameter();
            parametros[1].ParameterName = "@descripcion";
            parametros[1].DbType = DbType.String;
            parametros[1].Value = carrerabe.Descripcion;

            parametros[2] = new SqlParameter();
            parametros[2].ParameterName = "@id";
            parametros[2].DbType = DbType.Int32;
            parametros[2].Value = carrerabe.Id;

            DataTable Tabla = ac.ejecutar_stored_procedure("actualizar_carrera", parametros);
        }

        public void eliminar_carrera(Carrera_BE carrerabe)
        {

            SqlParameter[] parametros = new SqlParameter[1];
            parametros[0] = new SqlParameter();
            parametros[0].ParameterName = "@id";
            parametros[0].DbType = DbType.Int32;
            parametros[0].Value = carrerabe.Id;

            ac.ejecutar_stored_procedure("eliminar_carrera", parametros);

        }

        private void mappear_carrera(DataRow reg, Carrera_BE e)
        {
            e.Id = Convert.ToInt32(reg["id"].ToString());
            e.Nombre = reg["nombre"].ToString();
            e.Descripcion = reg["descripcion"].ToString();
        }
    }
}