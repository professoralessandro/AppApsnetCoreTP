using basecs.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Primitives;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace basecs.Auxiliar.Padroes
{
    public class ControllerCS : ControllerBase
    {
        public Int32 UsuarioIdPrincipal
        {
            get
            {
                int i = 0;
                try
                {
                    i = Convert.ToInt32(HttpContext?.Request.Headers["UsuarioLogado"]);
                }
                catch
                {
                    return 0;
                }

                return i;
            }
        }
    }
}
