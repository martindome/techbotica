﻿using BusinessEntity;
using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class Dictado_BLL
    {
        Dictado_DAL mapper = new Dictado_DAL();

        public List<Dictado_BE> ListarDictados()
        {
            return mapper.listar_dictados();
        }

        public List<Dictado_BE> ListarDictados(Curso_BE curso)
        {
            return mapper.listar_dictados_curso(curso.Id);
        }

        public List<Horario_BE> ListarHorariosDictado(Dictado_BE dictado)
        {
            return mapper.listar_horarios_dictado(dictado.Id);
        }

        public void NuevoDictado(Dictado_BE dictado)
        {
            mapper.nuevo_dictado(dictado);
        }

        public void ActualizarDictado(Dictado_BE dictado)
        {
            mapper.actualizar_dictado(dictado);
        }

        public void EliminarDictado(Dictado_BE dictado)
        {
            mapper.actualizar_dictado(dictado);
        }

        public void NuevoHorario(Horario_BE horario)
        {
            mapper.nuevo_horario(horario);
        }

        public void ActualizarHorario(Horario_BE horario)
        {
            mapper.actualizar_horario(horario); 
        }

        public void EliminarHorario(Horario_BE horario)
        {
            mapper.eliminar_horario(horario);
        }

        public List<Dictado_BE> ListarDictadosCurso(Curso_BE curso)
        {
            return mapper.listar_dictados_curso(curso.Id);
        }

        public void AgregarDictadoUsuario(Dictado_BE d, Usuario_BE u)
        {
            mapper.agregar_usuario_dictado(d.Id, u.IdUsuario);
        }

        public void EliminarDictadoUsuario(Dictado_BE d, Usuario_BE u)
        {
            mapper.eliminar_usuario_dictado(d.Id, u.IdUsuario);
        }
    }
}
