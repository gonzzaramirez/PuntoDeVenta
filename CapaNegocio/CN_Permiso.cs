﻿using CapaDatos;
using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
  public class CN_Permiso
    {
        private CD_Permiso ocd_permiso = new CD_Permiso();
        public List<Permiso> Listar(int IdUsuario)
        {
            return ocd_permiso.Listar(IdUsuario);
        }


    }
}
