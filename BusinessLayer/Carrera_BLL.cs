﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessEntity;
using DataAccessLayer;

namespace BusinessLayer
{
    public class Carrera_BLL
    {
        Carrera_DAL mapper = new Carrera_DAL();

        public List<Carrera_BE> ListarCarreras()
        {
            return mapper.listar_carreras();
        }

        public void NuevaCarrera(Carrera_BE carrera)
        {
            mapper.nueva_carrera(carrera);
        }

        public void ActualizarCarrera(Carrera_BE carrera_BE)
        {
            mapper.actualizar_carrera(carrera_BE);
        }

        public void EliminarCarrera(Carrera_BE carrera_BE)
        {
            mapper.eliminar_carrera(carrera_BE);
        }

        public void AgregarCursoCarrera(Carrera_BE carrera, Curso_BE curso)
        {
            mapper.agregar_curso_carrera(carrera.Id, curso.Id);
        }

        public void EliminarCursoCarrera(Carrera_BE carrera, Curso_BE curso)
        {
            mapper.eliminar_curso_carrera(carrera.Id, curso.Id);
        }

        public List<InscripcionCarrera_BE> ListarInscripciones()
        {
            return mapper.listar_inscripcion();
        }

        public InscripcionCarrera_BE NuevaInscripcion(int id_estudiante, int id_dictado)
        {
            return mapper.nueva_inscripcion(id_estudiante, id_dictado);
        }

        public void EliminarInscripcion(InscripcionCurso_BE i)
        {
            mapper.eliminar_inscripcion(i.Id);
        }

        public List<InscripcionCarrera_BE> ListarInscripcionesPorEstudiante(int idUsuario)
        {
            return mapper.ListarInscripcionesPorEstudiante(idUsuario);
        }
    }
}
